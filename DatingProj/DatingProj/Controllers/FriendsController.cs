using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            me.friends.Add(you);
            db.SaveChanges();

            return View();
        }
    }
}