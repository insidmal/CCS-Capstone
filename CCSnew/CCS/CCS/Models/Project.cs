﻿using System;
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
        string ID { get; set; }
        string CustomerID { get; set; }
        string Description { get; set; }
        List<Product> Products { get; set; }
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
        string Text { get; set; }
    }
}