using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace GridViewApp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Person> _pers = new ObservableCollection<Person>();


        public MainPage()
        {
            this.InitializeComponent();

            _pers.Add(new Person() { FirstName = "Ivan1", LastName = "Ivanov1", Age = 20, Image = "/Assets/avatar2.png" });
            _pers.Add(new Person() { FirstName = "Ivan2", LastName = "Ivanov2", Age = 23, Image = "/Assets/avatar2.png" });
            _pers.Add(new Person() { FirstName = "Ivan3", LastName = "Ivanov3", Age = 26, Image = "/Assets/avatar2.png" });
            _pers.Add(new Person() { FirstName = "Ivan4", LastName = "Ivanov4", Age = 29, Image = "/Assets/avatar2.png" });
            _pers.Add(new Person() { FirstName = "Ivan5", LastName = "Ivanov5", Age = 32, Image = "/Assets/avatar2.png" });
            _pers.Add(new Person() { FirstName = "Ivan6", LastName = "Ivanov6", Age = 35, Image = "/Assets/avatar2.png" });
            grdPers.ItemsSource = _pers;
        }

        private void grdPers_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(ItemPage), e.ClickedItem);
        }
    }
}
