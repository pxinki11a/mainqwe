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
    /// Логика взаимодействия для ShortPage.xaml
    /// </summary>
    public partial class ShortPage : Page
    {

        public TableName currentTable;

        public ShortPage()
        {
            InitializeComponent();
        }

        public ShortPage(TableName tn)
        {
            currentTable = tn;
            this.WindowTitle = currentTable.ToString();

            InitializeComponent();
            Update();
        }
        
        public void Update()
        {
            switch (currentTable)
            {
                case TableName.korpus:
                    List<qwe.korpus> korpus = AppData.db.korpus.ToList();
                    LVShort.ItemsSource = korpus;
                    break;
                case TableName.Role:
                    var roles = AppData.db.Role.ToList();
                    LVShort.ItemsSource = roles;
                    break;
                case TableName.status:
                    var status = AppData.db.status.ToList();
                    LVShort.ItemsSource = status;
                    break;
                case TableName.typecabinet:
                    var typecabinet = AppData.db.typecabinet.ToList();
                    LVShort.ItemsSource = typecabinet;
                    break;
                
                default:
                    MessageBox.Show("Ошибка!");
                    break;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            switch (currentTable)
            {
                case TableName.korpus:
                    var currentKorpus = button.DataContext as korpus;
                    NavigationService.Navigate(new AddEditShortPage(currentTable, currentKorpus));
                    break;
                case TableName.Role:
                    var currentRole = button.DataContext as Role;
                    NavigationService.Navigate(new AddEditShortPage(currentTable, null, currentRole));
                    break;   
                case TableName.status:
                    var currentStatus = button.DataContext as status;
                    NavigationService.Navigate(new AddEditShortPage(currentTable, null, null,  currentStatus));
                    break;
                case TableName.typecabinet:
                    var currentTypecabinet = button.DataContext as typecabinet;
                    NavigationService.Navigate(new AddEditShortPage(currentTable, null, null, null, currentTypecabinet));
                    break;
                default:
                    break;
            }
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                switch (currentTable)
                {
                    case TableName.korpus:
                        var currentKorpus = (sender as Button).DataContext as korpus;
                        AppData.db.korpus.Remove(currentKorpus);
                        break;
                    case TableName.Role:
                        var currentRole = (sender as Button).DataContext as Role;
                        AppData.db.Role.Remove(currentRole);
                        break;              
                    case TableName.status:
                        var currentStatus = (sender as Button).DataContext as status;
                        AppData.db.status.Remove(currentStatus);
                        break;
                    
                    case TableName.typecabinet:
                        var currentTypecabinet = (sender as Button).DataContext as typecabinet;
                        AppData.db.typecabinet.Remove(currentTypecabinet);
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                Update();
            }
        }




    }
}
