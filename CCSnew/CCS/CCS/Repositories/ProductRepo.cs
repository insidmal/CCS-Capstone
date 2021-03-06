﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;


// CREATIVE CYBER SOLUTIONS
// CREATED: 04/16/2018
// CREATED BY: JOHN BELL contact@conquest-marketing.com
// UPDATED: 04/18/2018
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
            p.Active = true;
            context.Product.Add(p);
            context.SaveChanges();
            return p;
        }

        public List<Product> ListActiveProducts() => context.Product.Where(a => a.Active == true).ToList<Product>();


        public List<Product> ListProducts() =>context.Product.OrderByDescending(a=>a.Active).ToList();


        public int RemoveProduct(Product p) => RemoveProduct(p.ID);

        public int RemoveProduct(int prodID)
        {
            Product p = context.Product.FirstOrDefault(a => a.ID == prodID);
            if (context.ProjProd.Any(a => a.ProductID == p.ID))
            {
                p.Active = false;
                context.Product.Update(p);
            }
            else
            {
                context.Product.Remove(p);
            }
            return context.SaveChanges();
        }

        public Product UpdateProduct(Product p)
        {
            Product oldP = context.Product.FirstOrDefault(a => a.ID == p.ID);
            if (context.ProjProd.Any(a => a.ProductID == p.ID) && oldP.Price!=p.Price)
            {
                oldP.Active = false;
                context.Product.Update(oldP);
                context.SaveChanges();

                context.Product.Add(new Product() { Name = p.Name, Active = true, Price = p.Price, Description = p.Description });
                context.SaveChanges();
            }
            else
            {
                Product newP = context.Product.FirstOrDefault(a => a.ID == p.ID);
                newP.Active = true;
                newP.Description = p.Description;
                newP.Name = p.Name;
                newP.Price = p.Price;

                context.Product.Update(newP);
                context.SaveChanges();
            }
            return p;
        }

        public Product ViewProduct(int id) => context.Product.FirstOrDefault(a => a.ID == id);
    }
}
