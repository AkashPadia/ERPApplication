using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ERPApplication.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayName("Contact Name")]
        public string ContactName { get; set; }

        [DisplayName("Contact Title")]
        public string ContactTitle { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int Phone { get; set; }

        public int Fax { get; set; }
    }
}