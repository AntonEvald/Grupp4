using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatingProj.Models;
using Microsoft.AspNet.Identity;

namespace DatingProj.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var userName = User.Identity.Name;

                var user = db.Users.Single(x => x.UserName == userName);
                return View(user);
            }
        }

       

    }
}
