using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonFinalApp
{   
    // This class represents a customer in the banking application.
    // It contains properties for customer information, login credentials, and methods for customer actions such as viewing account details
    public class Customer : User // Inherits from the User Class
    {   
        //Properties
        public string CustomerID { get; private set; }
        public string Contact { get; private set; }
        public decimal AccountBalance { get; private set; }


        //Constructor - passes shared fields up to User and initializes customer-specific fields
        public Customer(string name, string customerID, string contact, string userName, string password)
            : base(name, userName, password)  // calls User constructor
        {
            CustomerID = customerID;
            Contact = contact;
            AccountBalance = 0; // new customers start with a balance of 0
        }

        // Override GetRole to return "Customer"
        // In practice, admin and customer apps are usually separate,
        // but this demonstrates polymorphism through method overriding
        public override string GetRole()
        {
            return "Customer";
        }//End of GetRole method



        //Update Contact - for Admin to update customer contact information
        public void UpdateContact(string newContact)
        {
            // Check if the new contact information is not null or empty before updating
            if (!string.IsNullOrEmpty(newContact))
                Contact = newContact.Trim();

        }//End of UpdateContact method

        //Deposit method to allow customers to add funds to their account balance. It takes a decimal amount as a parameter and adds it to the AccountBalance if the amount is greater than 0.
        public void Deposit(decimal amount)
        {
            if (amount > 0)
                AccountBalance += amount;

        }//End of Deposit method

        //Withdraw method to allow customers to remove funds from their account balance. It takes a decimal amount as a parameter and subtracts it from the AccountBalance if the amount is greater than 0 and less than or equal to the current balance.
        public bool Withdraw(decimal amount)
        {
            // Check if the withdrawal amount is valid
            if (amount <= 0 || amount > AccountBalance)
                return false;

            // Subtract the amount from the account balance
            AccountBalance -= amount;
            return true;

        }//End of Withdraw method

    }//End of Class Customer
}//End of Namespace
