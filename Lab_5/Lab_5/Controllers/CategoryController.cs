using Lab_5.Models;
using Lab_5.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_5.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(CategoryRepo.Get());
        }

        public ActionResult Details(int Id)
        {
            return View(CategoryRepo.Get(Id));
        }
        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(CategoryModel item)
        {
            if (ModelState.IsValid)
            {
                CategoryRepo.Create(item);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}