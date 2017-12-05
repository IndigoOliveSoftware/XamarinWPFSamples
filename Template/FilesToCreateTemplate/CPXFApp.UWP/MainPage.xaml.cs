namespace $safeprojectname$ {
    public sealed partial class MainPage {
        public MainPage() {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("");
            LoadApplication(new $ext_safeprojectname$.App());
        }
    }
}