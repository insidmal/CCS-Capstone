using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CCS.Models;

namespace CCS.Controllers
{
    public class ContactController : Controller
    {
        CommentModel comments;

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CommentSent(string name, string email, string comment)
        {
            comments = new CommentModel();
            comments.Name = name;
            comments.Email = email;
            comments.Comment = comment;
            return View(comments);
        }
    }
}