using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using CCS.Models;
using CCS.Repositories;
using System.Net;

// CREATIVE CYBER SOLUTIONS
// CREATED: 05/10/2018
// CREATED BY: YADIRA DESPAINGE PLANCHE
// UPDATED: 05/22/2018
// UPDATED BY: JOHN BELL contact@conquest-marketing.com, YADIRA DESPAINGE PLANCHE


namespace CCS.Controllers
{
    public class ContactController : Controller
    {
        private ISettingRepository setting;
        Settings settings = new Settings();

        public ContactController(ISettingRepository set)
        {
            setting = set;
            settings = setting.GetSettings();
                
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add(settings.ContactEmail);//Where mail will be sent 
                    msz.Sender = new MailAddress(vm.Email, vm.Name);
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient(settings.ContactSMTP, settings.ContactPort);

                    smtp.Credentials = 
                        new NetworkCredential(settings.ContactLogin, settings.ContactPassword);

                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = true;
                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us.";
                    smtp.Dispose();
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry an error has occured: {ex.Message}";
                }
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}