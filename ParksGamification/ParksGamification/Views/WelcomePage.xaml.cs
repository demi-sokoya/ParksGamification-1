using ParksGamification.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParksGamification.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();

        }

        async void OnAccessAPIClicked(object sender, EventArgs e)
        {
            var client = DependencyService.Get<IWebClientService>();
            string content = await client.GetString("https://www.google.com");

            Application.Current.MainPage.DisplayAlert("HTTP", content.ToString(), "OK");
        }

        private void OnDeviceOrientationClicked(object sender, EventArgs e)
        {
            var device = DependencyService.Get<IDeviceOrientationService>();
            DeviceOrientation orientation = device.GetOrientation();

            Application.Current.MainPage.DisplayAlert("Orientation", orientation.ToString(), "OK");
        }

        async void OnPickPhotoClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
            }

            (sender as Button).IsEnabled = true;
        }
    }
}