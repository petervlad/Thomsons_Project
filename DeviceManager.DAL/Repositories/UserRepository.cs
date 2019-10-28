using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceManager.DAL.Contracts;

namespace DeviceManager.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private thomsonsEntities db = new thomsonsEntities();

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Delete(User user)
        {
            foreach (Device dev in db.Devices)
            {
                if (dev.Owner == user.ID_User)
                {
                    dev.Owner = null;
                }
            }

            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            foreach(Device dev in db.Devices)
            {
                if(dev.Owner == id)
                {
                    dev.Owner = null;
                }
            }

            db.Users.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetById(int id)
        {
            return db.Users.FirstOrDefault(o => o.ID_User == id);
        }

        public List<Device> GetDevices(int id)
        {
            var user = db.Users.FirstOrDefault(o => o.ID_User == id);
            return user.Devices.ToList();
        }

        public User Login(string email, string password)
        {
            return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User Update(User user)
        {
            var usr = db.Users.FirstOrDefault(o => o.ID_User == user.ID_User);

            db.Entry(usr).CurrentValues.SetValues(user);
            db.SaveChanges();
            return usr;
        }
    }
}
