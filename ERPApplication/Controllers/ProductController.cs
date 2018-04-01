
using ERPApplication.Models;
using ERPApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPApplication.Controllers
{
    public class ProductController : Controller
    {
        private ERPContext _context;

        public ProductController()
        {
            _context = new ERPContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public ActionResult New()
        {
            var viewModel = new ProductViewModel
            {
                Product = new Product(),
                Suppliers = _context.Suppliers.ToList()
            };
            return View("ProductForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (product.ProductId == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var productInDB = _context.Products.Single(p => p.ProductId == product.ProductId);
                productInDB.ProductName = product.ProductName;
                productInDB.UnitPrice = product.UnitPrice;
                productInDB.Package = product.Package;
                productInDB.IsDiscontinued = product.IsDiscontinued;
                productInDB.SupplierId = product.SupplierId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public ActionResult Edit(int id)
        {
            var productInDB = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if (productInDB == null)
                return HttpNotFound();

            var viewModel = new ProductViewModel
            {
                Product = productInDB,
                Suppliers = _context.Suppliers.ToList()
            };
            return View("ProductForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var productInDB = _context.Products.Include("Suppliers").SingleOrDefault(p => p.ProductId == id);
            if (productInDB == null)
                return HttpNotFound();

            return View(productInDB);
        }

        public ActionResult Delete(int id)
        {
            var productInDB = _context.Products.Include("Suppliers").SingleOrDefault(p => p.ProductId == id);
            if (productInDB == null)
                return HttpNotFound();

            return View(productInDB);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var productInDB = _context.Products.Single(p => p.ProductId == id);
            if (productInDB == null)
                return HttpNotFound();

            _context.Products.Remove(productInDB);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}