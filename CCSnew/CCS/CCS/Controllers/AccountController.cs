using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CCS.Models;
using Microsoft.AspNetCore.Identity;
using CCS.Repositories;

namespace CCS.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // CREATIVE CYBER SOLUTIONS
        // CREATED: 04/10/2018
        // CREATED BY: JOHN BELL contact@conquest-marketing.com
        // UPDATED: 04/25/2018
        // UPDATED BY: JOHN BELL contact@conquest-marketing.com



            private IProjectRepository project;
            private IProductRepository product;
            private UserManager<User> userManager;
            private SignInManager<User> signInManager;
            private IUserValidator<User> userValidator;
            private IPasswordValidator<User> passwordValidator;
            private IPasswordHasher<User> passwordHasher;
            private IMessageRepository message;
            private IProjectProductsRepository prodProj;
            private INoteRepository note;

            public AccountController(UserManager<User> usrMgr,
                SignInManager<User> signinMgr,
                IUserValidator<User> userValid,
                IPasswordValidator<User> passValid,
                IPasswordHasher<User> passwordHash,
                IMessageRepository repos,
                IProjectRepository proj,
                IProductRepository prod,
                IProjectProductsRepository prop,
                INoteRepository nor)
            {
                signInManager = signinMgr;
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

            //public IActionResult Index() => View();

            #region Account Functions
            [Authorize]
            public IActionResult Index() => View(GetData(nameof(Index)));

            [Authorize(Roles = "Users")]
            public IActionResult OtherAction() => View("Index",
                GetData(nameof(OtherAction)));

            private Dictionary<string, object> GetData(string actionName) =>
                new Dictionary<string, object>
                {
                    ["Action"] = actionName,
                    ["User"] = HttpContext.User.Identity.Name,
                    ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                    ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                    ["In Users Role"] = HttpContext.User.IsInRole("Users")
                };

            [AllowAnonymous]
            public IActionResult Login(string returnUrl)
            {
                ViewBag.returnUrl = returnUrl;
                return View();
            }

            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginModel details,
                string returnUrl)
            {
                if (ModelState.IsValid)
                {
                    User user = await userManager.FindByEmailAsync(details.Email);
                    if (user != null)
                    {
                        await signInManager.SignOutAsync();
                        Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                user, details.Password, false, false);
                        if (result.Succeeded)
                        {
                            return Redirect(returnUrl ?? "/");
                        }
                    }
                    ModelState.AddModelError(nameof(LoginModel.Email),
                        "Invalid user or password");
                }
                return View(details);
            }

            [Authorize]
            public async Task<IActionResult> Logout()
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }

            [AllowAnonymous]
            public IActionResult AccessDenied()
            {
                return View();
            }

        public ViewResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result
                    = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

      
        #endregion

        #region Message System Views

        public IActionResult MessageList()
            {
                ViewBag.UserId = GetCurrentUserId();
                var mess = message.GetMessagesToAndFromUser(GetCurrentUserId()).OrderByDescending(a => a.Date).ToList<Message>();
                foreach (Message m in mess)
                {
                    m.FromName = userManager.FindByIdAsync(m.FromID).Result.Id;
                    m.ToUser = userManager.FindByIdAsync(m.ToID).Result.Id;

                }
                return View();
            }
            public IActionResult MessageView(int id) => View(message.GetMessages(id));

            [HttpGet]
            public IActionResult MessageSend() => View(new Message() { FromID = GetCurrentUserId() });


            [HttpPost]
            public IActionResult MessageSend(Message m)
            {
                m.ToID = userManager.FindByNameAsync(m.ToUser).Result.Id;
                m.Date = DateTime.Now;
                message.Add(m);
                ViewBag.Message = "Message Sent to " + m.ToUser + "!";
                return RedirectToAction("MessageList");
            }

            #endregion

            public string GetCurrentUserId() => userManager.GetUserAsync(HttpContext.User).Result.Id ?? 0.ToString();

        }
    }
