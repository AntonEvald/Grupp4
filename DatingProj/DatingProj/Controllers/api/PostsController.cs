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

        public void Create(CreateViewModel post)
        {
            using (var db = new ApplicationDbContext())
            {
                Posts NewPost = new Posts
                {
                    Text = post.Post.Text,
                    ToUser = post.ToUser,
                    FromUser = post.Post.FromUser
                };
                db.Posts.Add(NewPost);
                db.SaveChanges();
            }
            Redirect("Index");
            
        }
    }
}
