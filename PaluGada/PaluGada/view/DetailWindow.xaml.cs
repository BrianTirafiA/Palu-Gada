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

        public DetailWindow(string name, string description, string imagePath, int itemId)
        {
            InitializeComponent();

            ItemName.Text = name;
            ItemDescription.Text = description;
            ItemId = itemId;

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



        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
