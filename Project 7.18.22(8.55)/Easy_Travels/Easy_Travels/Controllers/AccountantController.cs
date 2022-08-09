using Easy_Travels.Auth;
using Easy_Travels.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Easy_Travels.Controllers
{
    public class AccountantController : Controller
    {
        // GET: Accountant
        private int id;
        public int ID { get; private set; }
        [LogAuth]
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult PublicHome()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Accountant r)
        {
            var db = new Easy_TravelEntities();
            var product = (from p in db.Accountants where p.Username == r.Username && p.Password == r.Password select p).SingleOrDefault();
            if (product != null)
            {
                FormsAuthentication.SetAuthCookie(product.Name, false);
                Session["ID"] = product.Username;
                return RedirectToAction("Home", "Accountant");
            }
            else
            {
                ViewBag.Notification = "Wrong username or Password";
            }
            return View(r);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Accountant s)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities db = new Easy_TravelEntities();
                db.Accountants.Add(s);
                db.SaveChanges();
                return RedirectToAction("Login", "Accountant");
            }
            return View();
        }

        [LogAuth]
        public ActionResult Profile()
        {
            Easy_TravelEntities db = new Easy_TravelEntities();
            var data = db.Accountants.ToList();
            return View(data);
        }
        [LogAuth]
        [HttpGet]
        public ActionResult Add(int id)
        {
            var db = new Easy_TravelEntities();
            var data = (from d in db.Accountants where d.ID == id select d).SingleOrDefault();

            return View(data);

        }
        [LogAuth]
        [HttpPost]
        public ActionResult Add(Accountant s)
        {
            var db = new Easy_TravelEntities();
            var user = (from d in db.Accountants where d.ID == s.ID select d).FirstOrDefault();
            user.Name = s.Name;
            user.Address = s.Address;
            user.Email_ID = s.Email_ID;
            user.Date_of_Birth = s.Date_of_Birth;


            try
            {
                db.SaveChanges();
                return RedirectToAction("Profile");
            }
            catch (DbEntityValidationException n)
            {
                return View(s);
            }
        }
        [LogAuth]
        public ActionResult Delete(int ID)
        {
            var db = new Easy_TravelEntities();
            var s = (from d in db.Accountants where d.ID == ID select d).SingleOrDefault();
            db.Accountants.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Profile");
        }
        [LogAuth]
        [HttpGet]
        public ActionResult Report()
        {
            return View();
        }
        [LogAuth]
        [HttpPost]
        public ActionResult Report(Report p)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities db = new Easy_TravelEntities();
                db.Reports.Add(p);
                db.SaveChanges();
                
                return RedirectToAction("Home");

            }
            return View();
        }
        [LogAuth]
        public ActionResult HotelBooking()
        {
            Easy_TravelEntities db = new Easy_TravelEntities();
            var data = db.HotelBookings.ToList();
            return View(data);
        }
        [LogAuth]
        [HttpGet]
        public ActionResult BookedHotel()
        {
            return View();
        }
        [LogAuth]
        [HttpPost]
        public ActionResult BookedHotel(BookedHotel s)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities db = new Easy_TravelEntities();
                db.BookedHotels.Add(s);
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            return View();
        }
        [LogAuth]
        public ActionResult DeleteBooking(int ID)
        {
            var db = new Easy_TravelEntities();
            var s = (from d in db.HotelBookings where d.TouristID == ID select d).SingleOrDefault();
            db.HotelBookings.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Home");
        }
        [LogAuth]
        public ActionResult VehicleBooking()
        {
            Easy_TravelEntities db = new Easy_TravelEntities();
            var data = db.VehicleBookings.ToList();
            return View(data);
        }
        [LogAuth]
        [HttpGet]
        public ActionResult BookedVehicle()
        {
            return View();
        }
        [LogAuth]
        [HttpPost]
        public ActionResult BookedVehicle(BookedVehicle s)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities db = new Easy_TravelEntities();
                db.BookedVehicles.Add(s);
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            return View();
        }
        [LogAuth]
        public ActionResult DeleteVBooking(int ID)
        {
            var db = new Easy_TravelEntities();
            var s = (from d in db.VehicleBookings where d.TouristID == ID select d).SingleOrDefault();
            db.VehicleBookings.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Home");
        }
        [LogAuth]
        public ActionResult InqIndex()
        {
            Easy_TravelEntities db = new Easy_TravelEntities();
            var data = db.Inqs.ToList();
            return View(data);
        }
        [LogAuth]
        [HttpGet]
        public ActionResult Inq()
        {

            return View();
        }
        [LogAuth]
        [HttpPost]
        public ActionResult Inq(Inq h)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities db = new Easy_TravelEntities();
                db.Inqs.Add(h);
                db.SaveChanges();
                return RedirectToAction("InqIndex");

            }
            return View();
        }

        [LogAuth]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("PublicHome");
        }
        public JsonResult CheckUserName(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            Easy_TravelEntities db = new Easy_TravelEntities();
            var searchData = db.Accountants.Where(a => a.Username == userdata).SingleOrDefault();
            if( searchData != null)
            {
                return Json(1);

            }
            else
            {
                return Json(0);
            }

        }
       

    }
}