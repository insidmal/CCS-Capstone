using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;

namespace CCS.Repositories
{
    // CREATIVE CYBER SOLUTIONS
    // 04/10/2018
    // JOHN BELL contact@conquest-marketing.com
    // Product Test Repo

    public class TestProductRepo : IProductRepository
    {
        private List<Product> products;
        private List<ProjectProducts> projectProducts;
        public Product AddProduct(Product p)
        {
            products.Add(p);
            return p;
        }

        public Product AddProductToProject(int id, int prodID, int qty)
        {
            projectProducts.Add(new ProjectProducts { ProjectID = id, ProductID = prodID, Quantity=qty });
            return products.FirstOrDefault(a => a.ID == prodID);
        }

        public List<Product> ListProducts() => products;

        public int RemoveProduct(Product p)
        {
            products.Remove(p);
            return 1;
        }

        public int RemoveProductFromProject(int id, int prodId)
        {
            projectProducts.Remove(projectProducts.FirstOrDefault(a => a.ProductID == prodId && a.ProjectID == id));
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

        public Product UpdateProductQuantity(int id, int qty)
        {
            ProjectProducts pp = projectProducts.FirstOrDefault(a => a.ID == id);
            projectProducts.Remove(pp);
            pp.Quantity = qty;
            projectProducts.Add(pp);
            return products.FirstOrDefault(a=>a.ID==pp.ProductID);

        }

        public Product ViewProduct(int id) =>products.FirstOrDefault(a => a.ID == id);
        
    }
}
