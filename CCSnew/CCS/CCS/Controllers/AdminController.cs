using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Repositories;
using Microsoft.AspNetCore.Mvc;
using CCS.Models;

namespace CCS.Controllers
{
    public class AdminController : Controller
    {

        private IProjectRepository project;
        private IProductRepository product;

        public AdminController(IProjectRepository proj, IProductRepository prod)
        {
            project = proj;
            product = prod;
        }
        public IActionResult Index() => View();
        public IActionResult ProjectList() => View(project.ShowAllProjects());
        public IActionResult ProjectView(int? id)
        {
            if (id == null || id == 0) return RedirectToAction("ProjectList");
            else return View(project.ShowProjectByID((int)id));

        }
        public IActionResult ProductAdd(int id)
        {
            string productName;
            //string productSpace = "                                                                                ";

            ViewBag.Project = id.ToString();
            List<string> products = new List<string>();
            foreach (Product p in product.ListProducts())
            {
                productName = p.Name + "    — $" + p.Price.ToString();

                products.Add(productName);
            }
            return View(products);
        }


    }
}