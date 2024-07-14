using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faCodeAndImap.Models
{
    public class Data
    {
        public string id { get; set; }
        public string name { get; set; }
        public string raw_proxy { get; set; }
        public string profile_path { get; set; }
        public string browser_type { get; set; }
        public string browser_version { get; set; }
        public object note { get; set; }
        public int group_id { get; set; }
        public DateTime created_at { get; set; }
    }

    public class CreateProfileResult
    {
        public bool success { get; set; }
        public Data data { get; set; }
        public string message { get; set; }
    }
}
