using Easy_Travels.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy_Travels.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CheckUserName(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            Easy_TravelEntities db = new Easy_TravelEntities();
            var searchData = db.Accountants.Where(a => a.Username == userdata).SingleOrDefault();
            if (searchData != null)
            {
                return Json(1);

            }
            else
            {
                return Json(0);
            }

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}