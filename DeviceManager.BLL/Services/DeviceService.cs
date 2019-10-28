using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceManager.BLL.Contracts;
using DeviceManager.BLL.Mappers;
using DeviceManager.BLL.Models;
using DeviceManager.DAL;
using DeviceManager.DAL.Contracts;
using DeviceManager.DAL.Repositories;

namespace DeviceManager.BLL.Services
{
    public class DeviceService : IDeviceService
    {
        private IDeviceRepository deviceRepository;
        private DeviceMapper mapper = new DeviceMapper();

        public DeviceService(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        public DeviceService()
        {
            deviceRepository = new DeviceRepository();
        }

        public string Add(DeviceModel deviceModel)
        {
            var newDevice = mapper.map(deviceModel);
            deviceRepository.Add(newDevice);

            return "Device created";
        }

        public void DeleteDevice(DeviceModel deviceModel)
        {
            deviceRepository.Delete(deviceModel.ID_device);
        }

        public List<DeviceModel> GetAll()
        {
            var res = deviceRepository.GetAll();
            List<DeviceModel> deviceModels = new List<DeviceModel>();

            foreach(Device d in res)
            {
                deviceModels.Add(mapper.map(d));
            }

            return deviceModels;
        }

        public List<DeviceModel> GetAllAvailable()
        {
            var res = deviceRepository.GetAll();
            List<DeviceModel> deviceModels = new List<DeviceModel>();

            foreach (Device d in res)
            {
                if (d.Owner == null)
                {
                    deviceModels.Add(mapper.map(d));
                }               
            }

            return deviceModels;
        }
        public DeviceModel GetById(int id)
        {
            return mapper.map(deviceRepository.GetById(id));
        }

        public void UpdateDevice(DeviceModel deviceModel)
        {
            deviceRepository.Update(mapper.map(deviceModel));
        }
    }
}
