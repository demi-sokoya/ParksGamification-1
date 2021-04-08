using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParksGamification.Models;
using ParksGamification.Services;
using Xamarin.Forms;

namespace ParksGamification.ViewModels
{
    class ParkListViewModel : BaseViewModel
    {
        public ObservableCollection<Park> Parks { get; }

        public ICommand LoadParksCommand { get; }

        public ParkListViewModel()
        {
            Title = "Parks";

            Parks = new ObservableCollection<Park>();

            LoadParksCommand = new Command(async () => await ExecuteLoadParksCommand());
        }

        private async Task ExecuteLoadParksCommand()
        {
            IsBusy = true;
           
            Parks.Clear();

            var parks = await DataStore.GetItemsAsync(true);

            foreach (var park in parks)
            {
                Parks.Add(park);
            }

            IsBusy = false;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
