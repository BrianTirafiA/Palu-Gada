using GMap.NET.MapProviders;
using GMap.NET;
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
using GMap.NET.WindowsPresentation;

namespace PaluGada.view
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            InitializeMap();
        }

        private void InitializeMap()
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache; // Gunakan cache dan server
            MapControl.CacheLocation = @"cache"; // Lokasi folder cache

            // Set provider peta (misalnya OpenStreetMap)
            MapControl.MapProvider = GMapProviders.OpenStreetMap;

            // Set posisi awal (misalnya Jakarta)
            MapControl.Position = new PointLatLng(-6.200000, 106.816666);
            MapControl.MinZoom = 2;
            MapControl.MaxZoom = 17;
            MapControl.Zoom = 10;

            // Properti tambahan
            MapControl.ShowCenter = false;
            MapControl.CanDragMap = true;
            MapControl.DragButton = MouseButton.Left;
            MapControl.Bearing = 0; // Reset orientasi peta ke 0
            MapControl.Markers.Clear();
        }
    }
}
