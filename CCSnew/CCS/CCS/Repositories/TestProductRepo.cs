using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;

namespace CCS.Repositories
{
    // CREATIVE CYBER SOLUTIONS
    // Product Test Repo
    // CREATED: 04/11/2018
    // CREATED BY: JOHN BELL contact@conquest-marketing.com
    // LAST UPDATED: 04/16/2018
    // UPDATED BY: JOHN BELL contact@conquest-marketing.com


    public class TestProductRepo : IProductRepository
    {


        private List<Product> products = new List<Product>();

        public TestProductRepo()
        {
            var p1 = new Product { ID = 1, Description = "Test Product 1", Name = "Product 1", Price = 100 };
            var p2 = new Product { ID = 2, Description = "Test Product 2", Name = "Product 2", Price = 15 };
            var p3 = new Product { ID = 3, Description = "Test Product 3", Name = "Product 3", Price = 150 };
            AddProduct(p1);
            AddProduct(p2);
            AddProduct(p3);


        }

        public Product AddProduct(Product p)
        {
            products.Add(p);
            return p;
        }
        public List<Product> ListProducts() => products;
        public List<Product> ListActiveProducts() => products.Where(a=>a.Active==true).ToList<Product>();
        public int RemoveProduct(Product p)
        {
            products.Remove(p);
            return 1;
        }
        public int RemoveProduct(int prodID)
        {
            
            products.Remove(products.FirstOrDefault(a => a.ID == prodID));
            return 1;
        }
        public Product UpdateProduct(Product p)
        {
            Product oldP = products.FirstOrDefault(a => a.ID == p.ID);
            products.Remove(oldP);
            oldP.Description = p.Description;
            oldP.Name = p.Name;
            oldP.Price = p.Price;
            products.Add(p);
            return p;
        }
        public Product ViewProduct(int id) =>products.FirstOrDefault(a => a.ID == id); 
    }
}
