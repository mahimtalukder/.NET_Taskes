﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ZeroHunger.DB;
using ZeroHunger.Models;
using ZeroHunger.Repo;

namespace ZeroHunger.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            string json = (string)Session["admin"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var admin = AdminRepo.Get(user.Id);
            return View(admin);
        }

<<<<<<< HEAD
=======
        public ActionResult ViewProfile()
        {
            return View();
        }
>>>>>>> cb9763efd51e104642ff41e3633c2e785cbb2eec
    }
}