using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CCS2.Models
{
    public class Request
    {
        public Request()
        {
            DateRequested = DateTime.Now;
            CompleteDate = DateTime.Now.AddMonths(3);
            Approved = null;
        }

        [Key]
        public int RequestId { get; set; }
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateRequested { get; set; }
        public string Description { get; set; }
        public bool? Approved { get; set; }
        public DateTime CompleteDate { get; set; }
    }
}