using Npgsql;
using PaluGada.model;
using System.Collections.ObjectModel;

namespace PaluGada.viewModel
{
    public class MyItemViewModel
    {
        public ObservableCollection<Item> ItemListMyItem { get; set; }

        public MyItemViewModel(int sellerId)
        {
            ItemListMyItem = LoadMyItems(sellerId);
        }

        private ObservableCollection<Item> LoadMyItems(int sellerId)
        {
            var items = new ObservableCollection<Item>();
            string connectionString = Session.ConnectionString;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT item_id, name, description, image_path
                    FROM item
                    WHERE seller_id = @SellerId;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("SellerId", sellerId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new Item
                            {
                                ItemId = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.GetString(2),
                                ImagePath = reader.IsDBNull(3) ? null : reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return items;
        }
    }
}
