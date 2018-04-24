using CCS.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        //this is a placeholder from test repo, needs to be updated for new repo to use existing user ID string
        public IActionResult MessageList() => View(repo.GetMessagesToAndFromUser("1"));

        public IActionResult MessageView(int id) => View(repo.GetMessage(id));


    }
}