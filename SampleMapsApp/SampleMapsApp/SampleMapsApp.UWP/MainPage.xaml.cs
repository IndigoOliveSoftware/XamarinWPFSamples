namespace SampleMapsApp.UWP {
    public sealed partial class MainPage {
        public MainPage() {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("");
            LoadApplication(new SampleMapsApp.App());
        }
    }
}