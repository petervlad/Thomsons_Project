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
    public class CreateDevice
    {
        public string Name;
        public string OS;
        public string Type;
        public string OS_version;
        public string Processor;
        public Byte RAM;
    }

    public class DeviceController : ApiController
    {
        private IDeviceService deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        public DeviceController()
        {
            this.deviceService = new DeviceService();
        }

        // GET: api/Device
        public IEnumerable<DeviceModel> Get()
        {
            var devices = deviceService.GetAll();
            return devices;
        }

        // GET: api/Device/5
        public DeviceModel Get(int id)
        {
            return deviceService.GetById(id);
        }

        // POST: api/Device
        public string Post(int id, CreateDevice cd)
        {
            var device = new DeviceModel()
            {
                Name = cd.Name,
                OS = cd.OS,
                OS_version = cd.OS_version,
                RAM = cd.RAM,
                Processor = cd.Processor
            };       

            return deviceService.Add(device);
        }

        // PUT: api/Device/5
        public void Put(int id, [FromBody]DeviceModelAPI dev)
        {
            var device = deviceService.GetById(id);

            device.Name = dev.Name;
            device.OS = dev.OS;
            device.OS_version = dev.OS_version;
            device.RAM = dev.RAM;
            device.Processor = dev.Processor;

            deviceService.UpdateDevice(device);
        }

        // DELETE: api/Device/5
        public void Delete(int id)
        {
            deviceService.DeleteDevice(deviceService.GetById(id));
        }
    }
}
