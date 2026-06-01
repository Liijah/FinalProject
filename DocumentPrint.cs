using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonFinalApp
{
    public class DocumentPrint
    {
        public void PrintStatement(Customer customer)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("      OFFICIAL ACCOUNT PROOF      ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Customer Name: {customer.Name}");
            Console.WriteLine($"Customer ID:   {customer.CustomerID}");
            Console.WriteLine($"Date Issued:   {DateTime.Now.ToShortDateString()}");
            Console.WriteLine($"Current Balance: {customer.AccountBalance:C}"); // :C formats as currency
            Console.WriteLine("----------------------------------");
            Console.WriteLine("     End of Statement Record      ");



        }
    }
}
