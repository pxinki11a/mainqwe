using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CabinetsPage.xaml
    /// </summary>
    public partial class CabinetsPage : Page
    {
        public CabinetsPage()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            var content = AppData.db.cabinet.ToList();
            LVCabinets.ItemsSource = content;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var currentcabinet = button.DataContext as cabinet;
            NavigationService.Navigate(new AddEditCabinetPage(currentcabinet));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentcabinet = (sender as Button).DataContext as cabinet;
            if (MessageBox.Show("Вы уверены что хотите удалить этот кабинет?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AppData.db.cabinet.Remove(currentcabinet);
                AppData.db.SaveChanges();
                Update();
            }


        }
    }
}
