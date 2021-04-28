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
    public partial class EmployeeFullInfoEmployee : Window
    {
        Employers employers;
        public EmployeeFullInfoEmployee(Employers employee)
        {
            employers = employee;
            InitializeComponent();
            var employeeposts = CN.c.EmployeePost.Select(i => i.EmployeePostName).ToList();
            employeeposts.Insert(0, "Не менять");
            var ratefactors = CN.c.RateFactor.Select(i => i.RateFactor1).ToList();
            ratefactors.Insert(0, 0);
            RateBox.ItemsSource = ratefactors;
            PostBox.ItemsSource = employeeposts;
            Update();
        }
        private void Update()
        {

            string bddate = employers.BirthdayDate.ToString();
            string wsdate = employers.WorkingStartDate.ToString();
            string ws = wsdate.Substring(0, 10);
            string bd = bddate.Substring(0, 10);
            IEnumerable<string> gendernamequery =
                from Gender in CN.c.Gender
                where Gender.idGender == employers.Gender
                select Gender.GenderName;
            string GenderNameInfo = gendernamequery.First();
            IEnumerable<string> employeepostquery =
                from EmployeePost in CN.c.EmployeePost
                where EmployeePost.idEmployeePost == employers.EmployeePostID
                select EmployeePost.EmployeePostName;
            string EmployeePostName = employeepostquery.First();
            EmployeeID.Text = employers.idEmployee.ToString();
            FullName_label.Text = employers.EmployeeFullName;
            Gender_label.Text = GenderNameInfo;
            Email_label.Text = employers.Email;
            Phone_label.Text = employers.Phone;
            Age_label.Text = employers.Age.ToString();
            INN_label.Text = employers.INN.ToString();
            Snils_label.Text = employers.SNILS.ToString();
            PostBox.SelectedItem = employers.EmployeePostID;
            Post_Label.Content = EmployeePostName;
            WorkingStartDate.Text = ws;
            BirthdayDate_label.Text = bd;
            RateFactor.Content = employers.RateFactor.RateFactor1.ToString();
            ContractNumber.Text = employers.ContractNumber;
            PassportNumber.Text = employers.PassportNumber.ToString();
            PassportSerial.Text = employers.PassportSerial.ToString();

            if (ChangeBox.IsChecked == true)
            {
                FullName_label.IsReadOnly = false;
                BirthdayDate_label.IsReadOnly = false;
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
                BirthdayDate_label.IsReadOnly = true;
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

        private void ChangeBox_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Change_Button_Click(object sender, RoutedEventArgs e)
        {
            employers.PassportNumber = Convert.ToInt32(PassportNumber.Text);
            employers.PassportSerial = Convert.ToInt32(PassportSerial.Text);
            employers.INN = Convert.ToInt64(INN_label.Text);
            employers.SNILS = Convert.ToInt64(Snils_label.Text);
            employers.BirthdayDate = Convert.ToDateTime(BirthdayDate_label.Text);
            if (Gender_label.Text == "Мужской")
            {
                employers.Gender = 1;
            }
            else if (Gender_label.Text == "Женский")
            {
                employers.Gender = 2;
            }
            switch (RateBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    employers.RateFactorID = 1;
                    break;
                case 2:
                    employers.RateFactorID = 2;
                    break;
                case 3:
                    employers.RateFactorID = 3;
                    break;
            }
            switch (PostBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    employers.EmployeePostID = 1;
                    break;
                case 2:
                    employers.EmployeePostID = 2;
                    break;
                case 3:
                    employers.EmployeePostID = 3;
                    break;
                case 4:
                    employers.EmployeePostID = 4;
                    break;
                case 5:
                    employers.EmployeePostID = 5;
                    break;
                case 6:
                    employers.EmployeePostID = 6;
                    break;
                case 7:
                    employers.EmployeePostID = 7;
                    break;
            }


            employers.Age = Convert.ToInt32(Age_label.Text);
            employers.Email = Email_label.Text;
            employers.Phone = Phone_label.Text;
            employers.WorkingStartDate = Convert.ToDateTime(WorkingStartDate.Text);
            employers.ContractNumber = ContractNumber.Text;


            try
            {
                CN.c.SaveChanges();
                MessageBox.Show("Успешно изменено", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

       
    

