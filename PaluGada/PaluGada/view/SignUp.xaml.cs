using Npgsql;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=lhanif;Database=junpro2";

        public SignUp()
        {
            InitializeComponent();
        }

        private void lbl_Clickable_Login(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Label clicked!");
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.LoginFrame.Navigate(new Login());
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string username = box_Username.Text.Trim();
            string password = box_Password.Password;
            string name = box_Name.Text.Trim();
            string email = box_Email.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Username and password must not be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (SignUpUser(username, password, name, email))
            {
                MessageBox.Show("Sign-up successful!");
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.LoginFrame.Navigate(new ConfirmEmail());
            }
            else
            {
                MessageBox.Show("Sign-up failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool SignUpUser(string username, string password, string name, string email)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the username already exists
                    string checkUserQuery = "SELECT COUNT(*) FROM AppUser WHERE username = @username";
                    using (var checkUserCmd = new NpgsqlCommand(checkUserQuery, connection))
                    {
                        checkUserCmd.Parameters.AddWithValue("@username", username);
                        int userCount = Convert.ToInt32(checkUserCmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different one.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return false;
                        }
                    }

                    // Insert new user
                    string insertQuery = "INSERT INTO AppUser (username, password, name, email) VALUES (@username, @password, @name, @email)";
                    using (var command = new NpgsqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", email);
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void box_Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Logic for handling changes in the username text box (if needed)
        }
    }
}

