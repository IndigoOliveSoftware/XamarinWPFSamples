using System;
using System.Collections.Generic;
using SampleMaps2017App;
using SampleMaps2017App.Droid;

using Android.Views;
using Android.Widget;
using Android.Content;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.ComponentModel;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer (typeof(CustomMap), typeof(CustomMapRenderer))]
namespace SampleMaps2017App.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    {
        GoogleMap map;
        List < CustomPin > customPins;
        bool isDrawn;

        public CustomMapRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null) {
                var formsMap = (CustomMap)e.NewElement;
                this.customPins = formsMap.CustomPins;
                ((MapView)Control).GetMapAsync(this);
            }
        }

        protected override void OnMapReady (GoogleMap googleMap) 
        {
            this.map = googleMap;
            this.map.SetInfoWindowAdapter (this);

            updateAllPins();
        }

        private void updateAllPins() {
            if (this.customPins != null) {
                if (this.map != null) {
                    int nOdx = 0;
                    int nCount = 0;

                    this.map.Clear ();

                    nCount = this.customPins.Count;
                    for (nOdx = 0; nOdx < nCount; nOdx++) {
                        MarkerOptions marker = new MarkerOptions();
                        marker.SetPosition(new LatLng(this.customPins[nOdx].Latitude, this.customPins[nOdx].Longitude));
                        marker.SetTitle(this.customPins[nOdx].Label);
                        marker.SetSnippet(this.customPins[nOdx].Address);
                        if (this.customPins[nOdx].BluePin) {
                            marker.SetIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.bluemappin50));
                            Logger.LogInfo("CustomMapRenderer", "Blue Pin at: {0}, {1}", this.customPins[nOdx].Latitude, this.customPins[nOdx].Longitude);
                        } else {
                            marker.SetIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.orangemappin50));
                            Logger.LogInfo("CustomMapRenderer", "Orange Pin at: {0}, {1}", this.customPins[nOdx].Latitude, this.customPins[nOdx].Longitude);
                        }
                
                        this.map.AddMarker(marker);
                    }
                }
            }
        }

        protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);

            if (e.PropertyName.Equals ("VisibleRegion") && !isDrawn) {
                isDrawn = true;
            } else if (e.PropertyName.CompareTo("UpdateAllPins") == 0) {
                this.customPins = ((CustomMap)this.Element).CustomPins;
                updateAllPins();
            } else if (e.PropertyName.CompareTo("ClearAllPins") == 0) {
                this.customPins.Clear();
                this.map.Clear();
            }
        }

		protected override void OnLayout (bool changed, int l, int t, int r, int b)
		{
			base.OnLayout (changed, l, t, r, b);

			if (changed) {
				isDrawn = false;
			}
		}

        public Android.Views.View GetInfoContents (Marker marker)
        {
            return null;
        }

		public Android.Views.View GetInfoWindow (Marker marker)
		{
			return null;
		}
    }
}