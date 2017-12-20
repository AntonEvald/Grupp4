using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace DatingProj.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Users
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var users = db.Users.ToList();
                return View(users);
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
        }

        public ActionResult UserProfil(string id)
        {
            if (id == User.Identity.GetUserId())
            {
                return RedirectToAction("Index", "Profil");
            } 
            else
            {
                var userprofile = db.Users.Single(x => x.Id == id);
                return View(userprofile);
            }

        }

    }
}