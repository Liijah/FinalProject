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

        public string Name { get; private set; }
        public string CustomerID { get; private set; }
        public string ContactInfo { get; private set; }

        // login credentials and customer information will be stored.

        public string UserName { get; private set; }
        public string PassWord { get; private set; }

        //Constructor
        public Customer(string name, string customerID, string contactInfo, string userName, string passWord)
        {
            Name = name;
            CustomerID = customerID;
            ContactInfo = contactInfo;
            UserName = userName;
            PassWord = passWord;
        }
        
       
        

    }//End of Class Customer
}//End of Namespace
