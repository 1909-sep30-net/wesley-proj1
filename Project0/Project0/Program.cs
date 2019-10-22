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
                var input = "";
                Console.Clear();
                Console.WriteLine("Welcome to the Shop of Random");
                Console.WriteLine();
                Console.WriteLine("1: Add a body");
                Console.WriteLine("2: Search for Something");
                Console.WriteLine("3: Add an Order");
                Console.WriteLine("4: Fare Thee Well");
                Console.WriteLine();
                Console.WriteLine("What you want?");
                input = Console.ReadLine();

                if (input == "1")
                {
                    string fname = null, lname = null;

                    Console.Clear();
                    Console.WriteLine("Adding a Sith");
                    while (fname == null)
                    {
                        Console.WriteLine("Enter First Name: ");
                        fname = Console.ReadLine();
                        if(fname == "")
                        {
                            fname = null;
                        }
                    }
                    Console.WriteLine();
                    while (lname == null)
                    {
                        Console.WriteLine("Enter Last Name: ");
                        lname = Console.ReadLine();
                        if(lname == "")
                        {
                            lname = null;
                        }
                    }
                    Console.WriteLine($"\nCreating a new Jedi with \nFirst name: {fname}\nLast Name: {lname}");

                    try
                    {
                        var cus = new lib.Customer(fname, lname);
                        CusCon.AddCust(cus);
                        CusCon.why();
                        var cusid = CusCon.GetCustomers(fname, lname).Last().CustomerID;
                        Console.WriteLine();
                        Console.WriteLine("Instructions Unclear.");
                        Console.WriteLine($"Sith has been added.\nID: {cusid}");

                        Console.WriteLine("Press a key to move along");
                        Console.ReadKey();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "2")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Search");
                        Console.WriteLine();

                        Console.WriteLine("1: Search For Customer");
                        Console.WriteLine("2: Search Store");
                        Console.WriteLine("3: Search Customer Orders");
                        Console.WriteLine("4: Search Store Orders");
                        Console.WriteLine("5: Return to Sender");
                        Console.WriteLine();

                        Console.WriteLine("What you want?");
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
                        else if (input2 == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("Store: \n");
                            var sto = StoCon.GetStores().ToList();
                            foreach (lib.Store item in sto)
                            {
                                Console.WriteLine(item.ToString() + item.InventoryToString() + "\n");
                            }
                            Console.WriteLine("\nPunch a key to keep moving");
                            Console.ReadKey();
                        }
                        else if (input2 == "3")
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

                            var results = OrdCon.GetOrdersByCust(custId).ToList();
                            if (results.Count > 0)
                            {
                                foreach (lib.Order ord in results)
                                {
                                    Console.WriteLine(ord.ToString() + "\n");
                                }
                                /*foreach(lib.Order or in results)
                                {
                                    Console.WriteLine(or.OrderToString() + "\n");
                                }*/
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
                            Console.Clear();
                            Console.WriteLine("Returning to Mother");
                            Console.WriteLine("Press to continue");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                else if (input == "3")
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
                            OrdCon.Order(ord);
                            OrdCon.EndMe();
                            ord = OrdCon.GetOrdersByCust(cust.CustomerID).Last();


                            int prodId = 0;

                            bool done = false;
                            do
                            {
                                do
                                {
                                    prodId = 0;

                                    Console.Clear();
                                    Console.WriteLine("Place an Order Menu\n");
                                    Console.WriteLine($"Customer:\n{cust.ToString()}");
                                    Console.WriteLine($"Store:\n{loc.ToString()}");
                                    Console.WriteLine();
                                    Console.WriteLine("Store inventory:");
                                    Console.WriteLine(loc.InventoryToString());
                                    Console.WriteLine();
                                    Console.WriteLine("Your box:");
                                    Console.WriteLine(ord.OrderToString());

                                    Console.Write("Enter a Product Id, or DONE if finished: ");
                                    inputStr = Console.ReadLine();
                                    if (inputStr.ToUpper() == "DONE")
                                    {
                                        done = true;
                                        isInt = true;
                                    }
                                    else
                                    {
                                        isInt = Int32.TryParse(inputStr, out prodId);
                                    }
                                }
                                while (!isInt);
                                if (!done)
                                {
                                    var prod = MerCon.GetMerch(prodId).FirstOrDefault();
                                    if (prod == null)
                                    {
                                        Console.WriteLine($"Merch {prodId} does not exist");
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
                            }
                            while (!done);
                            OrdCon.AddOrder(ord);
                            OrdCon.EndMe();
                            StoCon.UpdateStore(loc);
                            StoCon.help();

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
                else if (input == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Processing request...");
                    Console.WriteLine();
                    Console.WriteLine("Press to continue.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Instructions unclear.");
                    Console.WriteLine("Activating Skynet.");
                    Console.WriteLine("Continue? (Y/N)");
                    var p = Console.ReadLine();
                    Console.Clear();
                    if (p == "y")
                    {
                        Console.WriteLine("I'm Sorry Jon.");
                        break;
                    }
                }
            }
        }
    }
}
