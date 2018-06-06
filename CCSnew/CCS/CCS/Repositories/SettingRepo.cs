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
            var oldS = GetSettings();
            oldS.ContactEmail = s.ContactEmail;
            oldS.ContactLogin = s.ContactLogin;
            oldS.ContactPassword = s.ContactPassword;
            oldS.ContactPort = s.ContactPort;
            oldS.ContactSMTP = s.ContactSMTP;
            oldS.InvoiceDays = s.InvoiceDays;
            oldS.InvoiceStatus = s.InvoiceStatus;
            oldS.MsgDays = s.MsgDays;
            oldS.ProjDays = s.ProjDays;
            oldS.WelcomeMessage = s.WelcomeMessage;

            context.Settings.Update(oldS);
            context.SaveChanges();
            return oldS;
        }
    }
}
