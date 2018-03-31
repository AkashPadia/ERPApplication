using ERPApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPApplication.Controllers
{
    public class SupplierController : Controller
    {
        private ERPContext _context;

        public SupplierController()
        {
            _context = new ERPContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Supplier
        public ActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList();
            return View(suppliers);
        }

        public ActionResult New()
        {
            return View("SupplierForm");
        }

        [HttpPost]
        public ActionResult Save(Supplier supplier)
        {
            if(supplier.SupplierId == 0)
            {
                _context.Suppliers.Add(supplier);
            }
            else
            {
                var supplierInDB = _context.Suppliers.Single(s => s.SupplierId == supplier.SupplierId);
                supplierInDB.CompanyName = supplier.CompanyName;
                supplierInDB.ContactName = supplier.ContactName;
                supplierInDB.ContactTitle = supplier.ContactTitle;
                supplierInDB.City = supplier.City;
                supplierInDB.Country = supplier.Country;
                supplierInDB.Phone = supplier.Phone;
                supplierInDB.Fax = supplier.Fax;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var supplierInDB = _context.Suppliers.Single(s => s.SupplierId == id);

            if (supplierInDB == null)
                return HttpNotFound();

            return View("SupplierForm", supplierInDB);
        }

        public ActionResult Details(int id)
        {
            var supplierInDB = _context.Suppliers.Single(s => s.SupplierId == id);

            if (supplierInDB == null)
                return HttpNotFound();

            return View(supplierInDB);
        }

        public ActionResult Delete(int id)
        {
            var supplierInDB = _context.Suppliers.Single(s => s.SupplierId == id);

            if (supplierInDB == null)
                return HttpNotFound();

            return View(supplierInDB);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var supplierInDB = _context.Suppliers.Single(s => s.SupplierId == id);

            if (supplierInDB == null)
                return HttpNotFound();

            _context.Suppliers.Remove(supplierInDB);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}