using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonFinalApp
{

    // This class will handle the business logic of the banking application,
    // such as user registration, transactions, and account management. 
    public class BankingService
    {
        public void HandleRegistration()

        {
            Console.Write("Please enter a new username: ");
            string name = Console.ReadLine();
            Console.Write("Please set a password: ");
            string password = Console.ReadLine();

            Customer newCustomer = new Customer(name, password);

            // add the new customer to the list of customers (assuming we have a list to store customers)
            Customer.Add(newCustomer);

            Console.WriteLine("Registration successful!");



        }
    }
}
