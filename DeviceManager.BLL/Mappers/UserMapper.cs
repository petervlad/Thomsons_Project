using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceManager.DAL;
using DeviceManager.BLL.Models;

namespace DeviceManager.BLL.Mappers
{
    class UserMapper
    {
        public User map(UserModel user)
        {
            if(user == null)
            {
                return null;
            }
            var newUser = new User()
            {
                ID_User = user.ID_User,
                Name = user.Name,
                Location = user.Location,
                Devices = user.Devices,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };

            return newUser;
        }

        public UserModel map(User user)
        {
            if(user == null)
            {
                return null;
            }
            var newUser = new UserModel()
            {
                ID_User = user.ID_User,
                Name = user.Name,
                Location = user.Location,
                Devices = user.Devices,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };

            return newUser;
        }
    }
}
