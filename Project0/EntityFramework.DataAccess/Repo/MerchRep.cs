using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using lib = Project0.Library;
using Project0.Library.Repo;

namespace EntityFramework.DataAccess.Repo
{
    public class MerchRep : IMerchRep
    {
        private readonly Entities.Project0Context _context;

        public MerchRep(Entities.Project0Context dbcontext) =>
            _context = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));

        public IEnumerable<lib.Merchandise> GetMerch(int merch)
        {
            IQueryable<Entities.Merchandise> items = _context.Merchandise
                .Include(p => p.OrderDetails).AsNoTracking()
                .Include(p => p.Inventory)
                    .ThenInclude(i => i.Location);

            if (merch != 0)
                items = items.Where(p => p.Id == merch);

            return items.Select(Mapper.MapMerch);
        }

        public void Salvation()
        {
            _context.SaveChanges();
        }
    }
}
