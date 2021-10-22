using Xamarin.Forms;
using ParksGamification.Services;

namespace ParksGamification
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<ParkDataStoreLocalJson>();
            DependencyService.Register<ParkDataStoreSQLite>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
