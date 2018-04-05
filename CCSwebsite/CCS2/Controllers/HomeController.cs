using CCS2.Models;
using CCS2.ViewModels;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;

namespace CCS2.Controllers
{
    public class HomeController : Controller
    {
        CcsContext _db = new CcsContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Windows, Web, and Mobile Software Development.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Creative CyberSolutions Today";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactVM e)
        {
            if (ModelState.IsValid)
            {

                StringBuilder message = new StringBuilder();
                MailAddress from = new MailAddress(e.Email.ToString());
                message.Append("Name: " + e.Name + "\n");
                message.Append("Email: " + e.Email + "\n");
                message.Append("Telephone: " + e.Telephone + "\n\n");
                message.Append(e.Message);

                MailMessage mail = new MailMessage();

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.mail.yahoo.com";
                smtp.Port = 465;

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("yahooaccount", "yahoopassword");

                smtp.Credentials = credentials;
                smtp.EnableSsl = true;

                mail.From = from;
                mail.To.Add("yahooemailaddress");
                mail.Subject = "Test enquiry from " + e.Name;
                mail.Body = message.ToString();

                smtp.Send(mail);
            }
            return View();
        }
    }
}
