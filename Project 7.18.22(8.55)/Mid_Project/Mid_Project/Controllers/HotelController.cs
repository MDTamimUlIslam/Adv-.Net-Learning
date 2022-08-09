using Mid_Project.auth;
using Mid_Project.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Mid_Project.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        [logAuth]
        public ActionResult Index()
        {
            Easy_TravelEntities db = new Easy_TravelEntities();
            var data = db.RoomLists.ToList();
            return View(data);
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(HotelReg r)
        {
            var db = new Easy_TravelEntities();
            var product = (from p in db.HotelRegs where p.Email == r.Email && p.Password == r.Password select p).SingleOrDefault();
            if (product != null)
            {
                FormsAuthentication.SetAuthCookie(product.Name, false);
                Session["ID"] = product.Email;
        
                return RedirectToAction("Home");

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("ID");
            Session.RemoveAll();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult HotelReg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HotelReg(HotelReg r)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities db = new Easy_TravelEntities();
                db.HotelRegs.Add(r);
                db.SaveChanges();
                return RedirectToAction("HotelReg");

            }
            return View();
        }

        [logAuth]
        public ActionResult Home()
        {

            return View();
        }
        [logAuth]
        [HttpGet]
        public ActionResult RoomList()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RoomList(RoomList s)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities db = new Easy_TravelEntities();
                db.RoomLists.Add(s);
                db.SaveChanges();
                return RedirectToAction("Home");

            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new Easy_TravelEntities();
            var data = (from d in db.RoomLists where d.Id == id select d).SingleOrDefault();

            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(RoomList s)
        {
            var db = new Easy_TravelEntities();
            var user = (from d in db.RoomLists where d.Id == s.Id select d).FirstOrDefault();
            user.Name = s.Name;
            user.Price = s.Price;
            user.Type = s.Type;
            user.Price = s.Price;
            user.Offer = s.Offer;
            user.ExtraInfo = s.ExtraInfo;
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException n)
            {
                return View(s);
            }
        }
        public ActionResult Delete(int ID)
        {
            var db = new Easy_TravelEntities();
            var s = (from d in db.RoomLists where d.Id == ID select d).SingleOrDefault();
            db.RoomLists.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [logAuth]
        [HttpGet]
        public ActionResult Report()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Report(Report p)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities db = new Easy_TravelEntities();
                db.Reports.Add(p);
                db.SaveChanges();
                return RedirectToAction("Report");

            }
            return View();
        }
        [logAuth]
        public ActionResult InqIndex()
        {
            Easy_TravelEntities db = new Easy_TravelEntities();
            var data = db.Inqs.ToList();
            return View(data);
        }
        [logAuth]
        [HttpGet]
        public ActionResult Inq()
        {

            return View();
        }
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
        public ActionResult BookedHotelIndex()
        {
            Easy_TravelEntities db = new Easy_TravelEntities();
            var data = db.BookedHotels.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult BookedHotel()
        {

            return View();
        }
        [HttpPost]
        public ActionResult BookedHotel(BookedHotel b)
        {
            
            if (ModelState.IsValid)
            {
                Easy_TravelEntities db = new Easy_TravelEntities();
                db.BookedHotels.Add(b);
                db.SaveChanges();
                return RedirectToAction("BookedHotelIndex");

            }
            return View();
        }

    }
    
}
