using Npgsql;
using PaluGada.model;
using PaluGada.viewModel;
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

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for MyItem.xaml
    /// </summary>
    public partial class MyItem : Page
    {
        public MyItem()
        {
            InitializeComponent();
            this.DataContext = new MyItemViewModel(Session.UserId);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int itemId)
            {
                using (var conn = new NpgsqlConnection(Session.ConnectionString))
                {
                    conn.Open();

                    // Hapus item dari tabel item
                    string query = @"
                    DELETE FROM item
                    WHERE item_id = @ItemId AND seller_id = @SellerId;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("ItemId", itemId);
                        cmd.Parameters.AddWithValue("SellerId", Session.UserId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item berhasil dihapus!");
                            RefreshItemList(); // Refresh UI untuk memperbarui daftar item
                        }
                        else
                        {
                            MessageBox.Show("Item tidak ditemukan atau Anda tidak memiliki izin.");
                        }
                    }
                }
            }
        }

        private void SoldButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int itemId)
            {
                using (var conn = new NpgsqlConnection(Session.ConnectionString))
                {
                    conn.Open();

                    // Hapus item dari tabel item
                    string query = @"
                    DELETE FROM item
                    WHERE item_id = @ItemId AND seller_id = @SellerId;";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("ItemId", itemId);
                        cmd.Parameters.AddWithValue("SellerId", Session.UserId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item telah terjual!");
                            RefreshItemList(); // Refresh UI untuk memperbarui daftar item
                        }
                        else
                        {
                            MessageBox.Show("Item tidak ditemukan atau Anda tidak memiliki izin.");
                        }
                    }
                }
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
            // Refresh ViewModel dan set ulang DataContext
            this.DataContext = new MyItemViewModel(Session.UserId);
        }


    }
}
