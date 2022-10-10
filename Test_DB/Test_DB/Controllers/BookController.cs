using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_DB.DB;

namespace Test_DB.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            //recive boook db
            var db = new LibaryDBEntities();
            var books = db.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            var db = new LibaryDBEntities();
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new LibaryDBEntities();
            var book = (from b in db.Books
                        where b.ID == id 
                        select b).SingleOrDefault();
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            var db = new LibaryDBEntities();
            if (book != null) {
                var ext=(from b in db.Books
                            where b.ID == book.ID
                            select b).SingleOrDefault();
                //ext.Title = book.Title;
                //ext.Author = book.Author;
                //ext.Edition = book.Edition;


                db.Entry(ext).CurrentValues.SetValues(book);

                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var db = new LibaryDBEntities();
            var book = db.Books.Find(id);
            //var book = (from b in db.Books
            //            where b.ID == id
            //            select b).SingleOrDefault();

            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}