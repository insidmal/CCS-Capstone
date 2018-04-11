using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// CREATIVE CYBER SOLUTIONS
// 04/11/2018
// JOHN BELL contact@conquest-marketing.com
// Repo for Project Products

namespace CCS.Repositories
{
    interface IProductRepository
    {
        Product AddProductToProject(int id, int prodID, int Qty);
        int RemoveProductFromProject(int id, int prodId);
        Product UpdateProductQuantity(int id, int qty);
        Product AddProduct(Product p);
        int RemoveProduct(Product p);
        List<Product> ListProducts();
        Product ViewProduct(int id);
        Product UpdateProduct(Product p);
    }
}
