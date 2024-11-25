using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using PaluGada.view;

namespace PaluGada.model
{
    public class Pin
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GMapMarker CreateMarker()
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
                Text = Name,
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

            var marker = new GMapMarker(new PointLatLng(Latitude, Longitude))
            {
                Shape = bubbleContainer,
                Offset = new System.Windows.Point(-10, -30) 
            };

            bubbleContainer.MouseLeftButtonUp += (s, e) =>
            {
                ShowDetails();
            };

            return marker;
        }

        private void ShowDetails()
        {
            var detailWindow = new DetailWindow(Name, Description, ImagePath, ItemId);
            detailWindow.Show();
        }
    }
}
