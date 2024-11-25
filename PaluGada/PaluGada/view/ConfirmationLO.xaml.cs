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

            if (creatingForm != null)
            {
                creatingForm.Close();
                creatingForm = new MainMenu();
                //How ever you are passing information to the secondWindow
            }

            MainWindow login = new MainWindow();
            Application.Current.MainWindow = login;
            login.Show();
            this.Close();

        }

        private void nobtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
