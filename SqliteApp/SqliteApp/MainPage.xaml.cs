using SQLite.Net;
using SqliteApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SqliteApp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int k = 0;
        string path;
        SQLiteConnection conn;
        List<Product> prs = new List<Product>();

        public MainPage()
        {
            this.InitializeComponent();
            path = Path.Combine(ApplicationData.Current.LocalFolder.Path,
                "Products.sqlite");
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),
                path);
            ShowProducts();
            
        }

        private void ShowProducts()
        {
            prs = conn.Table<Product>().ToList<Product>();
            lvProducts.ItemsSource = prs;
        }

        private void btnAdd_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Product p = new Product()
            {
                Name = $"Product {k}",
                Description = $"Description of product {k++}",
                Price = k*100.0m 
            };
            conn.Insert(p);
            ShowProducts();
        }

        private void btnCreate_Tapped(object sender, TappedRoutedEventArgs e)
        {
            conn.CreateTable<Product>();
        }

        private void btnDelete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var p = lvProducts.SelectedItems;
            foreach (var item in p)
            {
                conn.Delete(item);
            }
            ShowProducts();
        }
    }
}
