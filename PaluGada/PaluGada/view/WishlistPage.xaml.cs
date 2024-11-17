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
    /// Interaction logic for WishlistPage.xaml
    /// </summary>
    public partial class WishlistPage : Page
    {
        public WishlistPage()
        {
            InitializeComponent();
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
    }
}
