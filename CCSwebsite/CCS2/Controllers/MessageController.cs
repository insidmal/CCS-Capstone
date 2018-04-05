using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CCS2.Models;

namespace CCS2.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        CcsContext _db = new CcsContext();
        //
        // GET: /Message/

        public ActionResult Index()
        {
            // Get the logged in user
            var username = User.Identity.Name;
            var user = _db.Clients.FirstOrDefault(u => u.UserName == username);
            // -1 seems to mean my keys aren't lining up, I will work on this
            var messages = _db.Messages.Where(m => m.ClientId == user.UserProfileId 
                || m.SentTo == user.UserProfileId - 1 || m.SentTo == -1);

            // get rid of deleted messages
            if (User.IsInRole("Administrator"))
                messages = messages.Where(m => m.AdminDelete == false);
            else
                messages = messages.Where(m => m.UserDelete == false);
            return View(messages);
        }

        //
        // GET: /Admin/Message/id
        [HttpGet]
        public ActionResult Message(int id)
        {
                        // Get the logged in user
            var username = User.Identity.Name;
            var user = _db.Clients.FirstOrDefault(u => u.UserName == username);
            
            // Get the message we are looking for
            var msg = _db.Messages.FirstOrDefault(m => m.MessageId == id);

            // Was the user sent you, everyone, or from you?
            if(msg.SentTo == (user.UserProfileId - 1) || msg.SentTo == -1 || msg.ClientId == user.UserProfileId)
                return View(msg);

            // No, then you can't see it
            return RedirectToAction("Index");
        }

        //
        // GET: /Message/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Message/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, Message msg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Get the current user
                    string username = User.Identity.Name;
                    UserProfile user = _db.Clients.FirstOrDefault(u => u.UserName == username);

                    if(msg.Email == "" || msg.Email == null)
                    {
                        // If no email user is provide use the default
                        msg.Email = user.Email;
                    }

                    if (user.UserProfileId != 0)
                        msg.SentTo = 0;

                    msg.ClientId = user.UserProfileId;
                    _db.Messages.Add(msg);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                { return View(msg); }
            }
            catch
            {
                return View(msg);
            }
        }

        //
        // GET: /Message/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Message/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Message mes = _db.Messages.Find(id);
                if (User.IsInRole("Administrator"))
                    mes.AdminDelete = true;
                else
                    mes.UserDelete = true;

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
