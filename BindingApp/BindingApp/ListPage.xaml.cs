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
using BindingApp.Models;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace BindingApp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ListPage : Page
    {

        public ObservableCollection<Person> Pers = new ObservableCollection<Person>();
        private int num = 104;

        public ListPage()
        {
            this.InitializeComponent();


            Pers.Add(new Person() { PersonID = 100, FirstName = "Ivan", LastName = "Petrov" });
            Pers.Add(new Person() { PersonID = 101, FirstName = "Ivan1", LastName = "Petrov" });
            Pers.Add(new Person() { PersonID = 102, FirstName = "Ivan2", LastName = "Petrov" });
            Pers.Add(new Person() { PersonID = 103, FirstName = "Ivan3", LastName = "Petrov" });

            grdPersons.ItemsSource = Pers;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pers.Add(Person.CreatePerson(num++));



        }

        private async void grdPersons_ItemClick(object sender, ItemClickEventArgs e)
        {
            Person p = (Person) e.ClickedItem;
            MessageDialog dlg = new MessageDialog($"{p.PersonID}:{p.FirstName} {p.LastName}");
            await dlg.ShowAsync();
           

        }
    }
}
