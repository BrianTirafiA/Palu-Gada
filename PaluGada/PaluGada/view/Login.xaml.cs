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
        private readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=lhanif;Database=junpro2";

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

            // Autentikasi user dan dapatkan user_id
            int userId = AuthenticateUser(username, password);
            if (userId > 0)
            {
                MessageBox.Show("Login successful!");

                // Simpan user_id ke session
                PaluGada.model.Session.UserId = userId;

                // Navigasi ke MainMenu
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();

                // Tutup jendela login
                Window.GetWindow(this)?.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private int AuthenticateUser(string username, string password)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT user_id FROM AppUser WHERE username = @username AND password = @password";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        var result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0; // Kembalikan user_id jika ditemukan
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
