using ParksGamification.ViewModels;
using Xamarin.Forms;

namespace ParksGamification.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            BindingContext = new WelcomeViewModel();

            var learnMoreButton = new Button() {Text = "LEARN MORE"};
            learnMoreButton.SetBinding(Button.CommandProperty, new Binding("OpenWebCommand"));

            var testPageButton = new Button() {Text = "Go To test Page"};
            testPageButton.SetBinding(Button.CommandProperty, new Binding("GoToTestPageCommand"));

            Content = new StackLayout() { Padding = 30, Children =
            {
                learnMoreButton
                , testPageButton
            }
            };

        }
    }
}