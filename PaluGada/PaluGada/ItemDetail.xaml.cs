using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaluGada
{
    /// <summary>
    /// Interaction logic for ItemDetail.xaml
    /// </summary>
    public partial class ItemDetail : Page
    {
        //users user1 = new users();
        users user1 = new Owner();
        public ItemDetail()
        {
            InitializeComponent();
        }

        private void editItem()
        {
            user1.EditItem();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            editItem();
        }
    }
}
