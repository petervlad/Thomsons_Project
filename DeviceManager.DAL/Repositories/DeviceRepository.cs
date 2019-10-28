using DeviceManager.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.DAL.Repositories
{
    public class DeviceRepository: IDeviceRepository
    {
        private thomsonsEntities db = new thomsonsEntities();

        public void Add(Device device)
        {
            db.Devices.Add(device);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Devices.Remove(GetById(id));
            db.SaveChanges();
        }

        public void Delete(Device device)
        {
            db.Devices.Remove(device);
            db.SaveChanges();
        }

        public List<Device> GetAll()
        {
            return db.Devices.ToList();
        }

        public Device GetById(int id)
        {
            return db.Devices.FirstOrDefault(dev => dev.ID_device == id);
        }

        public Device Update(Device device)
        {
            var dev = db.Devices.FirstOrDefault(d => d.ID_device == device.ID_device);
            db.Entry(dev).CurrentValues.SetValues(device);
            db.SaveChanges();
            return dev;
        }
    }
}
