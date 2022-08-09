using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EasyTravelRepo : IRepo<AdminList, int>
    {
        Easy_TravelEntities db;
        public EasyTravelRepo(Easy_TravelEntities db)
        {
            this.db = db;
        }
        public bool Create(AdminList obj)
        {
            db.AdminLists.Add(obj);
            var res = db.SaveChanges();
            return res > 0;
        }

        public bool Delete(int id)
        {
            db.AdminLists.Remove(db.AdminLists.FirstOrDefault(e => e.Id == id));
            var res = db.SaveChanges();
            return res == 0;
        }

        public List<AdminList> Get()
        {
            return db.AdminLists.ToList();
        }

        public AdminList Get(int id)
        {
            return db.AdminLists.Find(id);
        }

        public bool Update(AdminList obj)
        {
            var data = db.AdminLists.FirstOrDefault(e => e.Id == obj.Id);
            data.Name = obj.Name;
            data.Paaword = obj.Paaword;
            data.Phone = obj.Phone;
            data.Email = obj.Email;
            data.OtherInfo = obj.OtherInfo;
            db.SaveChanges();
            return true;
        }
    }
}
