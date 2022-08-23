using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Company_210520
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
    }

    public class CompanyGroup_210520
    {
        public string CompID { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
    }

}