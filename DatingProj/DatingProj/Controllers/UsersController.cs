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
        
        public ActionResult Index(string searchString = "")
        {
            var users = db.Users.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                var searchResult =  users.Where(x => x.Name.Contains(searchString));
                return View(searchResult);
            }
            else
            {
                return View(users);
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