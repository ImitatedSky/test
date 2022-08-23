using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Company
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
    }

    public class Comp_LoginInfo
    {
        public string ID { get; set; }
        public string Password { get; set; }
    }

}