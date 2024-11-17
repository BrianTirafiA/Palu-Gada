using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PaluGada.view
{
    public partial class DetailWindow : Window
    {
        public DetailWindow(string name, string description, string imagePath)
        {
            InitializeComponent();

            // Set data ke UI
            ItemName.Text = name;
            ItemDescription.Text = description;

            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    ItemImage.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                }
                catch (Exception)
                {
                    ItemImage.Source = null; // Jika gambar tidak ditemukan
                }
            }


        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Tutup jendela
            this.Close();
        }
    }
}
