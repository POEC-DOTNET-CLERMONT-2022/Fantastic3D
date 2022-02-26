using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Fantastic3D.GUI.Converters
{
    [ValueConversion(typeof(string), typeof(Uri))]
    internal class PathToBitmapConverter : IValueConverter
    {
        private readonly string _picturePath = @"pack://application:,,,/../../../../Data/pics/";
        //private readonly string _picturePath = @"Data/pics/";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string path)
            {
                if (File.Exists(_picturePath + path))
                    return new Uri(_picturePath + path, UriKind.RelativeOrAbsolute);
            }
            return new Uri("/medias/notfound.png", UriKind.RelativeOrAbsolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
