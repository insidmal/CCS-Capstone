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
        List<ProjectProducts> GetProjectProducts(int projectId);
        Product AddProjectProduct(int projectID, Product p, int qty);
        int RemoveProjectProduct(int projectID, Product p);
        int RemoveProjectProductId(int projectID, int productId);
        Product UpdateProjectProductQty(int projectID, int productId, int qty);

    }
}
