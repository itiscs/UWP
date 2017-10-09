using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace BindingApp1
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<int> mas = new ObservableCollection<int>();

        public MainPage()
        {
           
            this.InitializeComponent();
        }

        private async void Sort()
        {
            for (int i = 0; i < mas.Count; i++)
            {
                var x = mas[i];
                var k = i;
                for (int j = i + 1; j < mas.Count; j++)
                {
                    if (mas[j] < mas[k])
                    {
                        k = j;
                    }
                }
                mas[i] = mas[k];
                mas[k] = x;
                //DataControl.ItemsSource = mas;
                await Task.Delay(1000);
            }
           
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < 30; i++)
                mas.Add(r.Next(10, 200));

            DataControl.ItemsSource = mas;
            
            Sort();

        }

    }
}
