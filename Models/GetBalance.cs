using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faCodeAndImap.Models
{
    public class DataBalance
    {
        public int balance { get; set; }
    }

    public class GetBalance
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public DataBalance data { get; set; }
    }
}
