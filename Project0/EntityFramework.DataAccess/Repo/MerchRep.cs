using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using lib = Project0.Library;

namespace EntityFramework.DataAccess.Repo
{
    public class MerchRep
    {
        private readonly Entities.Project0Context _context;

        public MerchRep(Entities.Project0Context dbcontext) =>
            _context = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));

        public IEnumerable<lib.Merchandise> GetMerch(string merch)
        {
            IQueryable<Entities.Product> items = _context.Product
                .Include(p => p.OrderDetails).AsNoTracking()
                .Include(p => p.Inventory)
                    .ThenInclude(i => i.Location);

            if (merch != null)
                items = items.Where(p => p.Name == merch);

            return items.Select(Mapper.MapMerch);
        }

        public void Salvation()
        {
            _context.SaveChanges();
        }
    }
}
