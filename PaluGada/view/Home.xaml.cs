using System;
using System.Windows;
using System.Windows.Controls;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using Npgsql;
using System.Windows.Shapes;
using System.Windows.Media;
using GMap.NET.MapProviders;
using PaluGada.model;

namespace PaluGada.view
{
    public partial class Home : Page
    {
        // private readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=lhanif;Database=junpro2";

        public Home()
        {
            InitializeComponent();
            ConfigureMap();
            LoadPinsFromDatabase();
        }

        private void ConfigureMap()
        {
            MapControl.MapProvider = GMapProviders.GoogleMap;
            MapControl.Position = new PointLatLng(-7.801268, 110.364868);
            MapControl.MinZoom = 2;
            MapControl.MaxZoom = 18;
            MapControl.Zoom = 12;
            MapControl.ShowCenter = false; 
        }

        private void LoadPinsFromDatabase()
        {
            try
            {
                using (var connection = new NpgsqlConnection(Session.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT item_id, name, description, latitude, longitude, image_path FROM Item";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int itemId = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string description = reader.GetString(2);
                                double latitude = reader.GetDouble(3);
                                double longitude = reader.GetDouble(4);
                                string imagePath = reader.IsDBNull(5) ? null : reader.GetString(5);

                                AddPinToMap(itemId, name, description, latitude, longitude, imagePath);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pins: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddPinToMap(int itemId, string name, string description, double latitude, double longitude, string imagePath)
        {
            var marker = new GMapMarker(new PointLatLng(latitude, longitude))
            {
                Shape = CreateBubble(name),
                Offset = new System.Windows.Point(-10, -30) 
            };

            marker.Shape.MouseLeftButtonUp += (s, e) =>
            {
                ShowDetails(itemId, name, description, imagePath);
            };

            MapControl.Markers.Add(marker);
        }

        private UIElement CreateBubble(string name)
        {
            var bubbleContainer = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            var bubble = new Border
            {
                Background = Brushes.White,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(5),
                Margin = new Thickness(0, 0, 0, 5)
            };

            var bubbleText = new TextBlock
            {
                Text = name,
                Foreground = Brushes.Black,
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center
            };

            bubble.Child = bubbleText;

            var triangle = new Polygon
            {
                Points = new PointCollection
                {
                    new System.Windows.Point(0, 0),
                    new System.Windows.Point(10, 10),
                    new System.Windows.Point(-10, 10)
                },
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            bubbleContainer.Children.Add(bubble);
            bubbleContainer.Children.Add(triangle);

            return bubbleContainer;
        }

        private void ShowDetails(int itemId, string name, string description, string imagePath)
        {
            var detailWindow = new DetailWindow(name, description, imagePath, itemId);
            detailWindow.Show();
        }

        private void MapControl_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (MapControl.IsMouseOver)
            {
                if (e.Delta > 0)
                {
                    MapControl.Zoom = Math.Min(MapControl.Zoom + 1, MapControl.MaxZoom);
                }
                else if (e.Delta < 0)
                {
                    MapControl.Zoom = Math.Max(MapControl.Zoom - 1, MapControl.MinZoom);
                }

                e.Handled = true;
            }
        }
    }
}
