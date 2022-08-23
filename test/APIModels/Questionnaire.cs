using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Questionnaire
    {
        public int GroupID { get; set; }
        public int ItemID { get; set; }
    }

    public class Questionnaire_Item
    {
        public int GroupID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int weighte { get; set; }
    }
}