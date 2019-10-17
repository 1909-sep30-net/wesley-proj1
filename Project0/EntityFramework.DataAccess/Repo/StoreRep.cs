using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using lib = Project0.Library;

namespace EntityFramework.DataAccess.Repo
{
    public class StoreRep
    {
        private readonly Entities.Project0Context _context;

        public StoreRep(Entities.Project0Context dbContext) =>
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<lib.Store> GetStores(int id = -1)
        {
            IQueryable<Entities.Store> sto = _context.Store
                .Include(s => s.Inventory)
                    .ThenInclude(i => i.NameNavigation)
                .Include(s => s.OrderInfo);

            if (id != -1)
                sto = sto.Where(s => s.Id == id);
            

            return sto.Select(Mapper.MapStore);
        }

        public void help()
        {
            _context.SaveChanges();
        }
    }
}
