using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Workshop_03
{
    public class ProgressBarColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double progressv = (double)value;
            Brush color = Brushes.Green;

            if (progressv <= 6 && progressv > 3)
            {
                color = Brushes.Yellow;
            }
            else if (progressv <= 3)
            {
                color = Brushes.Red;
            }
            return color;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
