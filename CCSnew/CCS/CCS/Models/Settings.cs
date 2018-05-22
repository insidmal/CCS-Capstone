using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Models
{
    public class Settings
    {
        public int ID { get; set; }
        public string ContactSMTP { get; set; }
        public string ContactEmail { get; set; }
        public string ContactLogin { get; set; }
        public string ContactPassword { get; set; }
        public int ContactPort { get; set; }
        public int InvoiceDays { get; set; }
        public Status InvoiceStatus { get; set; }
    }
}
