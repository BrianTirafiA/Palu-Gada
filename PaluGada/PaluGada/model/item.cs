using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaluGada.model
{
    public class Item
    {
        // Title of the item, e.g., "Jas UGM"
        public string Title { get; set; }

        // Description of the item, can contain more details about it
        public string Description { get; set; }

        // Path to the image file representing the item
        public string ImagePath { get; set; }

        // You can also add additional properties as needed
        // For example, a boolean to check if the item is sold
        public bool IsSold { get; set; }
    }
}
