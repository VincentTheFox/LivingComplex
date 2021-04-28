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
    /// Логика взаимодействия для EmployeeInfo.xaml
    /// </summary>
    public partial class EmployeeFullInfo : Window
    {
        
        public EmployeeFullInfo(Employers employee)
        {
            
            InitializeComponent();
            string bddate = employee.BirthdayDate.ToString();
            string wsdate = employee.WorkingStartDate.ToString();
            string ws = wsdate.Substring(0, 10);
            string bd = bddate.Substring(0, 10);
            IEnumerable<string> gendernamequery =
                from Gender in CN.c.Gender
                where Gender.idGender == employee.Gender
                select Gender.GenderName;
            string GenderNameInfo = gendernamequery.First();
            IEnumerable<string> employeepostquery =
                from EmployeePost in CN.c.EmployeePost
                where EmployeePost.idEmployeePost == employee.EmployeePostID
                select EmployeePost.EmployeePostName;
            string EmployeePostName = employeepostquery.First();
            EmployeeID.Content = employee.idEmployee;
            FullName_label.Content = employee.EmployeeFullName;
            Gender_label.Content = GenderNameInfo;
            Email_label.Content = employee.Email;
            Phone_label.Content = employee.Phone;
            Age_label.Content = employee.Age + " лет";
            INN_label.Content = employee.INN;
            Snils_label.Content = employee.SNILS;
            Post_Label.Content = EmployeePostName;
            WorkingStartDate.Content = ws;
            BirthdayDate_label.Content = bd;
            RateFactor.Content = employee.RateFactor.RateFactor1;
            ContractNumber.Content = employee.ContractNumber;
            PassportNumber.Content = employee.PassportSerial + " " + employee.PassportNumber;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
