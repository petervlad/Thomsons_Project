using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceManager.DAL;
using DeviceManager.BLL.Models;

namespace DeviceManager.BLL.Contracts
{
    public interface IDeviceService
    {
        string Add(DeviceModel deviceModel);

        void DeleteDevice(DeviceModel deviceModel);

        List<DeviceModel> GetAll();

        DeviceModel GetById(int id);

        void UpdateDevice(DeviceModel deviceModel);

        List<DeviceModel> GetAllAvailable();
    }
}
