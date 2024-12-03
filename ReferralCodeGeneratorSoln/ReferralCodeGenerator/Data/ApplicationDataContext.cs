using Microsoft.EntityFrameworkCore;
using ReferralCodeGenerator.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Principal;

namespace ReferralCodeGenerator.Data;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
    {
    }

    public DbSet<ReferralCode> ReferralCodes { get; set; }

}