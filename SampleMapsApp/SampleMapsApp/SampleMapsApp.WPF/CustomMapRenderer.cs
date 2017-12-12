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
        MapControl.Map nativeMap;
        List<CustomPin> customPins;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                nativeMap = null;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                this.nativeMap = Control as MapControl.Map;
                this.customPins = formsMap.CustomPins;

                updateAllPins();
            }
        }

        private void updateAllPins() {
            if (this.customPins != null) {
                int nOdx = 0;
                int nCount = 0;

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
                        Name = sPinLabel,
                        Location = new MapControl.Location(aLoc.Latitude, aLoc.Longitude)
                    };

                    System.Windows.Style style = new System.Windows.Style {TargetType = typeof(MapItem) };
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

                    MapControl.MapItemsControl aControl = new MapItemsControl {
                        ItemsSource = somePushpins,
                        ItemContainerStyle = style,
                        IsSynchronizedWithCurrentItem = true
                    };

                    Control.Children.Add(aControl);
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
            }
        }
    }
}