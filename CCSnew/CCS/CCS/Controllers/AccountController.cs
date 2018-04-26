using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CCS.Models;
using Microsoft.AspNetCore.Identity;

namespace CCS.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userMgr,
            SignInManager<User> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }

       
    }
}