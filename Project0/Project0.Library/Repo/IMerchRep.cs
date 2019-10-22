using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library.Repo
{
    public interface IMerchRep
    {
        public IEnumerable<Merchandise> GetMerch(int merch);

        public void Salvation();
    }
}
