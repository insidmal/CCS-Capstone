using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CCS.Models;
using Microsoft.AspNetCore.Authorization;
using System.Web;

// CREATIVE CYBER SOLUTIONS
// CREATED: 04/10/2018
// CREATED BY: JOHN BELL contact@conquest-marketing.com
// UPDATED: 06/10/2018
// UPDATED BY: JOHN BELL contact@conquest-marketing.com, YADIRA DESPAINGE PLANCHE


namespace CCS.Controllers
{
   [Authorize(Roles = "Administrator")]
    #region constructor and var decs
    public class AdminController : Controller
    {


        const bool CLIENT = false;
        private IProjectRepository project;
        private IProductRepository product;
        private UserManager<User> userManager;
        private IUserValidator<User> userValidator;
        private IPasswordValidator<User> passwordValidator;
        private IPasswordHasher<User> passwordHasher;
        private IMessageRepository message;
        private IProjectProductsRepository prodProj;
        private INoteRepository note;
        private ISettingRepository settings;

        public AdminController(UserManager<User> usrMgr,
            IUserValidator<User> userValid,
            IPasswordValidator<User> passValid,
            IPasswordHasher<User> passwordHash,
            IMessageRepository repos, 
            IProjectRepository proj, 
            IProductRepository prod,
            IProjectProductsRepository prop,
            INoteRepository nor,
            ISettingRepository set)
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
            settings = set;
        }

        #endregion

        public IActionResult Index() => View();
        
        #region Account Function Views
        public ViewResult ViewUsers(string message) => View(userManager.Users);

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

                    ViewBag.Message = "Account Created";

                else
                    ViewBag.Message = "An Error has Occured, Please Try Again";

            }
            return View("ViewUsers", userManager.Users);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    ViewBag.Message = "Account Deleted";
                else
                    ViewBag.Message = "An Error has Occured, Please Try Again";
            }
            else
                ViewBag.Message = "User Not Found";

            return View("ViewUsers", userManager.Users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                ViewBag.Message = "User Not Found";

                return View("ViewUsers", userManager.Users);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email,
            string password)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail
                = await userValidator.ValidateAsync(userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    var validNewPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validNewPass.Succeeded)
                    {
                        await userManager.RemovePasswordAsync(user);
                        await userManager.AddPasswordAsync(user, password);
                        ViewBag.Message = "Password Updated";
                    }
                    else
                    {
                        ViewBag.Message = "An Error Has Occured: ";
                        foreach (IdentityError s in validNewPass.Errors.ToList())
                        {
                            ViewBag.Message += s.Description + " ";
                        }
    
                        return View(user);
                    }

  
                }
                if ((validEmail.Succeeded && validPass == null)
                || (validEmail.Succeeded
                && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        ViewBag.Message = "Account Updated!";

                        return View("ViewUsers", userManager.Users);
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            ViewBag.Message = "An Error has Occured, Please Try Again";

            return View(user);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        #endregion

        #region Project Views
        //view projects
        public IActionResult ProjectList() {
            List<Project> projects = project.ShowAllProjects();
            foreach (Project p in projects)
            {
                if (userManager.Users.FirstOrDefault(a=>a.Id==p.CustomerID)==null) p.CustomerName = "[Deleted]";
                else p.CustomerName = userManager.Users.FirstOrDefault(a => a.Id == p.CustomerID).UserName;
            }

            return View(projects);
        }
        
        public IActionResult ProjectView(int? id)
        {
            if (id == null || id == 0) return RedirectToAction("ProjectList");


            else
            {

                var pj = project.ShowProjectByID((int)id,CLIENT);
                foreach (Note n in pj.Notes)
                {
                    if (userManager.Users.FirstOrDefault(a => a.Id == n.From) == null) n.FromName = "[Deleted]";
                    else n.FromName = userManager.Users.FirstOrDefault(a => a.Id == n.From).UserName;
                }
                ViewBag.Message = TempData["Message"];
                pj.CustomerName = userManager.FindByIdAsync(pj.CustomerID).Result.UserName;
                return View(pj);
            }
        }
        //add projects
        [HttpGet]
        public IActionResult ProjectAdd() => View();

        [HttpPost]
        public IActionResult ProjectAdd(Project p)
        {
            if (userManager.Users.FirstOrDefault(a => a.UserName == p.CustomerName) != null)
            { 
           
                p.Progress = Status.New;
                p.CustomerID = userManager.Users.FirstOrDefault(a => a.UserName == p.CustomerName).Id;
                p.LastUpdate = DateTime.Now;
                project.Add(p);
                p.Notes = new List<Note>();
                ViewBag.Message = "Project Created!";
                return View("ProjectView", p);
            }
            else
            {
                ViewBag.Message = "User not Found, Please Check your Recipient and Try Again";
                return View(p);
            }
        }       

        //add quote to project
        [HttpGet]
        public IActionResult ProjectQuote(int id)
        {
            Project p = project.ShowProjectByID(id,CLIENT);
            ViewBag.ProjectName = p.Name;
            ViewBag.ProjectDescription = p.Description;
            return View(id);
        }
        [HttpPost]
        public IActionResult ProjectQuote(int projectId, double quote)
        {
            TempData["Message"] = "Quote Added, Message Sent to Client!";
            var p = project.ShowProjectByID(projectId,CLIENT);
            project.AddQuote(projectId, quote);
            message.Add(new Message()
            {
                Date = DateTime.Now,
                FromID = GetCurrentUserId(),
                ToID = p.CustomerID,
                Status = Read.Unread,
                Parent = 0,
                Subject = "Quote Added for " + p.Name,
                Text = "We've added a quote for your project. " + HttpUtility.HtmlDecode("<a href=\"/Account/ProjectView/" + p.ID + "\"> Click Here to View your Project and see your quote.</a>")
            });
            return View("ProjectView", project.ShowProjectByID(projectId, CLIENT));

        }

        public IActionResult UpdateStatus(int id, Status status)
        {
            TempData["Message"] = "Status Updated to " + status.ToString();
            project.UpdateStatus(id, status, GetCurrentUserId());
            return View("ProjectView", project.ShowProjectByID(id,CLIENT));
        }

        public IActionResult MarkPaid(int id)
        {
            var p = project.ShowProjectByID(id,CLIENT);
            p.Paid = Paid.Paid;
            project.Update(p);
            TempData["Message"] = "Project Marked as Paid!";
            return View("ProjectView", project.ShowProjectByID(id, CLIENT));
        }

        #endregion

        #region Project Products

        //add products to project
        [HttpGet]
        public IActionResult ProductAdd(int id)
        {
            ViewBag.Project = id;
              return View(product.ListActiveProducts());
        }

        [HttpPost]
        public IActionResult ProductAdd(int ProjectId, int ProductId, int Qty)
        {
            prodProj.AddProjectProductId(ProjectId, ProductId, Qty);
            TempData["Message"] = "Product Added to Project";
            return View("ProjectView", project.ShowProjectByID(ProjectId,CLIENT));
        }

        [HttpGet]
        public IActionResult ProjProdEdit(int id) => View(prodProj.GetProjectProduct(id));

        [HttpPost]
        public IActionResult ProjProdEdit(ProjectProducts pp)
        {
            TempData["Message"] = "Product Updated";
            prodProj.UpdateProjectProductQty(pp);
            return View("ProjectView", project.ShowProjectByID(pp.ProjectID, CLIENT));
        }

        #endregion

        #region Product Views
        public IActionResult ProductList() => View(product.ListProducts());

        public IActionResult ProductDelete(int id)
        {
            product.RemoveProduct(id);
            return RedirectToAction("ProductList");
        }

        public IActionResult ProductView(int id) => View(product.ViewProduct(id));

        [HttpGet]
        public IActionResult ProductNew() => View();

        [HttpPost]
        public IActionResult ProductNew(Product p)
        {
            TempData["Message"] = "Product Added";
            product.AddProduct(p);
            return View("ProductView", p);
        }

        [HttpGet]
        public IActionResult ProductEdit(int id) => View(product.ViewProduct(id));

        [HttpPost]
        public IActionResult ProductEdit(Product p)
        {
            product.UpdateProduct(p);
            ViewBag.Message = "Product Updated!";
            return View("ProductView",p);
        }
        #endregion

        #region Note Views
        
        [HttpGet]
        public IActionResult NoteAdd(int id)
        {
            if (userManager.GetUserAsync(HttpContext.User).Result.Id is null)
            {
                ViewBag.From = 0;
            }
            else ViewBag.From = userManager.GetUserAsync(HttpContext.User).Result.Id;
            Note n = new Note();
            n.ProjectID = id;
            return View(n);
        }

        [HttpPost]
        public IActionResult NoteAdd(Note n)
        {
            n.Date = DateTime.Now;
            note.AddNote(n.ProjectID, n);
            TempData["Message"] = "Note Added!";
            return View("ProjectView", project.ShowProjectByID(n.ProjectID, CLIENT));
        }

        [HttpGet]
        public IActionResult NoteEdit(int id) => View(note.GetNote(id));
        [HttpPost]
        public IActionResult NoteEdit(Note n)
        {
            note.UpdateNote(n);
            TempData["Message"] = "Project Note Updated!";
            return View("ProjectView", project.ShowProjectByID(n.ProjectID, CLIENT));
        }
        #endregion

        #region Settings
        [HttpGet]
        public IActionResult Settings() => View(settings.GetSettings());
        [HttpPost]
        public IActionResult Settings(Settings s)
        {
            settings.UpdateSettings(s);
            ViewBag.Message = "Your Settings Have Been Saved.";
            return View(s);
        }

        #endregion

        public string GetCurrentUserId() => userManager.GetUserAsync(HttpContext.User).Result.Id ?? 0.ToString();



}
}

