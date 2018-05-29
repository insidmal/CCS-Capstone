using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Models
{

    // CREATIVE CYBER SOLUTIONS
    // CREATED 05/22/2018
    // CREATED BY JOHN BELL contact@conquest-marketing.com
    // UPDATED 05/29/2018
    // UPDATED BY JOHN BELL contact@conquest-marketing.com


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
