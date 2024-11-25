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
            bool isUserMessage = (bool)value;

            if (isUserMessage)
            {
                return new SolidColorBrush(Colors.LightGreen); 
            }
            else
            {
                return new SolidColorBrush(Colors.LightGray); 
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
