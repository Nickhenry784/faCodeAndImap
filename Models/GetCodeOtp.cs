using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faCodeAndImap.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DataGetCodeOtp
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int Status { get; set; }
        public int Price { get; set; }
        public string Phone { get; set; }
        public string SmsContent { get; set; }
        public string IsSound { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Code { get; set; }
        public string PhoneOriginal { get; set; }
        public string CountryISO { get; set; }
        public string CountryCode { get; set; }
    }

    public class GetCodeOtp
    {
        public int status_code { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public DataGetCodeOtp data { get; set; }
    }


}
