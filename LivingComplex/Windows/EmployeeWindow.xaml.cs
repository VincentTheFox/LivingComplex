using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static LivingComplex.Entity.CN;

namespace LivingComplex.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    
    public partial class EmployeeWindow : Window, INotifyPropertyChanged
    {

       
        /// <summary>
        /// Properties for pages and rows
        /// </summary>
        public int RowsAmount { get; set; } = 0;
        public int RowsShowed { get; set; } = 0;
        public double AllPages { get; set; } = 1;
        public int Page { get; set; } = 0;

        /// <summary>
        /// Properties for filtering
        /// </summary>
        public string Search { get; set; } = "";
        public string ServiceFilter { get; set; } = "Все услуги";
        public string OfferDate { get; set; } = "Без сортировки";
        public string SortType { get; set; } = "Отсутствует";
        public string SortTypeOffers { get; set; } = "Отсутствует";
        public string SortPole { get; set; } = "Без сортировки";
        EmployeeLogin Employeer;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        /// <summary>
        /// Observable Collections for database tables
        /// </summary>
        
       
        List<Offers> offerssource = new List<Offers>();
        List<History> historysource = new List<History>();
        List<Tenants> tenantsource = new List<Tenants>();
        List<Employers> employeesource = new List<Employers>();
        List<EmployeeLogin> emploginsource = new List<EmployeeLogin>();
        List<TenantLogin> tenloginsource = new List<TenantLogin>();
        public EmployeeWindow(EmployeeLogin employeeLogged)
        {

            Employeer = employeeLogged;
            InitializeComponent();
            DataContext = this;
            
         /// Lists for ComboBoxes
           
            var offerdatelist = new List<string>
            {
                "Без сортировки",
                "Дата создания",
                "Дата обновления",
            };
            var SortTypeList = new List<string> {
                "Отсутствует",
                "По возрастанию",
                "По убыванию",
                
            };
            SortPoleCombobox.ItemsSource = new List<string>
            {
                "Без сортировки",
                "Дата рождения",
                "СНИЛС",
                "ИНН",
                "Серия паспорта",
                "Номер паспорта",
               
            };
            var filter = c.Service.Select(i => i.ServiceName).ToList() ;
            filter.Insert(0, "Все услуги");
            ServiceFilterBox.ItemsSource = filter;
            SortTypeComboBox.ItemsSource = SortTypeList.ToList();
            Update();

        }
        /// <summary>
        /// Observable collectios templates
        /// </summary>
  
        /// <summary>
        /// Method for updation information in app
        /// </summary>
        private void Update()
        {
            
            if (MainTabs.SelectedItem == tenanttab)
            {
                AddTenantButton.Visibility = Visibility.Visible;
            }
            else
            {
                AddTenantButton.Visibility = Visibility.Hidden;
            }
            if (MainTabs.SelectedItem == employeetab)
            {
                AddEmployeeButton.Visibility = Visibility.Visible;
            }
            else
            {
                AddEmployeeButton.Visibility = Visibility.Hidden;
            }

            employeesource = c.Employers.ToList();
            historysource = c.History.ToList();
            offerssource = c.Offers.ToList();
            
            tenantsource = c.Tenants.ToList();
            emploginsource = c.EmployeeLogin.ToList();
            tenloginsource = c.TenantLogin.ToList();
            /// <summary>
            /// Filtering for tenanttab and table Tenants
            /// <summary>
            if (string.IsNullOrEmpty(Search) != true)
            {
                string search = Search.ToLower();
                tenantsource = tenantsource.Where(i => i.FirstName.ToLower().Contains(search) || i.LastName.ToLower().Contains(search) || i.Patronymic.ToLower().Contains(search) == true).ToList();
            }
            else
            {
                tenantsource = tenantsource.ToList();
            }
            if (SortType != "Отсутcтвует")
            {
                SortPoleCombobox.IsEnabled = true;
                var ascending = SortType == "По возрастанию";
                switch (SortPole)
                {
                    case "Дата рождения":
                        if (ascending)
                        {
                            tenantsource = tenantsource.OrderBy(i => i.Birthday).ToList();
                        }
                        else
                        {
                            tenantsource = tenantsource.OrderByDescending(i => i.Birthday).ToList();
                        }
                        break;
                    case "СНИЛС":
                        if (ascending)
                        {
                            tenantsource = tenantsource.OrderBy(i => i.SNILS).ToList();
                        }
                        else
                        {
                            tenantsource = tenantsource.OrderByDescending(i => i.SNILS).ToList();
                        }
                        break;
                    case "ИНН":
                        if (ascending)
                        {
                            tenantsource = tenantsource.OrderBy(i => i.INN).ToList();
                        }
                        else
                        {
                            tenantsource = tenantsource.OrderByDescending(i => i.INN).ToList();
                        }
                        break;
                    case "Серия паспорта":
                        if (ascending)
                        {
                            tenantsource = tenantsource.OrderBy(i => i.PassportSerial).ToList();
                        }
                        else
                        {
                            tenantsource = tenantsource.OrderByDescending(i => i.PassportSerial).ToList();
                        }
                        break;
                    case "Номер паспорта":
                        if (ascending)
                        {
                            tenantsource = tenantsource.OrderBy(i => i.PassportNumber).ToList();
                        }
                        else
                        {
                            tenantsource = tenantsource.OrderByDescending(i => i.PassportNumber).ToList();
                        }
                        break;
                    case "Без сортировки":
                        tenantsource = CN.c.Tenants.ToList();
                        break;
                }
            }
            else
            {
                tenantsource = tenantsource.ToList();
            }
            /// <summary>
            /// Filtering for Offerstab and table offers
            /// <summary>
            if (ServiceFilter != "Все услуги")
            {
                offerssource = offerssource.Where(i => i.Service1.ServiceName == ServiceFilter && i.TaskStatus.idTaskStatus == 2).ToList();
                
            }
            else
            {
                offerssource = c.Offers.Where(i=>i.TaskStatus.idTaskStatus == 2 || i.TaskStatus.idTaskStatus == 3).OrderByDescending(i=>i.idOffer).ToList();
            }
            
           
            
            switch (MainTabs.SelectedIndex)
            {
                case 0:
                    RowsAmount = tenantsource.Count();
                    AllPages = Math.Ceiling((float)RowsAmount / 200);
                    tenantsource = tenantsource.Skip(Page * 200).Take(200).ToList();

                    RowsShowed = tenantsource.Count();
                    if (tenantsource.Count < 200)
                    {
                        NextPageButton.IsEnabled = false;
                    }
                    else
                    {
                        NextPageButton.IsEnabled = true;
                    }
                    if (Page == 0)
                    {
                        PrevPageButton.IsEnabled = false;
                    }
                    else
                    {
                        PrevPageButton.IsEnabled = true;
                    }
                    break;
                case 1:
                    RowsAmount = offerssource.Count();
                    AllPages = Math.Ceiling((float)RowsAmount / 100);

                    offerssource = offerssource.Skip(Page * 100).Take(100).ToList();

                    RowsShowed = offerssource.Count();
                    if (offerssource.Count < 100)
                    {
                        NextPageButton.IsEnabled = false;
                    }
                    else
                    {
                        NextPageButton.IsEnabled = true;
                    }
                    if (Page == 0)
                    {
                        PrevPageButton.IsEnabled = false;
                    }
                    else
                    {
                        PrevPageButton.IsEnabled = true;
                    }
                    break;
                case 2:
                    RowsAmount = historysource.Count();
                    AllPages = Math.Ceiling((float)RowsAmount / 200);
                    historysource = historysource.Skip(Page * 200).Take(200).ToList();

                    RowsShowed = historysource.Count();
                    if (historysource.Count < 200)
                    {
                        NextPageButton.IsEnabled = false;
                    }
                    else
                    {
                        NextPageButton.IsEnabled = true;
                    }
                    if (Page == 0)
                    {
                        PrevPageButton.IsEnabled = false;
                    }
                    else
                    {
                        PrevPageButton.IsEnabled = true;
                    }
                    break;
                case 3:

                    RowsAmount = employeesource.Count();
                    AllPages = Math.Ceiling((float)RowsAmount / 50);
                    historysource = historysource.Skip(Page * 200).Take(200).ToList();
                    RowsShowed = employeesource.Count();

                    if (employeesource.Count < 50)
                    {
                        NextPageButton.IsEnabled = false;
                    }
                    else
                    {
                        NextPageButton.IsEnabled = true;
                    }
                    if (Page == 0)
                    {
                        PrevPageButton.IsEnabled = false;
                    }
                    else
                    {
                        PrevPageButton.IsEnabled = true;
                    }
                    break;
                case 4:
                    RowsAmount = tenloginsource.Count();
                    AllPages = Math.Ceiling((float)RowsAmount / 200);
                    tenloginsource = tenloginsource.Skip(Page * 200).Take(200).ToList();

                    RowsShowed = tenloginsource.Count();

                    if (tenloginsource.Count < 200)
                    {
                        NextPageButton.IsEnabled = false;
                    }
                    else
                    {
                        NextPageButton.IsEnabled = true;
                    }
                    if (Page == 0)
                    {
                        PrevPageButton.IsEnabled = false;
                    }
                    else
                    {
                        PrevPageButton.IsEnabled = true;
                    }
                    break;
                case 5:
                    RowsAmount = emploginsource.Count();
                    AllPages = Math.Ceiling((float)RowsAmount / 50);
                    emploginsource = emploginsource.Skip(Page * 50).Take(50).ToList();

                    RowsShowed = emploginsource.Count();

                    if (emploginsource.Count < 50)
                    {
                        NextPageButton.IsEnabled = false;
                    }
                    else
                    {
                        NextPageButton.IsEnabled = true;
                    }
                    if (Page == 0)
                    {
                        PrevPageButton.IsEnabled = false;
                    }
                    else
                    {
                        PrevPageButton.IsEnabled = true;
                    }
                    break;
            }
            
            OffersView.ItemsSource = offerssource;
            EmployeeView.ItemsSource = employeesource;
            HistoryView.ItemsSource = historysource;
            TenantView.ItemsSource = tenantsource;
            EmployeeLoginView.ItemsSource = emploginsource;
            TenantLoginView.ItemsSource = tenloginsource;
            
            PageBlock.Text = "Страница № " + (Page+1).ToString()+" из " +AllPages+"\nЗаписей "+ RowsShowed +" из " + RowsAmount;
        }

        

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow log = new LoginWindow();
            this.Close();
            log.Show();
            
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            Page++;
            Update();
        }

        private void PrevPageButton_Click(object sender, RoutedEventArgs e)
        {
            Page--;
            Update();
        }

        private void TenantView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(TenantView.SelectedItem is Tenants tenant)
            {

                TenantFullInfoEmployee tfi = new TenantFullInfoEmployee(tenant);
                tfi.ShowDialog();
                Update();
            }
        }

       

        private void OffersView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(OffersView.SelectedItem is Offers offer)
            {
                OfferFullInfoEmployee ofi = new OfferFullInfoEmployee(offer);
                ofi.ShowDialog();
            }
        }

        private void EmployeeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (EmployeeView.SelectedItem is Employers employee)
            {
                EmployeeFullInfoEmployee efi = new EmployeeFullInfoEmployee(employee);
                efi.ShowDialog();
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Page = 0;
            Update();
        }

        private void SearcBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Page = 0;
            Update();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            UserWindow usi = new UserWindow(Employeer);
            usi.ShowDialog();
        }

        private void AddTenantButton_Click(object sender, RoutedEventArgs e)
        {
            AddTenant adi = new AddTenant();
            adi.ShowDialog();
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee adi = new AddEmployee();
            adi.ShowDialog();
        }
    }
}
