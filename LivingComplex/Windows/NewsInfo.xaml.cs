﻿using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для NewsInfo.xaml
    /// </summary>
   
    public partial class NewsInfo : Window
    {
        public byte[] Photo { get; set; } 
        public NewsInfo(News news)
        {
            InitializeComponent();
            
            string pname = news.Employers.LastName + " " + news.Employers.FirstName + " " + news.Employers.Patronymic;
            NewsTitle.Text = news.NewsTitle;
            NewsText.Text = news.NewsText;

            NewsCreator.Content = pname;
            if (news.NewsPhoto != null)
            {
                using (MemoryStream stream = new MemoryStream(CN.c.News.Where(i => i.idNews == news.idNews).Select(i => i.NewsPhoto).FirstOrDefault()))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    NewsPhoto.Source = bitmapImage;
                }
            }
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
