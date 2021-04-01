using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ParksGamification.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public WelcomeViewModel()
        {
            Title = "Welcome";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.google.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}