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

        public ProductTests()
        {
            repo = new TestProductRepo();
            Product p1 = new Product { ID = 1, Description = "Test Product 1", Name = "Product 1", Price = 100 };
            Product p2 = new Product { ID = 2, Description = "Test Product 2", Name = "Product 2", Price = 15 };
            Product p3 = new Product { ID = 3, Description = "Test Product 3", Name = "Product 3", Price = 150 };

            Project pr1 = new Project { ID = 1 };
        }

        [Fact]
        public void AddProductToProjectTest()
        {

        }

        [Fact]
        public void RemoveProductFromProjectTest()
        {

        }

        [Fact]
        public void UpdateProductQuantityTest()
        {

        }

        [Fact]
        public void AddProductTest()
        {

        }

        [Fact]
        public void RemoveProductTest()
        {

        }

        [Fact]
        public void ListProductsTest()
        {

        }

        [Fact]
        public void ViewProductTest()
        {

        }

        [Fact]
        public void UpdateProductTest()
        {

        }
    }
}
