using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class QA_Title
    {
        public int ID { get; set; }
        public string Content { get; set; }
    }

    public class QA_Subtitle
    {
        public int TitleID { get; set; }
        public int ID { get; set; }
        public string Content { get; set; }
    }

    public class QA_ContentTitle
    {
        public int TitleID { get; set; }
        public int SubtitleID { get; set; }
        public int ID { get; set; }
        public string Title { get; set; }
    }

    public class QA_Content
    {
        public int TitleID { get; set; }
        public int SubtitleID { get; set; }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}