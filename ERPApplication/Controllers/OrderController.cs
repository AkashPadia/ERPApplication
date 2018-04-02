using ERPApplication.Models;
using ERPApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPApplication.Controllers
{
    public class OrderController : Controller
    {
        private ERPContext _context;
        public OrderController()
        {
            _context = new ERPContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Order
        public ActionResult Index()
        {
            var order = _context.Orders.ToList();//.Include("Customers")
            return View(order);
        }

        public ActionResult New()
        {
            var viewModel = new OrderViewModel
            {
                Order = new Order(),
                Customers = _context.Customers.ToList()
            };
            return View("OrderForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Order order)
        {
            if (order.OrderId == 0)
            {
                _context.Orders.Add(order);
            }
            else
            {
                var orderInDB = _context.Orders.Single(o => o.OrderId == order.OrderId);
                if (orderInDB == null)
                    return HttpNotFound();

                orderInDB.OrderDate = order.OrderDate;
                orderInDB.OrderNumber = order.OrderNumber;
                orderInDB.TotalAmount = order.TotalAmount;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Order");
        }

        public ActionResult Edit(int id)
        {
            var orderInDB = _context.Orders.SingleOrDefault(o => o.OrderId == id);

            if (orderInDB == null)
                return HttpNotFound();

            var viewModel = new OrderViewModel
            {
                Order = orderInDB,
                Customers = _context.Customers.ToList()
            };
            
            return View("OrderForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var orderInDB = _context.Orders.Include("Customers").SingleOrDefault(o => o.OrderId == id);

            if (orderInDB == null)
                return HttpNotFound();

            return View(orderInDB);
        }

        public ActionResult Delete(int id)
        {
            var orderInDB = _context.Orders.Include("Customers").SingleOrDefault(o => o.OrderId == id);

            if (orderInDB == null)
                return HttpNotFound();

            return View(orderInDB);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var orderInDB = _context.Orders.Include("Customers").SingleOrDefault(o => o.OrderId == id);

            if (orderInDB == null)
                return HttpNotFound();
            _context.Orders.Remove(orderInDB);
            _context.SaveChanges();
            return RedirectToAction("Index", "Order");
        }
    }
}