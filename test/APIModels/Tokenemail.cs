using System;


namespace FveyeWebAPI.Models
{
    public class Tokenemail
    {                 
      
        public string token { get; set; }
        public DateTime? token_datetime { get; set; }
    }
    public class Tokenemail_Post
    {
        public string email { get; set; }
      
    }
    public class Tokenemail_token_check
    {
        public string CompID { get; set; }
        public string CustID { get; set; }
        public string token { get; set; }
    }
}