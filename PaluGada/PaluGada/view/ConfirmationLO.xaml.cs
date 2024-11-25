using PaluGada.model;
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
using System.Windows.Shapes;

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for ConfirmationLO.xaml
    /// </summary>
    public partial class ConfirmationLO : Window
    {
        MainMenu creatingForm;
        public ConfirmationLO()
        {
            InitializeComponent();
        }

        private void yesbtn(object sender, RoutedEventArgs e)
        {
            // Reset session data to log out the current user
            Session.ResetSession();

            foreach (Window w in Application.Current.Windows)
            {
                // Check if creatingForm exists and close it
                if (creatingForm != null)
                {
                    creatingForm.Close();
                    creatingForm = new MainMenu();
                }
            }

            // Navigate to MainWindow (Login screen)
            MainWindow login = new MainWindow();
            Application.Current.MainWindow = login;
            login.Show();

            // Close the current confirmation window
            this.Close();
        }


        private void nobtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
