using System.ComponentModel.DataAnnotations.Schema;

namespace ReferralCodeGenerator.Models;


[Table("zib_zenith_shares_referal_code")]
public class ReferralCode
{
    public long id { get; set; }
    public string staff_no { get; set; }
    public string email { get; set; }
    public string ref_code { get; set; }
    public DateTime created_at { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }

}