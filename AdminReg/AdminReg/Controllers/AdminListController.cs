using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminReg.Models.Database;
using System.Web.Mvc;

namespace AdminReg.Controllers
{
    public class AdminListController : Controller
    {
        // GET: AdminList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowAdmin()
        {
            Summer_TEntities db = new Summer_TEntities();
            var data = db.AdminLists.ToList();
            return View(data);

        }
        [HttpGet]
        public ActionResult Create()
        {

            return View(new AdminList());
        }
        [HttpPost]
        public ActionResult Create(AdminList b)
        {
            if (ModelState.IsValid)
            {
                Summer_TEntities db = new Summer_TEntities();
                db.AdminLists.Add(b);
                db.SaveChanges();
                return RedirectToAction("ShowAdmin");
            }
            return View();
        }
        
       public ActionResult Edit(AdminList sub_b)
        {
            Summer_TEntities db = new Summer_TEntities();
            var adminlist = (from b in db.AdminLists
                        where b.Id == sub_b.Id
                        select b).FirstOrDefault();
            db.Entry(adminlist).CurrentValues.SetValues(sub_b);
            db.SaveChanges();
            return RedirectToAction("ShowAdmin");
        }
    }
}