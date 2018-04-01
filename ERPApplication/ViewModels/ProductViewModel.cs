using ERPApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPApplication.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}