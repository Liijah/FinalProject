using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonFinalApp
{// This class represents a customer in the banking application.
 // It contains properties for customer information, login credentials, and methods for customer actions such as viewing account details
    public class Customer
    {   //Properties

        public string Name { get; set; }
        public string CustomerID { get; set; }
        public string ContactInfo { get; set; }

        // login credentials and customer information will be stored.

        public string UserName { get; set; }
        public string PassWord { get; private set; }

        //Account balance

        public decimal AccountBalance { get; set; }

        //Register time for the customer
        public DateTime RegistrationDate { get; private set; }

        //Constructor
        public Customer(string name, string customerID, string contactInfo, string userName, string passWord)
        {
            Name = name;
            CustomerID = customerID;
            ContactInfo = contactInfo;
            UserName = userName;
            PassWord = passWord;
            AccountBalance = 0.0m; // Initial account balance is set to 0
            RegistrationDate = DateTime.Now; // Set registration date to current date and time
        }

        // Method to verify the customer's password during login
        public bool VerifyPassword(string input)
        {
            
            return this.PassWord == input;
        }



    }//End of Class Customer
}//End of Namespace
