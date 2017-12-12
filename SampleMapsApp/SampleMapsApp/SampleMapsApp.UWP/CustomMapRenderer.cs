using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;

using SampleMapsApp;
using SampleMapsApp.UWP;

using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace SampleMapsApp.UWP
{
    public class CustomMapRenderer : MapRenderer
    {
        MapControl nativeMap;
        List<CustomPin> customPins;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                nativeMap.Children.Clear();
                nativeMap = null;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                this.nativeMap = Control as MapControl;
                this.customPins = formsMap.CustomPins;

                updateAllPins();
            }
        }

        private void updateAllPins() {
            if (this.customPins != null) {
                int nOdx = 0;
                int nCount = 0;

                this.nativeMap.Children.Clear();
                this.nativeMap.MapElements.Clear();

                nCount = this.customPins.Count;
                for (nOdx = 0; nOdx < nCount; nOdx++) {
                    var snPosition = new BasicGeoposition { Latitude = this.customPins[nOdx].Latitude, Longitude = this.customPins[nOdx].Longitude };
                    var snPoint = new Geopoint(snPosition);
                    var mapIcon = new MapIcon();

                    if (this.customPins[nOdx].BluePin) {
                        string sUriString = "ms-appx:///bluemappin50.png";
                        mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri(sUriString));
                    } else {
                        string sUriString = "ms-appx:///orangemappin50.png";
                        mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri(sUriString));
                    }
                    mapIcon.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;
                    mapIcon.Location = snPoint;
                    mapIcon.NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1.0);
                
                    this.nativeMap.MapElements.Add(mapIcon);                    
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
                this.nativeMap.MapElements.Clear();
            }
        }
    }
}