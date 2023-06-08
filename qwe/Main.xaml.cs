using qwe;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();

            Update();
        }

        public void Update()
        {
            var content = AppData.db.cabinet.ToList();
            LVMain.ItemsSource = content;

        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var currentCabinet = button.DataContext as cabinet;
            NavigationService.Navigate(new AddCab(currentCabinet));
        }


    }
}
