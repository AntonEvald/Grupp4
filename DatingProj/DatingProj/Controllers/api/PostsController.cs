using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        public class PostModel
        {
            public string Text { get; set; }
            public string FromUser { get; set; }
            public string ToUser { get; set; }

        }



        [HttpGet]
        public List<Posts> List()
        {
            using (var db = new ApplicationDbContext())
            {
                var posts = db.Posts.ToList();
                return posts;
            }
        }

        [HttpPost]
        public void PostMessage(PostModel post)
        {

            using (var db = new ApplicationDbContext())
            {
                var from = db.Users.Single(u => u.Id == post.FromUser);
                var to = db.Users.Single(u => u.Id == post.ToUser);
                var posts = new Posts(){Text = post.Text, FromUser = from, ToUser = to};
 
                db.Posts.Add(posts);
                db.SaveChanges();
            }


        }
    }

}
