namespace ReferralCodeGenerator.Models.Responses;

public class UserPrincipal
{
    public string? GivenName { get; set; }
    public string? MiddleName { get; set; }
    public string? Surname { get; set; }
    public string? EmailAddress { get; set; }
    public object? VoiceTelephoneNumber { get; set; }
    public object? EmployeeId { get; set; }
    public string? Guid { get; set; }
    public DateTime? LastLogon { get; set; }
    public DateTime? LastBadPasswordAttempt { get; set; }
    public DateTime? LastPasswordSet { get; set; }
    public string? UserPrincipalName { get; set; }
    public List<object>? GroupPrincipals { get; set; }
}
