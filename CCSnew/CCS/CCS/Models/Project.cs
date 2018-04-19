using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com

namespace CCS.Models
{
    public class Project
    {
  

        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public List<Note> Notes { get; set; }
        public double Quote { get; set; }
        public double TotalDue { get; set; }
        public DateTime QuoteDate { get; set; }
        public DateTime InvoiceDue { get; set; }
        public Paid Paid { get; set; }
        public Status Progress { get; set; }
        public Project()
        {
            Products = new List<Product>();
        }
    }

    public enum Paid
    {
        Paid = 1,
        Unaid = 2
    }

    public enum Status
    {
        New = 0,
        Quoted = 1,
        Accepted = 2,
        Started = 3,
        Completed = 4
    }


}
