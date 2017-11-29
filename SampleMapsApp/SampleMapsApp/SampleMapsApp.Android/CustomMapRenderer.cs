using System;
using System.Collections.Generic;
using SampleMapsApp;
using SampleMapsApp.Droid;

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
namespace SampleMapsApp.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    {
        GoogleMap map;
        List < CustomPin > customPins;
        bool isDrawn;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null) {
                var formsMap = (CustomMap)e.NewElement;
                this.customPins = formsMap.CustomPins;
                ((MapView)Control).GetMapAsync(this);
            }
        }

        //protected override void OnElementChanged (Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.View> e)
        //{
        //    base.OnElementChanged (e);

        //    //if (e.OldElement != null) {
        //    //    map.InfoWindowClick -= OnInfoWindowClick;
        //    //}

        //    if (e.NewElement != null) {
        //        var formsMap = (CustomMap)e.NewElement;
        //        this.customPins = formsMap.CustomPins;
        //        ((MapView)Control).GetMapAsync (this);
        //    }
        //}

        protected override void OnMapReady (GoogleMap googleMap) 
        // public void OnMapReady (GoogleMap googleMap)
        {
            this.map = googleMap;
            // map.InfoWindowClick += OnInfoWindowClick;
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
                //map.Clear ();

                //foreach (var pin in customPins) {
                //    var marker = new MarkerOptions ();
                //    marker.SetPosition (new LatLng (pin.Pin.Position.Latitude, pin.Pin.Position.Longitude));
                //    marker.SetTitle (pin.Pin.Label);
                //    marker.SetSnippet (pin.Pin.Address);
                //    if (pin.BluePin) {
                //        marker.SetIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.bluemappin));
                //    } else {
                //        marker.SetIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.orangemappin));
                //    }

                //    map.AddMarker (marker);
                //}
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

        //{
        //    var inflater = Android.App.Application.Context.GetSystemService (Context.LayoutInflaterService) as Android.Views.LayoutInflater;
        //    if (inflater != null) {
        //        Android.Views.View view;

        //        var customPin = GetCustomPin (marker);
        //        if (customPin == null) {
        //            throw new Exception ("Custom pin not found");
        //        }

        //        if (customPin.Id == "Xamarin") {
        //            view = inflater.Inflate (Resource.Layout.XamarinMapInfoWindow, null);
        //        } else {
        //            view = inflater.Inflate (Resource.Layout.MapInfoWindow, null);
        //        }

        //        var infoTitle = view.FindViewById<TextView> (Resource.Id.InfoWindowTitle);
        //        var infoSubtitle = view.FindViewById<TextView> (Resource.Id.InfoWindowSubtitle);

        //        if (infoTitle != null) {
        //            infoTitle.Text = marker.Title;
        //        }
        //        if (infoSubtitle != null) {
        //            infoSubtitle.Text = marker.Snippet;
        //        }

        //        return view;
        //    }
        //    return null;
        //}

		public Android.Views.View GetInfoWindow (Marker marker)
		{
			return null;
		}

        //void OnInfoWindowClick (object sender, GoogleMap.InfoWindowClickEventArgs e)
        //{
        //    var customPin = GetCustomPin (e.Marker);
        //    if (customPin == null) {
        //        throw new Exception ("Custom pin not found");
        //    }

        //    if (!string.IsNullOrWhiteSpace (customPin.Url)) {
        //        var url = Android.Net.Uri.Parse (customPin.Url);
        //        var intent = new Intent (Intent.ActionView, url);
        //        intent.AddFlags (ActivityFlags.NewTask);
        //        Android.App.Application.Context.StartActivity (intent);
        //    }
        //}
    }
}