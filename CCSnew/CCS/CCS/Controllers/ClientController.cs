using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Repositories;
using Microsoft.AspNetCore.Mvc;
using CCS.Repositories;

namespace CCS.Controllers
{
    public class ClientController : Controller
    {

        private IMessageRepository repo;
        private const int USERID = 1;

        public ClientController(IMessageRepository repos)
        {
            repo = repos;
        }

        public IActionResult Index() => View();

        public IActionResult MessageList() => View(repo.GetMessagesToAndFromUser(1));

        public IActionResult MessageView(int id) => View(repo.GetMessage(id));


    }
}