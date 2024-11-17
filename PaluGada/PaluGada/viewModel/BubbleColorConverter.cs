using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace PaluGada.viewModel
{
    public class BubbleColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Periksa apakah pesan berasal dari user
            bool isUserMessage = (bool)value;

            // Jika pesan dari user, gunakan warna tertentu
            if (isUserMessage)
            {
                return new SolidColorBrush(Colors.LightGreen); // Warna bubble untuk user
            }
            else
            {
                return new SolidColorBrush(Colors.LightGray); // Warna bubble untuk user lain
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
