using System;

using Xamarin.Forms;

namespace SampleCarouselApp {
    public class MainPage : CarouselPage {
        public MainPage() {
            ContentPage itemsPage, aboutPage = null;

            itemsPage = new ItemsPage() {
                Title = "Browse"
            };

            aboutPage = new AboutPage() {
                Title = "About"
            };

            Children.Add(itemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged() {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
