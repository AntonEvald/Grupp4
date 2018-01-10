using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace DatingProj.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Users
        public ActionResult Index(string searchString)
        {
            var users = db.Users.ToList();
            List<Models.ApplicationUser> filteredBySearchable =  users.Where(User => User.Searchable == true).Cast<Models.ApplicationUser>().ToList();
            
            if (!string.IsNullOrEmpty(searchString))
                {
                List<Models.ApplicationUser> filteredByNameAndSearchable = filteredBySearchable.Where(User => User.Name.Contains(searchString)).Cast<Models.ApplicationUser>().ToList();
                   
                    return View(filteredByNameAndSearchable);
                }
            return View(filteredBySearchable);
        }

        public ActionResult ChangeLanguage(string lang)
        {
            if(lang != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

    }
}