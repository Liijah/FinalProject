using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonFinalApp
{
    public class Admin
    {

        //Fields
       
            public string UserName { get; private set; }
            private string _password;

            public Admin(string username, string password)
            {
                UserName = username;
                _password = password;
            }

            public bool VerifyPassword(string inputPassword)
            {
                return _password == inputPassword;
            }
        }


    }//End of Class Admin
}//End of Namespace
