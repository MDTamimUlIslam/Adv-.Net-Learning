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
            {
                c.CreateMap<AdminList, AdminListModel>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<AdminListModel>>(EasyTravelRepo.Get());
            return data;
        }
            public static List<string> GetNames()
        {
            var data = EasyTravelRepo.Get().Select(e => e.Name).ToList();
            return data;
           
        }
        public static void add(AdminListModel s)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminList, AdminListModel>();

            });
            var mapper = new Mapper(config);
            var data = mapper.Map<AdminList>(s);
            EasyTravelRepo.Add(data);
           
        }
    }
}
