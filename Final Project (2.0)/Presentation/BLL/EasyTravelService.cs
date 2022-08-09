using BLL.BEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
    public class EasyTravelService
    {
        public static List<AdminListModel> Get()
        {
            var config = new MapperConfiguration(c =>

                c.CreateMap<AdminList, AdminListModel>());

            var mapper = new Mapper(config);
            var data = mapper.Map<List<AdminListModel>>(DataAccessFactory.GetAdminListDataAccess().Get());
            return data;
        }
        public static void Create(AdminListModel s)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminListModel, AdminList>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<AdminList>(s);
            DataAccessFactory.GetAdminListDataAccess().Create(data);
        }
        public static AdminListModel GetOnly(int id)
        {
            var item = DataAccessFactory.GetAdminListDataAccess().Get(id);
            var d = new AdminListModel() { Id = item.Id, Name = item.Name, Paaword = item.Paaword,Phone = item.Phone, Email = item.Email,OtherInfo=item.OtherInfo };
            return d;

        }
        /* public static void add(AdminListModel s)
         {
             var config = new MapperConfiguration(c =>
             {
                 c.CreateMap<AdminList, AdminListModel>();

             });
             var mapper = new Mapper(config);
             var data = mapper.Map<AdminList>(s);
             EasyTravelRepo.Add(data);

         }*/

        public static void Update(AdminListModel s)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminListModel, AdminList>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<AdminList>(s);
            DataAccessFactory.GetAdminListDataAccess().Update(data);
        }
        public static void Delete(int id)
        {
            DataAccessFactory.GetAdminListDataAccess().Delete(id);
        }
    }
}
