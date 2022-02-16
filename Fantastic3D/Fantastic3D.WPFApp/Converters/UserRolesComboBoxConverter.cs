using Fantastic3D.AppModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Fantastic3D.GUI.Converters
{
    [ValueConversion(typeof(UserRole), typeof(string))]
    internal class UserRolesComboBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is UserRole role)
            {
                return role.ToString();
            }
            return "Basic";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string roleAsString)
            {
                return roleAsString switch
                {
                    "Admin" => UserRole.Admin,
                    "Premium" => UserRole.Premium,
                    _ => UserRole.Basic,
                };
            }
            return UserRole.Basic;
        }
    }
}
