using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPApplication.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public float TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
    }
}