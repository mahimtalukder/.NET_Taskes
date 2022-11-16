using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            ViewBag.Categories = CategoryServices.Get();
            return View(NewsServices.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = CategoryServices.Get();
            return View(new NewsModel());
        }

        [HttpPost]
        public ActionResult Create(NewsModel news)
        {
            if (ModelState.IsValid)
            {
                NewsServices.Create(news);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = CategoryServices.Get();
            return View(news);
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Categories = CategoryServices.Get();
            return View(NewsServices.Get(Id));

        }

        [HttpPost]
        public ActionResult Edit(NewsModel news)
        {
            if (ModelState.IsValid)
            {
                NewsServices.Update(news);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = CategoryServices.Get();
            return View(news);

        }

        public ActionResult Details(int Id)
        {
            return View(NewsServices.Get(Id));
        }

        public ActionResult Delete(int Id)
        {
            NewsServices.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}