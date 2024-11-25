using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET.MapProviders;
using Microsoft.AspNetCore.SignalR.Client;
using Npgsql;
using PaluGada.model;

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Page
    {
        public ObservableCollection<Chatroom> Chatrooms { get; set; }

        public Chat()
        {
            InitializeComponent();
            LoadChatrooms();
        }
        private int? _initialChatroomId;

        public Chat(int? initialChatroomId = null)
        {
            InitializeComponent();
            LoadChatrooms();
            _initialChatroomId = initialChatroomId;
            int idroom = _initialChatroomId.GetValueOrDefault();
            ChatFrame.Navigate(new ChatRoomPage(idroom));
        }

        private void NavigateToPage(Page page)
        {
            ChatFrame.Navigate(page);
        }

        private void LoadChatrooms()
        {
            Chatrooms = new ObservableCollection<Chatroom>();

            using (var conn = new NpgsqlConnection(Session.ConnectionString))
            {
                conn.Open();

                string query = @"
                SELECT c.chatroom_id, 
                       CASE 
                           WHEN c.buyer_id = @UserId THEN s.name
                           ELSE b.name 
                       END AS partner_name,
                       (SELECT content 
                        FROM message m 
                        WHERE m.chatroom_id = c.chatroom_id 
                        ORDER BY timestamp DESC 
                        LIMIT 1) AS last_message
                    FROM chatroom c
                    JOIN appuser b ON c.buyer_id = b.user_id
                    JOIN appuser s ON c.seller_id = s.user_id
                    WHERE c.buyer_id = @UserId OR c.seller_id = @UserId
                    ORDER BY c.chatroom_id DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", Session.UserId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Chatrooms.Add(new Chatroom
                            {
                                ChatroomId = reader.GetInt32(0),
                                PartnerName = reader.GetString(1),
                                LastMessage = reader.IsDBNull(2) ? "No messages yet" : reader.GetString(2)
                            });
                        }
                    }
                }
            }

            ChatroomList.ItemsSource = Chatrooms;
        }



        private void ChatroomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChatroomList.SelectedItem is Chatroom selectedChatroom)
            {
                ChatFrame.Navigate(new ChatRoomPage(selectedChatroom.ChatroomId));
            }
        }
    }
}
