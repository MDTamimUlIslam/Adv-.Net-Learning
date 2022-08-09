using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static Easy_TravelEntities db = new Easy_TravelEntities();
        public static IRepo<AdminList, int> GetAdminListDataAccess()
        {
            return new EasyTravelRepo(db);
        }
    }
}
