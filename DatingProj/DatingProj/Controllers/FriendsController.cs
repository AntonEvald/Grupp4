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
        // GET: Friends
        public  ActionResult SendFriendRequest(string id)
        {

            var you = db.Users.Single(x => x.Id == id);
            var me = db.Users.Single(z => z.Id == User.Identity.GetUserId());
            return View();
        }

        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var friends = db.Friends.Where(z => z.FriendTo == id && z.IsConfirmed == true).ToList();
            return View(friends);

        }
    }
}