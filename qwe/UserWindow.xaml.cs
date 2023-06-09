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

            AppFrame.frameUser = UserFrame;
            UserFrame.Navigate(new Main());
        }

        private void GoBackImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            UserFrame.GoBack();
        }

        private void CabinetList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
