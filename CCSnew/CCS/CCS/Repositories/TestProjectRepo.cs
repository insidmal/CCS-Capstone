using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;

namespace CCS.Repositories
{
    public class TestProjectRepo : IProjectRepository
    {
        private List<Project> projects = new List<Project>();

        IProductRepository products = new TestProductRepo();
        IProjectProductsRepository projProds = new TestProjProdRepo();

        //public TestProjectRepo()
        //{
        //    if (projects.Count == 0)
        //    {

        //        Add(new Project() { ID = 1, CustomerID = 1, Name = "Project 1", Description = "Test Project 1", Progress = Status.New, QuoteDate = DateTime.Now });
        //        Add(new Project() { ID = 2, CustomerID = 1, Name = "Project 2", Description = "Test Project 2", Progress = Status.Started, QuoteDate = DateTime.Now });
        //        Add(new Project() { ID = 3, CustomerID = 2, Name = "Project 3", Description = "Test Project 3", Progress = Status.New, QuoteDate = DateTime.Now });
        //    }
        //}

            
        public Project Add(Project p)
        {
            projects.Add(p);
            return p;
        }



        public Project AddQuote(int id, double q)
        {
            Project oldP = ShowProjectByID(id);
            projects.Remove(oldP);
            oldP.Quote = q;
            oldP.Progress = Status.Quoted;
            oldP.QuoteDate = DateTime.Now;
            projects.Add(oldP);
            return oldP;
        }

        

        public int Remove(Project p)
        {
            projects.Remove(p);
            return 1;
        }

        public int Remove(int id)
        {
            Project p = ShowProjectByID(id);
            projects.Remove(p);
            return 1;
        }



        public List<Project> ShowAllProjects() => projects;
        public Project ShowProjectByID(int id) {
            Project proj = projects.FirstOrDefault(a => a.ID == id);

            proj.Products= projProds.GetProjectProducts(id);


            return proj;
               }

        public List<Project> ShowProjectsByCustomer(string custID) => projects.Where(a => a.CustomerID == custID).ToList();
        public List<Project> ShowProjectsByStatus(Status s) => projects.Where(a => a.Progress == s).ToList();
        public Project Update(Project p)
        {
            Project oldP = ShowProjectByID(p.ID);
            projects.Remove(oldP);
            oldP.Description = p.Description;
            oldP.InvoiceDue = p.InvoiceDue;
            oldP.Quote = p.Quote;
            oldP.TotalDue = p.TotalDue;
            projects.Add(oldP);
            return oldP;
        }

        public Project UpdateStatus(int id, Status s)
        {
            Project oldP = ShowProjectByID(id);
            projects.Remove(oldP);
            oldP.Progress = s;
            projects.Add(oldP);
            return oldP;
        }
    }
}
