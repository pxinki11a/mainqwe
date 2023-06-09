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
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace qwe
{
    /// <summary>
    /// Логика взаимодействия для AddCab.xaml
    /// </summary>
    public partial class AddCab : Page
    {

        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
        public string selectefFileName;
        public string extension = "";

        public cabinet currentCabinet;

        public AddCab()
        {
            InitializeComponent();
        }

        public AddCab(cabinet cabinet)
        {
            currentCabinet = cabinet;
            InitializeComponent();

            this.WindowTitle = "Редактирование кабинета";

            TBCabNum.Text = currentCabinet.namecab;
            TBTypeCab.Text = Convert.ToString(currentCabinet.typecabinet.name);
            TBKorpus.Text = Convert.ToString(currentCabinet.korpus.name);
            TBStatus.Text = Convert.ToString(currentCabinet.status.name);
            if (currentCabinet.photo != null)
            {
                _mainImageData = File.ReadAllBytes(path + currentCabinet.photo);
                Imageqwe.Source = new ImageSourceConverter().ConvertFrom(_mainImageData) as ImageSource;
            }
        }

    }
}
