using ParksGamification.Services;
using System;
using System.Collections.Generic;
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

        private void OnDeviceOrientationClicked(object sender, EventArgs e)
        {
            var device = DependencyService.Get<IDeviceOrientationService>();
            DeviceOrientation orientation = device.GetOrientation();

            Application.Current.MainPage.DisplayAlert("Orientation", orientation.ToString(), "OK");
        }
    }
}