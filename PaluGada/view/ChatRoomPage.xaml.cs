using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading; 
using Npgsql;
using PaluGada.model;

namespace PaluGada.view
{
    public partial class ChatRoomPage : Page
    {
        private int ChatroomId;
        public ObservableCollection<Message> Messages { get; set; }
        private DispatcherTimer RefreshTimer;

        public ChatRoomPage(int chatroomId)
        {
            InitializeComponent();
            ChatroomId = chatroomId;

            Messages = new ObservableCollection<Message>();
            MessageList.ItemsSource = Messages;

            LoadMessages();

            RefreshTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2) 
            };
            RefreshTimer.Tick += (s, e) =>
            {
                try
                {
                    LoadMessages();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error auto-refreshing messages: {ex.Message}");
                }
            };
            RefreshTimer.Start();
        }

        private void LoadMessages()
        {
            try
            {
                using (var conn = new NpgsqlConnection(Session.ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT user_id, content, timestamp
                        FROM message
                        WHERE chatroom_id = @ChatroomId
                        ORDER BY timestamp ASC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ChatroomId", ChatroomId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            var latestMessages = new ObservableCollection<Message>();
                            while (reader.Read())
                            {
                                latestMessages.Add(new Message
                                {
                                    UserId = reader.GetInt32(0),
                                    Content = reader.GetString(1),
                                    Timestamp = reader.GetDateTime(2),
                                    IsUserMessage = reader.GetInt32(0) == Session.UserId
                                });
                            }

                            if (latestMessages.Count != Messages.Count || !AreMessagesEqual(latestMessages, Messages))
                            {
                                Messages.Clear();
                                foreach (var message in latestMessages)
                                {
                                    Messages.Add(message);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading messages: {ex.Message}");
            }
        }

        private bool AreMessagesEqual(ObservableCollection<Message> latestMessages, ObservableCollection<Message> currentMessages)
        {
            if (latestMessages.Count != currentMessages.Count)
                return false;

            for (int i = 0; i < latestMessages.Count; i++)
            {
                if (latestMessages[i].UserId != currentMessages[i].UserId ||
                    latestMessages[i].Content != currentMessages[i].Content ||
                    latestMessages[i].Timestamp != currentMessages[i].Timestamp)
                {
                    return false;
                }
            }

            return true;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MessageText.Text))
            {
                try
                {
                    using (var conn = new NpgsqlConnection(Session.ConnectionString))
                    {
                        conn.Open();

                        string query = @"
                            INSERT INTO message (chatroom_id, user_id, content, timestamp)
                            VALUES (@ChatroomId, @UserId, @Content, NOW())";

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ChatroomId", ChatroomId);
                            cmd.Parameters.AddWithValue("@UserId", Session.UserId);
                            cmd.Parameters.AddWithValue("@Content", MessageText.Text);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    Messages.Add(new Message
                    {
                        UserId = Session.UserId,
                        Content = MessageText.Text,
                        Timestamp = DateTime.Now,
                        IsUserMessage = true
                    });

                    MessageText.Text = string.Empty; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending message: {ex.Message}");
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            RefreshTimer?.Stop(); 
    }
}
