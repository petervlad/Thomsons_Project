using DeviceManager.BLL.Contracts;
using DeviceManager.BLL.Models;
using DeviceManager.BLL.Mappers;
using DeviceManager.DAL.Repositories;
using DeviceManager.DAL.Contracts;
using DeviceManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.BLL.Services
{
    public class UserService : IUserService
    {

        private IUserRepository userRepository;
        private UserMapper mapper = new UserMapper();
        private DeviceMapper devMapper = new DeviceMapper();

        public UserService(IUserRepository iUserRepository)
        {
            userRepository = iUserRepository;
        }
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public string Add(UserModel userModel)
        {
            //To Add: mail verification 
            var newUser = mapper.map(userModel);
            userRepository.AddUser(newUser);

            return "User Created";
        }

        public void DeleteUser(UserModel userModel)
        {
            userRepository.Delete(userModel.ID_User);
        }

        public List<UserModel> GetAll()
        {
            var res = userRepository.GetAll();
            List<UserModel> userModels = new List<UserModel>();

            foreach(User u in res)
            {
                userModels.Add(mapper.map(u));
            }

            return userModels;
        }

        public UserModel GetById(int id)
        {
            return mapper.map(userRepository.GetById(id));
        }

        public List<DeviceModel> GetUserDevices(int id)
        {
            var dev = userRepository.GetDevices(id);
            List<DeviceModel> devModels = new List<DeviceModel>();

            foreach(Device d in dev)
            {
                devModels.Add(devMapper.map(d));
            }

            return devModels;
        }

        public UserModel Login(string email, string password)
        {
            var user = userRepository.Login(email, password);
            var userModel = mapper.map(user);
            return userModel;
        }

        public void UpdateUser(UserModel userModel)
        {
            userRepository.Update(mapper.map(userModel));
        }
    }
}
