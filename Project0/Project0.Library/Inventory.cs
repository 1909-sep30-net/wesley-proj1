

namespace Project0.Library
{
    public class Inventory
    {
        public int StockAmount { get; set; }

        public Merchandise merch { get; set; }

        public int Store { get; set; }

        public Inventory(int store, int stock = 0)
        {
            StockAmount = stock;
            Store = store;
        }
        
        /*public bool CheckInventory()
        {
            if (merch.CheckValidMerchAmount() == true)
                return true;
            else
                return false;
        }*/
    }
}
