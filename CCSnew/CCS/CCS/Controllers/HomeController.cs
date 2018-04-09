using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CCS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return File("~/Index.html", "text/html");
            
        }
    }
}