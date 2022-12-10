using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(CategoryServices.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel data)
        {
            if (ModelState.IsValid)
            {
                CategoryServices.Create(data);
                return RedirectToAction("Index");
            }
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            return View(CategoryServices.Get(Id));  

        }

        [HttpPost]
        public ActionResult Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                CategoryServices.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);

        }

        public ActionResult Delete(int Id)
        {
            if (CategoryServices.HasNews(Id))
            {
                TempData["msg"] = "Delete not poassibale";
                return RedirectToAction("Index");
            }
            CategoryServices.Delete(Id);
            return RedirectToAction("Index");
        }



    }
}