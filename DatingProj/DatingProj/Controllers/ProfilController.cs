using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            var desc = user.Description;
            var userPhoto = user.UserPhoto;
            var name = user.Name;
            var search = user.Searchable;
            EditViewModel model = new EditViewModel
            {
                Email = userName,
                Searchable = search,
                Description = desc,
                Name = name,
                UserPhoto = userPhoto
            };
            return View(model);
            
        }
        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            var userName = User.Identity.Name;
            var user = db.Users.Single(x => x.UserName == userName);
            byte[] imageData = null;
            HttpPostedFileBase poImgFile = Request.Files["EditPhoto"];
            if(Request.Files.Count > 0)
            {
                using (var binary = new BinaryReader(poImgFile.InputStream))
                {
                    imageData = binary.ReadBytes(poImgFile.ContentLength);
                }
            } else
            {
                imageData = user.UserPhoto;
            }


            user.UserPhoto = imageData;
            user.Name = model.Name;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.Description = model.Description;
            user.Searchable = model.Searchable;

            if (TryUpdateModel(user, "", new string[] {"Email", "UserName", "Name", "Description", "Searchable", "UserPhoto"}))
                {
                    db.SaveChanges();
                }

            return RedirectToAction("Index");

        }
    }
}
