using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Models
{
    public class Settings
    {
        string ContactTo { get; set; }
        string ContactSMTP { get; set; }
        string ContactEmail { get; set; }
        string ContactPassword { get; set; }
        int ContactPort { get; set; }
        int InvoiceDays { get; set; }
        Status InvoiceStatus { get; set; }
    }
}
