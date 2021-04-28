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
    /// Логика взаимодействия для AddTenant.xaml
    /// </summary>
    
    public partial class AddTenant : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public string GenderAdd { get; set; } = "Выберите пол";
        public string TenantStatusAdd { get; set; } = "Выюерите статус жильца";
        public AddTenant()
        {
            InitializeComponent();
            var gender = CN.c.Gender.Select(i => i.GenderName).ToList() ;
            gender.Insert(0, "Выберите пол");
            var tenantstatus = CN.c.TenantStatus.Select(i => i.StatusName).ToList();
            tenantstatus.Insert(0, "Выберите статус жильца");
            TenantStatusCombobox.ItemsSource = tenantstatus;
            GenderBox.ItemsSource = gender;
        }

        private void AddTenant_Button_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    CN.c.Tenants.Add(new Tenants
                    {
                        LastName = LastNameBox.Text,
                        FirstName = FirstNameBox.Text,
                        Patronymic = Patronymicbox.Text,
                        GenderID = GenderBox.SelectedIndex,
                        Age = Convert.ToInt32(Age.Text), 
                        Phone = PhoneBox.Text,
                        Email = EmailBox.Text,
                        FlatID = Convert.ToInt32(FlatID.Text),
                        TenantStatusID = TenantStatusCombobox.SelectedIndex,
                        BirthdayDate = BirthdayDate.SelectedDate.Value,
                        PassportNumber = Convert.ToInt32(PassportNumberBox.Text),
                        PassportSerial = Convert.ToInt32(PassportSerialBox.Text),
                        INN = Convert.ToInt32(INN.Text),
                        SNILS = Convert.ToInt64(SNILSBox.Text),

                    });
                    MessageBox.Show("Успех");
                    CN.c.SaveChanges();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            

        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FirstNameBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void FirstNameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(FirstNameBox.Text == "Имя")
            {
                FirstNameBox.Text = "";
            }
        }

      
        private void LastNameBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void LastNameBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Patronymicbox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Patronymicbox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Age_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Age_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void FlatID_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void FlatID_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PhoneBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PhoneBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void INN_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void INN_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SNILSBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SNILSBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PassportNumberBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PassportNumberBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PassportSerialBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PassportSerialBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void EmailBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void EmailBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
