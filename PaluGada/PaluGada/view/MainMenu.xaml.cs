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

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for mainmenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private Button _currentActiveButton;

        public MainMenu()
        {
            InitializeComponent();
            NavigateToPageMenu(new Home()); // Set halaman default
            SetActiveButton(HomeButton);
        }


        public void NavigateToPageMenu(Page page)
        {
            MainMenuFrame.Navigate(page);

            // Set warna tombol aktif
            if (_currentActiveButton != null)
            {
                _currentActiveButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BEEBAD"));
            }
        }

        private void SetActiveButton(Button button)
        {
            // Set tombol aktif baru
            _currentActiveButton = button;
            _currentActiveButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#378C87"));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPageMenu(new Home());
            SetActiveButton(sender as Button);
        }

        private void AddPostButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPageMenu(new AddPost());
            SetActiveButton(sender as Button);
        }

        private void MyItemButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPageMenu(new MyItem());
            SetActiveButton(sender as Button);
        }

        private void WishlistButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPageMenu(new WishlistPage());
            SetActiveButton(sender as Button);
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPageMenu(new Chat());
            SetActiveButton(sender as Button);
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPageMenu(new Account());
            SetActiveButton(sender as Button);
        }

        public void CloseMe()
        {
            this.Close();
        }
    }
}
