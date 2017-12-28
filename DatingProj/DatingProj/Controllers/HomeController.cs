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
            if (User.Identity.IsAuthenticated)
            {
                string userid = User.Identity.GetUserId();

                if(userid == null)
                {
                    string filename = Path.Combine(HttpRuntime.AppDomainAppPath, "Images/noavatar.png");
                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(filename);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");
                }
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = bdUsers.Users.Where(x => x.Id == userid).FirstOrDefault();
                return new FileContentResult(userImage.UserPhoto, "image/jpeg");
            }
            else
            {
                string filename  = Path.Combine(HttpRuntime.AppDomainAppPath, "Images/noavatar.png");
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(filename);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");
            }
        }
    }
}