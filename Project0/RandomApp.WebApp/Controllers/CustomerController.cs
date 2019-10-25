using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project0.Library.Repo;
using RandomApp.WebApp.Models;

namespace RandomApp.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRep irepOrig;
        public CustomerController(ICustomerRep irep)
        {
            irepOrig = irep;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var LC = irepOrig.GetCustomers();
            return View(LC);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var cust = irepOrig.GetCustomers();
            var custMod = new CustomerMod
            {
                //FirstName = cust.Select(c => c.FristName).First(),
                //LastName = cust.Select(c => c.LsatName).First()
            };
            return View(custMod);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var cust = irepOrig.GetCustomers();
            var custMod = new CustomerMod
            {
                //FirstName = cust.Select(c => c.FristName).First(),
                //LastName = cust.Select(c => c.LsatName).First()
            };
            return View(custMod);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerMod custMod)
        {
            try
            {
                // TODO: Add insert logic here
                if(!ModelState.IsValid)
                {
                    var cust = irepOrig.GetCustomers();
                    custMod.FirstName = cust.Select(c => c.FristName).First();
                    custMod.LastName = cust.Select(c => c.LsatName).First();
                    return View(custMod);
                }
                Project0.Library.Customer tempcust = new Project0.Library.Customer(custMod.FirstName, custMod.LastName);
                irepOrig.AddCust(tempcust);
                irepOrig.why();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var cust = irepOrig.GetCustomers();
                custMod.FirstName = cust.Select(c => c.FristName).First();
                custMod.LastName = cust.Select(c => c.LsatName).First();
                return View(custMod);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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