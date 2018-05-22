using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;

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
            context.Update(s);
            context.SaveChanges();
            return s;
        }
    }
}
