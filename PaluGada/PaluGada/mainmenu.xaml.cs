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
using System.Windows.Shapes;

namespace PaluGada
{
    /// <summary>
    /// Interaction logic for mainmenu.xaml
    /// </summary>
    public partial class mainmenu : Window
    {
        public mainmenu()
        {
            InitializeComponent();
        }

        private void NavigateToPage(Page page)
        {
            this.MainMenuFrame.Navigate(page);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked!");
            NavigateToPage(new Home());
        }

        private void AddPostButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked!");
            NavigateToPage(new AddPost());
        }

        private void MyItemButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked!");
            NavigateToPage(new MyItem());
        }

        private void WishlistButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked!");
            NavigateToPage(new WishlistPage());
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked!");
            NavigateToPage(new Chat());
        }
    }
}
