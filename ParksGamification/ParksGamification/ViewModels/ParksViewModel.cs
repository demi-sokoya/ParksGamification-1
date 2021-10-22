using Azure.Storage.Blobs;
using ParksGamification.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace ParksGamification.ViewModels
{
    class ParksViewModel :ViewModelBase
    {
        public ObservableRangeCollection<Park> Parks { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Park> SelectedCommand { get; }

        Park selectedPark;

        public Park SelectedPark
        {
            get => selectedPark;
            set => SetProperty(ref selectedPark, value);
        }

        public ParksViewModel()
        {
            Title = "Parks";

            Parks = new ObservableRangeCollection<Park>();

            LoadParks();

            RefreshCommand = new AsyncCommand(Refresh);
            SelectedCommand = new AsyncCommand<Park>(Selected);
        }

        async Task Selected(Park park)
        {
            string route = $"{nameof(Views.ParkDetailPage)}?ParkId={park.Id}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Refresh()
        {
            IsBusy = true;

            Parks.Clear();
            LoadParks();

            IsBusy = false;
        }

        public async void LoadParks()
        {
            IEnumerable<Park> parks = await ParkDataStore.GetParks();
            Parks.AddRange(parks);
        }
    }
}
