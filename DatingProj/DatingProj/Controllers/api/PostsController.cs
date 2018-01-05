using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DatingProj.Models;
using System.Web.Http;
using DataBase.Models;

namespace DatingProj.Controllers
{
    public class PostsController : ApiController
    {
        [HttpGet]
        public List<Posts> List(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                var Posts = db.Posts.Where(u => u.ToUser.Id == id).ToList();
                return Posts;
            }
        }

        public void Create(Posts post)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
            Redirect("Index");
            
        }
    }
}
