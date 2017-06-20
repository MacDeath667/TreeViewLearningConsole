using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetwork.UserClasses
{
    public class Device
    {
        public Device(Int64 MAC, string vendor, string IP = null)
        {
            Link = new List<Device>();
            this.MAC = MAC;
            this.vendor = vendor;
            this.IP = IP;
        }

        public override string ToString()
        {
            return string.Format("MAC: {0}, Vendor: {1}, IP: {2}", this.MAC, this.vendor, this.IP);
        }
        public List<Device> Link;
        protected Int64 MAC;
        protected string vendor;
        protected string IP;
    }

    public class Router : Device
    {
        public Router(Int64 MAC, string vendor, string IP) : base(MAC, vendor, IP)
        {}
    }

    public class Switch : Device
    {
        public Switch(Int64 MAC, string vendor) : base(MAC, vendor)
        {}

        public override string ToString()
        {
            return string.Format("MAC: {0}, Vendor: {1}", this.MAC, this.vendor);
        }
    }

    public class Computer : Device
    {
        public Computer(Int64 MAC, string vendor, string IP) : base(MAC, vendor, IP)
        {}
    }
}
