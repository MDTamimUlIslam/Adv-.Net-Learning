using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntroMVC.Models;

namespace IntroMVC.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Login()
        {
            return View();  //view folder e person folder e PersonController khujbe
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Home()
        {
            /* ViewBag.Name = "Tamim";
             ViewBag.Id = "19-40902-2";
             ViewBag.Dob = "26 August 1999";

             ViewData["Name"] = "Tamim";
             ViewData["Id"] = "19 -40902-2";
             ViewData["Dob"] = "26 August 1999";

             string[] names = { "Tamim", "Nazifa", "Labib", "Ayesha khan" };
             ViewBag.Names = names;*/

            List<person> persons = new List<person>();
            for(int i = 0; i < 100; i++)
            {
                var p = new person()
                {
                    id = i + 1,
                    Name = "Person" + (i + 1),
                    Dob = DateTime.Now,
                };
                persons.Add(p);
            }
            return View(persons);
        }
        public ActionResult tamim()
        {
            return View();
        }
        public ActionResult Ind()
        {
            var p = new person
            {
                id = 1,
                Name = "Nazifa",
                Dob = DateTime.Now
            };
            return View(p);
        }

    }
}