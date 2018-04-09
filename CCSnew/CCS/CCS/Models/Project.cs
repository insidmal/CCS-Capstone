using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Models
{
    public class Project
    {
        string ID { get; set; }
        string CustomerID { get; set; }
        string Description { get; set; }
        float Quote { get; set; }
        float TotalDue { get; set; }
        DateTime QuoteDate { get; set; }
        DateTime InvoiceDue { get; set; }
        Paid Paid { get; set; }

    }

    public enum Paid
    {
        Paid = 1,
        Unaid = 2
    }

    public class Note
    {
        int ID { get; set; }
        int From { get; set; }
        int ProjID { get; set; }
        string Text {get;set;}
}
