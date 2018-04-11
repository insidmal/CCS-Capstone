using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com
// Joining Table for Project Products

namespace CCS.Models
{
    public class ProjectProducts
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
