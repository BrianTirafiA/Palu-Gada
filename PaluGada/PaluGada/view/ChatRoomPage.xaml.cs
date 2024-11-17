using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Npgsql;
using PaluGada.model;

namespace PaluGada.view
{
    public partial class ChatRoomPage : Window
    {
        private int ChatroomId;
        public ObservableCollection<Message> Messages { get; set; }

        public ChatRoomPage(int chatroomId)
        {
            InitializeComponent();
            ChatroomId = chatroomId;

            LoadMessages();
        }

        private void LoadMessages()
        {
            Messages = new ObservableCollection<Message>();

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
                        while (reader.Read())
                        {
                            Messages.Add(new Message
                            {
                                UserId = reader.GetInt32(0),
                                Content = reader.GetString(1),
                                Timestamp = reader.GetDateTime(2),
                                IsUserMessage = reader.GetInt32(0) == Session.UserId
                            });
                        }
                    }
                }
            }

            MessageList.ItemsSource = Messages;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MessageBox.Text))
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
                        cmd.Parameters.AddWithValue("@Content", MessageBox.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                Messages.Add(new Message
                {
                    UserId = Session.UserId,
                    Content = MessageBox.Text,
                    Timestamp = DateTime.Now,
                    IsUserMessage = true
                });

                MessageBox.Text = string.Empty; // Kosongkan textbox
            }
        }
    }
}
