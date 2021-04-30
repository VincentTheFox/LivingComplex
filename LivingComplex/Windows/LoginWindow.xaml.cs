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
using System.Windows.Shapes;
using LivingComplex.Entity;
namespace LivingComplex.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }


        private void LoginBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == "Введите логин")
            {
                LoginBox.Text = "";
            }
        }

        private void LoginBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == "Введите логин")
            {
                LoginBox.Text = "";
            }
        }

        private void LogIn_btn_Click(object sender, RoutedEventArgs e)
        {
            var userLogin = CN.c.TenantLogin.Where(i => i.Login == LoginBox.Text && i.Password == PasswordBox.Password).FirstOrDefault();
            if (userLogin != null && userLogin.RoleID == 2)
            {
                string pass = userLogin.Password;
                pass = pass.Substring(0, 8);
                if (pass == "Password")
                {
                    MessageBox.Show("Похоже вы зашли первый раз, пожалуйста измените пароль", "Первый раз?", MessageBoxButton.OK, MessageBoxImage.Information);
                    FTChangePassword ftc = new FTChangePassword(userLogin);
                    ftc.ShowDialog();
                }
                else
                {
                    TenantWindow tnt = new TenantWindow(userLogin);
                    this.Close();

                    tnt.Show();
                }
            }
            else if (userLogin == null)
            {
                var empLogin = CN.c.EmployeeLogin.Where(i => i.Login == LoginBox.Text && i.Password == PasswordBox.Password).FirstOrDefault();
                if (empLogin != null)
                {
                    ClassHelper.UserDataClass.employee = empLogin;

                    EmployeeWindow emp = new EmployeeWindow(empLogin);
                    emp.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("No such user or wrong data");
                }

            }
        }
    }
}
