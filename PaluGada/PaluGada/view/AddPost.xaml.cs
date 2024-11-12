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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Microsoft.Win32;


namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for AddPost.xaml
    /// </summary>
    public partial class AddPost : Page
    {
        public AddPost()
        {
            InitializeComponent();

            // Konfigurasi awal untuk map
            mapControl.MapProvider = GMapProviders.GoogleMap;
            mapControl.Position = new PointLatLng(-7.801268, 110.364868); // Lokasi default (misalnya Yogyakarta)
            mapControl.MinZoom = 2;
            mapControl.MaxZoom = 18;
            mapControl.Zoom = 12;
            mapControl.ShowCenter = true;
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            // Membuka dialog untuk memilih file gambar
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                // Memuat gambar dan mengubah isi tombol menjadi pratinjau gambar
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(openFileDialog.FileName);
                bitmap.EndInit();

                // Mengubah konten tombol menjadi Image dengan pratinjau gambar
                Image imagePreview = new Image
                {
                    Source = bitmap,
                    Width = 392,
                    Height = 149,
                    Stretch = System.Windows.Media.Stretch.UniformToFill
                };
                UploadButton.Content = imagePreview;
            }
        }

        private async void box_Location_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string location = box_Location.Text;
                if (!string.IsNullOrEmpty(location))
                {
                    // Mencari koordinat berdasarkan lokasi
                    var provider = GMapProviders.GoogleMap;
                    var geoCoder = provider.GetGeocoder();

                    var point = await geoCoder.GetPointAsync(location);
                    if (point.HasValue)
                    {
                        // Update posisi map dan tambahkan marker
                        mapControl.Position = point.Value;

                        GMapMarker marker = new GMapMarker(point.Value)
                        {
                            Shape = new System.Windows.Shapes.Ellipse
                            {
                                Width = 10,
                                Height = 10,
                                Stroke = System.Windows.Media.Brushes.Red,
                                StrokeThickness = 1.5
                            }
                        };

                        mapControl.Markers.Clear();
                        mapControl.Markers.Add(marker);
                    }
                    else
                    {
                        MessageBox.Show("Location not found, please try again.");
                    }
                }
            }
        }
    }
}
