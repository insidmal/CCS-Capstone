using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// CREATIVE CYBER SOLUTIONS
// CREATED 04/12/2018
// CREATED BY YADIRA DESPAINGE PLANCHE
// UPDATED 04/16/2018
// UPDATED BY JOHN BELL contact@conquest-marketing.com


namespace CCS.Models
{
    public class AppIdentityDbContext : IdentityDbContext<User>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }


        public DbSet<Project> Project { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ProjectProducts> ProjProd { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                User user = new User
                {
                    UserName = username,
                    Email = email
                };

                IdentityResult result = await userManager
                    .CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
