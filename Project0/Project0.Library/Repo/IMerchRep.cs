using System.Collections.Generic;

namespace Project0.Library.Repo
{
    public interface IMerchRep
    {
        public IEnumerable<Merchandise> GetMerch(int merch);

        public void Salvation();
    }
}
