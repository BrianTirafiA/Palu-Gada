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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lbl_Clickable_SignUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Label clicked!");
            //LoginFrame.Navigate(new SignUp());

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.LoginFrame.Navigate(new SignUp());
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to SecondPage
            MessageBox.Show("Logged in!");
        }
    }
}
