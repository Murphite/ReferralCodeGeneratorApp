using ReferralCodeGenerator.Models.Responses;
using RestSharp;
using Microsoft.Extensions.Logging;
using System.Transactions;
using Newtonsoft.Json;

namespace ReferralCodeGenerator.Services;

public class ADService : IADService
{
    private readonly string _ldapPath;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ADService> _logger;


    public ADService(IConfiguration configuration, ILogger<ADService> logger)
    {
        _ldapPath = configuration.GetSection("ActiveDirectory")["ldapPath"];
        _configuration = configuration;
        _logger = logger;
    }
    public async Task<ApiResponse<UniqueResponse>> XceedUserValidator(string firstName, string lastName)
    {
        try
        {
            _logger.LogInformation($"Inside the XceedUserValidator Method for {firstName} {lastName}");

            string baseurl = $"{_configuration.GetValue<string>("ActiveDirectory:xceedPath")}";

            RestRequest request = new RestRequest($"GetXceedData/GetStaffExceedProfile/{firstName}.{lastName}/1", Method.Get);
            var client = new RestClient(baseurl);

            request.AddHeader("Content-Type", "application/json; charset=UTF-8");

            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                XeedUserResponse deserializeList = JsonConvert.DeserializeObject<XeedUserResponse>(response.Content);

                if (deserializeList != null)
                {
                    var data = new UniqueResponse
                    {
                        name = deserializeList.name,
                        deptname = deserializeList.department,
                        email = deserializeList.email,
                        grade = deserializeList.grade,
                        pay_group = deserializeList.pay_group,
                        employee_number = deserializeList.employee_number
                    };
                    return new ApiResponse<UniqueResponse>
                    {
                        Data = data,
                        IsSuccess = true,
                        Message = "Success",
                        ResponseCode = "00"
                    };
                }

                return new ApiResponse<UniqueResponse>
                {
                    IsSuccess = false,
                    Message = $"Unable to retrieve customer details for {firstName} {lastName}.",
                    ResponseCode = "06"
                };
            }
            else
            {
                _logger.LogError($"Error fetching data for {firstName} {lastName} from Xceed");
                return new ApiResponse<UniqueResponse>
                {
                    IsSuccess = false,
                    Message = "Error fetching data from Xceed"
                };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<UniqueResponse>
            {
                IsSuccess = false,
                Message = $"Error occurred: {ex.Message}"
            };
        }
    }
}
