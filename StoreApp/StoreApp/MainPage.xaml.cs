using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StoreApp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CurrentAppSimulator.LicenseInformation.LicenseChanged += LicenseInformation_LicenseChanged;
            ConfigureSimulator();
            GetLicense();
        }

        private void GetLicense()
        {
            if (CurrentAppSimulator.LicenseInformation.IsActive)
            {
                if(CurrentAppSimulator.LicenseInformation.IsTrial)
                    txtVersion.Text = "Trial license";
                else
                    txtVersion.Text = "Full version";
            }
            else
                txtVersion.Text = "Not active license";
            if (CurrentAppSimulator.LicenseInformation.ProductLicenses["product1"].IsActive)
                txtProduct1.Text = "Product 1 Active";
            else
                txtProduct1.Text = "Product 1 Not Active";
            if (CurrentAppSimulator.LicenseInformation.ProductLicenses["product2"].IsActive)
                txtProduct2.Text = "Product 2 Active";
            else
                txtProduct2.Text = "Product 2 Not Active";
        }

        public async void ConfigureSimulator()
        {
            StorageFile proxyFile = await Package.Current.InstalledLocation.GetFileAsync("data\\trial-mode.xml");
            await CurrentAppSimulator.ReloadSimulatorAsync(proxyFile);
            ListingInformation li = await CurrentAppSimulator.LoadListingInformationAsync();
            btnBuyFull.Content = $"Buy license: {li.FormattedPrice}";
            btnBuyProduct1.Content = $"Buy product 1: {li.ProductListings["product1"].FormattedPrice}";
            btnBuyProduct2.Content = $"Buy product 2: {li.ProductListings["product2"].FormattedPrice}";
        }


        private void LicenseInformation_LicenseChanged()
        {
            GetLicense();
        }

        private async void btnBuyFull_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LicenseInformation licenseInformation = CurrentAppSimulator.LicenseInformation;
            if (licenseInformation.IsTrial)
            {
                try
                {
                    await CurrentAppSimulator.RequestAppPurchaseAsync(false);
                    if (!licenseInformation.IsTrial && licenseInformation.IsActive)
                    {
                        NotifyUser("You successfully upgraded your app to the fully-licensed version.");
                    }
                    else
                    {
                        NotifyUser("You still have a trial license for this app.");
                    }
                }
                catch (Exception)
                {
                    NotifyUser("The upgrade transaction failed. You still have a trial license for this app.");
                }
            }
            else
            {
                NotifyUser("You already bought this app and have a fully-licensed version.");
            }

        }

        private async void NotifyUser(string v)
        {
            MessageDialog msg = new MessageDialog(v);
            await msg.ShowAsync();
        }

        private async void btnBuyProduct1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LicenseInformation li = CurrentAppSimulator.LicenseInformation;
            if (!li.ProductLicenses["product1"].IsActive)
            {
                try
                {
                    await CurrentAppSimulator.RequestProductPurchaseAsync("product1");
                    if (li.ProductLicenses["product1"].IsActive)
                    {
                        NotifyUser("You successfully bought Product 1.");
                    }
                    else
                    {
                        NotifyUser("You still haven't Product 1.");
                    }
                }
                catch (Exception)
                {
                    NotifyUser("The upgrade transaction failed.");
                }
            }
            else
            {
                NotifyUser("You already bought Product 1.");
            }

        }

        private async void btnBuyProduct2_Tapped(object sender, TappedRoutedEventArgs e)
        {

            LicenseInformation li = CurrentAppSimulator.LicenseInformation;
            if (!li.ProductLicenses["product2"].IsActive)
            {
                try
                {
                    await CurrentAppSimulator.RequestProductPurchaseAsync("product2");
                    if (li.ProductLicenses["product2"].IsActive)
                    {
                        NotifyUser("You successfully bought Product 2.");
                    }
                    else
                    {
                        NotifyUser("You still haven't Product 2.");
                    }
                }
                catch (Exception)
                {
                    NotifyUser("The upgrade transaction failed.");
                }
            }
            else
            {
                NotifyUser("You already bought Product 2.");
            }

        }
    }
}
