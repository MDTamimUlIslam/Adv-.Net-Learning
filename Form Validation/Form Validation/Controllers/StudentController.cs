using Form_Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form_Validation.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new student());
        }
        [HttpPost]
        public ActionResult Create(student s)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Dash");
            }
            else
            {
                return View(s);
            }

        }
       // [HttpPost]
        public ActionResult Dash()
        {
            return View();
        }
    }
}