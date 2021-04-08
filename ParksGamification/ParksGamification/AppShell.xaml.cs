using System;
using ParksGamification.Views;
using Xamarin.Forms;

namespace ParksGamification
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TestPage),typeof(TestPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
        }
    }
}
