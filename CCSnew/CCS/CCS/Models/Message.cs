using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com

namespace CCS.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int FromID { get; set; }
        public int ToID { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public Read Status { get; set; }
    }

    public enum Read
    {
       Read = 1,
       Unread = 0
    }
}
