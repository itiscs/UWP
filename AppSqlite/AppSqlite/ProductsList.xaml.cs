using AppSqlite.Models;
using SQLite.Net;
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

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace AppSqlite
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ProductsList : Page
    {
        SQLiteConnection conn;

        public ProductsList()
        {
            this.InitializeComponent();
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),
                Path.Combine(ApplicationData.Current.LocalFolder.Path, "ProductsBase.sqlite"));

            listView.ItemsSource = conn.Table<Product>().ToList();

        }

        private void listView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(ProductPage), ((Product)e.ClickedItem).Id);

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}
