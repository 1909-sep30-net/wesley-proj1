using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using lib = Project0.Library;
using Project0.Library.Repo;

namespace EntityFramework.DataAccess.Repo
{
    public class StoreRep : IStoreRep
    {
        private readonly Entities.Project0Context _context;

        public StoreRep(Entities.Project0Context dbContext) =>
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<lib.Store> GetStores(int id = -1)
        {
            IQueryable<Entities.Store> sto = _context.Store
                .Include(s => s.Inventory)
                    .ThenInclude(i => i.Merch)
                .Include(s => s.OrderInfo);

            if (id != -1)
                sto = sto.Where(s => s.Id == id);


            return sto.Select(Mapper.MapStore);
        }

        public void UpdateStore(lib.Store targetStore)
        {
            /*Entities.Store dbStore = Mapper.MapStore(GetStores().First(s => s.StoreID == targetStore.StoreID));

            if (dbStore != null)
            {
                dbStore.Id = targetStore.StoreID;
                foreach (var item in targetStore.iven.Keys)
                {
                    
                    
                }
            }
                //_context.Entry(dbStore).CurrentValues.SetValues(targetStore);*/
            Entities.Store sto = _context.Store
                .Include(s => s.Inventory)
                .FirstOrDefault(s => s.Id == targetStore.StoreID);

            foreach (Entities.Inventory item in sto.Inventory)
            {
                item.Stock = targetStore.iven.Where(i => i.Key.MerchID == item.MerchId).FirstOrDefault().Value;
            }
        }

        public void help()
        {
            _context.SaveChanges();
        }
    }
}
