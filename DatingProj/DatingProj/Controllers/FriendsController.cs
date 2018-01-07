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
    
    public class FriendsController : BaseController
    {
        

        public ActionResult SendRequest(string id)
        {
            var Userid = User.Identity.GetUserId();
            var friendList = db.Friends.Where(f => f.FriendFrom == Userid || f.FriendTo == Userid).ToList();
            
            var Request = new Friend { FriendFrom = User.Identity.GetUserId(), FriendTo = id };

            try
            {
                db.Friends.Add(Request);
                db.SaveChanges();
                return RedirectToAction("Index", "Profil", new { id = User.Identity.GetUserId() });

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public ActionResult FriendsList()
        {
            var Userid = User.Identity.GetUserId();
            var Friend1 = db.Friends.Where(u => u.FriendTo == Userid && u.IsConfirmed == true).ToList();
            var Friend2 = db.Friends.Where(u => u.FriendFrom == Userid && u.IsConfirmed == true).ToList();
            var list = new List<ApplicationUser>();
            foreach (var item in Friend1)
            {
                var a = item.FriendFrom;
                var b = db.Users.Where(u => u.Id == a).ToList();
                foreach (var z in b)
                {
                    list.Add(z);
                }
            }

            foreach (var item in Friend2)
            {
                var a = item.FriendTo;
                var b = db.Users.Where(u => u.Id == a).ToList();
                foreach (var z in b)
                {
                    list.Add(z);
                }
            }
            return View(list);
        
    }

        public FileContentResult CountFriendRequests()
        {

            var id = User.Identity.GetUserId();
            var requests = db.Friends.Where(u => u.FriendTo == id && u.IsConfirmed == false).ToList();
            var a = requests.Count();
            if (a > 0)
            {
                string filename = Path.Combine(HttpRuntime.AppDomainAppPath, "Images/NewFriendRequests.png");
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(filename);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");
            }
            else
            {
                string filename = Path.Combine(HttpRuntime.AppDomainAppPath, "Images/NoFriendRequests.png");
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(filename);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");
            }
        }

        public ActionResult AcceptFriend(string id)
        {
            var Userid = User.Identity.GetUserId();
            var request = db.Friends.Single(x => x.FriendFrom == id && x.FriendTo == Userid);
            request.IsConfirmed = true;
            db.SaveChanges();

            return RedirectToAction("GetFriendRequests","Friends");
        }

        public ActionResult GetFriendRequests()
        {
            var id = User.Identity.GetUserId();
            var Requests = db.Friends.Where(u => u.FriendTo == id && u.IsConfirmed == false).ToList();
            var list = new List<ApplicationUser>();
            foreach (var item in Requests)
            {
                var a = item.FriendFrom;
                var b = db.Users.Where(u => u.Id == a).ToList();
                foreach (var z in b)
                {
                    list.Add(z);
                }
            }
            return View(list);
        }


    }


}