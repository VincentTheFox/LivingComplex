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
    /// Логика взаимодействия для TenantFullInfo.xaml
    /// </summary>
    public partial class TenantFullInfo : Window
    {
        Tenants tenant;
        public TenantFullInfo(Tenants tenantshowinfo)
        {
            tenant = tenantshowinfo;
            InitializeComponent();
            string bddate = tenant.BirthdayDate.ToString();
            string bd = bddate.Substring(0, 10);
           
            FullName_label.Content = tenant.FullName;
            BirthDayDate_label.Text = " " + bd;
            Gender_label.Content = tenant.Gender.GenderName;
            Email_label.Content = tenant.Email;
            Phone_label.Content = tenant.Phone;
            Age_label.Content = tenant.Age + " лет";
            TenantStatusLabel_label.Content =tenant.TenantStatus.StatusName;
            INN_label.Content = tenant.INN;
            Snils_label.Content = tenant.SNILS;
            PassportNumber.Content = tenant.PassportSerial + " " + tenant.PassportNumber;


        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
