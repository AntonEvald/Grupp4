using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatingProj.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;


namespace DatingProj.Controllers
{
    public class PostController : BaseController
    {
        // GET: Post

        public ActionResult Create(string id)
        {

            return View();
        }

    }
}