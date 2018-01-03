using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatingProj.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace DatingProj.Controllers
{
    public class ProfilController : BaseController
    {

    

        // GET: Profil
        public ActionResult Index()
        {
 
                var userName = User.Identity.Name;

                var user = db.Users.Single(x => x.UserName == userName);
                return View(user);

        }

        public ActionResult Edit()
        {
           
                var userName = User.Identity.Name;

                var user = db.Users.Single(x => x.UserName == userName);
                return View(user);
            
        }
        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {

            var userName = User.Identity.Name;
            var edit = db.Users.Single(x => x.UserName == userName);
            if (TryUpdateModel(edit, "", new string[] {"UserName", "Name", "Description", "Searchable"}))
                {
                    db.SaveChanges();
                }

            return RedirectToAction("Index");

        }
    }
}
