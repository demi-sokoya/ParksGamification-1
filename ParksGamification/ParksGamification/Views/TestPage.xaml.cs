using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParksGamification.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParksGamification.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
            BindingContext = new TestViewModel();

            var testLabel1 = new Label() {Text = "Hello and welcome to the test page."};
            var testLabel2 = new Label() { Text = "This is the second message." };

            Content = new StackLayout() {Padding = 30, Children = { testLabel1 , testLabel2 } };
        }
    }
}