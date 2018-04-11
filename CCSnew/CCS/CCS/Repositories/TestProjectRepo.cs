using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;

namespace CCS.Repositories
{
    public class TestProjectRepo : IProjectRepository
    {
        private List<Project> projects;
        public Project Add(Project p)
        {
            projects.Add(p);
            return p;
        }



        public Project AddQuote(int id, float q)
        {
            Project oldP = ShowProjectByID(id);
            projects.Remove(oldP);
            oldP.Quote = q;
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
        public Project ShowProjectByID(int id) => projects.FirstOrDefault(a => a.ID == id);
        public List<Project> ShowProjectsByCustomer(int custID) => projects.Where(a => a.CustomerID == custID).ToList();
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
