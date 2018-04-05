using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCS2.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brief { get; set; }
        public bool Featured { get; set; }
        // public int RequestId { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}