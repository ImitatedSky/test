using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Body
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Disease { get; set; }
        public int Point_X { get; set; }
        public int Point_Y { get; set; }
    }
}