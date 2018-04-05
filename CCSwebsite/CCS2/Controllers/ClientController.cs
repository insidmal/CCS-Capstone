using CCS2.Models;
using CCS2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS2.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        CcsContext _db = new CcsContext();

        //
        // GET: /Client/
        public ActionResult Index()
        {
            // Get the username of the current user
            string username = User.Identity.Name;
            // User the name to get the client information store it in user
            UserProfile user = _db.Clients.FirstOrDefault(u => u.UserName == username);
            //  Load all the requests for that user
            var reqs = _db.Requests.Where(r => r.ClientId == user.UserProfileId);
            // get our list of services for names
            var servs = _db.Services.ToList();
            // Our list of user friendly requests
            List<RequestVM> ReqView = new List<RequestVM>();
            

            if(reqs != null)
                foreach (var r in reqs)
                {
                    
                    ReqView.Add(new RequestVM
                    {
                        RequestId = r.RequestId,
                        // primary keys for service must be 1, 2, 3... for this to work
                        ServiceName = servs[r.ServiceId - 1].Name,
                        DateReq = r.DateRequested,
                        Description = r.Description,
                        Approved = r.Approved
                    });
                }

            // That was fun, now let's add all the notes to a ViewBag
            // so we can use it in our partial view
            var notes = _db.Notes.Where(n => n.UserId == user.UserProfileId);
            

            ViewBag.NotesForUser = notes;

            // That should be it
            return View(ReqView);
        }

        //
        // GET: /Client/Details/id
        [HttpGet]
        public ActionResult Details(int id)
        {
            var req = _db.Requests.Find(id);

            return View(req);
        }

        //
        // GET: /Client/SubmitRequest/
        [HttpGet]
        public ActionResult SubmitRequest()
        {
            ViewBag.Services = new SelectList(_db.Services);
            
            return View(new Request());
        }

        //
        // POST: /Client/SubmitRequest/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRequest(Request req, string Services)
        {
            try {
                if (ModelState.IsValid) {
                    var username = User.Identity.Name;
                    var user = _db.Clients.FirstOrDefault(u => u.UserName == username);
                    req.ClientId = user.UserProfileId;
                    req.ServiceId = _db.Services.Where(s => s.Name == Services).FirstOrDefault().ServiceId;
                    _db.Requests.Add(req);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else {
                    ViewBag.Services = new SelectList(_db.Services);
                    return View("SubmitRequest");
                }
            }
            catch {
                ViewBag.Services = new SelectList(_db.Services);
                return View("SubmitRequest");
            }
        }

        //
        // GET: /Client/AllReports/repId
        [HttpGet]
        public ActionResult AllClientReports(int reqId) // Gets all reports for a given request
        {
            var reports = _db.Reports.Where(r => r.RequestId == reqId);

            List<ReportVM> PageReports = new List<ReportVM>();

            foreach (var r in reports)
            {
                var tempRep = new ReportVM
                {
                    RequestNum = r.RequestId.ToString(),
                    Title = r.Name,
                    BriefNotes = r.Notes.Substring(0,25),
                    Date = r.ReportDate,
                    RepId = r.ProgressReportId
                };

                if (r.Notes.Length > tempRep.BriefNotes.Length)
                    tempRep.BriefNotes += "...";

                PageReports.Add( tempRep );
            }

            return View(PageReports);
        }

        //
        // GET: /Client/Report/id
        [HttpGet]
        public ActionResult Report(int id)  // gets a specific report
        {
            ProgressReport rep = _db.Reports.Find(id);

            return View(rep);
        }

        [HttpGet]
        public ActionResult ClientBills()
        { 
            var username = User.Identity.Name;
            var user = _db.Clients.FirstOrDefault(u => u.UserName == username);
            int id = user.UserProfileId;
            var bills = _db.Bills.Where(b => b.UserId == id);

            return View(bills);
        }

        public FileContentResult Download(int id)
        {
            Bill file = _db.Bills.Find(id);

            return new FileContentResult(file.FileContent.ToArray(), file.FileExtension);
        }
    }
}
