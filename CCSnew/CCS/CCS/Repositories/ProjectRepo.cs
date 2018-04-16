using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Repositories
{
    public class ProjectRepo : IProjectRepository
    {

        private readonly AppIdentityDbContext context;

        public ProjectRepo(AppIdentityDbContext repo)
        {
            context = repo;
        }

        public Project Add(Project p)
        {
            context.Add(p);
            context.SaveChanges();
            return p;
        }

        public Project AddQuote(int id, double q)
        {
            throw new NotImplementedException();
        }

        public int Remove(Project p)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> ShowAllProjects()
        {
            throw new NotImplementedException();
        }

        public Project ShowProjectByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> ShowProjectsByCustomer(int custID)
        {
            throw new NotImplementedException();
        }

        public List<Project> ShowProjectsByStatus(Status s)
        {
            throw new NotImplementedException();
        }

        public Project Update(Project p)
        {
            throw new NotImplementedException();
        }

        public Project UpdateStatus(int id, Status s)
        {
            throw new NotImplementedException();
        }
    }
}
