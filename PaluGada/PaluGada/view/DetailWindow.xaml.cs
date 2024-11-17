using Npgsql;
using PaluGada.model;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PaluGada.view
{
    public partial class DetailWindow : Window
    {
        private int ItemId { get; set; }
        private int SellerId { get; set; }


        public DetailWindow(string name, string description, string imagePath, int itemId)
        {
            InitializeComponent();

            ItemName.Text = name;
            ItemDescription.Text = description;
            ItemId = itemId;
            LoadSellerId(itemId);


            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    ItemImage.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                }
                catch (Exception)
                {
                    ItemImage.Source = null;
                }
            }


        }

        private void LoadSellerId(int itemId)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Session.ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT seller_id FROM Item WHERE item_id = @ItemId";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemId", itemId);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            SellerId = (int)result; // Isi nilai seller_id ke properti SellerId
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading seller ID: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WishlistButton_Click(object sender, RoutedEventArgs e)
        {
            int buyerId = Session.UserId;
            int itemId = this.ItemId;

            using (var conn = new NpgsqlConnection(Session.ConnectionString))
            {
                conn.Open();

                string checkWishlistQuery = @"
            SELECT wishlist_id FROM wishlist WHERE buyer_id = @BuyerId;";

                int wishlistId;
                using (var cmd = new NpgsqlCommand(checkWishlistQuery, conn))
                {
                    cmd.Parameters.AddWithValue("BuyerId", buyerId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        wishlistId = (int)result;
                    }
                    else
                    {
                        string insertWishlistQuery = @"
                    INSERT INTO wishlist (buyer_id)
                    VALUES (@BuyerId)
                    RETURNING wishlist_id;";

                        using (var insertCmd = new NpgsqlCommand(insertWishlistQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("BuyerId", buyerId);
                            wishlistId = (int)insertCmd.ExecuteScalar();
                        }
                    }
                }

                string insertWishlistItemQuery = @"
                INSERT INTO wishlist_item (wishlist_id, item_id)
                VALUES (@WishlistId, @ItemId);";

                using (var cmd = new NpgsqlCommand(insertWishlistItemQuery, conn))
                {
                    cmd.Parameters.AddWithValue("WishlistId", wishlistId);
                    cmd.Parameters.AddWithValue("ItemId", itemId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Item berhasil ditambahkan ke wishlist!");
        }

        private void ChatSellerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int chatroomId = GetOrCreateChatroom(Session.UserId, SellerId);

                var chatRoomPage = new ChatRoomPage(chatroomId);
                chatRoomPage.Show();
                this.Close();

                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to chatroom: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private int GetOrCreateChatroom(int buyerId, int sellerId)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Session.ConnectionString))
                {
                    conn.Open();

                    // Periksa apakah chatroom sudah ada
                    string query = @"
                        SELECT chatroom_id 
                        FROM Chatroom 
                        WHERE buyer_id = @BuyerId AND seller_id = @SellerId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuyerId", buyerId);
                        cmd.Parameters.AddWithValue("@SellerId", sellerId);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            // Chatroom sudah ada, kembalikan chatroom_id
                            return (int)result;
                        }
                    }

                    // Buat chatroom baru jika belum ada
                    query = @"
                        INSERT INTO Chatroom (buyer_id, seller_id, created_at)
                        VALUES (@BuyerId, @SellerId, NOW())
                        RETURNING chatroom_id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuyerId", buyerId);
                        cmd.Parameters.AddWithValue("@SellerId", sellerId);

                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating or retrieving chatroom: {ex.Message}");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
