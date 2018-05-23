using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;

// CREATIVE CYBER SOLUTIONS
// CREATED 05/22/2018
// CREATED BY JOHN BELL contact@conquest-marketing.com
// UPDATED 05/23/2018
// UPDATED BY JOHN BELL contact@conquest-marketing.com


namespace CCS.Repositories
{
    public class SettingRepo : ISettingRepository
    {
        private readonly AppIdentityDbContext context;
        public SettingRepo(AppIdentityDbContext repo)
        {
            context = repo;
        }

        public Settings GetSettings() => context.Settings.FirstOrDefault();

        public Settings UpdateSettings(Settings s)
        {
            context.Settings.Update(s);
            context.SaveChanges();
            return s;
        }
    }
}
