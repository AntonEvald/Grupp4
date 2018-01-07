using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataBase.Models;
using DatingProj.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace DatingProj.Controllers
{
    public class ProfilController : BaseController
    {
        // GET: Profil
        public ActionResult Index(string id)
        {
            
            var user = db.Users.Single(x => x.Id == id);
            var Userid = User.Identity.GetUserId();
            var friendList = db.Friends.Where(f => f.FriendFrom == Userid || f.FriendTo == Userid).ToList();
            var list = new List<string>();
            foreach (var item in friendList)
            {
                if(item.FriendFrom != Userid)
                {
                    list.Add(item.FriendFrom);
                }
                if(item.FriendTo != Userid)
                {
                    list.Add(item.FriendTo);
                }
            }
            return View(new ProfilViewModel
            {
                User = user,
                Posts = new List<Posts>(),
                Friends = list

            });
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
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                using (var binary = new BinaryReader(poImgFile.InputStream))
                {
                    imageData = binary.ReadBytes(poImgFile.ContentLength);
                    user.UserPhoto = imageData;
                    if (TryUpdateModel(user, "", new string[] { "Name", "Description", "Searchable", "UserPhoto" }))
                    {
                            db.SaveChanges();
                    }
                }

            }
            else
            {
                if (TryUpdateModel(user, "", new string[] { "Name", "Description", "Searchable" }))
                {
                    db.SaveChanges();
                }
            }      

            return RedirectToAction("Index", new { id = User.Identity.GetUserId() });

        }
    }
}
