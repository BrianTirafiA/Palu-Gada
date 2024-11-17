using Npgsql;
using PaluGada.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PaluGada.viewModel
{
    public class WishlistViewModel
    {
        public ObservableCollection<Item> ItemListWishlist { get; set; }

        public WishlistViewModel(int buyerId)
        {
            ItemListWishlist = LoadWishlist(buyerId);
        }

        private ObservableCollection<Item> LoadWishlist(int buyerId)
        {
            var items = new ObservableCollection<Item>();
            string connectionString = Session.ConnectionString;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT i.item_id, i.name, i.description, i.image_path
                FROM item i
                JOIN wishlist_item wi ON i.item_id = wi.item_id
                JOIN wishlist w ON wi.wishlist_id = w.wishlist_id
                WHERE w.buyer_id = @BuyerId";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("BuyerId", buyerId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new Item
                            {
                                ItemId = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.GetString(2),
                                ImagePath = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return items;
        }
    }
}
