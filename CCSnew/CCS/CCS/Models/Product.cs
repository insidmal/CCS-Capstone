using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com
// Products that can be added to Projects for Invoicing purposes

namespace CCS.Models
{
    public class Product
    {

        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        float Price { get; set; }
    }
}
