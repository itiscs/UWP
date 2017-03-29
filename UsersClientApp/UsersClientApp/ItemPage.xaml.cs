using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Net.Http;
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
using Windows.Web.Http;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UsersClientApp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ItemPage : Page
    {
        HttpClient client = new HttpClient();

        public ItemPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        { 
            

            //var response = "";
            //Task task = Task.Run(async () =>
            //{
            //    response = await client.GetStringAsync("http://localhost:17947/api/users/"+e.Parameter.ToString()); // sends GET request
            //});
            //task.Wait(); // Wait
            //User u = JsonConvert.DeserializeObject<User>(response); // Bind the list
            //txtID.Text = u.ID.ToString();
            //txtName.Text = u.Name;
            //chkGender.IsChecked = u.Gender;
            //txtInt.Text = u.Interests[0].ToString();



        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            User user = new User() {
                ID = Convert.ToInt32(txtID.Text),
                Name = txtName.Text,
                Gender = (chkGender.IsChecked == true) ? true : false,
                Interests = txtInt.Text.Split(',')
               };

            var content = JsonConvert.SerializeObject(user);


                // Send a PUT
                Task task = Task.Run(async () =>
                {
                    var data = new HttpFormUrlEncodedContent(
                        new Dictionary<string, string>
                        {
                            ["value"] = content
                        }
                    );
                    await client.PutAsync(App.BaseUri, data); // sends POST request
                });
                task.Wait();
             Frame.Navigate(typeof(MainPage));
            

            
        }
    }
}
