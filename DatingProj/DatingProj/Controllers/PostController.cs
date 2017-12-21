using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatingProj.Models;
using Microsoft.AspNet.Identity;

namespace DatingProj.Controllers
{
    public class PostController : BaseController
    {
        // GET: Post
        public ActionResult Index(string id)
        {
            var posts = db.Posts.Where(x => x.ToUser.Id == id).ToList();
            return View(new PostIndexViewModel { Id = id, Posts = posts });
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Posts post, string id)
        {

            var userName = User.Identity.Name;

            var user = db.Users.Single(x => x.UserName == userName);

            post.FromUser = user;

            var toUser = db.Users.Single(x => x.Id == id);
            post.ToUser = toUser;

            db.Posts.Add(post);

            db.SaveChanges();

            return RedirectToAction("Index", new { id = id });
        }


    }

    public class PostIndexViewModel
    {
        public string Id { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}