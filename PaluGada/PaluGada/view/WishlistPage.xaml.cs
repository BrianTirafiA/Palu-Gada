using PaluGada.viewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for WishlistPage.xaml
    /// </summary>
    public partial class WishlistPage : Page
    {
        public WishlistPage()
        {
            InitializeComponent();

            this.DataContext = new WishlistViewModel(Session.UserId);

        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // Remove placeholder text on focus
                if (textBox.IsFocused && textBox.Text == "Search item")
                {
                    textBox.Text = "";
                    textBox.Foreground = System.Windows.Media.Brushes.Black;
                }

                // Show placeholder text when empty and not focused
                if (!textBox.IsFocused && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = "Search item";
                    textBox.Foreground = System.Windows.Media.Brushes.Gray;
                }
            }
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "Search item")
            {
                textBox.Text = "";
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Ambil ItemId dari Tag tombol
            if (sender is Button button && button.Tag is int itemId)
            {
                int buyerId = Session.UserId; // ID pembeli dari session

                using (var conn = new NpgsqlConnection(Session.ConnectionString))
                {
                    conn.Open();

                    // Langkah 1: Dapatkan wishlist_id untuk buyer_id
                    string getWishlistIdQuery = @"
                    SELECT wishlist_id 
                    FROM wishlist 
                    WHERE buyer_id = @BuyerId;";

                    int wishlistId;
                    using (var cmd = new NpgsqlCommand(getWishlistIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("BuyerId", buyerId);
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Wishlist tidak ditemukan.");
                            return; // Keluar jika wishlist tidak ditemukan
                        }
                        wishlistId = (int)result;
                    }

                    // Langkah 2: Hapus item dari wishlist_item
                    string deleteItemQuery = @"
                    DELETE FROM wishlist_item
                    WHERE wishlist_id = @WishlistId AND item_id = @ItemId;";

                    using (var cmd = new NpgsqlCommand(deleteItemQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("WishlistId", wishlistId);
                        cmd.Parameters.AddWithValue("ItemId", itemId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item berhasil dihapus dari wishlist!");
                        }
                        else
                        {
                            MessageBox.Show("Item tidak ditemukan dalam wishlist.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Gagal mengambil ID item.");
            }
        }



        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search item";
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }
    }
}
