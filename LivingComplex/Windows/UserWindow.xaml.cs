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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow(EmployeeLogin employer)
        {
            InitializeComponent();
            Loginlabel.Content = employer.Login;
            Passowrdlabel.Content = employer.Password;
            Rolelabel.Content = employer.Roles.RoleName;
            IEnumerable<string> firstNamequery =
                from Employers in CN.c.Employers
                where Employers.idEmployee == employer.idEmployee
                select Employers.FirstName;
            IEnumerable<string> lastNamequery =
                from Employers in CN.c.Employers
                where Employers.idEmployee == employer.idEmployee
                select Employers.LastName;
            IEnumerable<string> patrNamequery =
                from Employers in CN.c.Employers
                where Employers.idEmployee == employer.idEmployee
                select Employers.Patronymic;
            string fullname = lastNamequery.First() + " " + firstNamequery.First() + " " + patrNamequery.First();
            FullNameEmplabel.Content = fullname;
            idEmpLabel.Content = employer.idEmployee;
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
