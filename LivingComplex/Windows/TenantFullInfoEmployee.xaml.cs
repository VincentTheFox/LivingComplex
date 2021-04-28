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
    public partial class TenantFullInfoEmployee : Window
    {
        Tenants tenant;
        public TenantFullInfoEmployee(Tenants tenantshowinfo)
        {
            tenant = tenantshowinfo;
            InitializeComponent();
            var tenantstatuses = CN.c.TenantStatus.Select(i => i.StatusName).ToList();
            tenantstatuses.Insert(0, "Не менять");
            StatusBox.ItemsSource = tenantstatuses;
            Update();

        }
        private void Update()
        {
            string bddate = tenant.BirthdayDate.ToString();
            string bd = bddate.Substring(0, 10);
            IEnumerable<string> gendernamequery =
                from Gender in CN.c.Gender
                where Gender.idGender == tenant.GenderID
                select Gender.GenderName;
            string GenderNameInfo = gendernamequery.First();

            IEnumerable<string> tenantstatusquery =
                from TenantStatus in CN.c.TenantStatus
                where TenantStatus.idStatusTenant == tenant.TenantStatusID
                select TenantStatus.StatusName;
            string StatusNameInfo = tenantstatusquery.First();
            FullName_label.Text = tenant.FullName;
            BirthDayDate_label.Text = " " + bd;
            Gender_label.Text = GenderNameInfo;
            Email_label.Text = tenant.Email;
            Phone_label.Text = tenant.Phone;
            Age_label.Text = tenant.Age.ToString();
            TenantStatusLabel_label.Content = StatusNameInfo;
            INN_label.Text = tenant.INN.ToString();
            Snils_label.Text = tenant.SNILS.ToString();
            PassportNumber.Text = tenant.PassportNumber.ToString();
            PassportSerial.Text = tenant.PassportSerial.ToString();
            StatusBox.SelectedItem = tenant.TenantStatus;
            if (ChangeBox.IsChecked == true)
            {
                FullName_label.IsReadOnly = false;
                BirthDayDate_label.IsReadOnly = false;
                Gender_label.IsReadOnly = false;
                Email_label.IsReadOnly = false;
                Phone_label.IsReadOnly = false;
                Age_label.IsReadOnly = false;
                
                INN_label.IsReadOnly = false;
                Snils_label.IsReadOnly = false;
                PassportNumber.IsReadOnly = false;
                PassportSerial.IsReadOnly = false;
                PassportNumber.IsReadOnly = false;
                Change_Button.IsEnabled = true;
            }
            else
            {
                Change_Button.IsEnabled = true;
                FullName_label.IsReadOnly = true;
                BirthDayDate_label.IsReadOnly = true;
                Gender_label.IsReadOnly = true;
                Email_label.IsReadOnly = true;
                Phone_label.IsReadOnly = true;
                Age_label.IsReadOnly = true;
                
                INN_label.IsReadOnly = true;
                Snils_label.IsReadOnly = true;
                PassportSerial.IsReadOnly = true;
                PassportNumber.IsReadOnly = true;
                Change_Button.IsEnabled = false;
                
            }
        }
        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void Change_Button_Click(object sender, RoutedEventArgs e)
        {
            tenant.PassportNumber = Convert.ToInt32(PassportNumber.Text);
            tenant.PassportSerial = Convert.ToInt32(PassportSerial.Text);
            tenant.INN = Convert.ToInt64(INN_label.Text);
            tenant.SNILS = Convert.ToInt64(Snils_label.Text);
            tenant.BirthdayDate = Convert.ToDateTime(BirthDayDate_label.Text);
            if (Gender_label.Text == "Мужской")
            {
                tenant.GenderID = 1;
            }
            else if (Gender_label.Text == "Женский")
            {
                tenant.GenderID = 2;
            }
            tenant.Age = Convert.ToInt32(Age_label.Text);
            tenant.Email = Email_label.Text;
            tenant.Phone = Phone_label.Text;
            switch (StatusBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    tenant.TenantStatusID = 1;
                    break;
                case 2:
                    tenant.TenantStatusID = 2;
                    break;
                case 3:
                    tenant.TenantStatusID = 3;
                    break;
            }
            try
            {
                CN.c.SaveChanges();
                MessageBox.Show("Успешно изменено", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при изменении", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }

        private void ChangeBox_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Change_Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
