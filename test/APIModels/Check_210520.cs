using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Check_210520
    {
        public string CompID { get; set; }
        public string CompGroupID { get; set; }
        public string SalesmanID { get; set; }
        public string CustID { get; set; }
        public int ID { get; set; }
        public string Iris_Left { get; set; }
        public string Iris_Right { get; set; }
        public DateTime? CheckDate { get; set; }
        public DateTime? QuestionnaireFilledDate { get; set; }
        public DateTime? HealthyPointFilledDate { get; set; }
        public string ImproveMethod { get; set; }
        public string ImproveDiet { get; set; }
        public string UploadDateTime { get; set; }
    }

    public class Check_Post_210520
    {
        public string Iris_Left { get; set; }
        public string Iris_Right { get; set; }
        public DateTime CheckDate { get; set; }
    }

    public class Check_Part_210520
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Check_Part_Score_210520
    {
        public int CheckPartID { get; set; }
        public string CheckPartName { get; set; }
        public int Score { get; set; }
    }

    public class Check_Part_Score_Post_210520
    {
        public int CheckPartID { get; set; }
        public int Score { get; set; }
    }

    public class Check_Part_Score_Average_210520
    {
        public int CheckID { get; set; }
        public double ScoreAverage { get; set; }
    }

    public class Check_Img_Analysis_210520
    {
        public string CompID { get; set; }
        public string CompGroupID { get; set; }
        public string SalesmanID { get; set; }
        public string CustID { get; set; }
        public int CheckID { get; set; }
        public int Iris { get; set; }
        public int ID { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int ShapeID { get; set; }
    }

    public class Check_Count_210520
    {
        public string TimeUnitResult { get; set; }
        public int Count { get; set; }
    }
}