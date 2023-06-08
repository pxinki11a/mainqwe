using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using System.Xml.Linq;

namespace qwe
{
    /// <summary>
    /// Логика взаимодействия для AddEditCabinetPage.xaml
    /// </summary>
    public partial class AddEditCabinetPage : Page
    {
        public cabinet currentCabinet;
        public AddEditCabinetPage()
        {
            InitializeComponent();
            this.WindowTitle = "Добавление кабинета";
        }
        public AddEditCabinetPage(cabinet cabinet)
        {
            currentCabinet = cabinet;
            InitializeComponent();

            this.WindowTitle = "Редактирование кабинета";

            TBCabNum.Text = currentCabinet.namecab;
            TBTypeCab.Text = Convert.ToString(currentCabinet.id_typecab);
            TBKorpus.Text = Convert.ToString(currentCabinet.id_korpus);
            TBStatus.Text = Convert.ToString(currentCabinet.id_status);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentCabinet == null)
            {
                cabinet cabinet = new cabinet()
                {
                    namecab = TBCabNum.Text,
                    id_typecab = Int32.Parse(TBTypeCab.Text),
                    id_korpus = Int32.Parse(TBKorpus.Text),
                    id_status = Int32.Parse(TBStatus.Text),
                };
                AppData.db.cabinet.Add(cabinet);
                AppData.db.SaveChanges();
                MessageBox.Show("Кабинет успешно добавлен!");
            }
            else if (currentCabinet.namecab != TBCabNum.Text || currentCabinet.id_typecab != Int32.Parse(TBTypeCab.Text) || currentCabinet.id_korpus != Int32.Parse(TBKorpus.Text) || currentCabinet.id_status != Int32.Parse(TBStatus.Text))
            {
                currentCabinet.namecab = TBCabNum.Text;
                currentCabinet.id_typecab = Int32.Parse(TBTypeCab.Text);
                currentCabinet.id_korpus = Int32.Parse(TBKorpus.Text);
                currentCabinet.id_status = Int32.Parse(TBStatus.Text);

                AppData.db.SaveChanges();
                MessageBox.Show("Кабинет успешно обновлен!");
                currentCabinet = null;
            }
        }
    }
}
