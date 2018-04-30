using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com
//  Notes associated with Projects

namespace CCS.Models
{
    public class Note
    {
        public int ID { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public int ProjectID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Visible { get; set; }
    }
}
