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


        public Product AddProjectProduct(int projectID, Product p, int qty)
        {
            projectProducts.Add(new ProjectProducts { ProjectID = projectID, ProductID = p.ID, Quantity = qty });
            return p;

        }

        public List<ProjectProducts> GetProjectProducts(int projectId) => projectProducts.Where(a => a.ProjectID == projectId).ToList();

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


        public Product UpdateProjectProductQty(int projectID, int productId, int qty)
        {
            ProjectProducts pp = projectProducts.FirstOrDefault(a => a.ProductID == productId && a.ProjectID==projectID);
            projectProducts.Remove(pp);
            pp.Quantity = qty;
            projectProducts.Add(pp);
            return products.FirstOrDefault(a => a.ID == pp.ProductID);
        }
    }
}
