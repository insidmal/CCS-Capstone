using CCS.Models;
using CCS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

// CREATIVE CYBER SOLUTIONS
// 04/12/2018
// JOHN BELL contact@conquest-marketing.com
// Project Products Test

namespace CCS.Tests
{
    public class ProjProdTests
    {
        IProjectProductsRepository repo;
        Product p1;
        Product p2;
        Product p3;
        Project pr1;
        Project pr2;
        Project pr3;


        public ProjProdTests()
        {
            repo = new TestProjProdRepo();
            pr1 = new Project() { ID = 1, CustomerID = 1, Name = "Project 1", Description = "Test Project 1", Progress = Status.New };
            pr2 = new Project() { ID = 2, CustomerID = 1, Name = "Project 2", Description = "Test Project 2", Progress = Status.Started };
            pr3 = new Project() { ID = 3, CustomerID = 2, Name = "Project 3", Description = "Test Project 3", Progress = Status.New };
            p1 = new Product { ID = 1, Description = "Test Product 1", Name = "Product 1", Price = 100 };
            p2 = new Product { ID = 2, Description = "Test Product 2", Name = "Product 2", Price = 15 };
            p3 = new Product { ID = 3, Description = "Test Product 3", Name = "Product 3", Price = 150 };

        }

        [Fact]
        public void GetProjectProductsTest()
        {
            Assert.Empty(repo.GetProjectProducts(1));
            repo.AddProjectProduct(1, p1, 2);
            Assert.Single(repo.GetProjectProducts(1));
            repo.AddProjectProduct(1, p2, 1);
            Assert.Equal(2,repo.GetProjectProducts(1).Count);

        }

        [Fact]
        public void AddProjectProductTest()
        {
            Assert.Empty(repo.GetProjectProducts(1));
            repo.AddProjectProduct(1, p1, 2);
            Assert.Single(repo.GetProjectProducts(1));

        }

        [Fact]
        public void RemoveProjectProductTest()
        {
            Assert.Empty(repo.GetProjectProducts(1));
            repo.AddProjectProduct(1, p1, 2);
            Assert.Single(repo.GetProjectProducts(1));
            repo.RemoveProjectProduct(1,p1);
            Assert.Empty(repo.GetProjectProducts(1));
         }

        [Fact]
        public void RemoveProjectProductByIdTest()
        {
            Assert.Empty(repo.GetProjectProducts(1));
            repo.AddProjectProduct(1, p1, 2);
            Assert.Single(repo.GetProjectProducts(1));
            repo.RemoveProjectProductId(1, 1);
            Assert.Empty(repo.GetProjectProducts(1));
        }

        [Fact]
        public void UpdateProjectProductQtyTest()
        {
            Assert.Empty(repo.GetProjectProducts(1));
            repo.AddProjectProduct(1, p3, 2);
            Assert.Equal(2, repo.GetProjectProducts(1)[0].Quantity);
            repo.UpdateProjectProductQty(1, 3, 1);
            Assert.Equal(1, repo.GetProjectProducts(1)[0].Quantity);

        }
    }
}
