using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SampleCarouselApp {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}