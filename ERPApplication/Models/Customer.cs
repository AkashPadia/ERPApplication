using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPApplication.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }

        public string FullName { get { return string.Format("{0} {1}", FirstName, Lastname); } }
    }
}