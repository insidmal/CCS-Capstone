using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public List<Note> Notes { get; set; }
        [DataType(DataType.Currency)]
        public double Quote { get; set; }
        [DataType(DataType.Currency)]
        public double TotalDue { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime QuoteDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDue { get; set; }
        public DateTime LastUpdate { get; set; }
        public Paid Paid { get; set; }
        public Status Progress { get; set; }
        public Project()
        {
            Products = new List<Product>();
        }
    }

    public enum Paid
    {
        Unpaid = 0,
        Paid = 1
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
