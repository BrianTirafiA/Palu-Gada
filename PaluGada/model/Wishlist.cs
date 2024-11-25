using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaluGada.model
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int BuyerId { get; set; }
        public List<Item> Items { get; set; }
    }
}
