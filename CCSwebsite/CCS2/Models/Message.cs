using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCS2.Models
{
    public class Message : IDelete
    {
        public Message()
        {
            DateReceived = DateTime.Now;
            UserDelete = false;
            AdminDelete = false;
        }

        public int MessageId { get; set; }
        [Required]
        public int ClientId { get; set; }
        public int? ReplyId { get; set; }
        public int? SentTo { get; set; }
        bool Read { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime DateReceived { get; set; }
        public string Subject { get; set; }
        [Required]
        public string cMessage { get; set; }
        public bool UserDelete { get; set; }
        public bool AdminDelete { get; set; }
    }
}