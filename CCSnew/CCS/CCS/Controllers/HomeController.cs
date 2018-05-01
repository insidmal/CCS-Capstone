using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// CREATIVE CYBER SOLUTIONS
// CREATED: 04/10/2018
// CREATED BY: CODY CONNOR
// UPDATED: 04/25/2018
// UPDATED BY: JOHN BELL contact@conquest-marketing.com


namespace CCS.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> userManager;

        public HomeController(UserManager<User> usrMgr)
        {
            userManager = usrMgr;

        }

        public IActionResult Index()
        {
            return View();
            
        }

        public IActionResult About()
        {
            return View();

        }

   

        public IActionResult Services()
        {
            return View();

        }


        public IActionResult memberMessageList()
        {
            string s = "";
            foreach (User u in userManager.Users.ToList())
            {
                s+= "\"" + u.UserName + "\",";
            }
            s = s.Remove(s.Length-1);
            return View("memberMessageList",s);
        }
    }
}