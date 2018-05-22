using CCS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Repositories
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppIdentityDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppIdentityDbContext>>()))
            {
                Settings s = new Settings();
                s.ContactEmail = "ccscapstonelcc@gmail.com";
                s.ContactSMTP = "smtp.gmail.com";
                s.ContactPort = 587;
                s.ContactLogin = "ccscapstonelcc@gmail.com";
                s.ContactPassword = "capstone123";


            }
        }
    }
}
