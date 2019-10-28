using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceManager.API.Models
{
    public class UserModelAPI
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<DeviceModelAPI> Devices { get; set; }
    }
}