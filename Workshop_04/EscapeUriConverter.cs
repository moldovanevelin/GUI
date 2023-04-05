using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SZTGUI_GYAK04
{
    public class EscapeUriConverter : IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            if (value.ToString().Contains(" "))
            {                
                string s = value.ToString().Replace(" ","%20");
                return "/Images/"+s + ".jpg";                
            }
            else
            {
                return "/Images/" + value.ToString() + ".jpg";
            }
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
