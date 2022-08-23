using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Customer_210520
    {
        public string CompID { get; set; }
        public string CompGroupID { get; set; }
        public string SalesmanID { get; set; }
        public string MobileNum { get; set; }
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

    public class Customer_Put_210520
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

    public class Customer_Put_Password_210520
    {
        public string Password { get; set; }
    }

    public class Customer_Post_210520
    {
        public string CompID { get; set; }
        public string CompGroupID { get; set; }
        public string SalesmanID { get; set; }
        public string MobileNum { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string HomeNum { get; set; }
        public string Email { get; set; }
        public int? Zip { get; set; }
        public string Address { get; set; }
        public string Memo { get; set; }
        public string Password { get; set; }
    }

    public class LoginInfo_210520
    {
        public string CompID { get; set; }
        public string CompGroupID { get; set; }
        public string SalesmanID { get; set; }
        public string MobileNum { get; set; }
        public string Password { get; set; }
    }

    public class Token_210520
    {
        public string TokenString { get; set; }
        public string RefreshTokenString { get; set; }
    }

    public class RefreshToken_210520
    {
        public string RefreshTokenString { get; set; }
    }
}