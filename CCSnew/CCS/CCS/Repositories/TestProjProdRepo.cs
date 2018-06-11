using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;

// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com
//  Project Products repo

namespace CCS.Repositories
{
    public class TestProjProdRepo : IProjectProductsRepository
    {
        private List<ProjectProducts> projectProducts = new List<ProjectProducts>();
        private List<Product> products = new List<Product>();

        public void TestProjectRepo()
        {
            projectProducts.Add(new ProjectProducts { ProductID = 1, ProjectID = 1, Quantity = 1 });
        } 

        public Product AddProjectProduct(int projectID, Product p, int qty)
        {
            projectProducts.Add(new ProjectProducts { ProjectID = projectID, ProductID = p.ID, Quantity = qty });
            return p;

        }

        public int AddProjectProductId(int projectID, int productId, int qty)
        {
            projectProducts.Add(new ProjectProducts { ProjectID = projectID, ProductID= productId, Quantity = qty });
            return projectID;

        }

        public ProjectProducts GetProjectProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProjectProducts(int projectId)
        {
            List<Product> p = new List<Product>();
            Product pr = new Product();
            foreach (ProjectProducts pp in projectProducts.Where(a => a.ProjectID == projectId).ToList())
            {
                pr = products.FirstOrDefault(a => a.ID == pp.ID);
                pr.Quantity = pp.Quantity;
                pr.Price = pp.Quantity * pr.Price;
                p.Add(pr);
            }
            return p;
        }

    public int RemoveProjectProduct(int projectID, Product p)
        {
            projectProducts.Remove(projectProducts.FirstOrDefault(a => a.ProductID == p.ID && a.ProjectID == projectID));
            return 1;
        }

        public int RemoveProjectProductId(int projectID, int productId)
        {
            projectProducts.Remove(projectProducts.FirstOrDefault(a => a.ProductID == productId && a.ProjectID == projectID));
            return 1;
        }

        public Product UpdateProjectProductQty(ProjectProducts pp)
        {
            throw new NotImplementedException();
        }


        //public Product UpdateProjectProductQty(int projectID, int productId, int qty)
        //{
        //    ProjectProducts pp = projectProducts.FirstOrDefault(a => a.ProductID == productId && a.ProjectID==projectID);
        //    projectProducts.Remove(pp);
        //    pp.Quantity = qty;
        //    projectProducts.Add(pp);
        //    return products.FirstOrDefault(a => a.ID == pp.ProductID);
        //}
    }
}
