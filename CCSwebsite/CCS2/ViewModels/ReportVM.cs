using System;

namespace CCS2.ViewModels
{
    public class ReportVM
    {
        public string BriefNotes { get; set; }
        public string ServicName { get; set; }
        public string RequestNum { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int RepId { get; set; }
    }
}