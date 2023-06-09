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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            var content = AppData.db.User.ToList();
            LVUsers.ItemsSource = content;
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var currentUser = button.DataContext as User;
            NavigationService.Navigate(new AddEditUsers(currentUser));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = (sender as Button).DataContext as User;
            if (MessageBox.Show("Вы уверены что хотите удалить этого пользователя?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AppData.db.User.Remove(currentUser);
                AppData.db.SaveChanges();
                Update();
            }
        }

    }
}
