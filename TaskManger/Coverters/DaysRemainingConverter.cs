using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TaskManger.Coverters
{
    public class DaysRemainingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            {
                if (value is DateTime dueDate)
                {
                    TimeSpan difference = dueDate.Date - DateTime.Today;
                    int days = difference.Days;
                    if (days < 0) return "פג תוקף!";
                    if (days == 0) return "לבצע היום!";
                    return $"נותרו עוד {days} ימים";
                }
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
