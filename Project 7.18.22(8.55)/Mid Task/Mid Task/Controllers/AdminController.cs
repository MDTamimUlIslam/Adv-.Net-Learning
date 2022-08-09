using Mid_Task.AUTH;
using Mid_Task.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mid_Task.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }

        /*---------------------------------Admin Show edit delete--------------------------*/
        [LogAUTH]
        public ActionResult AdminList()
        {
            Easy_TravelEntities1 db = new Easy_TravelEntities1();
            var data = db.AdminLists.ToList();
            return View(data);
        }

        [LogAUTH]
        [HttpGet]
        public ActionResult AdminEdit(int Id)
        {
            var db = new Easy_TravelEntities1();
            var data = (from d in db.AdminLists where d.Id == Id select d).SingleOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult AdminEdit(AdminList s)
        {
            var db = new Easy_TravelEntities1();
            var user = (from d in db.AdminLists where d.Id == s.Id select d).FirstOrDefault();
            user.Id = s.Id;
            user.Name = s.Name;
            user.Paaword = s.Paaword;
            user.Phone = s.Phone;
            user.Email = s.Email;
            user.OtherInfo = s.OtherInfo;
            try
            {
                db.SaveChanges();
                return RedirectToAction("AdminList");
            }
            catch (DbEntityValidationException n)
            {
                return View(s);
            }
        }
        public ActionResult AdminDelete(int Id)
        {
            var db = new Easy_TravelEntities1();
            var s = (from d in db.AdminLists where d.Id == Id select d).SingleOrDefault();
            db.AdminLists.Remove(s);
            db.SaveChanges();
            return RedirectToAction("AdminList");
        }





        /*-----------------------------------Accountant Edit Delete------------------------------*/

        [LogAUTH]
        [HttpGet]
        public ActionResult AccountantEdit(int Id)
        {
            var db = new Easy_TravelEntities1();
            var data = (from b in db.Accountants where b.ID == Id select b).SingleOrDefault();

            return View(data);

        }
        [LogAUTH]
        [HttpPost]
        public ActionResult AccountantEdit(Accountant s)
        {
            var db = new Easy_TravelEntities1();
            var user = (from b in db.Accountants where b.ID == s.ID select b).FirstOrDefault();
            user.Name = s.Name;
            user.Address = s.Address;
            user.Email_ID = s.Email_ID;
            user.Date_of_Birth = s.Date_of_Birth;


            try
            {
                db.SaveChanges();
                return RedirectToAction("AdminHome");
            }
            catch (DbEntityValidationException n)
            {
                return View(s);
            }
        }

       /* public ActionResult AccountantDelete(int Id)
        {
            var db = new Easy_TravelEntities1();
            var s = (from b in db.AccountantLists where b.Id == Id select b).SingleOrDefault();
            db.AccountantLists.Remove(s);
            db.SaveChanges();
            return RedirectToAction("AccountantList");
        }*/


        [LogAUTH]
        public ActionResult AccountantList()
        {
            Easy_TravelEntities1 db = new Easy_TravelEntities1();
            var data = db.Accountants.ToList();
            return View(data);
        }

        public ActionResult AccDelete(int ID)
        {
            var db = new Easy_TravelEntities1();
            var s = (from b in db.Accountants where b.ID == ID select b).SingleOrDefault();
            db.Accountants.Remove(s);
            db.SaveChanges();
            return RedirectToAction("AccountantList");
        }


        /*==============================================Registration=========================*/
        /*==============================================AdminReg=========================*/

        [LogAUTH]
        [HttpGet]
        public ActionResult AdminReg()
        {
            return View();
        }
        [LogAUTH]
        [HttpPost]
        public ActionResult AdminReg(AdminList r)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities1 db = new Easy_TravelEntities1();
                db.AdminLists.Add(r);
                db.SaveChanges();
                return RedirectToAction("AdminHome");
            }
            return View();

        }

        /*==============================================Registration=========================*/
        /*====LIST==========================================AccountantLIST=========================*/

        [LogAUTH]
        [HttpGet]
        public ActionResult AccReg()
        {
            return View();
        }
        [LogAUTH]
        [HttpPost]
        public ActionResult AccReg(AccountantList r)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities1 db = new Easy_TravelEntities1();
                db.AccountantLists.Add(r);
                db.SaveChanges();
                return RedirectToAction("AdminHome");
            }
            return View();

        }


        /*==============================================Registration=========================*/
        /*==============================================Accountant=========================*/

        [LogAUTH]
        [HttpGet]
        public ActionResult AccountantReg()
        {
            return View();
        }
        [LogAUTH]
        [HttpPost]
        public ActionResult AccountantReg(Accountant r)
        {
            if (ModelState.IsValid)
            {
                Easy_TravelEntities1 db = new Easy_TravelEntities1();
                db.Accountants.Add(r);
                db.SaveChanges();
                return RedirectToAction("AdminHome");
            }
            return View();

        }




        /*-=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-Login Home-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-*/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminList r)
        {
            var db = new Easy_TravelEntities1();
            var product = (from p in db.AdminLists where p.Email == r.Email && p.Paaword == r.Paaword select p).SingleOrDefault();
            if (product != null)
            {
                FormsAuthentication.SetAuthCookie(product.Name, false);
                Session["ID"] = product.Email;
                return RedirectToAction("AdminHome");
            }
            return View();
        }

        /*-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=LogOUT-=-=-=-=-==-=-=-=-=-=*/

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [LogAUTH]
        public ActionResult AdminHome()
        {
            return View();
        }




        /*-----------------------------------------------Hotel Show Edit delete*/
        [LogAUTH]
        public ActionResult HotelList()
        {
            Easy_TravelEntities1 db = new Easy_TravelEntities1();
            var data = db.HotelRegs.ToList();
            return View(data);
        }
        [LogAUTH]
        [HttpGet]

        public ActionResult HotelEdit(int id)
        {
            var db = new Easy_TravelEntities1();
            var data = (from d in db.HotelRegs where d.Id == id select d).SingleOrDefault();
            return View(data);

        }
        [LogAUTH]
        [HttpPost]
        public ActionResult HotelEdit(HotelReg s)
        {
            var db = new Easy_TravelEntities1();
            var user = (from d in db.HotelRegs where d.Id == s.Id select d).FirstOrDefault();
            user.Id = s.Id;
            user.Name = s.Name;
            user.Password = s.Password;
            user.Type = s.Type;
            user.Place = s.Place;
            user.Address = s.Address;
            user.Phone = s.Phone;
            user.Email = s.Email;

            try
            {
                db.SaveChanges();
                return RedirectToAction("HotelList");
            }
            catch (DbEntityValidationException n)
            {
                return View(s);
            }
        }
        public ActionResult HotelDelete(int Id)
        {
            var db = new Easy_TravelEntities1();
            var s = (from d in db.HotelRegs where d.Id == Id select d).SingleOrDefault();
            db.HotelRegs.Remove(s);
            db.SaveChanges();
            return RedirectToAction("HotelList");
        }


        /*-------------------------------------------------------Inq show and reply*/
        [LogAUTH]
        public ActionResult InqList()
        {
            Easy_TravelEntities1 db = new Easy_TravelEntities1();
            var data = db.Inqs.ToList();
            return View(data);
        }
        [LogAUTH]
        [HttpGet]
        public ActionResult InqEdit(int Id)
        {
            var db = new Easy_TravelEntities1();
            var data = (from d in db.Inqs where d.Id == Id select d).SingleOrDefault();
            return View(data);

        }
        [LogAUTH]
        [HttpPost]
        public ActionResult InqEdit(Inq s)
        {
            var db = new Easy_TravelEntities1();
            var user = (from d in db.Inqs where d.Id == s.Id select d).FirstOrDefault();
            user.Id = s.Id;
            user.Name = s.Name;
            user.Question = s.Question;
            user.Answer = s.Answer;
            try
            {
                db.SaveChanges();
                return RedirectToAction("InqList");
            }
            catch (DbEntityValidationException n)
            {
                return View(s);
            }
        }

        public ActionResult InqDelete(int Id)
        {
            var db = new Easy_TravelEntities1();
            var s = (from d in db.Inqs where d.Id == Id select d).SingleOrDefault();
            db.Inqs.Remove(s);
            db.SaveChanges();
            return RedirectToAction("InqList");
        }



        /*-----------------------------------------------Report show and reply*/
        [LogAUTH]
        public ActionResult ReportList()
        {
            Easy_TravelEntities1 db = new Easy_TravelEntities1();
            var data = db.Reports.ToList();
            return View(data);
        }
        public ActionResult ReportDelete(int Id)
        {
            var db = new Easy_TravelEntities1();
            var s = (from d in db.Reports where d.Id == Id select d).SingleOrDefault();
            db.Reports.Remove(s);
            db.SaveChanges();
            return RedirectToAction("ReportList");
        }









        /*-------------------------------------------------Tourist show Edit delete*/
        [LogAUTH]
        public ActionResult TouristList()
        {
            Easy_TravelEntities1 db = new Easy_TravelEntities1();
            var data = db.CusLogins.ToList();
            return View(data);
        }


        [LogAUTH]
        [HttpGet]
        public ActionResult TouristEdit(int Id)
        {
            var db = new Easy_TravelEntities1();
            var data = (from d in db.CusLogins where d.Id == Id select d).SingleOrDefault();
            return View(data);

        }
        [LogAUTH]
        [HttpPost]
        public ActionResult TouristEdit(CusLogin s)
        {
            var db = new Easy_TravelEntities1();
            var user = (from d in db.CusLogins where d.Id == s.Id select d).FirstOrDefault();
            user.Id = s.Id;
            user.Name = s.Name;
            user.Password = s.Password;
            user.Address = s.Address;
            user.Phone = s.Phone;
            user.Email = s.Email;
            try
            {
                db.SaveChanges();
                return RedirectToAction("TouristList");
            }
            catch (DbEntityValidationException n)
            {
                return View(s);
            }
        }

        public ActionResult TouristDelete(int Id)
        {
            var db = new Easy_TravelEntities1();
            var s = (from d in db.CusLogins where d.Id == Id select d).SingleOrDefault();
            db.CusLogins.Remove(s);
            db.SaveChanges();
            return RedirectToAction("TouristList");
        }


        /*-------------------------------------------------Transport show Edit delete*/


        public ActionResult TransportList()
        {
            Easy_TravelEntities1 db = new Easy_TravelEntities1();
            var data = db.TransportRegs.ToList();
            return View(data);
        }



        [HttpGet]
        public ActionResult TransportEdit(int Id)
        {
            var db = new Easy_TravelEntities1();
            var data = (from d in db.TransportRegs where d.Id == Id select d).SingleOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult TransportEdit(TransportReg s)
        {
            var db = new Easy_TravelEntities1();
            var user = (from d in db.TransportRegs where d.Id == s.Id select d).FirstOrDefault();
            user.Id = s.Id;
            user.Name = s.Name;
            user.Password = s.Password;
            user.Email = s.Email;
            user.Phone = s.Phone;
            user.Type = s.Type;
            user.Address = s.Address;
            try
            {
                db.SaveChanges();
                return RedirectToAction("TransportList");
            }
            catch (DbEntityValidationException n)
            {
                return View(s);
            }
        }
        public ActionResult TransportDelete(int Id)
        {
            var db = new Easy_TravelEntities1();
            var s = (from d in db.TransportRegs where d.Id == Id select d).SingleOrDefault();
            db.TransportRegs.Remove(s);
            db.SaveChanges();
            return RedirectToAction("TransportList");
        }






        public ActionResult PublicHome()
        {
            return View();
        }
    }


    





}