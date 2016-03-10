using App22.Models;
using App22.Convertors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using SQLite;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App22
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string path;
        
        public MainPage()
        {
            this.InitializeComponent();

        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            using(SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(path))
            {
                con.CreateTable<Person>();
            }

        }

        private void btnAdd_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
