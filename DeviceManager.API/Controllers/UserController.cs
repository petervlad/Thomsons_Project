using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeviceManager.BLL.Contracts;
using DeviceManager.BLL.Services;
using DeviceManager.BLL.Models;
using DeviceManager.API.Models;


namespace DeviceManager.API.Controllers
{
    public class CreateUser
    {
        public string email;
    }

    public class UserController : ApiController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public UserController()
        {
            this.userService = new UserService();
        }

        // GET: api/User
        //[Authorize(Roles = "admin")]
        public IEnumerable<UserModel> Get()
        {
            var users = userService.GetAll();
            return users;
        }

        // GET: api/User/5
        //[Authorize(Roles = "admin")]
        public UserModel Get(int id)
        {
            return userService.GetById(id);
        }

        // GET: api/User/Devices
        [Route("api/User/Devices")]
        public IEnumerable<DeviceModel> GetDevices(int id)
        {
            if(id == null)
            {
                return null;
            }
            return userService.GetUserDevices(id);
        }


        // POST: api/User
        //[Authorize(Roles = "admin")]
        public string Post(CreateUser cu)
        {
            var user = new UserModel() { Email = cu.email };
            return userService.Add(user);
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]UserModelAPI userModelAPI)
        {
            var user = userService.GetById(id);
            user.Email = userModelAPI.Email;
            user.Location = userModelAPI.Location;
            user.Password = userModelAPI.Password;
            user.Role = userModelAPI.Role;
            userService.UpdateUser(user);
        }

        [Route("api/User/Login")]
        public UserModel Put([FromBody]UserModelAPI userModelAPI)
        {
            var user = userService.Login(userModelAPI.Email, userModelAPI.Password);
            return user;
        }

        // DELETE: api/User/5
        //[Authorize(Roles = "admin")]
        public void Delete(int id)
        {
            userService.DeleteUser(userService.GetById(id));
        }
    }
}
