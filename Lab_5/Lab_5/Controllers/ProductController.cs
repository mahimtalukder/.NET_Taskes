using Lab_5.Models;
using Lab_5.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_5.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(ProductRepo.Get());
        }

        public ActionResult Detalis(int Id)
        {
            return View(ProductRepo.Get(Id));
        }
        [HttpGet]

        public ActionResult Create()
        {
            ViewBag.Categories = CategoryRepo.Get();
            return View();
        }

        [HttpPost]

        public ActionResult Create(ProductModel item)
        {
            if (ModelState.IsValid)
            {
                ProductRepo.Create(item);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = CategoryRepo.Get();
            return View();
        }
    }
}