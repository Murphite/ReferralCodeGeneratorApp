namespace ReferralCodeGenerator.Models.Responses;

public class UniqueResponse
{
    public string name { get; set; }
    public string grade { get; set; }
    public string pay_group { get; set; }
    public object deptname { get; set; }
    public string email { get; set; }
    public string employee_number { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
}
public class XeedUserResponse
{
    public UserPrincipal? userPrincipal { get; set; }
    public object? staffPhoenixProfile { get; set; }
    public List<object>? uds_roles { get; set; }
    public List<object>? tgt_roles { get; set; }
    public List<object>? app_roles { get; set; }
    public string? employee_number { get; set; }
    public int? employee_id { get; set; }
    public string? name { get; set; }
    public string? grade { get; set; }
    public object? oldgrade { get; set; }
    public DateTime? doe { get; set; }
    public DateTime? dob { get; set; }
    public object? age { get; set; }
    public object? RoleTitle { get; set; }
    public object? Branch { get; set; }
    public string? branch_name { get; set; }
    public string? branch_code { get; set; }
    public string? branch_address { get; set; }
    public string? mobile_phone { get; set; }
    public string? gsm { get; set; }
    public string? jobtitle { get; set; }
    public string? office_ext { get; set; }
    public int? org_id { get; set; }
    public int? ad_org_id { get; set; }
    public string? org_name { get; set; }
    public object? conn_name { get; set; }
    public string? xceed_server { get; set; }
    public bool? status { get; set; }
    public object? financial_year { get; set; }
    public long? lastlogondate { get; set; }
    public string? SelectedDept { get; set; }
    public string? department { get; set; }
    public object? dept_code { get; set; }
    public object? Departments { get; set; }
    public object? SelectedSuperGroup { get; set; }
    public string? supergroupname { get; set; }
    public int? supergroupcode { get; set; }
    public object? Subsidiaries { get; set; }
    public object? promotion_history { get; set; }
    public string? user_logon_name { get; set; }
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public string? email { get; set; }
    public DateTime? confirmationdate { get; set; }
    public int? emp_confirm { get; set; }
    public string? pay_group { get; set; }
    public object? companyName { get; set; }
    public List<string>? membership { get; set; }
    public object? hodeptcode { get; set; }
    public object? hodeptname { get; set; }
    public DateTime? lastpromotiondate { get; set; }
    public object? wedding_date { get; set; }
    public int? department_id { get; set; }
    public object? department_code { get; set; }
    public object? unit { get; set; }
    public int? confirm { get; set; }
    public int? gender { get; set; }
    public int? grade_id { get; set; }
    public string? imagelink { get; set; }
    public bool? hasBatchApproval { get; set; }
    public string? account_no { get; set; }
    public int? ranking { get; set; }
    public string? category { get; set; }
    public int? lengthofservice { get; set; }
    public string? unitname { get; set; }
    public string? unitcode { get; set; }
    public object? deptname { get; set; }
    public object? deptcode { get; set; }
    public string? groupname { get; set; }
    public string? groupcode { get; set; }
    public object? StatusCode { get; set; }
    public object? StatusTitle { get; set; }
    public object? DeptCodes { get; set; }
    public object? DeptTitles { get; set; }
    public XceedDefinition? xceed_definition { get; set; }
    public int? referral_role_classid { get; set; }
    public object? referral_role_class { get; set; }
    public object? referral_role_dept_id { get; set; }
    public object? referral_role_dept_name { get; set; }
}


public class XceedDefinition
{
    public int? entry_key { get; set; }
    public int? ad_org_id { get; set; }
    public int? org_id { get; set; }
    public string? org_name { get; set; }
    public string? ipaddress { get; set; }
    public int? port { get; set; }
    public string? conn_name { get; set; }
    public string? username { get; set; }
    public string? password { get; set; }
    public string? catalog { get; set; }
    public string? status { get; set; }
}
