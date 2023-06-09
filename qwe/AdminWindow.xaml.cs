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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace qwe
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public TableName currentTable;
        public AdminWindow()
        {
            InitializeComponent();
            SelectTable.SelectedIndex = 0;
        }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentTable = (TableName)SelectTable.SelectedIndex;
            switch (currentTable)
            {
                case TableName.cabinet:
                    MainFrame.Navigate(new CabinetsPage());
                    break;
                case TableName.korpus:
                    MainFrame.Navigate(new ShortPage(TableName.korpus));
                    break;
                
                case TableName.Role:
                    MainFrame.Navigate(new ShortPage(TableName.Role));
                    break;
                case TableName.status:
                    MainFrame.Navigate(new ShortPage(TableName.status));
                    break;
                case TableName.typecabinet:
                    MainFrame.Navigate(new ShortPage(TableName.typecabinet));
                    break;
                case TableName.User:
                    MainFrame.Navigate(new UserPage());
                    break;
                case TableName.UserCabinet:
                    MainFrame.Navigate(new ZanyatoPage());
                    break;
                default:
                    break;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (currentTable)
            {
                
            case TableName.cabinet:
                MainFrame.Navigate(new AddEditCabinetPage());
                break;
                case TableName.korpus:
                    MainFrame.Navigate(new AddEditShortPage(TableName.korpus));
                    break;
                case TableName.Role:
                MainFrame.Navigate(new AddEditShortPage(TableName.Role));
                break;
                case TableName.status:
                    MainFrame.Navigate(new AddEditShortPage(TableName.status));
                    break;
                case TableName.typecabinet:
                MainFrame.Navigate(new AddEditShortPage(TableName.typecabinet));
                break;
            
            case TableName.User:
                    MainFrame.Navigate(new AddEditUsers());
                break;
            case TableName.UserCabinet:
                    MainFrame.Navigate(new ZanyatoPage());
                break;
            default:
                break;
            }
        }

        private void GoBackImage_Click(object sender, MouseEventArgs e)
        {
            if (MainFrame.CanGoBack
                //&& MessageBox.Show("Вы уверены, что хотите вернуться?",
                //"Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes
                )
                MainFrame.GoBack();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void GoBackImage_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
