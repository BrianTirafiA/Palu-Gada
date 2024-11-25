using Npgsql;
using PaluGada.model;
using PaluGada.viewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading; // Untuk timer

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for MyItem.xaml
    /// </summary>
    public partial class MyItem : Page
    {
        private DispatcherTimer RefreshTimer;

        public MyItem()
        {
            InitializeComponent();

            this.DataContext = new MyItemViewModel(Session.UserId);

            RefreshTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5) 
            };
            RefreshTimer.Tick += (s, e) => RefreshItemList();
            RefreshTimer.Start();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button button && button.Tag is int itemId)
                {
                    using (var conn = new NpgsqlConnection(Session.ConnectionString))
                    {
                        conn.Open();

                        string deleteWishlistQuery = "DELETE FROM wishlist_item WHERE item_id = @ItemId;";
                        using (var cmd = new NpgsqlCommand(deleteWishlistQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("ItemId", itemId);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteItemQuery = @"
                        DELETE FROM item
                        WHERE item_id = @ItemId AND seller_id = @SellerId;";
                        using (var cmd = new NpgsqlCommand(deleteItemQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("ItemId", itemId);
                            cmd.Parameters.AddWithValue("SellerId", Session.UserId);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Item berhasil dihapus!");
                                RefreshItemList();
                            }
                            else
                            {
                                MessageBox.Show("Item tidak ditemukan atau Anda tidak memiliki izin.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int itemId)
            {
                var editWindow = new EditItemWindow(itemId);
                editWindow.ShowDialog();
            }
        }

        private void RefreshItemList()
        {
            this.DataContext = new MyItemViewModel(Session.UserId);
        }

        ~MyItem()
        {
            RefreshTimer?.Stop();
        }
    }
}
