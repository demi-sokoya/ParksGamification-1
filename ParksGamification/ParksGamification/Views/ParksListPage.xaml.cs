using ParksGamification.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParksGamification.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParksListPage : ContentPage
    {
        private readonly ParkListViewModel _viewModel;
        public ParksListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ParkListViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}