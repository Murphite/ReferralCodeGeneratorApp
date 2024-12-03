namespace ReferralCodeGenerator.Models.Responses;


public class ApiResponse<T>
{
    public string? ResponseCode { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
}
