using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project0.Library.Repo;

namespace RandomApp.WebApp.Controllers
{
    public class OrderViewerController : Controller
    {
        private IOrderRep irepOrig;
        private ICustomerRep irepOrigCust;
        private IStoreRep irepOrigSto;
        private IMerchRep irepOrigMerch;
        public OrderViewerController(IOrderRep irep, ICustomerRep irepCust, IStoreRep irepSto, IMerchRep irepMerch)
        {
            irepOrig = irep;
            irepOrigCust = irepCust;
            irepOrigSto = irepSto;
            irepOrigMerch = irepMerch;
        }
        // GET: OrderViewer
        public ActionResult Index()
        {
            var ordView = irepOrig.GetOrders();
            var viewMod = ordView.Select(o => new Models.OrderViewerMod
            {
                OrderID = o.OrderID,
                CustID = o.OrderCust.CustomerID,
                Name = o.OrderCust.FullName,
                StoID = o.OrderSto.StoreID,
                StoLoc = o.OrderSto.Loc,
                time = o.time,
                Cost = o.CalcPriceOfOrder()
            });
            return View(viewMod);
        }

        // GET: OrderViewer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderViewer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderViewer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderViewer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderViewer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderViewer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderViewer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}