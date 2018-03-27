using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPApplication.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public int SupplierId { get; set; }

        public Supplier Suppliers { get; set; }
    }
}