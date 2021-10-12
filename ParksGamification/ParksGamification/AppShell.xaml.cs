using System;
using Xamarin.Forms;
using ParksGamification.Views;

namespace ParksGamification
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
            Routing.RegisterRoute(nameof(ParksPage), typeof(ParksPage));
            Routing.RegisterRoute(nameof(ParkDetailPage), typeof(ParkDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
        }
    }
}
