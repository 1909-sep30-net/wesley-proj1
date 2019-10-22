using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library.Repo
{
    public interface IStoreRep
    {
        public IEnumerable<Store> GetStores(int id = -1);

        public void UpdateStore(Store targetStore);

        public void help();
    }
}
