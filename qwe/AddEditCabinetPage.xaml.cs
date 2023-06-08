﻿using qwe;
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
    /// Логика взаимодействия для AddEditCabinetPage.xaml
    /// </summary>
    public partial class AddEditCabinetPage : Page
    {

        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
        public string selectefFileName;
        public string extension = "";

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

        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "Фото | *.png; *.jpg; *.jpeg";
                if (ofd.ShowDialog() == true)
                {
                    img = Path.GetFileName(ofd.FileName);
                    extension = Path.GetExtension(img);
                    selectefFileName = ofd.FileName;
                    _mainImageData = File.ReadAllBytes(ofd.FileName);
                    ImagePFP.Source = new ImageSourceConverter()
                        .ConvertFrom(_mainImageData) as ImageSource;
                }
        }
    }
}
