using App22.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace App22
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BindingCollection : Page
    {
        private int currentID = 0;
        public ObservableCollection<Person> Pers { get; set; }
            = new ObservableCollection<Person>(); 

        public BindingCollection()
        {
            this.InitializeComponent();
            DataContext = this;
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Pers.Add(Person.CreatePerson(currentID++));
        }

        private async void grdPersons_ItemClick(object sender, ItemClickEventArgs e)
        {
            Person p = e.ClickedItem as Person;
            MessageDialog msg = new MessageDialog($"{p.PersonID} - {p.FirstName} {p.LastName}");
            await msg.ShowAsync();
        }
    }
}
