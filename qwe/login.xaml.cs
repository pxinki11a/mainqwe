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
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                var currentUser = AppData.db.User.FirstOrDefault((u) => u.login == TBLogin.Text && u.password == TBPassword.Text);

                if (currentUser == null)
                {
                    MessageBox.Show("Такого пользователя не существует", "Ошибка авторизации");
                }
                else
                {
                    if (currentUser.login.Equals(TBLogin.Text) && currentUser.password.Equals(TBPassword.Text))
                    {
                        if (currentUser.roleID == 1)
                        {
                            AdminWindow admin = new AdminWindow(); //currentUser.userID
                            admin.Show();
                        }
                        else
                        {
                            UserWindow userWindow = new UserWindow();
                            userWindow.Show();
                        }
                        Window.GetWindow(this).Close();
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные логин и пароль", "Ошибка авторизации");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString());
            }
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new reg());
        }

        private void TBLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
