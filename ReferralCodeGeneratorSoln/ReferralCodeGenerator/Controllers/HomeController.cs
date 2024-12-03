using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReferralCodeGenerator.Data;
using ReferralCodeGenerator.Models;
using ReferralCodeGenerator.Services;
using System.Diagnostics;
using System.Net.Mail;

namespace ReferralCodeGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IADService _adService;
        private readonly ApplicationDataContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IADService adService, ApplicationDataContext dbContext)
        {
            _logger = logger;
            _adService = adService;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GenerateCode(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "Please enter a valid email address.";
                return View("Index");
            }

            var emailParts = email.Split('@')[0].Split('.');
            if (emailParts.Length != 2)
            {
                ViewBag.Error = "Email format is incorrect. Please use 'firstname.lastname@zenithbank.com'.";
                return View("Index");
            }

            string firstName = emailParts[0];
            string lastName = emailParts[1];

            var xceedResponse = await _adService.XceedUserValidator(firstName, lastName);

            if (!xceedResponse.IsSuccess)
            {
                ViewBag.Error = xceedResponse.Message;
                return View("Index");
            }

            var employeeNumber = xceedResponse.Data?.employee_number;
            var firstNumber = xceedResponse.Data?.firstname;
            var lastNumber = xceedResponse.Data?.lastname;

            // Check if the referral code already exists for the email
            var existingReferralCode = await _dbContext.ReferralCodes
                .FirstOrDefaultAsync(rc => rc.email == email);

            if (existingReferralCode != null)
            {
                ViewBag.ReferralCode = existingReferralCode.ref_code;
            }
            else
            {
                // Generate a new referral code
                string referralCode;
                do
                {
                    referralCode = GenerateReferralCode();
                } while (await _dbContext.ReferralCodes.AnyAsync(rc => rc.ref_code == referralCode));

                // Store the new referral code in the database
                var newReferralCode = new ReferralCode
                {
                    staff_no = employeeNumber,
                    email = email,
                    ref_code = referralCode,
                    created_at = DateTime.UtcNow,
                    first_name = firstName,
                    last_name = lastName
                };
                _dbContext.ReferralCodes.Add(newReferralCode);
                await _dbContext.SaveChangesAsync();

                ViewBag.ReferralCode = referralCode;
            }

            return View("Index");
        }

        private string GenerateReferralCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        
    }
}
