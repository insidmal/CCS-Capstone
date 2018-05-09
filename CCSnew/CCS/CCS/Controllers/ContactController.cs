using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using CCS.Models;

namespace CCS.Controllers
{
    public class ContactController : Controller
    {
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
                    msz.To.Add("yady0312@gmail.com");//Where mail will be sent 
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                    smtp.Credentials = 
                        new System.Net.NetworkCredential("yady0312@gmail.com", "Belkis/50");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us ";
                    smtp.Dispose();
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //[HttpGet]
        //public ViewResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Contact(EmailFormModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress("brianb@ccybers.com"));  // replace with valid value 
        //        message.From = new MailAddress("sender@outlook.com");  // replace with valid value
        //        message.Subject = "Your email subject";
        //        message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
        //        message.IsBodyHtml = true;

        //        using (var smtp = new SmtpClient())
        //        {
        //            var credential = new NetworkCredential
        //            {
        //                UserName = "user@outlook.com",  // replace with valid value
        //                Password = "password"  // replace with valid value
        //            };
        //            smtp.Credentials = credential;
        //            smtp.Host = "smtp-mail.outlook.com";
        //            smtp.Port = 587;
        //            smtp.EnableSsl = true;
        //            await smtp.SendMailAsync(message);
        //            return RedirectToAction("Sent");
        //        }
        //    }
        //    return View(model);
        //}

        //public ActionResult Sent()
        //{
        //    return View();
        //}

        //CommentModel comments;

        //[HttpPost]
        //public ViewResult CommentSent(string name, string email, string comment)
        //{
        //    comments = new CommentModel();
        //    comments.Name = name;
        //    comments.Email = email;
        //    comments.Comment = comment;
        //    return View(comments);
        //}
    }
}