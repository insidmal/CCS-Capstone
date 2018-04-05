using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCS2.Models
{
    public interface IEmailSender
    {
        bool SendEmail(string message, string recipient, string recipName, string subject = "no subject");
    }
}
