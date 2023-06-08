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
    /// Логика взаимодействия для AddEditShortPage.xaml
    /// </summary>
    public partial class AddEditShortPage : Page
    {

        public TableName currentTable;
        public string itemName;
        public Role role;
        public typecabinet typecabinet;
        public korpus korpus;
        public status status;
        public bool addOrEditFlag = false; //добавление - true, изменение - false;

        public AddEditShortPage(TableName tn)
        {
            InitializeComponent();

            this.WindowTitle = "Добавление";
            currentTable = tn;
            addOrEditFlag = true;

            switch (currentTable)
            {
                case TableName.korpus:
                    this.WindowTitle = "Добавление корпуса";
                    TBName.Text = "Корпус:";
                    break;
                case TableName.Role:
                    this.WindowTitle = "Добавление ролей";
                    TBName.Text = "Роль:";
                    break;
                case TableName.status:
                    this.WindowTitle = "Добавление статусов";
                    TBName.Text = "Статусы:";
                    break;
                case TableName.typecabinet:
                    this.WindowTitle = "Добавление типа кабинета";
                    TBName.Text = "Типы:";
                    break;
                default:
                    break;
            }
        }
            public AddEditShortPage(TableName tn, korpus kor = null, Role rl = null, status st = null, typecabinet type = null)
            {
                this.currentTable = tn;
                addOrEditFlag = false;

                this.korpus = kor;
                this.role = rl;
                this.status = st;
                this.typecabinet = type;
                InitializeComponent();

                switch (currentTable)
                {
                    case TableName.korpus:
                        this.WindowTitle = "Редактирование корпусов";
                        TBName.Text = "Корпус:";
                        TBShortName.Text = korpus.korpusname;
                        break;
                    case TableName.Role:
                        this.WindowTitle = "Редактирование ролей";
                        TBName.Text = "Роль:";
                        TBShortName.Text = role.Name;
                        break;
                    case TableName.status:
                        this.WindowTitle = "Редактирование статусов:";
                        TBName.Text = "Статус:";
                        TBShortName.Text = status.status1;
                        break;
                    case TableName.typecabinet:
                        this.WindowTitle = "Редактирование типов кабинета:";
                        TBName.Text = "Типы:";
                        TBShortName.Text = typecabinet.typecab;
                        break;
                    default:
                        break;
                }
            }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //(TableName)currentTable ct = new (TableName)currentTable();
            //CS8370: Feature 'top-level statements' is not available in C# 7.3. Please use language version 9.0 or greater.
            if (addOrEditFlag)
            {
                switch (currentTable)
                {
                    case TableName.korpus:
                        korpus korpus = new korpus()
                        {
                            korpusname = TBShortName.Text,
                        };
                        AppData.db.korpus.Add(korpus);
                        break;
                    case TableName.Role:
                        Role role = new Role()
                        {
                            Name = TBShortName.Text,
                        };
                        AppData.db.Role.Add(role);
                        break;
                    case TableName.status:
                        status status = new status()
                        {
                            status1 = TBShortName.Text,
                        };
                        AppData.db.status.Add(status);
                        break;
                    case TableName.typecabinet:
                        typecabinet typecabinet = new typecabinet() 
                        { typecab = TBShortName.Text, };
                        AppData.db.typecabinet.Add(typecabinet);
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена в таблицу!");
            }
            else
            {
                switch (currentTable)
                {
                    case TableName.korpus:
                        korpus.korpusname = TBShortName.Text;
                        break;
                    case TableName.Role:
                        role.Name = TBShortName.Text;
                        break;
                    case TableName.status:
                        status.status1 = TBShortName.Text;
                        break;
                    case TableName.typecabinet:
                        typecabinet.typecab = TBShortName.Text;
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Запись успешно изменена");
            }
            NavigationService.Navigate(new ShortPage(currentTable));
        }




    }
}
