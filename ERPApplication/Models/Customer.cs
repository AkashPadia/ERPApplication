using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ERPApplication.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int Phone { get; set; }

        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
    }
}