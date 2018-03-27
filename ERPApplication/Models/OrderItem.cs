using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPApplication.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Orders { get; set; }
        public Product Products { get; set; }
    }
}