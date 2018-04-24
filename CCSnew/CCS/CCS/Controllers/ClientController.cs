using System.Linq;
using CCS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CCS.Models;

namespace CCS.Controllers
{

    // CREATIVE CYBER SOLUTIONS
    // CREATED: 04/10/2018
    // CREATED BY: JOHN BELL contact@conquest-marketing.com
    // UPDATED: 04/24/2018
    // UPDATED BY: JOHN BELL contact@conquest-marketing.com


    public class ClientController : Controller
    {

        private IProjectRepository project;
        private IProductRepository product;
        private UserManager<User> userManager;
        private IUserValidator<User> userValidator;
        private IPasswordValidator<User> passwordValidator;
        private IPasswordHasher<User> passwordHasher;
        private IMessageRepository message;
        private IProjectProductsRepository prodProj;
        private INoteRepository note;

        public ClientController(UserManager<User> usrMgr,
            IUserValidator<User> userValid,
            IPasswordValidator<User> passValid,
            IPasswordHasher<User> passwordHash,
            IMessageRepository repos,
            IProjectRepository proj,
            IProductRepository prod,
            IProjectProductsRepository prop,
            INoteRepository nor)
        {
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
            message = repos;
            project = proj;
            product = prod;
            prodProj = prop;
            note = nor;
        }

        public IActionResult Index() => View();

        public IActionResult MessageList()
        {
          ViewBag.UserId = GetCurrentUserId();
          return View(message.GetMessagesToAndFromUser(GetCurrentUserId()).OrderByDescending(a => a.Date).ToList<Message>());
        }
        public IActionResult MessageView(int id) => View(message.GetMessage(id));

        [HttpGet]
        public IActionResult MessageSend() => View(GetCurrentUserId());

        [HttpPost]
        public IActionResult MessageSend(Message m)
        {
            message.Add(m);
            return View();
        }

        public string GetCurrentUserId() => userManager.GetUserAsync(HttpContext.User).Result.Id ?? 0.ToString();

    }
}