using GMap.NET;
using GMap.NET.WindowsPresentation;
using Microsoft.Win32;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Linq;
using Npgsql;
using PaluGada.model;
using Azure.Storage.Blobs; 
using System.Configuration;

namespace PaluGada.view
{
    public partial class EditItemWindow : Window
    {
        private PointLatLng currentPosition;
        private GMapMarker currentMarker;
        private int ItemId;
        private string OldImagePath; 
        private string NewImagePath; 

        public EditItemWindow(int itemId)
        {
            InitializeComponent();
            ItemId = itemId;

            ConfigureMap();
            LoadItemData();
        }

        private void ConfigureMap()
        {
            mapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            mapControl.Position = new PointLatLng(-7.801268, 110.364868); 
            mapControl.MinZoom = 2;
            mapControl.MaxZoom = 18;
            mapControl.Zoom = 12;
            mapControl.ShowCenter = false;

            currentPosition = mapControl.Position;
            currentMarker = new GMapMarker(currentPosition)
            {
                Shape = new System.Windows.Shapes.Ellipse
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

        private void LoadItemData()
        {
            using (var conn = new NpgsqlConnection(Session.ConnectionString))
            {
                conn.Open();

                string query = @"
                    SELECT name, description, latitude, longitude, image_path
                    FROM item
                    WHERE item_id = @ItemId";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemId", ItemId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            box_ItemName.Text = reader.GetString(0);
                            box_Description.Text = reader.GetString(1);
                            currentPosition = new PointLatLng(reader.GetDouble(2), reader.GetDouble(3));
                            OldImagePath = reader.GetString(4);

                            box_Location.Text = $"{currentPosition.Lat}, {currentPosition.Lng}";
                            currentMarker.Position = currentPosition;
                            mapControl.Position = currentPosition;

                            if (!string.IsNullOrEmpty(OldImagePath))
                            {
                                ItemImage.Source = new BitmapImage(new Uri(OldImagePath));
                            }
                        }
                    }
                }
            }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFilePath = openFileDialog.FileName;

                string blobConnectionString = ConfigurationManager.ConnectionStrings["AzureBlobStorage"].ConnectionString;
                string containerName = "imageuserpg";

                try
                {
                    if (!string.IsNullOrEmpty(OldImagePath))
                    {
                        BlobServiceClient blobServiceClient = new BlobServiceClient(blobConnectionString);
                        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                        string oldBlobName = Path.GetFileName(new Uri(OldImagePath).LocalPath);
                        containerClient.DeleteBlobIfExists(oldBlobName);
                    }

                    string newBlobName = Guid.NewGuid().ToString() + Path.GetExtension(sourceFilePath);
                    BlobServiceClient newBlobServiceClient = new BlobServiceClient(blobConnectionString);
                    BlobContainerClient newContainerClient = newBlobServiceClient.GetBlobContainerClient(containerName);
                    BlobClient blobClient = newContainerClient.GetBlobClient(newBlobName);

                    using (FileStream uploadFileStream = File.OpenRead(sourceFilePath))
                    {
                        blobClient.Upload(uploadFileStream, true);
                    }

                    NewImagePath = blobClient.Uri.ToString();

                    ItemImage.Source = new BitmapImage(new Uri(NewImagePath));

                    BitmapImage buttonImage = new BitmapImage(new Uri(NewImagePath));
                    Image buttonPreview = new Image
                    {
                        Source = buttonImage,
                        Stretch = Stretch.UniformToFill
                    };

                    UploadButton.Content = buttonPreview; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error uploading image: {ex.Message}");
                }
            }
        }

        private async Task<PointLatLng?> GetCoordinatesFromNominatim(string address)
        {
            try
            {
                string uri = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(address)}&format=json&addressdetails=1&limit=1";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "PaluGadaApp");
                    var response = await client.GetStringAsync(uri);
                    var data = JArray.Parse(response);

                    if (data.Count > 0)
                    {
                        double lat = (double)data[0]["lat"];
                        double lng = (double)data[0]["lon"];
                        return new PointLatLng(lat, lng);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return null;
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Session.ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE item
                        SET name = @Name, description = @Description, latitude = @Latitude, longitude = @Longitude, image_path = @ImagePath
                        WHERE item_id = @ItemId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", box_ItemName.Text);
                        cmd.Parameters.AddWithValue("@Description", box_Description.Text);
                        cmd.Parameters.AddWithValue("@Latitude", currentPosition.Lat);
                        cmd.Parameters.AddWithValue("@Longitude", currentPosition.Lng);
                        cmd.Parameters.AddWithValue("@ImagePath", NewImagePath ?? OldImagePath); 
                        cmd.Parameters.AddWithValue("@ItemId", ItemId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Item updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void box_Location_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string location = box_Location.Text.Trim();
                var coordinates = await GetCoordinatesFromNominatim(location);

                if (coordinates.HasValue)
                {
                    currentPosition = coordinates.Value;
                    currentMarker.Position = currentPosition;
                    mapControl.Position = currentPosition;
                }
                else
                {
                    MessageBox.Show("Location not found.");
                }
            }
        }

        private void mapControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(mapControl);
            currentPosition = mapControl.FromLocalToLatLng((int)point.X, (int)point.Y);

            currentMarker.Position = currentPosition;
            box_Location.Text = $"{currentPosition.Lat}, {currentPosition.Lng}";
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


    }
}
