using CCS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppIdentityDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppIdentityDbContext>>()))
            {
                context.Database.EnsureCreated();

                UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var userStore = new UserStore<User>(context);


                if (!context.Settings.Any())
                {
                    //seed default settings
                    Settings s = new Settings();
                    s.ContactEmail = "ccscapstonelcc@gmail.com";
                    s.ContactSMTP = "smtp.gmail.com";
                    s.ContactPort = 587;
                    s.ContactLogin = "ccscapstonelcc@gmail.com";
                    s.ContactPassword = "capstone123";

                    s.InvoiceDays = 30;
                    s.InvoiceStatus = Status.Completed;

                    s.MsgDays = 90;
                    s.ProjDays = 90;

                    s.WelcomeMessage = "Welcome to Creative Cyber Solutions.  We look forward to helping you create the website or software product you need, our 45 years of combined experience help make sure you get the software you need at the price you want.";

                    context.Settings.Add(s);
                    context.SaveChanges();
                }


                if (!context.Users.Any())
                {

                    //seed default admin role
                    string[] roles = new string[] { "Administrator" };

                    foreach (string role in roles)
                    {
                        var roleStore = new RoleStore<IdentityRole>(context);
                        var Nrole = new IdentityRole();
                        if (!context.Roles.Any(r => r.Name == role))
                        {

                            Nrole = new IdentityRole(role);
                            Nrole.NormalizedName = role.ToUpper();
                            await roleStore.CreateAsync(Nrole);
                        }
                        context.SaveChanges();



                        //seed default admin account
                        var admin = new User { FirstName = "Admin", LastName = "Admin", Email = "admin@creativecybersolutions.com", UserName = "Admin", EmailConfirmed = true, LockoutEnabled = false, SecurityStamp = Guid.NewGuid().ToString("D") };
                    var password = new PasswordHasher<User>();
                    var hashed = password.HashPassword(admin, "adminpass");
                    admin.PasswordHash = hashed;
                    admin.NormalizedUserName = "ADMIN";
                    admin.NormalizedEmail = ("admin@creativecybersolutions.com").ToUpper();
                    await userStore.CreateAsync(admin);
                     context.SaveChanges();

                        await userManager.AddToRoleAsync(admin, "Administrator");
                    }
                    context.SaveChanges();

                }

            }
        }
    }
}
