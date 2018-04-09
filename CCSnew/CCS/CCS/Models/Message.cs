using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Models
{
    public class Message
    {
        int ID { get; set; }
        int FromID { get; set; }
        int ToID { get; set; }
        string Text { get; set; }
        Read Status { get; set; }
    }

    public enum Read
    {
       Read = 1,
       Unread = 0
    }
}
