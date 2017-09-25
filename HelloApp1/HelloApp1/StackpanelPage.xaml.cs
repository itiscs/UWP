using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloApp1
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class StackpanelPage : Page
    {
        public StackpanelPage()
        {
            this.InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
             Ellipse el = new Ellipse
            {
                Width = 100,
                Height = 100,
                Fill = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0)),
                
            };

            el.Tapped += El_Tapped;
            stPanel.Children.Add(el);           
          
        }

        private async void El_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Сообщение");            
            await msg.ShowAsync();
            
        }
    }
}
