using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace NetflixPart
{
    public class BackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush color = Brushes.LightYellow;            
            if ((double) value <=3)
            {
                color = Brushes.LightCoral;
            }
            else if ((double)value>4.4)
            {
                color = Brushes.LightGreen;
            }            
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
