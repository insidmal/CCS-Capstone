using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// CREATIVE CYBER SOLUTIONS
// CREATED: 04/11/2018
// LAST UPDATED: 04/16/2018
// JOHN BELL contact@conquest-marketing.com
// Repo for Project Products

namespace CCS.Repositories
{
    public interface IProductRepository
    {
        Product AddProduct(Product p);
        int RemoveProduct(Product p);
        int RemoveProduct(int prodID);
        List<Product> ListProducts();
        List<Product> ListActiveProducts();
        Product ViewProduct(int id);
        Product UpdateProduct(Product p);
    }
}
