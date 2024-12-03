using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReferralCodeGenerator.Data;
using System.ComponentModel.DataAnnotations;
using ReferralCodeGenerator.Models.Responses;

namespace ReferralCodeGenerator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReferralCodeController : ControllerBase
{
    private readonly ApplicationDataContext _dbContext;
    private readonly IConfiguration _configuration;

    public ReferralCodeController(ApplicationDataContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    [HttpGet("check")]
    public async Task<IActionResult> CheckReferralCode([FromQuery][Required] string referralCode, [FromHeader][Required] string apikey)
    {
        if(!string.Equals(apikey, _configuration.GetValue<string>("Auth:apikey"))){
            return Unauthorized();
        }

        if (string.IsNullOrEmpty(referralCode))
        {
            return BadRequest(new { Message = "Referral code is required." });
        }

        var referral = await _dbContext.ReferralCodes
            .Where(rc => rc.ref_code == referralCode)
            .Select(rc => new { rc.first_name, rc.last_name })
            .FirstOrDefaultAsync();

        if (referral == null)
        {
            return NotFound(new ApiResponse<object> { IsSuccess = false, ResponseCode = "11", Message = "Referral code was not found." });
        }

        return Ok(new ApiResponse<object> { IsSuccess = true, Data = new { referral.first_name, referral.last_name }, Message = "Validated Successfully", ResponseCode = "00" });
    }
}