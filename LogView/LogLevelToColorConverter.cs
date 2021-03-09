using Cave.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace LogView
{
    public class LogLevelToColorConverter : IValueConverter
    {
        public SolidColorBrush[] colors = new SolidColorBrush[9]{
            Brushes.Purple,
            Brushes.Red,
            Brushes.OrangeRed,
            Brushes.Orange,
            Brushes.Yellow,
            Brushes.Blue,
            Brushes.Green,
            Brushes.White,
            Brushes.Gray
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is LogLevel)
            {
                int lvl = (int)value;
                lvl = Math.Min(lvl, 8);
                return colors[lvl];
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
