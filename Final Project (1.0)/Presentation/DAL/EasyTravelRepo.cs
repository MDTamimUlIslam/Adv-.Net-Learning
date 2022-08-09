using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EasyTravelRepo
    {
        static Easy_TravelEntities db;
        static EasyTravelRepo()
        {
            db= new Easy_TravelEntities();
        }
        public static List<AdminList> Get()
        {
            return db.AdminLists.ToList();
        }
        public static AdminList Get(int Id)
        {
            return db.AdminLists.FirstOrDefault(e => e.Id == Id);
        }
        public static void Edit(AdminList s)
        {
            var ds =db.AdminLists.FirstOrDefault(e => e.Id == s.Id);
            db.Entry(ds).CurrentValues.SetValues(s);
            db.SaveChanges();
        }
        public static void Delete(int Id)
        {
            var ds =db.AdminLists.FirstOrDefault(e => e.Id == Id);
            db.AdminLists.Remove(ds);
        }
        public static void Add(AdminList s)
        {
            db.AdminLists.Add(s);
            db.SaveChanges();
        }
    }
}
