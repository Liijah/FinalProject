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
        //Create list of customers to store registered customers
        private List<Customer> _customers = new List<Customer>();

        //Use constructor to create a new customer
        public void HandleRegistration()

        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter Contact: ");
            string contact = Console.ReadLine();
            Console.Write("Enter Username: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            // add the new customer to the list of customers (assuming we have a list to store customers)

            Customer newCustomer = new Customer(name, id, contact, userName, password);
            _customers.Add(newCustomer);
            
            Console.WriteLine("Registration successful!");



        }
    }
}
