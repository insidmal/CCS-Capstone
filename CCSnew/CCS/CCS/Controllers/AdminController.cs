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
        private IMessageRepository repo;

        public AdminController(IMessageRepository repos)
        {
            repo = repos;
        }

        public IActionResult Index() => View();
        
    }
}