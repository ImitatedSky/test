using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Check
    {
        public string CompID { get; set; }
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

    public class Check_Post
    {
        public string Iris_Left { get; set; }
        public string Iris_Right { get; set; }
        public DateTime CheckDate { get; set; }
    }

    public class Check_Part
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Check_Part_Score
    {
        public int CheckPartID { get; set; }
        public string CheckPartName { get; set; }
        public int Score { get; set; }
    }

    public class Check_Part_Score_Post
    {
        public int CheckPartID { get; set; }
        public int Score { get; set; }
    }

    public class Check_Part_Score_Average
    {
        public int CheckID { get; set; }
        public double ScoreAverage { get; set; }
    }

    public class Check_Img_Analysis
    {
        public string CompID { get; set; }
        public string CustID { get; set; }
        public int CheckID { get; set; }
        public int Iris { get; set; }
        public int ID { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int ShapeID { get; set; }
    }

    public class Check_Count
    {
        public string TimeUnitResult { get; set; }
        public int Count { get; set; }
    }

}