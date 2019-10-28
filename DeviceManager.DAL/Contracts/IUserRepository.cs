using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.DAL.Contracts
{
    public interface IUserRepository
    {
        List<User> GetAll();

        void AddUser(User user);

        User Update(User user);

        void Delete(User user);

        void Delete(int id);

        User GetById(int id);

        User Login(string email, string password);

        List<Device> GetDevices(int id);
    }
}
