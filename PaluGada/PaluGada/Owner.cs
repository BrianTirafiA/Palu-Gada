using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaluGada
{
    public class Owner : users
    {
        public override void EditItem()
        {
            MessageBox.Show("Access Granted");
        }
    }
}
