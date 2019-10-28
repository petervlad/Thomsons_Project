using DeviceManager.BLL.Models;
using DeviceManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.BLL.Contracts
{
    public interface IUserService
    {
        string Add(UserModel userModel);

        void DeleteUser(UserModel userModel);

        List<UserModel> GetAll();

        UserModel GetById(int id);

        List<DeviceModel> GetUserDevices(int id);

        void UpdateUser(UserModel userModel);

        UserModel Login(string email, string password);
    }
}
