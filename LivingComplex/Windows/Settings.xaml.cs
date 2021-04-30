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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        TenantLogin Tenant;
        public Settings(TenantLogin tenant)
        {
            Tenant = tenant;
            InitializeComponent();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            string newlogin = LoginBox.Text;
            string newpassword = NewPasswordBox.Password;
            if(OldPasswordbox.Password == Tenant.Password)
            {
                if (newlogin != "" && newpassword != "")
                {
                    string nps = NewPasswordBox.Password;

                    if (nps.Length > 13 && !nps.Contains("Password") && !nps.Contains("qwe") && !nps.Contains("123") && !nps.Contains("321") && newlogin.Length > 13 && NewPasswordBox.Password == RENewPasswordBox.Password)
                    {
                        Tenant.Password = newpassword;
                        Tenant.Login = newlogin;
                        try
                        {
                            CN.c.SaveChanges();
                            MessageBox.Show("Успешно изменено", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Что-то пошло не так", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль и логин не должны содержать сочетания qwe, 321, 123, Password, а также быть больше 13 символов", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if(newlogin != "" && newpassword == "")
                {
                    if(newlogin.Length > 13 && !newlogin.Contains("qwe") && !newlogin.Contains("123") && !newlogin.Contains("qwe"))
                    {
                        Tenant.Login = newlogin;
                        try
                        {
                            CN.c.SaveChanges();
                            MessageBox.Show("Успешно изменено", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Что-то пошло не так", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }
                else if(newpassword != "" && newlogin == "")
                {
                    if (newpassword.Length > 13 && !newpassword.Contains("Password") && !newpassword.Contains("qwe") && !newpassword.Contains("123") && !newpassword.Contains("321") && NewPasswordBox.Password == RENewPasswordBox.Password)
                    {
                        Tenant.Password = newpassword;
                        try
                        {
                            CN.c.SaveChanges();
                            MessageBox.Show("Успешно изменено", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Что-то пошло не так", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль не должен содержать сочетания qwe, 321, 123, Password, а также быть больше 13 символов", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Данные не изменены", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                MessageBox.Show("Вы ввели неправильный старый пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
