using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaluGada
{
    public class users
    {
        protected string username;
        protected string password;
        protected string email;

        public virtual void EditItem()
        {
            MessageBox.Show("No Access");
        }
    } 
}
