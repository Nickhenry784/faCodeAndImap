using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faCodeAndImap.Models
{
    public class DataOpenProfile
    {
        public bool success { get; set; }
        public string profile_id { get; set; }
        public string browser_location { get; set; }
        public string remote_debugging_address { get; set; }
        public string driver_path { get; set; }
    }

    public class OpenProfileResult
    {
        public bool success { get; set; }
        public DataOpenProfile data { get; set; }
        public string message { get; set; }
    }

    public class CloseProfileResult
    {
        public bool success { get; set; }
        public string message { get; set; }
    }

    public class DeleteProfileResult
    {
        public bool success { get; set; }
        public object data { get; set; }
        public string message { get; set; }
    }
}
