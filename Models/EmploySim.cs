using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faCodeAndImap.Models
{

    public class DataEmploySim
    {
        public string phone_number { get; set; }
        public int balance { get; set; }
        public string request_id { get; set; }
        public string re_phone_number { get; set; }
        public string countryISO { get; set; }
        public string countryCode { get; set; }
    }

    public class EmploySim
    {
        public int status_code { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public DataEmploySim data { get; set; }
    }
}
