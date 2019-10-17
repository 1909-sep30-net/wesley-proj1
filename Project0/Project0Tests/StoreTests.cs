using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Project0.Library;

namespace Project0Tests
{
    public class StoreTests
    {
        //private readonly TestVariables tvar = new TestVariables();
        // we need the connection string to connect to the database..
        // but it should not be uploaded to public github




        /*[Theory]
        [InlineData("123 Sesame Street", "Sesame", "SE", "12345")]
        [InlineData()]
        [InlineData()]
        public void DoesAddressWork(string a, string b, string c, string d)
        {
            //arrange
            Address k = new Address(a, b, c, d);

            //act


            //assert
        }*/

        /*[Theory]
        [InlineData("123 sesame st", "dallas", "TX", "1954")]
        [InlineData("aoqiwme", "Var", "VA", "9520")]
        [InlineData("cxedr", "Car", "CA", "8520025")]
        public void DoesCheckAddressTrueWork(string a, string b, string c, string d)
        {
            //arrange
            Address k;

            //act
            k = new Address(a, b, c, d);

            //assert
            Assert.True(k.CheckValidAddress());
        }

        [Theory]
        [InlineData(null, "dallas", "TX", "1954")]
        [InlineData("aoqiwme", null, "VA", "9520")]
        [InlineData("cxedr", "Car", null, "8520025")]
        [InlineData("zxcv", "qwer", "asdf", null)]
        public void DoesCheckAddressFalseWork(string a, string b, string c, string d)
        {
            //arrange
            Address k;

            //act
            k = new Address(a, b, c, d);

            //assert
            Assert.False(k.CheckValidAddress());
        }

        [Theory]
        [InlineData("123 sesame st", "dallas")]
        [InlineData("aoqiwme", "Var")]
        [InlineData("cxedr", "Car")]
        public void DoesCheckCustomerTrueWork(string a, string b)
        {
            //arrange
            Customer k;

            //act
            k = new Customer(a, b);

            //assert
            Assert.True(k.CheckValidCustomer());
        }

        [Theory]
        [InlineData(null, "abcd")]
        [InlineData("zxcv", null)]
        public void DoesCheckCustomerFalseWork(string a, string b)
        {
            //arrange
            Customer k;

            //act
            k = new Customer(a, b);

            //assert
            Assert.False(k.CheckValidCustomer());
        }*/

        /*[Theory]
        [InlineData(3.5)]
        [InlineData(4.8)]
        public void DoesCheckOrderTrueWork(double t)
        {
            //arrange
            Order k = tvar.GetOrder();

            //act
            k.Customer = tvar.GetCustomer();
            k.Store = tvar.GetStore();
            k.OrderTime = t;
            k.m = tvar.GetMerchandise();

            //assert values are valid
            Assert.True(k.Customer.CheckValidCustomer());
            Assert.True(k.Store.CheckStoreValid()) ;
            Assert.True(k.m.CheckValidMerchAmount());

            //assert order valid
            Assert.True(k.IsOrderValid());
        }

        [Theory]
        [InlineData(-1)]
        public void DoesCheckOrderFalseWork(double t)
        {
            //arrange
            Order k = tvar.GetOrder();

            //act
            k.Customer = tvar.GetCustomer();
            k.Store = tvar.GetStore();
            k.OrderTime = t;
            k.m = tvar.GetMerchandise();

            //assert values are valid
            Assert.True(k.Customer.CheckValidCustomer());
            Assert.True(k.Store.CheckStoreValid());
            Assert.True(k.m.CheckValidMerchAmount());

            //assert order valid
            Assert.False(k.IsOrderValid());
        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(9, 4, 5)]
        [InlineData(8, 3, 6)]
        public void DoesMerchValidTrueWork(int a, int b, int c)
        {
            //arrange
            Merchandise m = new Merchandise();

            //act
            m.aAmount = a;
            m.bAmount = b;
            m.cAmount = c;

            //assert
            Assert.True(m.CheckValidMerchAmount());
        }

        [Theory]
        [InlineData(-3, 2, 1)]
        [InlineData(9, -4, 5)]
        [InlineData(8, 3, -6)]
        public void DoesMerchValidFalseWork(int a, int b, int c)
        {
            //arrange
            Merchandise m = new Merchandise();

            //act
            m.aAmount = a;
            m.bAmount = b;
            m.cAmount = c;

            //assert
            Assert.False(m.CheckValidMerchAmount());
        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(9, 4, 5)]
        [InlineData(8, 3, 6)]
        public void DoesCheckInventoryTrueWork(int a, int b, int c)
        {
            //arrange
            Inventory i = new Inventory();

            //act
            i.merch.aAmount = a;
            i.merch.bAmount = b;
            i.merch.cAmount = c;

            //assert
            Assert.True(i.CheckInventory());
        }

        [Theory]
        [InlineData(-3, 2, 1)]
        [InlineData(9, -4, 5)]
        [InlineData(8, 3, -6)]
        public void DoesCheckInventoryFalseWork(int a, int b, int c)
        {
            //arrange
            Inventory i = new Inventory();

            //act
            i.merch.aAmount = a;
            i.merch.bAmount = b;
            i.merch.cAmount = c;

            //assert
            Assert.False(i.CheckInventory());
        }*/

       /* [Theory]
        [InlineData("123 sesame st", "abc", "ab", "12345")]
        [InlineData("231 sesame st", "bac", "ba", "21354")]
        [InlineData("321 sesame st", "cba", "ac", "52341")]
        public void DoesCheckStoreTrueWork(string a, string b, string c, string d)
        {
            //arrange
            Address k;
            Store x;
            Inventory i = tvar.GetInventory();

            //act
            k = new Address(a, b, c, d);
            x = new Store(k, i);

            //assert values true
            Assert.True(i.CheckInventory());
            Assert.True(k.CheckValidAddress());

            //assert store true
            Assert.True(x.CheckStoreValid());
        }

        [Theory]
        [InlineData(null, "abc", "ab", "12345")]
        [InlineData("231 sesame st", null, "ba", "21354")]
        [InlineData("321 sesame st", "cba", null, "52341")]
        [InlineData("312 sesame st", "cab", "cd", null)]
        public void DoesCheckStoreFalseWork(string a, string b, string c, string d)
        {
            //arrange
            Address k;
            Store x;
            Inventory i = new Inventory();

            //act
            k = new Address(a, b, c, d);
            i = tvar.GetInventory2();
            x = new Store(k, i);

            //assert values false
            Assert.False(i.CheckInventory());
            Assert.False(k.CheckValidAddress());

            //assert store false
            Assert.False(x.CheckStoreValid());
        }*/
    }
}
