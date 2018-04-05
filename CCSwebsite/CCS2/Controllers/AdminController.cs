using CCS2.Models;
using CCS2.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private CcsContext _db = new CcsContext();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Requests

        [HttpGet]
        public ActionResult Requests() 
        {
            // Get all the requests in the database
            string serviceName;
            string clientName;
            var reqs = _db.Requests;
            
            var Clients = _db.Clients.ToList();

            var Services = _db.Services.ToList();

            List<RequestVM> vreqs = new List<RequestVM>();
            foreach (var req in reqs)
            {
                clientName = _db.Clients.Find(req.ClientId).UserName;
                serviceName = _db.Services.Find(req.ServiceId).Name;
                vreqs.Add(new RequestVM() {
                    ClientName = clientName,
                    ServiceName = serviceName,
                    DateReq = req.DateRequested,
                    RequestId = req.RequestId,
                    Approved = false,
                    Description = req.Description,
                    DateComp = req.CompleteDate
                });
            }

            return View(vreqs);
        }

        //
        // GET: /Admin/RequestFor/id

        [HttpGet]
        public ActionResult RequestFor(int reqId)
        {
            var req = _db.Requests.FirstOrDefault(r => r.RequestId == reqId);

            RequestVM vreq = new RequestVM() { 
                RequestId = reqId,
                ClientName = _db.Clients.Find(req.ClientId).UserName,
                ServiceName = _db.Services.Find(req.ServiceId).Name,
                DateReq = req.DateRequested,
                DateComp = req.CompleteDate,
                Description = req.Description,
            };

            // Get all the reports for this request
            ViewBag.Reports = _db.Reports.Where(r => r.RequestId == req.RequestId);

            return View(vreq);
        }

        //
        // GET: /Admin/MakeReport/reqId

        [HttpGet]
        public ActionResult MakeReport(int reqId)
        {
            ViewBag.reqId = reqId;

            return View();
        }

        //
        // POST: /Admin/MakeReport/reqId

        [HttpPost]
        public ActionResult MakeReport(ProgressReport progRep, int reqId)
        {
            try
            {
                progRep.RequestId = reqId;
                if (progRep.Name == null || progRep.Name == "")
                    progRep.Name = "Report ID " + progRep.ProgressReportId.ToString();
                if (ModelState.IsValid)
                {
                    _db.Reports.Add(progRep);
                    _db.SaveChanges();

                    var req = _db.Requests.FirstOrDefault(r => progRep.RequestId == r.RequestId);

                    return RedirectToAction("RequestFor", new { reqId = req.RequestId });
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public List<SelectListItem> GetAllUsers()
        {
            var allUsers = _db.Clients;

            List<SelectListItem> users = new List<SelectListItem>();

            int counter = -1;
            users.Add(new SelectListItem { Text = "All Users", Value = counter.ToString() });
            foreach (var user in allUsers)
            {
                counter++;
                users.Add(new SelectListItem { Text = user.UserName, Value = counter.ToString() });
            }

            return users;
        }

        //
        // GET: /Admin/SendMessage

        [HttpGet]
        public ActionResult SendMessage()
        {
            ViewBag.Users = GetAllUsers();

            return View();
        }

        //
        // POST: /Admin/SendMessage/Users

        [HttpPost]
        public ActionResult SendMessage(Message mes, string Users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Users != null && Users != "")
                    {
                        mes.SentTo = Int32.Parse(Users.ToString());
                    }

                    _db.Messages.Add(mes);
                    _db.SaveChanges();


                    //Email email = new Email();
                    //var user = _db.Clients.Find(mes.SentTo);
                    //if(email.SendEmail(mes.cMessage, user.Email, user.UserName, mes.Subject))
                        
                    return RedirectToAction("Messages", "Client", null);
                    
                }
                else
                {
                    return View();
                }
            }
            catch { return View(); }
        }

        //
        // GET: /Admin/Approve/reqId

        [HttpGet]
        public ActionResult Approve(int reqId)
        {
            var req = _db.Requests.Find(reqId);

            try
            {
                req.Approved = true;
                _db.SaveChanges();

                return RedirectToAction("Requests");
            }
            catch {
                return RedirectToAction("Requests");
            }
        }

        //
        // GET: /Admin/Deny/reqId

        [HttpGet]
        public ActionResult Deny(int reqId)
        {
            var req = _db.Requests.Find(reqId);

            try
            {
                req.Approved = false;
                _db.SaveChanges();

                return RedirectToAction("Requests");
            }
            catch
            {
                return RedirectToAction("Requests");
            }
        }

        //
        // GET: /Admin/AddNote
        [HttpGet]
        public ActionResult AddNote()
        {
            ViewBag.Users = GetAllUsers();

            return View();
        }

        //
        //  POST: /Admin/AddNote
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNote(Note note, string Users)
        {
            if (Users != null && Users != "")
            {
                // The plus 1 is because the drop down starts at
                // 0 and the users list starts at 1
                note.UserId = Int32.Parse(Users) + 1;
            }
            note.Text = HttpUtility.HtmlEncode(note.Text);
            if (ModelState.IsValid)
            {
                _db.Notes.Add(note);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(note);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            ViewBag.Users = GetAllUsers();
            return View();
        }

        [HttpPost]
        public ActionResult Upload(Bill file, HttpPostedFileBase fileUpload, string Users)
        {
            foreach (string upload in Request.Files)
            {
                file.FileExtension = fileUpload.ContentType;
                file.FileName = fileUpload.FileName;
                file.UserId = Int32.Parse(Users) + 1;

                int fileLength = fileUpload.ContentLength;
                Stream s = fileUpload.InputStream;

                file.FileContent = new byte[fileLength];

                s.Read(file.FileContent, 0, fileLength);
            }

            if (ModelState.IsValid)
            {
                _db.Bills.Add(file);
                _db.SaveChanges();
            }

            return RedirectToAction("Bills");
        }

        public FileContentResult Download(int id)
        {
            Bill file = _db.Bills.Find(id);

            return new FileContentResult(file.FileContent.ToArray(), file.FileExtension);
        }

        public ActionResult Bills()
        {
            List<Bill> bills = _db.Bills.ToList();

            return View(bills);
        }
    }
}
