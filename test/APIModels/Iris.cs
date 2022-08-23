using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Iris
    {
        public string ID { get; set; }
        public string Img { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CapturedDate { get; set; }
        public int Sex { get; set; }
        public string CompID { get; set; }
        public string CustID { get; set; }
        public int CheckID { get; set; }
    }

    public class Iris_Post
    {
        public string Img { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CapturedDate { get; set; }
        public int Sex { get; set; }
        public string CompID { get; set; }
        public string CustID { get; set; }
        public int CheckID { get; set; }
    }

    public class Iris_Put
    {
        public DateTime? Birthday { get; set; }
        public DateTime? CapturedDate { get; set; }
        public byte Sex { get; set; }
        public string CompID { get; set; }
        public string CustID { get; set; }
        public int CheckID { get; set; }
    }

    public class IrisAnalysis
    {
        public int AnalysisPartID { get; set; }
        public int Score { get; set; }
    }
}