using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Product_Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Product_Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Product
    {
        public int ID { get; set; }
        public int TypeID { get; set; }
        public int BrandID { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public string Contents { get; set; }
        public string Suggestion { get; set; }
        public string User { get; set; }
        public string Features { get; set; }
        public string Instructions { get; set; }
        public string Notice { get; set; }
        public string ProductUnit { get; set; }
        public string Unit { get; set; }
        public int NumberOfPUnit { get; set; }
        public string Manufacturing { get; set; }
        public string ManufacturingNumber { get; set; }
        public string ManufacturingDate { get; set; }
        public string Savedate { get; set; }
        public string Origin { get; set; }
        public string Capacity { get; set; }
        public string StoragemMethod { get; set; }
        public string Calories { get; set; }
        public string Protein { get; set; }
        public string TotalFat { get; set; }
        public string SaturatedFat { get; set; }
        public string TransFat { get; set; }
        public string TotalCarbohydrate { get; set; }
        public string Sugar { get; set; }
        public string Sodium { get; set; }
        public string Calcium { get; set; }     
        public string English { get; set; }
    }

    public class Product_Suggestion
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public int Count { get; set; }
    }

    public class Product_Suggestion_Post
    {
        public int PID { get; set; }
        public int Count { get; set; }
    }
}