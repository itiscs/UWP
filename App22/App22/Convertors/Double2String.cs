using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace App22.Convertors
{
    public class Double2String : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, string language)
        {
            double val;
            if (double.TryParse(value.ToString(), out val))
                return val;
            return 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }
    }
}
