using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
namespace PaluGada
{
    internal class Item
    {
        public int _itemID;
        public string _itemName;
        public int _itemPrice;
        public string _itemDescription;
        public string _itemLocation;
        public int _sellerID;

        public int itemID { get; set; }
        public string itemName { get; set; }
        public int itemPrice { get; set; }
        public int itemDescription { get; set; }
        public int itemLocation { get; set; }
        public int sellerID { get; set; }
        //method
        public void addItem()
        {
        }
        public void deleteItem()
        {
        }
        public void editItem()
        {
        }
        public void viewItem()
        {
        }
    }
    

 }