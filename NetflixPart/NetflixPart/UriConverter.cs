using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NetflixPart
{
    public class UriConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = value.ToString();
            if (s.Contains(" ") || s.Contains("'"))
            {
                if (s.Contains(" "))
                {                    
                    s = s.ToString().Replace(" ", "%20");                    
                }
                if (s.Contains("'"))
                {                    
                    s = s.ToString().Replace("'", "%27");                  
                }
                return "/Source/" + s + ".jpg";
            }      
            else
            {
                return "/Source/" + s + ".jpg";
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
