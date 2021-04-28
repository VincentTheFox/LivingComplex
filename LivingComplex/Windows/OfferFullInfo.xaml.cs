﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            IEnumerable<string> ShortDescriptionQuery =
                from Offers in CN.c.Offers
                where Offers.idOffer == offer.idOffer
                select Offers.ShortDescription;
            string ShortDescription = ShortDescriptionQuery.First();
            ShortDescription_text.Text = " " + ShortDescription;
            IEnumerable<string> ServiceStatusQuery =
                from Offers in CN.c.Offers
                join TaskStatus in CN.c.TaskStatus on Offers.StatusID equals TaskStatus.idTaskStatus
                where Offers.idOffer == offer.idOffer
                select TaskStatus.TaskStatusName;
            OfferStatus.Content = "Статус заявки: " + ServiceStatusQuery.First();
            IEnumerable<string> ServiceTypeQuery =
                from Offers in CN.c.Offers
                join Service in CN.c.Service on Offers.Service equals Service.idService
                where Offers.idOffer == offer.idOffer
                select Service.ServiceName;
            ServiceType.Content = "Услуга: " + ServiceTypeQuery.First();
            IEnumerable<DateTime> DateTimeQuery =
                from Offers in CN.c.Offers
                where Offers.idOffer == offer.idOffer
                select Offers.CreateDate;
            CreateData.Content = "Дата заявки: " + DateTimeQuery.First().ToString();
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

