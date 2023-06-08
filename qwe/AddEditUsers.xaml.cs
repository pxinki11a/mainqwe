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
    /// Логика взаимодействия для AddEditUsers.xaml
    /// </summary>
    public partial class AddEditUsers : Page
    {

        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
        public string selectefFileName;
        public string extension = "";
        public User currentUser;
        public AddEditUsers()
        {
            InitializeComponent();
            this.WindowTitle = "Добавление пользователя";
        }

        public AddEditUsers(User user)
        {
            currentUser = user;
            InitializeComponent();

            this.WindowTitle = "Редактирование пользователя";

            TBUserSurname.Text = currentUser.surname;
            TBUserName.Text = currentUser.name;
            TBUserPatronymic.Text = currentUser.patronymic;
            TBUseremail.Text = currentUser.email;
            TBUserLogin.Text = currentUser.login;
            TBUserPass.Password = currentUser.password;
            TBUserRole.Text = currentUser.roleID.ToString();
            if (currentUser.image != null)
            {
                _mainImageData = File.ReadAllBytes(path + currentUser.image);
                Imageqwe.Source = new ImageSourceConverter().ConvertFrom(_mainImageData) as ImageSource;
            }
        }

            private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
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
                    Imageqwe.Source = new ImageSourceConverter()
                        .ConvertFrom(_mainImageData) as ImageSource;
                }

            }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser == null)
            {
                User user = new User()
                {
                    name = TBUserName.Text,
                    surname = TBUserSurname.Text,
                    patronymic = TBUserPatronymic.Text,
                    email = TBUseremail.Text,
                    login = TBUserLogin.Text,
                    password = TBUserPass.Password,
                    roleID = Int32.Parse(TBUserRole.Text),
                    image = img
                };
                AppData.db.User.Add(user);
                AppData.db.SaveChanges();
                MessageBox.Show("Пользователь успешно добавлен!");
            }
            else if (currentUser.image != img || currentUser.name != TBUserName.Text || currentUser.surname != TBUserSurname.Text || currentUser.patronymic != TBUserPatronymic.Text | currentUser.email != TBUseremail.Text | currentUser.login != TBUserLogin.Text | currentUser.password != TBUserPass.Password | currentUser.roleID != TBUserRole.TabIndex)
            {
                currentUser.name = TBUserName.Text;
                currentUser.surname = TBUserSurname.Text;
                currentUser.patronymic = TBUserPatronymic.Text;
                currentUser.email = TBUseremail.Text;
                currentUser.login = TBUserLogin.Text;
                currentUser.password = TBUserPass.Password;
                currentUser.roleID = Int32.Parse(TBUserRole.Text);
                currentUser.image = img;
                AppData.db.SaveChanges();
                MessageBox.Show("Пользователь успешно обновлен!");
                currentUser = null;
            }
            NavigationService.Navigate(new UserPage());
        }
        private void PBPass_Changed(object sender, RoutedEventArgs e)
        {
            string password = TBUserPass.Password.ToString();
            Regex strongPass = new Regex(@"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{6,}");
            MatchCollection strongMatch = strongPass.Matches(password);
            if (strongMatch.Count > 0)
            {
                TBPassStrength.Text = "Средний пароль";
                TBPassStrength.Foreground = Brushes.LightCoral;

            }
            else
            {
                TBPassStrength.Text = "Легкий пароль";
                TBPassStrength.Foreground = Brushes.Green;

            }

            if (TBUserPass.Password != PBPassAgain.Password)
            {
                bsave.IsEnabled = false;
                TBUserPass.Background = Brushes.LightCoral;
                TBUserPass.Foreground = Brushes.Red;
                PBPassAgain.Background = Brushes.LightCoral;
                PBPassAgain.Foreground = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(TBUserPass.Password.ToString()) || String.IsNullOrEmpty(PBPassAgain.Password.ToString()))
            {
                bsave.IsEnabled = false;
                TBUserPass.Background = default;
                TBUserPass.Foreground = default;
                PBPassAgain.Background = default;
                PBPassAgain.Foreground = default;
                TBPassStrength.Visibility = Visibility.Collapsed;
            }
            else
            {
                bsave.IsEnabled = true;
                TBUserPass.Background = Brushes.LightGreen;
                TBUserPass.Foreground = Brushes.Green;
                PBPassAgain.Background = Brushes.LightGreen;
                PBPassAgain.Foreground = Brushes.Green;
            }
        }
        private void TBLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AppData.db.User.Count(x => x.login == TBUserLogin.Text) > 0)
            {
                TBLoginError.Visibility = Visibility.Visible;
            }
            else
            {
                TBLoginError.Visibility = Visibility.Collapsed;
            }
        }
        
        }

    }

