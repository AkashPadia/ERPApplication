using ERPApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPApplication.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}