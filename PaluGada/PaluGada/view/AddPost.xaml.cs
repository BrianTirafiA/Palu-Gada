using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PaluGada.model;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace PaluGada.view
{
    public partial class AddPost : Page
    {
        private PointLatLng currentPosition;
        private GMapMarker currentMarker;

        public AddPost()
        {
            InitializeComponent();
            ConfigureMap();
        }

        private void ConfigureMap()
        {

            mapControl.MapProvider = GMapProviders.GoogleMap;
            mapControl.Position = new PointLatLng(-7.801268, 110.364868);
            mapControl.MinZoom = 2;
            mapControl.MaxZoom = 18;
            mapControl.Zoom = 12;
            mapControl.ShowCenter = false;

            currentPosition = mapControl.Position;
            currentMarker = new GMapMarker(currentPosition)
            {
                Shape = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Stroke = Brushes.Red,
                    StrokeThickness = 2,
                    Fill = Brushes.Red
                }
            };
            mapControl.Markers.Add(currentMarker);
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFilePath = openFileDialog.FileName;

                string targetFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets/item_photo");
                if (!System.IO.Directory.Exists(targetFolder))
                {
                    System.IO.Directory.CreateDirectory(targetFolder);
                }

                string newFileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(sourceFilePath);

                string targetFilePath = System.IO.Path.Combine(targetFolder, newFileName);

                System.IO.File.Copy(sourceFilePath, targetFilePath, true);

                UploadButton.Tag = System.IO.Path.Combine("assets/item_photo", newFileName);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(targetFilePath, UriKind.Absolute);
                bitmap.EndInit();

                UploadButton.Width = bitmap.PixelWidth;
                UploadButton.Height = bitmap.PixelHeight;

                Image imagePreview = new Image
                {
                    Source = bitmap,
                    Stretch = Stretch.UniformToFill
                };

                UploadButton.Content = imagePreview;
            }
        }


        private async void box_Location_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string location = box_Location.Text.Trim();

                if (!string.IsNullOrEmpty(location))
                {
                    var coordinates = await GetCoordinatesFromNominatim(location);

                    if (coordinates.HasValue)
                    {
                        mapControl.Position = coordinates.Value;
                        currentPosition = coordinates.Value;
                        currentMarker.Position = currentPosition;

                        MessageBox.Show($"Location found: {location}\nLat: {currentPosition.Lat}, Lng: {currentPosition.Lng}");
                    }
                    else
                    {
                        MessageBox.Show("Location not found. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private async Task<PointLatLng?> GetCoordinatesFromNominatim(string address)
        {
            try
            {
                string requestUri = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(address)}&format=json&addressdetails=1&limit=1";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "YourAppName");
                    HttpResponseMessage response = await client.GetAsync(requestUri);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JArray data = JArray.Parse(json);

                        if (data.Count > 0)
                        {
                            double lat = (double)data[0]["lat"];
                            double lng = (double)data[0]["lon"];
                            return new PointLatLng(lat, lng);
                        }
                        else
                        {
                            MessageBox.Show("Location not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error while connecting to Nominatim API.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }


        private void mapControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(mapControl);

            currentPosition = mapControl.FromLocalToLatLng((int)mousePosition.X, (int)mousePosition.Y);

            currentMarker.Position = currentPosition;

            MessageBox.Show($"Marker moved to:\nLat: {currentPosition.Lat}, Lng: {currentPosition.Lng}");
        }

        private void mapControl_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (mapControl.IsMouseOver)
            {
                if (e.Delta > 0)
                {
                    mapControl.Zoom = Math.Min(mapControl.Zoom + 1, mapControl.MaxZoom);
                }
                else if (e.Delta < 0)
                {
                    mapControl.Zoom = Math.Max(mapControl.Zoom - 1, mapControl.MinZoom);
                }

                e.Handled = true;
            }
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(box_ItemName.Text) || string.IsNullOrEmpty(box_Description.Text) || UploadButton.Tag == null)
            {
                MessageBox.Show("Please fill out all fields and upload an image.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                string name = box_ItemName.Text.Trim();
                string description = box_Description.Text.Trim();
                double latitude = currentPosition.Lat;
                double longitude = currentPosition.Lng;
                int sellerId = PaluGada.model.Session.UserId;
                string imagePath = UploadButton.Tag.ToString();

                using (var connection = new NpgsqlConnection(Session.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                    INSERT INTO Item (seller_id, name, description, latitude, longitude, image_path)
                    VALUES (@seller_id, @name, @description, @latitude, @longitude, @image_path)";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@seller_id", sellerId);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@latitude", latitude);
                        command.Parameters.AddWithValue("@longitude", longitude);
                        command.Parameters.AddWithValue("@image_path", imagePath);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Item has been successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void ResetForm()
        {
            box_ItemName.Text = string.Empty;
            box_Description.Text = string.Empty;
            UploadButton.Content = "Upload Image";
            UploadButton.Tag = null;
        }
    }
}
