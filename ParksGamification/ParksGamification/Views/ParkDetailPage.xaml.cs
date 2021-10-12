using ParksGamification.Models;
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
    [QueryProperty(nameof(ParkId), nameof(ParkId))]
    public partial class ParkDetailPage : ContentPage
    {
        public string ParkId { get; set; }

        public IParkDataStore<Park> ParkDataStore => DependencyService.Get<IParkDataStore<Park>>();
        public ParkDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            int.TryParse(ParkId, out var parkId);

            BindingContext = await ParkDataStore.GetPark(parkId);
        }
    }
}