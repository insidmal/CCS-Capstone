using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;


// CREATIVE CYBER SOLUTIONS
// CREATED: 04/16/2018
// CREATED BY: JOHN BELL contact@conquest-marketing.com
// UPDATED: 04/16/2018
// UPDATED BY: JOHN BELL contact@conquest-marketing.com


namespace CCS.Repositories
{


    public class ProductRepo : IProductRepository
    {

        private readonly AppIdentityDbContext context;

        public ProductRepo(AppIdentityDbContext repo)
        {
            context = repo;
        }

        public Product AddProduct(Product p)
        {
            context.Product.Add(p);
            context.SaveChanges();
            return p;
        }

        public List<Product> ListActiveProducts() => context.Product.Where(a => a.Active == true).ToList<Product>();


        public List<Product> ListProducts() =>context.Product.ToList();


        public int RemoveProduct(Product p)
        {
            p.Active = false;
            context.Product.Update(p);
            return context.SaveChanges();
        }

        public int RemoveProduct(int prodID)
        {
            Product p = context.Product.FirstOrDefault(a => a.ID == prodID);
            p.Active = false;
            context.Product.Update(p);
            return context.SaveChanges();
        }

        public Product UpdateProduct(Product p)
        {
            context.Product.Update(p);
            context.SaveChanges();
            return p;
        }

        public Product ViewProduct(int id) => context.Product.FirstOrDefault(a => a.ID == id);
    }
}
