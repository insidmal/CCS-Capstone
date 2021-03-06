﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using CCS.Models;
using CCS.Repositories;

// CREATIVE CYBER SOLUTIONS
// CREATED: 05/09/2018
// CREATED BY: YADIRA DESPAINGE PLANCHE
// UPDATED: 05/31/2018
// UPDATED BY: JOHN BELL contact@conquest-marketing.com

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
                    msz.From = new MailAddress(vm.Email,vm.Name);//Email which you are getting 
                                                                 //from contact us page 

                    msz.Sender = msz.From;
                    msz.ReplyToList.Add(msz.From);
                    msz.To.Add(settings.ContactEmail);//Where mail will be sent 
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    

                    SmtpClient smtp = new SmtpClient(settings.ContactSMTP, settings.ContactPort);

                    smtp.Credentials =
                        new System.Net.NetworkCredential(settings.ContactLogin, settings.ContactPassword);

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Your message has been sent!";
                    smtp.Dispose();
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $"We're sorry, an error has occured.<br /> {ex.Message}";
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