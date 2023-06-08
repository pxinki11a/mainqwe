using qwe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace qwe
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();

            try
            {
                CabinetList.ItemsSource = AppData.db.cabinet.Take(4).ToList();
                var curentCabinet = CabinetList.SelectedItem as cabinet;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void GoBackImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
