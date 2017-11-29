﻿using System;

using Xamarin.Forms;

namespace SampleCarouselApp {
    public class MainPage : CarouselPage {
        public MainPage() {
            ContentPage itemsPage, aboutPage = null;

            //switch (Device.RuntimePlatform) {
            //    case Device.iOS:
            //        itemsPage = new NavigationPage(new ItemsPage()) {
            //            Title = "Browse"
            //        };

            //        aboutPage = new NavigationPage(new AboutPage()) {
            //            Title = "About"
            //        };
            //        itemsPage.Icon = "tab_feed.png";
            //        aboutPage.Icon = "tab_about.png";
            //        break;
            //    default:
            //        itemsPage = new ItemsPage() {
            //            Title = "Browse"
            //        };

            //        aboutPage = new AboutPage() {
            //            Title = "About"
            //        };
            //        break;
            //}

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
