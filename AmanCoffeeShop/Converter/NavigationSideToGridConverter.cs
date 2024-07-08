using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using AmanCoffeeShop.ViewModel;
using static AmanCoffeeShop.ViewModel.CustomersViewModel;

namespace AmanCoffeeShop.Converter
{
    public class NavigationSideToGridConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var navigationSide = (NavigationSides)value;
            return navigationSide == NavigationSides.Left ? 0 : 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
