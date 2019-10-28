using DeviceManager.BLL.Models;
using DeviceManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.BLL.Mappers
{
    class DeviceMapper
    {
        public Device  map(DeviceModel device)
        {
            if(device == null)
            {
                return null;
            }

            var newDevice = new Device()
            {
                ID_device = device.ID_device,
                Name = device.Name,
                OS = device.OS,
                OS_version = device.OS_version,
                Owner = device.Owner,
                Processor = device.Processor,
                RAM = device.RAM,
                Type = device.Type
            };

            return newDevice;
        }

        public DeviceModel map(Device device)
        {
            if (device == null)
            {
                return null;
            }

            var newDevice = new DeviceModel()
            {
                ID_device = device.ID_device,
                Name = device.Name,
                OS = device.OS,
                OS_version = device.OS_version,
                Owner = device.Owner,
                Processor = device.Processor,
                RAM = device.RAM,
                Type = device.Type
            };

            return newDevice;
        }
    }
}
