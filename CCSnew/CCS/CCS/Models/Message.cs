﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com
// Message Model for sending/receiving messages between clients/admins

namespace CCS.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string FromID { get; set; }
        public string FromName { get; set; }
        public string ToID { get; set; }
        public string ToUser { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public Read Status { get; set; }
        public DateTime Date { get; set; }
        public int Parent { get; set; }
    }

    public enum Read
    {
       Read = 1,
       Unread = 0
    }
}
