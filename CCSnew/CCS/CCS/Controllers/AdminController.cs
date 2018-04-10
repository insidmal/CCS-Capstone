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
        public IActionResult Index() => View();

    }
}