using Microsoft.Win32;
using System;
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
    /// Логика взаимодействия для CreateNews.xaml
    /// </summary>
    public partial class CreateNews : Window
    {
        EmployeeLogin emp;
        public string FilePath { get; set; }
        public CreateNews(EmployeeLogin employee)
        {
            emp = employee;
            InitializeComponent();
        }

        private void CreateNews_Click(object sender, RoutedEventArgs e)
        {
            string filename = FilePath;
            byte[] imageData;
            if (FilePath != null)
            {
                
                using (System.IO.FileStream fs = new System.IO.FileStream(filename, FileMode.Open))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                }
            }
            else
            {
                imageData = null;
            }
            if (string.IsNullOrEmpty(NewsText.Text) != true && string.IsNullOrEmpty(NewsTitle.Text) != true)
            {
                CN.c.News.Add(new News
                {
                    NewsDate = System.DateTime.Now,
                    NewsPhoto = imageData,
                    NewsText = NewsText.Text,
                    NewsTitle = NewsTitle.Text,
                    CreatorId = emp.idEmployee
                }) ;
                try
                {
                    CN.c.SaveChanges();
                    MessageBox.Show("Успешно добавлена новость", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так, попробуйте снова", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Изображения |*.png;*.jpg"
            };
            if(openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
            }
            if(FilePath == "")
            {
                ChosenFileName.Visibility = Visibility.Visible;
                ChosenFileName.Text = "Фото не выбрано!";
            }
            else
            {
                ChosenFileName.Visibility = Visibility.Visible;
                ChosenFileName.Text = "Выбраное фото: " + FilePath;
            }
        }
    }
}
