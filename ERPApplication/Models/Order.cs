using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ERPApplication.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [DisplayName("Order Date")]
        public DateTime? OrderDate { get; set; }

        [DisplayName("Order Number")]
        public string OrderNumber { get; set; }

        [DisplayName("Total Amount")]
        public float? TotalAmount { get; set; }

        [DisplayName("Customer Name")]
        public int CustomerId { get; set; }

        public Customer Customers { get; set; }
    }
}