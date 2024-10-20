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
    /// Interaction logic for ConfirmEmail.xaml
    /// </summary>
    public partial class ConfirmEmail : Page
    {
        public ConfirmEmail()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Signed in!");

            mainmenu mainMenuWindow = new mainmenu();

            mainMenuWindow.Show();

            Application.Current.MainWindow.Close();
        }
    }
}
