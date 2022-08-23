using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Fcm_Post
    {
        public string Token { get; set; }
        public DateTime Time { get; set; }
        public string Contents { get; set; }
    }
}