using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace TilesAndToasts
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "Jennifer Parker",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Photos from our trip",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Check out these awesome photos I took while in New Zealand!",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                                new AdaptiveImage()
                                {
                                    Source="Assets/StoreLogo.png"
                                }
                            }
                        }
                    }
                }
            };

            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            TileNotification notification = new TileNotification(content.GetXml());
            updater.Update(notification);

            XmlDocument badgeXml =
       BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);
            // Set the value of the badge in the XML to our number
            XmlElement badgeElement = badgeXml.SelectSingleNode("/badge") as XmlElement;
            badgeElement.SetAttribute("value", "42");

            var updaterBadge = BadgeUpdateManager.CreateBadgeUpdaterForApplication();
            BadgeNotification badge = new BadgeNotification(badgeXml);
            updaterBadge.Update(badge);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ToastContent content = new ToastContent()
            {
                Launch = "app-defined-string",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                                Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "Microsoft Company Store"
                        },

                        new AdaptiveText()
                        {
                            Text = "New Halo game is back in stock!"
                        }
                    }
                            }
                        },

                        Actions = new ToastActionsCustom()
                        {
                            Buttons =
                {
                    new ToastButton("See more details", "details"),

                    new ToastButton("Remind me later", "later")
                    {
                        ActivationType = ToastActivationType.Background
                    }
                }
                }
            };

            var notifier = ToastNotificationManager.CreateToastNotifier();
            var toast = new ToastNotification(content.GetXml());
            notifier.Show(toast);
        }
    }
}
