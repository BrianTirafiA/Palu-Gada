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
using Microsoft.AspNetCore.SignalR.Client;

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Page
    {
        private HubConnection connection;
        private string username;
        public Chat()
        {
            InitializeComponent();
            InitializeSignalR();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "UsernameBox") textBox.Text = "Enter your username";
                else if (textBox.Name == "RecipientBox") textBox.Text = "Recipient's username";
                else if (textBox.Name == "MessageBox") textBox.Text = "Enter your message";

                textBox.Foreground = Brushes.Gray;
            }
        }

        private async void InitializeSignalR()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5094/ChatHub") // Server URL
                .WithAutomaticReconnect()
                .Build();

            // Handle incoming messages
            connection.On<string, string>("ReceiveMessage", (sender, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    ChatBox.Items.Add($"{sender}: {message}");
                });
            });

            try
            {
                await connection.StartAsync();
                ChatBox.Items.Add("Connected to the server.");
            }
            catch (Exception ex)
            {
                ChatBox.Items.Add($"Connection error: {ex.Message}");
            }
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (connection.State == HubConnectionState.Connected)
            {
                username = UsernameBox.Text;
                await connection.InvokeAsync("RegisterUser", username);
            }
            else
            {
                ChatBox.Items.Add("Unable to register. Not connected to the server.");
            }
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (connection.State == HubConnectionState.Connected)
            {
                var recipient = RecipientBox.Text;
                var message = MessageBox.Text;
                await connection.InvokeAsync("SendMessageToUser", username, recipient, message);
                MessageBox.Clear();
            }
            else
            {
                ChatBox.Items.Add("Unable to send message. Not connected to the server.");
            }
        }
    }
}
