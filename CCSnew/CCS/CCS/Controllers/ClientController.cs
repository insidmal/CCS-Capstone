using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CCS.Repositories

namespace CCS.Controllers
{
    public class ClientController : Controller
    {

        private IMessageRepository repo = new IMessageRepository();

        public IActionResult Index() => View();

    }
}