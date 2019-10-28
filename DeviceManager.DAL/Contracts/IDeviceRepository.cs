using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.DAL.Contracts
{
    public interface IDeviceRepository
    {
        List<Device> GetAll();

        void Add(Device device);

        Device Update(Device device);

        void Delete(int id);

        void Delete(Device device);

        Device GetById(int id);
    }
}
