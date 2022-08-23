using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Salesman_210520
    {
        public string CompID { get; set; }
        public string CompGroupID { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
    }

    public class Salesman_LoginInfo_210520
    {
        public string CompID { get; set; }
        public string CompGroupID { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
    }
}