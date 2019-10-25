using System;

namespace Project0.Library
{
    public class Customer
    {
        private string firstName;
        private string lastName;

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

        public int CustomerID { get; }

        public Customer(string fName, string lName, int custID = 0)
        {
            firstName = fName;
            lastName = lName;
            CustomerID = custID;
        }

        public override string ToString()
        {
            return $"\tID:{CustomerID} \n\tFIRST NAME: {firstName} \n\tLAST NAME: {lastName}";
        }

        public bool CheckValidCustomer()
        {
            if (firstName != null && lastName != null)
                return true;
            else
                return false;
        }
    }
}
