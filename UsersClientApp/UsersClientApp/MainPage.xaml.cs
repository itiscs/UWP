using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UsersClientApp.Model;
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

namespace UsersClientApp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        HttpClient client = new HttpClient();


        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            var response = "";
            Task task = Task.Run(async () =>
            {
                response = await client.GetStringAsync("http://localhost:17947/api/users"); // sends GET request
            });
            task.Wait(); // Wait
            lst.ItemsSource = JsonConvert.DeserializeObject<List<User>>(response); // Bind the list


        }

        private void lst_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(ItemPage), ((User)e.ClickedItem).ID);

        }
    }
}
