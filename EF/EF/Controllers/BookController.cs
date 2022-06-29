using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF.Models.Database;
using System.Web.Mvc;


namespace EF.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            Summer_TEntities db = new Summer_TEntities();
            var data = db.Books.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Book());
        }
        [HttpPost]
        public ActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                Summer_TEntities db = new Summer_TEntities();
                db.Books.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    
        public ActionResult Edit(int Id)
        {
            Summer_TEntities db = new Summer_TEntities();
            var book = (from b in db.Books
                        where b.Id == Id
                        select b).FirstOrDefault();  

            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book sub_b)
        {
            Summer_TEntities db = new Summer_TEntities();
            var book =(from b in db.Books
                       where b.Id == sub_b.Id
                       select b).FirstOrDefault();
            db.Entry(book).CurrentValues.SetValues(sub_b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}