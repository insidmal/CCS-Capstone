using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;
using Microsoft.AspNetCore.Mvc;

// CREATIVE CYBER SOLUTIONS
// CREATED: 04/18/2018
// CREATED BY: JOHN BELL contact@conquest-marketing.com
// UPDATED: 04/18/2018
// UPDATED BY: JOHN BELL contact@conquest-marketing.com


namespace CCS.Repositories
{
    public class ProjProdRepo : IProjectProductsRepository
    {

        private readonly AppIdentityDbContext context;

        public ProjProdRepo(AppIdentityDbContext repo)
        {
            context = repo;
        }

        public Product AddProjectProduct(int projectID, Product p, int qty)
        {
            AddProjectProductId(projectID, p.ID, qty);
            return p;
        }

        public int AddProjectProductId(int projectID, int productId, int qty)
        {
            ProjectProducts pd;

            if (context.ProjProd.Any(a => a.ProjectID == productId && a.ProductID == productId))
            {
                pd = new ProjectProducts() { ProductID = productId, ProjectID = projectID, Quantity = qty };
                context.ProjProd.Add(pd);
            }
            else
            {
                pd = context.ProjProd.FirstOrDefault(a => a.ProjectID == productId && a.ProductID == productId);

                pd.Quantity += qty;
                context.ProjProd.Update(pd);
            }
            return context.SaveChanges();

        }

        public ProjectProducts GetProjectProduct(int id) => context.ProjProd.FirstOrDefault(a => a.ID == id);

        public List<Product> GetProjectProducts(int projectId)
        {
            List<Product> pd = new List<Product>();
            foreach (ProjectProducts pp in context.ProjProd.Where(a=>a.ProjectID==projectId))
            {
                Product pro = context.Product.FirstOrDefault(a => a.ID == pp.ProductID);
                pro.ProjProdId = pp.ID;
                pro.Quantity = pp.Quantity;
                pro.Price *= pp.Quantity;
                pd.Add(pro);
            }
            return pd;
        }

        public int RemoveProjectProduct(int projectID, Product p) => RemoveProjectProductId(projectID, p.ID);
        
        public int RemoveProjectProductId(int projectID, int productId)
        {
            context.ProjProd.Remove(context.ProjProd.FirstOrDefault(a => a.ProjectID == projectID && a.ProductID == productId));
            return context.SaveChanges();
        }


        public Product UpdateProjectProductQty(ProjectProducts pp)
        {

            if (pp.Quantity <= 0) {
                context.ProjProd.Remove(pp);
            }
            else
            {
                context.ProjProd.Update(pp);
            }
            context.SaveChanges();

            Product pro = context.Product.FirstOrDefault(a => a.ID == pp.ProductID);
            pro.Quantity = pp.Quantity;
            pro.Price *= pp.Quantity;

            return pro;
        }
    }
}