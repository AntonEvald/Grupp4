using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatingProj.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace DatingProj.Controllers
{
    
    public class FriendsController : BaseController
    {
     
        public ActionResult SendRequest(string id)
        {
           var Request = new Friend{ FriendFrom = User.Identity.GetUserId(), FriendTo = id, IsConfirmed = false};
            db.Friends.Add(Request);
            db.SaveChanges();
            return RedirectToAction("UserProfil", "Users", new { id = id });
        }

        public ActionResult FriendsList()
        {
            var Userid = User.Identity.GetUserId();
            var Friend1 = db.Friends.Where(u => u.FriendTo == Userid && u.IsConfirmed == true).ToList();
            var Friend2 = db.Friends.Where(u => u.FriendFrom == Userid && u.IsConfirmed == true).ToList();
            var list = new List<ApplicationUser>();
            foreach (var item in Friend1)
            {
                var a = item.FriendFrom;
                var b = db.Users.Where(u => u.Id == a).ToList();
                foreach (var z in b)
                {
                    list.Add(z);
                }
            }

            foreach (var item in Friend2)
            {
                var a = item.FriendTo;
                var b = db.Users.Where(u => u.Id == a).ToList();
                foreach (var z in b)
                {
                    list.Add(z);
                }
            }
            return View(list);
        
    }

        public ActionResult AcceptFriend(string id)
        {

            var request = db.Friends.Single(x => x.FriendFrom == id);
            request.IsConfirmed = true;
            db.SaveChanges();

            return RedirectToAction("GetFriendRequests","Friends");
        }

        public ActionResult GetFriendRequests()
        {
            var id = User.Identity.GetUserId();
            var Requests = db.Friends.Where(u => u.FriendTo == id && u.IsConfirmed == false).ToList();
            var list = new List<ApplicationUser>();
            foreach (var item in Requests)
            {
                var a = item.FriendFrom;
                var b = db.Users.Where(u => u.Id == a).ToList();
                foreach (var z in b)
                {
                    list.Add(z);
                }
            }
            return View(list);
        }


    }


}