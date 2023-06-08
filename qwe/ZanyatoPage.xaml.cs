using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace qwe
{
    /// <summary>
    /// Логика взаимодействия для ZanyatoPage.xaml
    /// </summary>
    public partial class ZanyatoPage : Page
    {
        public ZanyatoPage()
        {
            InitializeComponent();
        }

        private void LWHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        class BackgroundConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null && value is bool && (bool)value)
                {
                    return Application.Current.FindResource("ActiveBrush");
                }

                return Application.Current.FindResource("DefaultBrush");
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }

    }
}
