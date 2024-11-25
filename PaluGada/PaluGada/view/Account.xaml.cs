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

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            ConfirmationLO confirmation = new ConfirmationLO();
            Application.Current.MainWindow = confirmation;
            confirmation.Show();
        }

        private void EditAcc_Click(object sender, RoutedEventArgs e)
        {
            EditAcc edit = new EditAcc();
            Application.Current.MainWindow = edit;
            edit.Show();
        }

    }
}
