using CCS.Models;
using CCS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

// CREATIVE CYBER SOLUTIONS
// CREATED: 04/11/2018
// UPDATED: 4/12/2018
// JOHN BELL contact@conquest-marketing.com
// Project Interface


namespace CCS.Tests
{
    public class ProjectTests
    {

        IProjectRepository repo;
        Project pr1;
        Project pr2;
        Project pr3;


        public ProjectTests()
        {
            repo = new TestProjectRepo();
            pr1 = new Project() { ID = 1, CustomerID = "1", Name = "Project 1", Description = "Test Project 1", Progress = Status.New };
            pr2 = new Project() { ID = 2, CustomerID = "1", Name = "Project 2", Description = "Test Project 2", Progress = Status.Started };
            pr3 = new Project() { ID = 3, CustomerID = "2", Name = "Project 3", Description = "Test Project 3", Progress = Status.New };

        }

        [Fact]
        public void AddQuoteTest()
        {
            repo.Add(pr1);
            Assert.Equal(Status.New, repo.ShowProjectByID(1).Progress);
            Assert.Equal(0, repo.ShowProjectByID(1).Quote);
            repo.AddQuote(1, 500.00);
            Assert.Equal(Status.Quoted, repo.ShowProjectByID(1).Progress);
            Assert.Equal(500, repo.ShowProjectByID(1).Quote);
        }

        [Fact]
        public void RemoveByProjectTest()
        {
            Assert.Empty(repo.ShowAllProjects());
            repo.Add(pr2);
            Assert.Single(repo.ShowAllProjects());
            repo.Remove(pr2);
            Assert.Empty(repo.ShowAllProjects());
        }

        [Fact]
        public void RemoveByIdTest()
        {
            Assert.Empty(repo.ShowAllProjects());
            repo.Add(pr2);
            Assert.Single(repo.ShowAllProjects());
            repo.Remove(2);
            Assert.Empty(repo.ShowAllProjects());
        }

        [Fact]
        public void ShowAllProjectsTest()
        {
            Assert.Empty(repo.ShowAllProjects());
            repo.Add(pr2);
            Assert.Single(repo.ShowAllProjects());
            repo.Add(pr3);
            Assert.Equal(2, repo.ShowAllProjects().Count);
        }

        [Fact]
        public void ShowProjectByIdTest()
        {
            Assert.Empty(repo.ShowAllProjects());
            repo.Add(pr1);
            Assert.Equal("Project 1", repo.ShowProjectByID(1).Name);
        }

        [Fact]
        public void ShowProjectByCustomerTest()
        {
            Assert.Empty(repo.ShowAllProjects());
            repo.Add(pr1);
            repo.Add(pr2);
            repo.Add(pr3);
            Assert.Equal(2, repo.ShowProjectsByCustomer("1").Count);

        }

        [Fact]
        public void ShowProjectByStatusTest()
        {
            Assert.Empty(repo.ShowAllProjects());
            repo.Add(pr1);
            repo.Add(pr2);
            repo.Add(pr3);
            Assert.Equal(2, repo.ShowProjectsByStatus(Status.New).Count);

        }

        [Fact]
        public void UpdateStatusTest()
        {
            Assert.Empty(repo.ShowAllProjects());
            repo.Add(pr1);
            Assert.Equal(Status.New, repo.ShowProjectByID(1).Progress);
            repo.UpdateStatus(1, Status.Started);
            Assert.Equal(Status.Started, repo.ShowProjectByID(1).Progress);
        }
    }
}
