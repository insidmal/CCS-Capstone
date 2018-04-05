using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCS2.Models
{
    public class Bill
    {
        public Bill() { Date = DateTime.Now; }

        public int BillId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileContent { get; set; }
    }
}