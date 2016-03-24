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

namespace App1
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Page1 : Page
    {

        public Page1()
        {
            this.InitializeComponent();
            LoadState();
        }

        internal void SaveState()
        {
            ApplicationData.Current.RoamingSettings.Values["Title"] = txtTitle.Text;
            ApplicationData.Current.RoamingSettings.Values["bookPage"] =
                book.SelectedIndex;
        }

        internal void LoadState()
        {
            var rs = ApplicationData.Current.RoamingSettings;
            if (rs.Values["Title"] != null)
                txtTitle.Text = rs.Values["Title"].ToString();
            if (rs.Values["bookPage"] != null)
                book.SelectedIndex = Convert.ToInt32(rs.Values["bookPage"]);
        }
    }
}
