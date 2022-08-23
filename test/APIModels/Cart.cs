using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Cart
    {
        public int PID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }

    public class Cart_Post
    {
        public int PID { get; set; }
        public int Count { get; set; }
    }
}