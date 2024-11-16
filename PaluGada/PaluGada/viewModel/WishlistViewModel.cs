using PaluGada.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaluGada.viewModel
{
    public class WishlistViewModel
    {
        public ObservableCollection<Item> ItemList { get; set; }

        public WishlistViewModel()
        {
            // Sample data for testing
            ItemList = new ObservableCollection<Item>
            {
                new Item { Title = "Jas UGM", Description = "This is a description of Jas UGM", ImagePath = "path_to_image.jpg" },
                new Item { Title = "Jas UGM", Description = "This is another description of Jas UGM", ImagePath = "path_to_image.jpg" }
            };
        }
    }
}
