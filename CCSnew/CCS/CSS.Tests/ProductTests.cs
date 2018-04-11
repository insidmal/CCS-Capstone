using CCS.Models;
using CCS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CCS.Tests
{

    public class ProductTests
    {
        IProductRepository repo;
        Product p1;
        Product p2;
        Product p3;
        Project pr1;
        Project pr2;
        Project pr3;

        public ProductTests()
        {
            repo = new TestProductRepo();
            p1 = new Product { ID = 1, Description = "Test Product 1", Name = "Product 1", Price = 100 };
            p2 = new Product { ID = 2, Description = "Test Product 2", Name = "Product 2", Price = 15 };
            p3 = new Product { ID = 3, Description = "Test Product 3", Name = "Product 3", Price = 150 };

            pr1 = new Project { ID = 1 };
            pr2 = new Project { ID = 2 };
            pr3 = new Project { ID = 3 };
        }

 
 
        [Fact]
        public void AddProductTest()
        {
            Assert.Empty(repo.ListProducts());
            repo.AddProduct(p1);
            Assert.Single(repo.ListProducts());
        }

        [Fact]
        public void RemoveProductByProductTest()
        {
            Assert.Empty(repo.ListProducts());
            repo.AddProduct(p1);
            Assert.Single(repo.ListProducts());
            repo.RemoveProduct(p1);
            Assert.Empty(repo.ListProducts());

        }

        [Fact]
        public void RemoveProductByIdTest()
        {
            Assert.Empty(repo.ListProducts());
            repo.AddProduct(p1);
            Assert.Single(repo.ListProducts());
            repo.RemoveProduct(p1.ID);
            Assert.Empty(repo.ListProducts());

        }

        [Fact]
        public void ListProductsTest()
        {
            repo.AddProduct(p1);
            repo.AddProduct(p2);
            Assert.Equal(2, repo.ListProducts().Count);
        }

        [Fact]
        public void ViewProductTest()
        {
            repo.AddProduct(p3);
            Assert.Equal("Product 3", repo.ViewProduct(3).Name);
        }

        [Fact]
        public void UpdateProductTest()
        {
            repo.AddProduct(p1);
            p1.Name = "Updated Product";
            repo.UpdateProduct(p1);
            Assert.Equal("Updated Product", repo.ViewProduct(1).Name);
        }
    }
}
