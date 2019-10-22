using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project0.Library.Repo;
using lib = Project0.Library;

namespace RandomApp.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRep irepOrig;
        private ICustomerRep irepOrigCust;
        private IStoreRep irepOrigSto;
        private IMerchRep irepOrigMerch;
        public OrderController(IOrderRep irep, ICustomerRep irepCust, IStoreRep irepSto, IMerchRep irepMerch)
        {
            irepOrig = irep;
            irepOrigCust = irepCust;
            irepOrigSto = irepSto;
            irepOrigMerch = irepMerch;
        }
        

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if(Convert.ToInt32(collection["CustID"]) > 0)
                {
                    int custID = Convert.ToInt32(collection["CustID"]);
                    TempData["CustID"] = custID;
                    int stoID = Convert.ToInt32(collection["StoID"]);
                    TempData["StoID"] = stoID;

                    lib.Customer Cust = irepOrigCust.GetCustomers(cusid: custID).First();
                    string custName = Cust.FullName;
                    TempData["CustName"] = custName;
                }
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit()
        {
            string custName = Convert.ToString(TempData["CustName"]);
            int stoID = Convert.ToInt32(TempData["StoID"]);
            lib.Store sto = irepOrigSto.GetStores(stoID).First();
            var viewMod = new Models.OrderViewMod()
            {
                custName = custName,
                stoLoc = sto.Loc
            };
            TempData.Keep();
            return View(viewMod);
        }

        public ActionResult AddOrder()
        {
            int stoID = Convert.ToInt32(TempData["StoID"]);
            lib.Store sto = irepOrigSto.GetStores(stoID).First();
            var viewMod = sto.iven.Select(i => new Models.IvenViewMod
            {
                merchID = i.Key.MerchID,
                merchName = i.Key.MerchName,
                merchPrice = i.Key.MerchPrice,
                quantity = i.Value
            });
            TempData.Keep();
            return View(viewMod);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrder(IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                int stoID = Convert.ToInt32(TempData["StoID"]);
                int custID = Convert.ToInt32(TempData["CustID"]);
                lib.Store sto = irepOrigSto.GetStores(stoID).First();
                lib.Customer cust = irepOrigCust.GetCustomers(cusid: custID).First();
                lib.Order ord = new lib.Order(cust, sto, 0);
                irepOrig.Order(ord);
                irepOrig.EndMe();
                ord = irepOrig.GetOrdersByCust(custID).Last();
                foreach (var item in collection)
                {
                    foreach (var iven in sto.iven)
                    {
                        /*var a = irepOrigMerch.GetMerch(iven.Key.MerchID).First();
                        ord.details.Add(a, Convert.ToInt32(item.Value));*/
                        try
                        {
                            if(iven.Key.MerchID == Convert.ToInt32(item.Key))
                            {
                                var a = irepOrigMerch.GetMerch(iven.Key.MerchID).First();
                                ord.details.Add(a, Convert.ToInt32(item.Value));
                                break;
                            }
                            
                        }
                        catch
                        {

                        }
                    }
                }
                foreach (var item in ord.details)
                {
                    sto.ChangeStock(item.Key, -1 * item.Value);
                }
                irepOrig.AddOrder(ord);
                TempData.Keep();
                irepOrigSto.UpdateStore(sto);
                irepOrigSto.help();
                irepOrig.EndMe();
                return RedirectToAction(nameof(EndOrder));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult EndOrder()
        {
            decimal btotal = 0;
            int custID = Convert.ToInt32(TempData["CustID"]);
            lib.Order ord = irepOrig.GetOrdersByCust(custID).Last();
            foreach (var item in ord.details)
            {
                btotal += item.Key.MerchPrice * item.Value;
            }
            var viewMod = ord.details.Select(i => new Models.EndOrderViewMod
            {
                merchID = i.Key.MerchID,
                merchName = i.Key.MerchName,
                merchPrice = i.Key.MerchPrice,
                quantity = i.Value,
                total = i.Key.MerchPrice * i.Value
            });
            ViewData["BigTotal"] = btotal;
            return View(viewMod);
        }

        // POST: Order/Delete/5
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