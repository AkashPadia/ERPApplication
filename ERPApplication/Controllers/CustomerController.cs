using ERPApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPApplication.Controllers
{
    public class CustomerController : Controller
    {
        private ERPContext _context;

        public CustomerController()
        {
            _context = new ERPContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            return View("CustomerForm");
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.CustomerId == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.CustomerId == customer.CustomerId);
                customerInDB.FirstName = customer.FirstName;
                customerInDB.Lastname = customer.Lastname;
                customerInDB.City = customer.City;
                customerInDB.Country = customer.Country;
                customerInDB.Phone = customer.Phone;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return HttpNotFound();

            return View("CustomerForm", customer);
        }

    }
}