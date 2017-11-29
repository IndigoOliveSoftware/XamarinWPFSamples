using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MapControl;

using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.WPF;
using System.ComponentModel;

using SampleMapsApp;
using SampleMapsApp.WPF;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace SampleMapsApp.WPF {
    public class Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Point : Base
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        private MapControl.Location location;
        public MapControl.Location Location
        {
            get { return location; }
            set
            {
                location = value;
                RaisePropertyChanged("Location");
            }
        }
    }
    
    public class CustomMapRenderer : MapRenderer
    {
        // Microsoft.Maps.MapControl.WPF.Map nativeMap;
        MapControl.Map nativeMap;
        List<CustomPin> customPins;
        // XamarinMapOverlay mapOverlay;
        // bool xamarinOverlayShown = false;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // nativeMap.MapElementClick -= OnMapElementClick;
                // nativeMap.Children.Clear();
                // mapOverlay = null;
                nativeMap = null;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                // this.nativeMap = Control as Microsoft.Maps.MapControl.WPF.Map;
                this.nativeMap = Control as MapControl.Map;
                this.customPins = formsMap.CustomPins;

                updateAllPins();
            }
        }

        private void updateAllPins() {
            if (this.customPins != null) {
                int nOdx = 0;
                int nCount = 0;

                // this.nativeMap.Children.Clear();
                // this.nativeMap.MapElements.Clear();

                nCount = this.customPins.Count;
                for (nOdx = 0; nOdx < nCount; nOdx++) {
                    string sPinLabel = this.customPins[nOdx].Latitude.ToString("F2").Substring(0, 2);
                    MapControl.Location aLoc = new MapControl.Location(this.customPins[nOdx].Latitude, this.customPins[nOdx].Longitude);
                    System.Windows.Media.Brush pinBrush = System.Windows.Media.Brushes.Blue;
                    if (this.customPins[nOdx].BluePin) {
                        pinBrush = System.Windows.Media.Brushes.Blue;
                    } else {
                        /** Orange Push Pin */
                        pinBrush = System.Windows.Media.Brushes.Orange;
                    }

                    ObservableCollection<Point> somePushpins = new ObservableCollection<Point>();
                    // ObservableCollection<MapControl.Pushpin> somePushpins = new ObservableCollection<MapControl.Pushpin>();

                    /**
                     * From Xaml Map Control github code (codeplex)
                     *  Pushpins = new ObservableCollection<Point>();
                        Pushpins.Add(
                            new Point
                            {
                                Name = "WHV - Eckwarderhörne",
                                Location = new Location(53.5495, 8.1877)
                            });
                     **/

                    Point aPushPin = new Point {
                    // MapControl.Pushpin aPushPin = new MapControl.Pushpin
                                Name = sPinLabel,
                                Location = new MapControl.Location(aLoc.Latitude, aLoc.Longitude)
                            //Content = sPinLabel,
                            //// Location = new MapControl.Location(42.2917° N, 85.5872° W),
                            //Location = aLoc,
                            //Foreground = System.Windows.Media.Brushes.Black,
                            //Visibility = Visibility.Visible
                    };

                    System.Windows.Style style = new System.Windows.Style {TargetType = typeof(MapItem) };
                    // style.Setters.Add(new EventSetter(MapItem.TouchDownEvent, new RoutedEventHandler( Map2ItemTouchDown )));
                    // style.Setters.Add(new System.Windows.Setter( MapItem.LocationProperty, aLoc));
                    style.Setters.Add(new System.Windows.Setter( MapPanel.LocationProperty, aLoc));
                    style.Setters.Add(new System.Windows.Setter( MapItem.VerticalContentAlignmentProperty, System.Windows.VerticalAlignment.Bottom ));
                    style.Setters.Add(new System.Windows.Setter( MapItem.ForegroundProperty, System.Windows.Media.Brushes.Black));
                    style.Setters.Add(new System.Windows.Setter( MapItem.BackgroundProperty, pinBrush));
                    style.Setters.Add(new System.Windows.Setter( MapItem.VisibilityProperty, System.Windows.Visibility.Visible));
                    System.Windows.FrameworkElementFactory aPin = new FrameworkElementFactory(typeof(MapControl.Pushpin));
                    aPin.SetValue(MapControl.Pushpin.ContentProperty, sPinLabel);
                    aPin.SetValue(MapControl.Pushpin.ForegroundProperty, System.Windows.Media.Brushes.Black);
                    aPin.SetValue(MapControl.Pushpin.BackgroundProperty, pinBrush);
                    System.Windows.Controls.ControlTemplate ct = new System.Windows.Controls.ControlTemplate(typeof(MapControl.MapItem));
                    ct.VisualTree = aPin;
                    style.Setters.Add(new System.Windows.Setter( MapItem.TemplateProperty, ct));

                    somePushpins.Add(aPushPin);
                    //map.Children.Add(new MapItemsControl { ItemsSource=somePushpins, ItemContainerStyle = MainWindow.PushpinItemStyle });

                    MapControl.MapItemsControl aControl = new MapItemsControl {
                        ItemsSource = somePushpins,
                        ItemContainerStyle = style,
                        IsSynchronizedWithCurrentItem = true
                    };

                    //MapControl.Pushpin aPushPinA = new Pushpin {
                    //    Content = "My Push Pin A",
                    //    Location = new MapControl.Location(21.821, 33.286),
                    //    Foreground = System.Windows.Media.Brushes.Blue,
                    //    Visibility = Visibility.Visible
                    //};

                    // map.Children.Add(aPushPinA);
                    Control.Children.Add(aControl);
                    //// MapControl.Location aLoc = new MapControl.Location(this.customPins[nOdx].Latitude, this.customPins[nOdx].Longitude);
                    //// if (this.customPins[nOdx].BluePin) {
                    ////System.Windows.Media.Color aColorBlue = System.Windows.Media.Color.FromRgb(0, 0, 255);
                    ////System.Windows.Media.Color aColorWhite = System.Windows.Media.Color.FromRgb(255, 255, 255);
                    ////MapControl.Pushpin aPin = new MapControl.Pushpin {
                    ////    Location = aLoc,
                    ////    Background = new System.Windows.Media.SolidColorBrush(aColorBlue),
                    ////    Foreground = new System.Windows.Media.SolidColorBrush(aColorWhite)
                    ////};
                    //Xamarin.Forms.Maps.Pin aNewPin = new Pin();
                    //aNewPin.Position = new Position(this.customPins[nOdx].Latitude, this.customPins[nOdx].Longitude);
                    //aNewPin.Label = "";
                    ////Control.Children.Add(aPin);
                    //Element.Pins.Add(aNewPin);
                    ////     } else {
                    ////         System.Windows.Media.Color aColorOrange = System.Windows.Media.Color.FromRgb(255, 128, 0);
                    ////         System.Windows.Media.Color aColorWhite = System.Windows.Media.Color.FromRgb(255, 255, 255);
                    ////         MapControl.Pushpin aPin = new MapControl.Pushpin {
                    ////             Location = aLoc,
                    ////             Background = new System.Windows.Media.SolidColorBrush(aColorOrange),
                    ////             Foreground = new System.Windows.Media.SolidColorBrush(aColorWhite)
                    ////         };
                    //////Control.Children.Add(aPin);
                    ////     }
                    //// Microsoft.Maps.MapControl.WPF.Location aLoc = new Microsoft.Maps.MapControl.WPF.Location(pin.Position.Latitude, pin.Position.Longitude); //Convert.ToDouble( _myGeocodeInfo[8]),Convert.ToDouble(_myGeocodeInfo[9]));
                    ////Microsoft.Maps.MapControl.WPF.Pushpin aPin = new Microsoft.Maps.MapControl.WPF.Pushpin();
                    ////Microsoft.Maps.MapControl.WPF.MapLayer.SetPosition(aPin, aLoc);
                    ////         Microsoft.Maps.MapControl.WPF.Location aLoc = new Microsoft.Maps.MapControl.WPF.Location(this.customPins[nOdx].Latitude, this.customPins[nOdx].Longitude);
                    ////         Microsoft.Maps.MapControl.WPF.Pushpin aPin = new Microsoft.Maps.MapControl.WPF.Pushpin();
                    ////         Microsoft.Maps.MapControl.WPF.MapLayer.SetPosition(aPin, aLoc);
                    ////Control.Children.Add(aPin);
                    ////var snPosition = new BasicGeoposition { Latitude = this.customPins[nOdx].Latitude, Longitude = this.customPins[nOdx].Longitude };
                    ////var snPoint = new Geopoint(snPosition);
                    ////var mapIcon = new MapIcon();

                    ////if (this.customPins[nOdx].BluePin) {
                    ////    string sUriString = "ms-appx:///bluemappin50.png";
                    ////    mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri(sUriString));
                    ////} else {
                    ////    string sUriString = "ms-appx:///orangemappin50.png";
                    ////    mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri(sUriString));
                    ////}
                    ////mapIcon.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;
                    ////mapIcon.Location = snPoint;
                    ////mapIcon.NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1.0);
                
                    ////this.nativeMap.MapElements.Add(mapIcon);                    
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.CompareTo("UpdateAllPins") == 0) {
                this.customPins = ((CustomMap)this.Element).CustomPins;
                updateAllPins();
            } else if (e.PropertyName.CompareTo("ClearAllPins") == 0) {
                this.customPins.Clear();
                // this.nativeMap.MapElements.Clear();
            }
        }
    }
}