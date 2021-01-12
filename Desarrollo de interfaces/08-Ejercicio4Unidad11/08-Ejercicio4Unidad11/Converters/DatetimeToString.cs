using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _08_Ejercicio4Unidad11.Converters
{
    public class DatetimeToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var time = (DateTime)value;
            
            //DateTime objects can't be null, no need to check
            time.ToString("dd-MM-yyyy");

            return time;
        }

        /// <summary>
        /// Converts strings formatted as dd-mm-yyyy as their DateTime equivalents
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string timestring = (string)value;
            //If unsupported format, returns epoch time
            DateTime parsedDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            // \\d\\d$ at the end is actually \d\d$ but I have to escape c# single "\" restriction
            Regex rx = new Regex("^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d$");

            if (rx.IsMatch(timestring))
            {
               parsedDate = DateTime.Parse(timestring);
            }

            return parsedDate;

        }
    }
}
