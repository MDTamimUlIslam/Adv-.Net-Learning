using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BEnt
{
    public class AdminListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Paaword { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OtherInfo { get; set; }
    }
}
