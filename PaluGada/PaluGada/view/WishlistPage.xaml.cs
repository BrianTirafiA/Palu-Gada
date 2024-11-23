using PaluGada.viewModel;
using PaluGada.model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading; // Untuk timer
using Npgsql;

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for WishlistPage.xaml
    /// </summary>
    public partial class WishlistPage : Page
    {
        private DispatcherTimer RefreshTimer;

        public WishlistPage()
        {
            InitializeComponent();

            // Set DataContext ke ViewModel
            this.DataContext = new WishlistViewModel(Session.UserId);

            // Inisialisasi Timer untuk auto-refresh
            RefreshTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5) // Refresh setiap 5 detik
            };
            RefreshTimer.Tick += (s, e) => RefreshWishlist(); // Panggil RefreshWishlist() setiap tick
            RefreshTimer.Start();
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

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search item";
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
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
                            RefreshWishlist(); // Panggil RefreshWishlist untuk memperbarui daftar
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

        private void RefreshWishlist()
        {
            // Refresh ViewModel dengan data terbaru
            this.DataContext = new WishlistViewModel(Session.UserId);
        }

        ~WishlistPage()
        {
            // Hentikan Timer saat halaman dihancurkan
            RefreshTimer?.Stop();
        }

        private void ShowDetails_Click(object sender, RoutedEventArgs e)
        {
            // Cast sender to Button
            var button = sender as Button;
            if (button == null) return;

            // Retrieve the Item object from DataContext
            var item = button.DataContext as Item;
            if (item == null) return;

            // Open the detail window with item details
            var detailWindow = new DetailWindow(item.Title, item.Description, item.ImagePath, item.ItemId);
            detailWindow.Show();
        }


    }
}
