using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class AnalysisData_Iris_210520
    {
        public string CompID { get; set; }
        public string CompGroupID { get; set; }
        public string SalesmanID { get; set; }
        public string CustID { get; set; }
        public int CheckID { get; set; }
        public int CenterPoint_X { get; set; }
        public int CenterPoint_Y { get; set; }
        public int InsideCRadius { get; set; }
        public int OutsideCRadius { get; set; }
        public int ICOuterRingDeltaRadius { get; set; }
        public int OCInnerRingDeltaRadius { get; set; }
    }

    public class AnalysisData_Iris_Post_210520
    {
        public int CenterPoint_X { get; set; }
        public int CenterPoint_Y { get; set; }
        public int InsideCRadius { get; set; }
        public int OutsideCRadius { get; set; }
        public int ICOuterRingDeltaRadius { get; set; }
        public int OCInnerRingDeltaRadius { get; set; }
    }
}