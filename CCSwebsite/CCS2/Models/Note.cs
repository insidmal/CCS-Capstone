using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCS2.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}