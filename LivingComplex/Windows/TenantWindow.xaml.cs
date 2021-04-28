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

namespace LivingComplex.Windows
{
    /// <summary>
    /// Логика взаимодействия для TenantWindow.xaml
    /// </summary>
    public partial class TenantWindow : Window, INotifyPropertyChanged
    {
        
       
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        TenantLogin Tenant;
        /// <summary>
        /// Observable collections
        /// </summary>
        /// <returns></returns>
        
        
        public TenantWindow(TenantLogin tenantLogged)
        {
            Tenant = tenantLogged;
            InitializeComponent();
            
            DataContext = this;
            var service = CN.c.Service.Select(i => i.ServiceName).ToList();
            CreateService_ComboBox.ItemsSource = service;
            Update();
        }
        /// <summary>
        /// Method for updating information
        /// </summary>
        private void Update()
        {
            var offersCollection = CN.c.Offers.ToList();
            var tenantsourseCollection = CN.c.Tenants.ToList();

            /// <summary>
            /// Getting address for label
            /// <summary>
            IEnumerable<int> FlatNumberquery =
             from Flats in CN.c.Flats
             where Flats.idFlat == Tenant.FlatID
             select Flats.FlatNumber;
            
            IEnumerable<int> HouseNumberquery =
                from Flats in CN.c.Flats
                where Flats.idFlat == Tenant.FlatID
                select Flats.HouseNumber;

            IEnumerable<int> StreetNumberquery =
                from Flats in CN.c.Flats
                where Flats.idFlat == Tenant.FlatID
                select Flats.StreetNumber;
            int StreetNumber = StreetNumberquery.First();
            IEnumerable<string> StreetNamequery =
                from Streets in CN.c.Streets
                where Streets.idStreet == StreetNumber
                select Streets.StreetName;
            int FlatNumber = FlatNumberquery.First();
            int HouseNumber = HouseNumberquery.First();
            string StreetName = StreetNamequery.First();
            string Address = "Улица " + StreetName + " Дом №" + HouseNumber + " Квартира №" + FlatNumber;
            CreateService_ComboBox.ItemsSource = CN.c.Service.Select(i => i.ServiceName).ToList();
            Address_label.Content = Address;
            /// <summary>
            /// Sorting collections to show row with right FlatID
            /// <summary>
            offersCollection = offersCollection.Where(i => i.OfferSenderFlatID == Tenant.FlatID).OrderByDescending(i=>i.idOffer).ToList() ;
            tenantsourseCollection = tenantsourseCollection.Where(i => i.FlatID == Tenant.FlatID).ToList();
            
            TenantView.ItemsSource = tenantsourseCollection;
            OffersList.ItemsSource = offersCollection;
            
        }
        
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow log = new LoginWindow();
            this.Close();
            log.Show();
        }

        private void MainTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        

        private void ShortDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ShortDescription.Text == "")
            {
                ShortDescription.Text = "Опишите проблему...";
            }
        }

        private void ShortDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            if(ShortDescription.Text == "Опишите проблему...")
            {
                ShortDescription.Text = "";
            }
        }

        private void CreateService_btn_Click(object sender, RoutedEventArgs e)
        {
            if (ShortDescription.Text != "")
            {
                if(ShortDescription.Text != "Опишите проблему...")
                {
                    CN.c.Offers.Add(new Offers
                    {
                        OfferSenderFlatID = Tenant.FlatID,
                        Service = CreateService_ComboBox.SelectedIndex,
                        ShortDescription = ShortDescription.Text,
                        CreateDate = System.DateTime.Now,
                        StatusID = 2

                    });
                    try
                    {
                        CN.c.SaveChanges();
                        MessageBox.Show("Успешно создана заявка", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString()) ;
                    }
                }
                else 
                {
                    MessageBox.Show("Опишите проблему", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            Update();
        }

        private void TenantView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(TenantView.SelectedItem is Tenants tenant)
            {
                TenantFullInfo tfi = new TenantFullInfo(tenant);
                tfi.ShowDialog();
            }
        }
        private void OffersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (OffersList.SelectedItem is Offers offers)
            {
                OfferFullInfo ofi = new OfferFullInfo(offers);
                ofi.ShowDialog();
            }

        }
    }
}
