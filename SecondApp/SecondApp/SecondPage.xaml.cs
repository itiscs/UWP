using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace SecondApp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        //DispatcherTimer timer;
        public SecondPage()
        {
            //timer.Tick += Timer_Tick;
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            txtUser.Text = $"Hello, {e.Parameter.ToString()}!";
            
            base.OnNavigatedTo(e);
        }


        private void Timer_Tick(object sender, object e)
        {
            throw new NotImplementedException();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Ellipse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Ellipse el = new Ellipse() { Width = 200, Height = 200,
                Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)) };
            el.Tapped += Ellipse_Tapped;
            stk.Children.Add(el);

        }
    }
}
