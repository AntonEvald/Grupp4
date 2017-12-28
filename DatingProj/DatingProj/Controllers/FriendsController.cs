using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingProj.Controllers
{
    public class FriendsController : Controller
    {
        // GET: Friends
        public ActionResult SendFriendRequest()
        {
            return View();
        }
    }
}