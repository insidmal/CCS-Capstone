using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// CREATIVE CYBER SOLUTIONS
// 04/11/2018
// JOHN BELL contact@conquest-marketing.com
// Project Products Interface

namespace CCS.Repositories
{
    public interface IProjectProductsRepository
    {
        List<Product> GetProjectProducts(int projectId);
        ProjectProducts GetProjectProduct(int id);

        Product AddProjectProduct(int projectID, Product p, int qty);
        int RemoveProjectProduct(int projectID, Product p);
        int RemoveProjectProductId(int projectID, int productId);
        Product UpdateProjectProductQty(ProjectProducts pp);
        int AddProjectProductId(int projectID, int productId, int qty);
    }
}
