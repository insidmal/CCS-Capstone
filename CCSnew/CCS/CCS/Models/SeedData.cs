using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppIdentityDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppIdentityDbContext>>()))
            {

            }
        }
    }
}
