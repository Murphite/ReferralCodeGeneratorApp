using ReferralCodeGenerator.Models.Responses;

namespace ReferralCodeGenerator.Services;

public interface IADService
{
    Task<ApiResponse<UniqueResponse>> XceedUserValidator(string firstName, string lastName);
}
