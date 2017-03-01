using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using SQLite.Net;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AppSqlite.Models;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppSqlite
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string path;
        SQLiteConnection conn;
        int num = 0; 

        public MainPage()
        {
            this.InitializeComponent();

            path = Path.Combine(ApplicationData.Current.LocalFolder.Path,
              "ProductsBase.sqlite");
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),
                path);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            conn.CreateTable<Product>();            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            num = conn.Table<Product>().ToList().Max(p1 => p1.Id);
            Product p = new Product()
            { Id = num++, Name = String.Format($"Товар {num}"), Description = "Описание",
                Price = 100 * num };
            conn.Insert(p);
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductsList));

        }
    }
}
