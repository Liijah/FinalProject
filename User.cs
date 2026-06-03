

        #nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SkeletonFinalApp
    {

    //create a base class User to hold common properties
    //and methods for both Customer and Admin
    public class User
        {
            //Fields - shared between Customer and Admin
            public string Name { get; protected set; }
            public string UserName { get; protected set; }
            protected string _password;

            //Constructor
            public User(string name, string userName, string password)
            {
                Name = name;
                UserName = userName;
                _password = password;
            }

            // Shared method - both Customer and Admin need to verify password
            public bool VerifyPassword(string inputPassword)
            {
                return _password == inputPassword;
            }//End of VerifyPassword method

        }//End of Class User
    }//End of Namespace

