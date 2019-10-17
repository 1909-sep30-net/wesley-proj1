using EntityFramework.DataAccess.Entities;
using ef = EntityFramework.DataAccess.Repo;
using Microsoft.EntityFrameworkCore;
using lib = Project0.Library;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project0
{
    class Program
    {
        //shortcuts for VS
        //CTRL + K, CTRL + C for commenting lines
        //CTRL + K, CTRL + U for uncommenting lines
        //CTRL + K, CTRL + D for formatting documents
        //CTRL + Shift + B builds the solution
        //CTRL + F5 runs without debugging
        //<snippet name><TAB><TAB> for snippets like "prop" for property
        //  <TAB> to navigate between the fields of that snippet

        //shortcuts for VS Code
        // CTRL + / for comment and uncomment
        // Alt+Shift+F for formatting document

        //----------------------------------------------------------------

        // casting / type conversion
        //among numeric types, conversions that could lose any data
        //  must be explicit with casting operator ()
        //otherwise they can be implicit
        //with these numeric conversions, the actual bytes are being changed

        // int five = 5;
        //double otherFive = five;
        //int nextFive = (int)otherFive;

        // conversions when type heirarchies are concerned
        // var list = new List<int>();
        //object o = list; //implicit upcasting
        //List<int> listAgain = (List<int>)o //explicit downcasting
        //      "could fail" - InvalidCastException if that object is not already really a List<int>
        //IList<int> ilist = list;


        static void Main(string[] args)
        {
            //establish connection to database
            string connectionString = lib.SecretConfig.ConnectionString;

            var options = new DbContextOptionsBuilder<Project0Context>();
                options.UseSqlServer(connectionString);
            var dbContext = new Project0Context(options.Options);

            Run(dbContext);
        }

        public static void Run(Project0Context dbContext)
        {
            //establish contexts with domains
            var CusCon = new ef.CustomerRep(dbContext);
            var MerCon = new ef.MerchRep(dbContext);
            var StoCon = new ef.StoreRep(dbContext);
            var OrdCon = new ef.OrderRep(dbContext);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Manager\n");
                Console.WriteLine();

                Console.WriteLine("1:\tAdd a body");
                Console.WriteLine("2:\tStart a Search");
                Console.WriteLine("3:\tWant to Order Something?");
                Console.WriteLine("4:\tFare Thee Well");
                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                var input = Console.ReadLine();
                if(input == "1")
                {
                    string fname = null;
                    string lname = null;

                    Console.Clear();
                    Console.WriteLine("Adding a Customer\n");

                    while(fname == null)
                    {
                        Console.Write("Enter First name: ");
                        fname = Console.ReadLine();
                        if (fname == "")
                            fname = null;
                    }
                    while (lname == null)
                    {
                        Console.Write("Enter Last name: ");
                        lname = Console.ReadLine();
                        if (lname == "")
                            lname = null;
                    }
                    Console.WriteLine($"\nCreating a new Customer with \nFirst Name: {fname}\nLast Name: {lname}");

                    try
                    {
                        var newCus = new lib.Customer(fname, lname);
                        CusCon.AddCust(newCus);
                        CusCon.why();
                        var dbCusId = CusCon.GetCustomers(fname, lname).Last().CustomerID;
                        Console.WriteLine($"Customer has been added.\nID: {dbCusId}");

                        Console.WriteLine("Press a key to keep going");
                        Console.ReadKey();
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if(input == "2")
                {
                    while(true)
                    {
                        Console.Clear();
                        Console.WriteLine("Search for something Screen");

                        Console.WriteLine("1:\tSearch for Customer");
                        Console.WriteLine("2:\tSearch for Store");
                        Console.WriteLine("3:\tSearch for Orders for Customer");
                        Console.WriteLine("4:\tSearch for Orders for Store");
                        Console.WriteLine("5:\tSearch for Order Details");
                        Console.WriteLine("6:\tLet Me Out");
                        Console.WriteLine();

                        Console.WriteLine("What do you want to do?");
                        var input2 = Console.ReadLine();
                        if (input2 == "1")
                        {
                            string fnamesearch = null;
                            string lnamesearch = null;
                            Console.Clear();
                            Console.WriteLine("Searching for Customers\n");
                            Console.WriteLine("Give me a First Name to search for ");
                            Console.WriteLine("\tor you could give me no name: ");
                            fnamesearch = Console.ReadLine();
                            if (fnamesearch == null)
                                fnamesearch = null;

                            Console.WriteLine("Now give me a Last Name to search for ");
                            Console.WriteLine("\tor you can leave nothing here also: ");
                            lnamesearch = Console.ReadLine();
                            if (lnamesearch == null)
                                lnamesearch = null;
                            Console.WriteLine($"So, I am searching for {fnamesearch} {lnamesearch} right? Give me a second.");
                            Console.WriteLine();
                            var cusSearch = CusCon.GetCustomers(fnamesearch, lnamesearch).ToList();
                            foreach (lib.Customer item in cusSearch)
                            {
                                Console.WriteLine(item.ToString() + "\n");
                            }
                            Console.WriteLine("\nPress something to continue");
                            Console.ReadKey();
                        }
                        else if(input2 == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("Store: \n");
                            var sto = StoCon.GetStores().ToList();
                            foreach (lib.Store item in sto)
                            {
                                Console.WriteLine(item.ToString() + "\n");
                            }
                            Console.WriteLine("\nPunch a key to keep moving");
                            Console.ReadKey();
                        }
                        else if(input2 == "3")
                        {
                            string input2key;
                            int custId = 0;
                            bool isInt = false;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Display All Orders for a Customer\n");

                                Console.Write("Enter a Customer ID: ");
                                input2key = Console.ReadLine();
                                isInt = Int32.TryParse(input2key, out custId);
                            }
                            while (!isInt);

                            var results = OrdCon.GetOrdersByCust(id: custId).ToList();
                            if (results.Count > 0)
                            {
                                foreach (lib.Order ord in results)
                                {
                                    Console.WriteLine(ord.ToString() + "\n");
                                }
                            }
                            else
                                Console.WriteLine($"No results matching CustomerID {custId}");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                        }
                        else if (input2 == "4")
                        {
                            string input2key;
                            int stoId = 0;
                            bool isInt = false;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Display All Orders for a Location\n");

                                Console.Write("Enter a Location ID: ");
                                input2key = Console.ReadLine();
                                isInt = Int32.TryParse(input2key, out stoId);
                            }
                            while (!isInt);

                            var results = OrdCon.GetOrdersByStore(stoId).ToList();
                            if (results.Count > 0)
                            {
                                foreach (lib.Order ord in results)
                                {
                                    Console.WriteLine(ord.ToString() + "\n");
                                }
                            }
                            else
                                Console.WriteLine($"No results matching LocationID {stoId}");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();

                        }
                        else if (input2 == "5")
                        {
                            string input2key;
                            string ordId = null;
                            bool isInt = false;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Display Details of an Order:\n");

                                Console.Write("Enter a Order ID: ");
                                input2key = Console.ReadLine();
                                ordId = input2key;
                            }
                            while (!isInt);

                            var result = OrdCon.GetOrdersByName(ordId).ToList().FirstOrDefault();
                            if (result == null)
                            {
                                Console.WriteLine($"No results matching OrderID {ordId}");
                            }
                            else
                            {
                                Console.WriteLine(result.ToString());
                                Console.WriteLine(result.OrderToString());
                            }
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();

                        }
                        else if (input2 == "6")
                        {
                            break;
                        }
                    }
                }
                else if(input == "3")
                {
                    string inputStr;
                    int custId = 0;
                    int stoId = 0;
                    bool isInt = false;


                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Place an Order Menu\n");

                        Console.Write("Enter a Customer ID: ");
                        inputStr = Console.ReadLine();
                        isInt = Int32.TryParse(inputStr, out custId);
                    }
                    while (!isInt);

                    var cust = CusCon.GetCustomers(cusid: custId).FirstOrDefault();

                    if (cust == null)
                    {
                        Console.WriteLine($"Customer {custId} does not exist.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Customer found:\n");
                        Console.WriteLine(cust.ToString());
                    }

                    isInt = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Place an Order Menu\n");

                        Console.WriteLine($"Enter a Customer ID: {custId}");
                        Console.WriteLine("Customer found:\n");
                        Console.WriteLine(cust.ToString());

                        Console.Write("Enter a Location ID: ");
                        inputStr = Console.ReadLine();
                        isInt = Int32.TryParse(inputStr, out stoId);
                    }
                    while (!isInt);

                    var loc = StoCon.GetStores(stoId).FirstOrDefault();
                    if (loc == null)
                    {
                        Console.WriteLine($"Store {stoId} does not exist.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Store found:\n");
                        Console.WriteLine(loc.ToString());
                    }
                    bool abort = false;
                    do
                    {
                        Console.Write("Would you like to continue? (YES/NO): ");
                        string answer = Console.ReadLine();
                        if (answer.ToUpper() == "YES")
                        {
                            /*Console.WriteLine("dirt");
                            Console.WriteLine("animal");
                            Console.WriteLine("box");
                            Console.WriteLine();
                            Console.WriteLine("What item do you want to order");
                            mName = Console.ReadLine();*/
                            break;
                        }
                        else if (answer.ToUpper() == "NO")
                        {
                            abort = true;
                        }
                    }
                    while (!abort);

                    if (!abort)
                    {

                        try
                        {
                            var ord = new lib.Order(cust, loc, 0);
                            /*OrdCon.Order(ord);
                            OrdCon.EndMe();*/
                            //var ord = OrdCon.GetOrdersByCust(cust.CustomerID).Last();


                            string merch = null;

                            bool done = false;
                            do
                            {
                                do
                                {
                                    //merch = null;

                                    Console.Clear();
                                    Console.WriteLine("Place an Order Menu\n");
                                    Console.WriteLine($"Customer:\n{cust.ToString()}");
                                    Console.WriteLine($"Store:\n{loc.ToString()}");
                                    Console.WriteLine();
                                    Console.WriteLine("Store inventory:");
                                    Console.WriteLine(loc.InventoryToString());
                                    Console.WriteLine();
                                    Console.WriteLine("Your order:");
                                    Console.WriteLine(ord.OrderToString());

                                    Console.Write("Enter a Product name, or DONE if finished: ");
                                    inputStr = Console.ReadLine();
                                    if (inputStr.ToUpper() == "DONE")
                                    {
                                        done = true;
                                        isInt = true;
                                    }
                                    else
                                    {
                                        merch = inputStr;
                                    }
                                }
                                while (!isInt);
                                if (!done)
                                {
                                    var prod = MerCon.GetMerch(merch: merch).FirstOrDefault();
                                    if (prod == null)
                                    {
                                        Console.WriteLine($"Merch {merch} does not exist");
                                        Console.WriteLine("\nPress any key to continue.");
                                        Console.ReadKey();
                                    }
                                    /*else if (!loc.FindItemById(prodId))
                                    {
                                        Console.WriteLine($"Merch {prodId} is not in this location's inventory");
                                        Console.WriteLine("\nPress any key to continue.");
                                        Console.ReadKey();
                                    }*/
                                    else
                                    {
                                        bool isIntQuantity = false;
                                        int quantity = 0;
                                        do
                                        {
                                            Console.Write("Enter a quanity: ");
                                            inputStr = Console.ReadLine();
                                            isIntQuantity = Int32.TryParse(inputStr, out quantity);

                                        }
                                        while (!isIntQuantity);
                                        if (loc.ChangeStock(prod, -1 * quantity))
                                        {
                                            ord.details.Add(prod, quantity);
                                            Console.WriteLine($"Added {quantity} {prod.MerchName}s to Order.");
                                            Console.WriteLine("\nPress any key to continue.");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                                ord = new lib.Order(cust, loc, 0, DateTime.Now, merch);
                                OrdCon.Order(ord);
                            }
                            while (!done);
                            OrdCon.AddOrder(ord);
                            OrdCon.EndMe();

                            Console.Clear();
                            Console.WriteLine($"Order Complete.\n");
                            Console.WriteLine(ord.ToString());
                            Console.WriteLine(ord.OrderToString());
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine(ex.Message);
                            
                        }
                    }
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                }
                else if(input == "4")
                {
                    Console.WriteLine("Alright, See you next time");
                    Console.WriteLine("\n Press any key to leave");
                    Console.ReadKey();
                    break;
                }
            }
        }

        /*public void Menu()
        {
            *//*string quit;
            int menu = 0;
            Console.WriteLine("Welcome to Stores Store");
            Console.WriteLine("What you want");
            Console.WriteLine("1. Place order");
            Console.WriteLine("2. Add Customer");
            Console.WriteLine("3. Add Store");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-----------------------");

            do
            {
                Console.WriteLine("Enter a number between 1 and 4 or q to quit");
                quit = Console.ReadLine();
                if(quit != "q")
                {
                    menu = Int32.Parse(quit);
                    if (menu < 1 || menu > 4)
                    {
                        Console.WriteLine("input must be between 1 and 4");
                    }
                }
            } while (menu < 1 || menu > 4 || quit != "q");

            switch (menu)
            {
                //place order
                case 1:
                    PlaceOrder();
                    break;

                //customer info
                case 2:
                    AddCustomer();
                    break;

                //Store info and inventory
                case 3:
                    StoreInfo();
                    break;
                default:
                    Console.WriteLine("Please come again soon.");
                    break;
            }*//*
        }

        public void PlaceOrder()
        {
            *//*int merch = 0;
            string quit;
            double time = 0;
            string box = "box", hat = "hat", shoe = "shoe";
            double bp = 3.20, hp = 5.90, sp = 1.50;
            Console.WriteLine("The products we have are: ");
            Console.WriteLine("1. Box at $3.20");
            Console.WriteLine("2. Hat at $5.90");
            Console.WriteLine("3. Shoe at $1.50");
            Merchandise b = new Merchandise(box, bp);
            Merchandise h = new Merchandise(hat, hp);
            Merchandise s = new Merchandise(shoe, sp);
            List<Merchandise> merchList = new List<Merchandise>();

            do
            {
                Console.WriteLine("Enter a number between 1 and 3 or q to quit");
                quit = Console.ReadLine();
                if(quit != "q")
                {
                    merch = Int32.Parse(quit);
                    if (merch < 1 || merch > 3)
                    {
                        Console.WriteLine("input not between 1 and 3");
                    }
                }
            } while (merch < 1 || merch > 3 || quit != "q");

            switch (merch)
            {
                case 1:
                    merchList.Add(b);
                    break;
                case 2:
                    merchList.Add(h);
                    break;
                case 3:
                    merchList.Add(s);
                    time = Convert.ToDouble(Stopwatch.GetTimestamp());
                    break;
                default:
                    Console.WriteLine("no order placed");
                    break;
            }

            a = new Order(customer, k, time, merchList);
            Console.Clear();
            Menu();*//*
        }

        public void AddCustomer()
        {
           *//* string FirstName, LastName;//, CustStreet, CustCity, CustState, CustZip;

            Console.WriteLine("Enter First Name of Customer: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name of Customer: ");
            LastName = Console.ReadLine();
            *//*Console.WriteLine("Enter Street of Customer Address");
            CustStreet = Console.ReadLine();
            Console.WriteLine("Enter City of Customer Address");
            CustCity = Console.ReadLine();
            Console.WriteLine("Enter State of Customer Address");
            CustState = Console.ReadLine();
            Console.WriteLine("Enter Zip of Customer Address");
            CustZip = Console.ReadLine();*/

        /* Address CustAddress = new Address(CustStreet, CustCity, CustState, CustZip);*/
        /*Customer customer = new Customer(FirstName, LastName, CustAddress);*//*
        customer = new Customer(FirstName, LastName);

       *//* Console.Clear();
        Menu();*/
    }

       /* public void StoreInfo()
        {

            *//*string name;
            int num ;

            Console.WriteLine("What is the Store name?");
            name = Console.ReadLine();
            Console.WriteLine("What is the Store number?");
            num = Int32.Parse(Console.ReadLine());

            k = new Store(name, num);*/
            /*string StoreStreet, StoreCity, StoreState, StoreZip;
            Merchandise m;
            List<Merchandise> n = new List<Merchandise>();
            string merchName;
            double merchPrice;
            string q = null;

            Console.WriteLine("Enter Street of Store Address");
            StoreStreet = Console.ReadLine();
            Console.WriteLine("Enter City of Store Address");
            StoreCity = Console.ReadLine();
            Console.WriteLine("Enter State of Store Address");
            StoreState = Console.ReadLine();
            Console.WriteLine("Enter Zip of Store Address");
            StoreZip = Console.ReadLine();

            while (q != "q")
            {
                Console.WriteLine("Enter Product Name");
                merchName = Console.ReadLine();
                Console.WriteLine("Enter Product Price");
                merchPrice = Convert.ToDouble(Console.ReadLine());
                m = new Merchandise(merchName, merchPrice);
                n.Add(m);
                Console.WriteLine("Type q to quit");
                q = Console.ReadLine();
            }
            Address StoreAddress = new Address(StoreStreet, StoreCity, StoreState, StoreZip);
            Inventory c = new Inventory(n);
            Store store = new Store(StoreAddress, c);*//*
        }*/
}
