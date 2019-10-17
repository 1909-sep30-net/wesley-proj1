using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private int ID;

        public string FristName
        {
            get { return firstName; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Do not give me null or emptiness please.");
                else if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("I require a first name that is less than 50 characters");
                else
                    firstName = value;
            }
        }

        public string LsatName
        {
            get { return lastName; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("I asked you not to give me null or emptiness");
                else if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Please give me a last name that is less than 50 characters");
                else
                    lastName = value;
            }
        }

        public string FullName
        {
            get { return firstName + " " + lastName; }
        }

        public int CustomerID
        {
            get { return ID; }
            /*set
            {
                ID = value;
            }*/
        }

        public Customer(string fName, string lName, int custID = 0)
        {
            //SetName(firstName, lastName);
            firstName = fName;
            lastName = lName;
            ID = custID;
        }

        public override string ToString()
        {
            return $"\tID:{CustomerID} \n\tFIRST NAME: {firstName} \n\tLAST NAME: {lastName}";
        }

        /* public string GetName()
         {
             return firstName + " " + lastName;
         }*/

        /*public void SetName(string firstName, string lastName)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException(nameof(firstName));
            }
            else if (lastName == null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }
            this.firstName = firstName;
            this.lastName = lastName;
        }*/
        /* public Address Getaddress()
         {
             return address;
         }

         public void SetAddress(Address customerAddress)
         {
             if (address == null)
             {
                 throw new ArgumentNullException(nameof(address));
             }
             this.address = customerAddress;
         }*/

        public bool CheckValidCustomer()
        {
            if (firstName != null && lastName != null)
                return true;
            else
                return false;
        }
    }
}
