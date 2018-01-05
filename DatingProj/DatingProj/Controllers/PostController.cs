using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatingProj.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;


namespace DatingProj.Controllers
{
    public class PostController : BaseController
    {
        // GET: Post

        public ActionResult Create()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult Create(Posts post, string id)
        {
            var userName = User.Identity.Name;

            var user = db.Users.Single(x => x.UserName == userName);
        }*/
    }
}