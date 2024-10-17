using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaluGada
{
    class User
    {
        public int _userID;
        public string _username;
        public string _password;

        public int userID {  get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public void register(string username, string password)
        {
            //Logic register
        }

        public bool login(string username, string password) 
        {
            if (_username == username && _password == password)
            {
                Console.WriteLine("Login successful!");
                return true;
            }
            else
            {
                Console.WriteLine("Login failed. Invalid username or password.");
                return false;
            }
        }
    }
}
