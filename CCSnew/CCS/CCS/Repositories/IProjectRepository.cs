using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com

namespace CCS.Repositories
{
    public interface IProjectRepository
    {
        List<Project> ShowAllProjects();
        List<Project> ShowProjectsByCustomer(string custID);
        List<Project> ShowProjectsByStatus(Status s);
        Project ShowProjectByID(int id);
        Project Add(Project p);
        int Remove(Project p);
        int Remove(int id);
        Project Update(Project p);
        Project UpdateStatus(int id, Status s, string UserId);
        Project AddQuote(int id, double q);


    }
}
