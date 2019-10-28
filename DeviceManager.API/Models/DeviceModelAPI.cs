using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceManager.API.Models
{
    public class DeviceModelAPI
    {
        public int ID_device { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string OS { get; set; }
        public string OS_version { get; set; }
        public string Processor { get; set; }
        public Nullable<byte> RAM { get; set; }
        public Nullable<int> Owner { get; set; }
    }
}