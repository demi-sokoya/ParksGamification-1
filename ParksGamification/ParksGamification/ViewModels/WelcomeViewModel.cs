using System.Windows.Input;
using ParksGamification.Models;
using ParksGamification.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ParksGamification.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public WelcomeViewModel()
        {
            Title = "Welcome to the application!";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.google.com"));
            GoToTestPageCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(TestPage)));

            var park = new Models.Park {Id = 1, Name = "GreenPark", Description = "This is an awesome park."};

            park.Amenities.Add(new Park.Amenity() { Type = Park.Amenity.Types.Swing, Quantity = 1, Description = "Blue swing set for ages 3 to 7." });
            park.Amenities.Add(new Park.Amenity() { Type = Park.Amenity.Types.Swing, Quantity = 1, Description = "Green swing set for ages 3 to 7." });

        }

        public ICommand OpenWebCommand { get; }
        public ICommand GoToTestPageCommand { get; }
    }
}