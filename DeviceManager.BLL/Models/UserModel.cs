using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceManager.DAL;

namespace DeviceManager.BLL.Models
{
    public class UserModel
    {
        public int ID_User { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }
}
