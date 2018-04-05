using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCS2.Models
{
    public class ProgressReport
    {
        public ProgressReport() {
            ReportDate = DateTime.Now;
        }

        public int ProgressReportId { get; set; }
        public int RequestId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime ReportDate { get; set; }
    }
}