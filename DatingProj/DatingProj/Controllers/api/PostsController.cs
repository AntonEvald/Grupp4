using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using DatingProj.Models;
using System.Web.Http;
using DataBase.Models;
using Microsoft.AspNet.Identity;

namespace DatingProj.Controllers
{
    public class PostsController : ApiController
    {


        [HttpGet]
        public List<PostModel> List()
        {
            using (var db = new ApplicationDbContext())
            {
                var list = new List<Posts>();
                var posts = db.Posts.ToList();
                foreach (var item in posts)
                {
                        list.Add(item);
                }
                return list.Select(post => new PostModel
                    {
                        Id = post.Id,
                        Text = post.Text,
                        FromUser = post.FromUser.Name,
                        ToUser = post.ToUser.Id
                    })
                    .ToList();
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
