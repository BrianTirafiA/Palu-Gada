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
using Npgsql;

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=lhanif;Database=junpro";

        public Login()
        {
            InitializeComponent();
        }

        private void lbl_Clickable_SignUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Label clicked!");
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.LoginFrame.Navigate(new SignUp());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = box_Username.Text.Trim();
            string password = box_Password.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password must not be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Login successful!");

                MainMenu mainMenuWindow = new MainMenu();
                mainMenuWindow.Show();

                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT COUNT(*) FROM AppUser WHERE username = @username AND password = @password";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        int userCount = Convert.ToInt32(command.ExecuteScalar());


                        return userCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
