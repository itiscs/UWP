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
    public sealed partial class ProductPage : Page
    {
        SQLiteConnection conn;
        public ProductPage()
        {
            this.InitializeComponent();
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),
                Path.Combine(ApplicationData.Current.LocalFolder.Path, "ProductsBase.sqlite"));

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int id = Convert.ToInt32(e.Parameter);
            this.DataContext = conn.Table<Product>().First(p => p.Id == id);
                        
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Product p = (Product)this.DataContext;
            conn.Update(p);
            
        }
    }
}
