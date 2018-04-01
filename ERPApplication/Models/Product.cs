using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ERPApplication.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Unit Price")]
        public float UnitPrice { get; set; }

        public string Package { get; set; }

        public bool IsDiscontinued { get; set; }

        [DisplayName("Supplier Name")]
        public int SupplierId { get; set; }

        public Supplier Suppliers { get; set; }
    }
}