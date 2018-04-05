using System;

namespace CCS2.ViewModels
{
    public class RequestVM
    {
        public int RequestId { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public DateTime DateReq { get; set; }
        public DateTime DateComp { get; set; }
        public bool? Approved { get; set; }

    }
}