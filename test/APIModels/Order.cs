using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FveyeWebAPI.Models
{
    public class Ordertotal
    {
        public string CustID { get; set; }
        public string ID { get; set; }
        public int Price { get; set; }
        public DateTime? PaymentDeadline { get; set; }
        public int OrderStateID { get; set; }
        public DateTime? DateTime { get; set; }
        public bool Iscompleted { get; set; }
    }
    public class Order
    {
        public string ID { get; set; }
        public int Price { get; set; }
        public DateTime? PaymentDeadline { get; set; }
        public int OrderStateID { get; set; }
        public DateTime? DateTime { get; set; }
        public bool Iscompleted { get; set; }
        public string bankorderID { get; set; }
        public string Memo { get; set; }
        public string Transport { get; set; }
        public string Shopaddress { get; set; }
        public string Orderaddress { get; set; }
        public string Xid { get; set; }
        public string Bankstate { get; set; }
        public DateTime? BankDateTime { get; set; }
    }

    public class Order_Post
    {
        public int Price { get; set; }
        public DateTime? PaymentDeadline { get; set; }
        public string Memo { get; set; }
        public string Transport { get; set; }
        public string Shopaddress { get; set; }
        public string Orderaddress { get; set; }
        public string Xid { get; set; }
        public string Bankstate { get; set; }
    }

    public class Order_Put
    {
        public int Price { get; set; }
        public int OrderStateID { get; set; }
        public bool Iscompleted { get; set; }
        public string Memo { get; set; }
        public string Transport { get; set; }
        public string Shopaddress { get; set; }
        public string Orderaddress { get; set; }
        public string Xid { get; set; }
        public string Bankstate { get; set; }
        public DateTime? BankDateTime { get; set; }
    }

    public class Order_Detail
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
    public class Order_SalesreportAll
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string OrderID { get; set; }
        public string CustID { get; set; }
    }
    public class Order_Salesreport
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string OrderID { get; set; }
    }
    public class Order_Detail_Post
    {
        public int PID { get; set; }
        public int Count { get; set; }
    }
    public class Order_time
    {
        public string ID { get; set; }
        public string CustID { get; set; }
      
    }
    public class Order_State
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}