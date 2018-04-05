using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace CCS2.Models
{
    public class Email : IEmailSender
    {
        const string mgMail = "Message@creativecybersolutions.net";
        
        const string displayName = "Creative CyberSolutions - Message";
        const string emailConn = "mail.creativecybersolutions.net";
        
        const string user = "Message";
        
        const string pass = "Ccs2013mg";
        

        public bool SendEmail(string message, string recipEmail, string recipName, string subject = "no subject")
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient(emailConn, 587);
            
            try
            {
                // Setup the message
                m.From = new MailAddress(mgMail, displayName, System.Text.Encoding.UTF8);
                m.To.Add(new MailAddress(recipEmail, recipName));
                m.Subject = subject;
                m.SubjectEncoding = System.Text.Encoding.UTF8;
                m.Body = message;
                m.BodyEncoding = System.Text.Encoding.UTF8;

                // Setup the email client (SMPTP)
                sc.Credentials = new System.Net.NetworkCredential(user, pass);

                // Send the message using the email client
                sc.Send(m);

                // If we made it this far our email sent and we are done
                return true;
            }
            catch (Exception ex)
            {
                // Uh-oh something went wrong.
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}