using DataBase.Models;
using DatingProj.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingProj.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;

                var user = db.Users.Single(x => x.UserName == userName);

                var users = db.Users.ToList();
                return View(new ViewModel
                {
                    user = user,
                    users = users
                });
            }
            else
            {
                var users = db.Users.ToList();
                return View(new ViewModel
                {
                    user = null,
                    users = users
                });
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "1337 Gaming description.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us!";

            return View();
        }

        public FileContentResult UserPhotos()
        {
          
            string userid = User.Identity.GetUserId();
            var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var userImage = bdUsers.Users.Where(x => x.Id == userid).FirstOrDefault();
            return new FileContentResult(userImage.UserPhoto, "image/jpeg");
            
        }
    }
}