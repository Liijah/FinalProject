using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonFinalApp
{
    public class Customer
    {   //Properties

        public string Name { get; set; }
        public string CustomerID { get; set; }
        public string ContactInfo { get; set; }

        // login credentials and customer information will be stored.

        public string UserName { get; set; }
        public string PassWord { get; set; }

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
