using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project0.Library.Repo;

namespace RandomApp.WebApp.Controllers
{
    public class SearchStoreController : Controller
    {
        private readonly IOrderRep irepOrig;
        private readonly ICustomerRep irepOrigCust;
        private readonly IStoreRep irepOrigSto;
        private readonly IMerchRep irepOrigMerch;
        public SearchStoreController(IOrderRep irep, ICustomerRep irepCust, IStoreRep irepSto, IMerchRep irepMerch)
        {
            irepOrig = irep;
            irepOrigCust = irepCust;
            irepOrigSto = irepSto;
            irepOrigMerch = irepMerch;
        }
        // GET: SearchStore
        public ActionResult Index()
        {
            var sto = irepOrigSto.GetStores().ToList();
            var viewMod = sto.Select(s => new Models.StoreMod
            {
                ID = s.StoreID,
                Loc = s.Loc
            });
            return View(viewMod);
        }

        // GET: SearchStore/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SearchStore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchStore/Create
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

        // GET: SearchStore/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearchStore/Edit/5
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

        // GET: SearchStore/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SearchStore/Delete/5
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