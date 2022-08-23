using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Customer
    {
        public string CompID { get; set; }
        public string MobileNum { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string HomeNum { get; set; }
        public string Email { get; set; }
        public int Zip { get; set; }
        public string Address { get; set; }
        public string Memo { get; set; }
        public string Password { get; set; }
    }

    public class Customer_Put
    {
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string HomeNum { get; set; }
        public string Email { get; set; }
        public int? Zip { get; set; }
        public string Address { get; set; }
        public string Memo { get; set; }
    }

    public class Customer_Put_Password
    {
        public string Password { get; set; }
    }

    public class Customer_Post
    {
        public string CompID { get; set; }
        public string MobileNum { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string HomeNum { get; set; }
        public string Email { get; set; }
        public int Zip { get; set; }
        public string Address { get; set; }
        public string Memo { get; set; }
        public string Password { get; set; }
    }

    public class LoginInfo
    {
        public string CompID { get; set; }
        public string MobileNum { get; set; }
        public string Password { get; set; }
    }

    public class Token
    {
        public string TokenString { get; set; }
        public string RefreshTokenString { get; set; }
    }

    public class RefreshToken
    {
        public string RefreshTokenString { get; set; }
    }
    public class Customer_change_password
    {      
        public string token { get; set; }
        public DateTime? token_datetime { get; set; }
    }
    public class Customer_change_password_Post
    {
        public string email { get; set; }        
    }
    public class customer_email_token_check
    {
        public string CompID { get; set; }
        public string CustID { get; set; }
        public string token { get; set; }
    }
}