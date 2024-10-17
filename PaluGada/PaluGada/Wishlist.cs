using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaluGada
{
    internal class Wishlist
    {
        public int wishlistID { get; set; }
        public List<Item> item { get; set; }
        public int buyerID { get; set; }

        //method
        public void addItemWishlist(Item item)
        {
        }
        public void removeItemWishlist(Item item)
        {
        }
        public void viewWishlist(Item item)
        {
        }
    }
}
