using MvvmHelpers;
using ParksGamification.Models;
using ParksGamification.Services;
using Xamarin.Forms;

namespace ParksGamification.ViewModels
{
    class ViewModelBase : BaseViewModel
    {
        public IParkDataStore<Park> ParkDataStore => DependencyService.Get<IParkDataStore<Park>>();
    }
}
