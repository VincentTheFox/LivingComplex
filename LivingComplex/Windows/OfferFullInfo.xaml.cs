using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Логика взаимодействия для OfferFullInfo.xaml
    /// </summary>
    public partial class OfferFullInfo : Window
    {
        Offers Offfer;
        public OfferFullInfo(Offers offer)
        {
            Offfer = offer;
            InitializeComponent();
            
            ShortDescription_text.Text = " " + offer.ShortDescription;
            
            OfferStatus.Content = "Статус заявки: " + offer.TaskStatus.TaskStatusName;
           
            ServiceType.Content = "Услуга: " + offer.Service1.ServiceName;
            
            if (offer.Photo != null)
            {
                using (MemoryStream stream = new MemoryStream(CN.c.Offers.Where(i => i.idOffer == offer.idOffer).Select(i => i.Photo).FirstOrDefault()))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    OfferImage.Source = bitmapImage;
                }
            }
            CreateData.Content = "Дата заявки: " + offer.CreationDate;
            Address.Content = GetAddress(offer);




        }
        private string GetAddress(Offers offer)
        {
            IEnumerable<int> FlatNumberquery =
                from Flats in CN.c.Flats
                where Flats.idFlat == offer.OfferSenderFlatID
                select Flats.FlatNumber;

            IEnumerable<int> HouseNumberquery =
                from Flats in CN.c.Flats
                where Flats.idFlat == offer.OfferSenderFlatID
                select Flats.HouseNumber;

            IEnumerable<int> StreetNumberquery =
                from Flats in CN.c.Flats
                where Flats.idFlat == offer.OfferSenderFlatID
                select Flats.StreetNumber;
            int StreetNumber = StreetNumberquery.First();
            IEnumerable<string> StreetNamequery =
                from Streets in CN.c.Streets
                where Streets.idStreet == StreetNumber
                select Streets.StreetName;
            int FlatNumber = FlatNumberquery.First();
            int HouseNumber = HouseNumberquery.First();
            string StreetName = StreetNamequery.First();
            return "Улица " + StreetName + "\nДом №" + HouseNumber + "\nКвартира №" + FlatNumber;
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangStatusButm_Click(object sender, RoutedEventArgs e)
        {/*
            from Offers in CN.c.Offers
            where Offers.idOffer == Offfer.idOffer
            update
            */
        }
    }
}

