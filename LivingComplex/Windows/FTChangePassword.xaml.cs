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
    /// Логика взаимодействия для FTChangePassword.xaml
    /// </summary>
    public partial class FTChangePassword : Window
    {
        TenantLogin Tnt;
        public FTChangePassword(TenantLogin tnt)
        {
            Tnt = tnt;
            InitializeComponent();
        }

        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            if ((NewPasswordBox.Password == RENewPasswordBox.Password) && OldPasswordbox.Password == Tnt.Password) 
            {
                string nps = NewPasswordBox.Password;

                if (nps.Length > 13 && !nps.Contains("Password") && !nps.Contains("qwe") && !nps.Contains("123") && !nps.Contains("321"))
                {
                    Tnt.Password = NewPasswordBox.Password;
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
                MessageBox.Show("Пароли не совпадают", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
