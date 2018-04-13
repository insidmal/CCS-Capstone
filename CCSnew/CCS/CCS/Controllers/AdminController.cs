using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CCS.Controllers
{
    public class AdminController : Controller
    {
        private IProjectRepository project;
        public AdminController(IProjectRepository proj)
        {
            project = proj;
        }
        public IActionResult Index() => View();
        public IActionResult ProjectList() => View(project.ShowAllProjects());
        public IActionResult ProjectView() => RedirectToAction("ProjectList");
        public IActionResult ProjectView(int id) => View(project.ShowProjectByID(id));


    }
}