using System;
using System.Collections.Generic;
using System.Text;

namespace mysocietywebsite.Resource.ViewModel
{
    public class UserCredential
    {

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
