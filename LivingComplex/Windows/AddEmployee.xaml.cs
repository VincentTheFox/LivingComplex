using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public string GenderAdd { get; set; } = "Выберите пол";
        public string EmployeePostAdd { get; set; } = "Выберите должность";
        public double RateFactorAdd { get; set; }
        public AddEmployee()
        {
            InitializeComponent();
            var genderquery = CN.c.Gender.Select(i => i.GenderName).ToList();
            var Employeepostquery = CN.c.EmployeePost.Select(i => i.EmployeePostName).ToList();
            var ratefactorqury = CN.c.RateFactor.Select(i => i.RateFactor1).ToList();
            genderquery.Insert(0, "Выберите пол");
            Employeepostquery.Insert(0, "Выберите должность");
            EmployeePostCombobox.ItemsSource = Employeepostquery;
            RateFactorBox.ItemsSource = ratefactorqury;
            GenderBox.ItemsSource = genderquery;
            
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CN.c.Employers.Add(new Employers
                {
                    FirstName = FirstNameBox.Text,
                    LastName = LastNameBox.Text,
                    Patronymic = Patronymicbox.Text,
                    Age = Convert.ToInt32(Age.Text),
                    BirthdayDate = BirthdayDatePick.SelectedDate.Value,
                    WorkingStartDate = WorkingStartDatePick.SelectedDate.Value,
                    PassportSerial = Convert.ToInt32(PassportSerialBox.Text),
                    PassportNumber = Convert.ToInt32(PassportNumberBox.Text),
                    SNILS = Convert.ToInt32(SNILSBox.Text),
                    INN = Convert.ToInt32(INN.Text),
                    EmployeePostID = EmployeePostCombobox.SelectedIndex,
                    Gender = GenderBox.SelectedIndex, 
                    ContractNumber = ContractNumber.Text,
                    RateFactorID = RateFactorBox.SelectedIndex,
                    Email = EmailBox.Text,
                    Phone = PhoneBox.Text,
                    
                });
                MessageBox.Show("Успех");
                CN.c.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
