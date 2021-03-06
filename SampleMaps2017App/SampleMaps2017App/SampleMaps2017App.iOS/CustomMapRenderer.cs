using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SampleMaps2017App;
using SampleMaps2017App.iOS;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Foundation;
using UIKit;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;
using MapKit;
using CoreGraphics;
using CoreLocation;

[assembly:ExportRenderer (typeof(CustomMap), typeof(CustomMapRenderer))]
namespace SampleMaps2017App.iOS {
    public class CustomMapRenderer : MapRenderer {
        private List<CustomPin> customPins;
        private MKMapView nativeMap;

        protected override void OnElementChanged (ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged (e);

            if (e.OldElement != null) {
                this.nativeMap = Control as MKMapView;
                this.nativeMap.GetViewForAnnotation = null;
            }

            if (e.NewElement != null) {
                var formsMap = (CustomMap)e.NewElement;
                this.nativeMap = Control as MKMapView;
                this.customPins = formsMap.CustomPins;

                nativeMap.GetViewForAnnotation = GetViewForAnnotation;
                updateAllPins();
            }
        }

        private void updateAllPins() {
            if (this.customPins != null) {
                int nOdx = 0;
                int nCount = 0;

                this.nativeMap.RemoveAnnotations(this.nativeMap.Annotations);

                nCount = this.customPins.Count;
                for (nOdx = 0; nOdx < nCount; nOdx++) {
                    this.nativeMap.AddAnnotation(new MKPointAnnotation {
                        Title = "Indigo Olive Software",
                        Coordinate = new CLLocationCoordinate2D(this.customPins[nOdx].Latitude, this.customPins[nOdx].Longitude)
                    });
                }
            }
        }

        MKAnnotationView GetViewForAnnotation (MKMapView mapView, IMKAnnotation annotation)
        {
            MKPinAnnotationView annotationView = null;

            if (annotation == null)
                return null;

            if (annotation is MKUserLocation)
                return null;

            var customPin = GetCustomPin (annotation.Coordinate);
            if (customPin == null) {
                return null;
            }

            annotationView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(customPin.Id);
            if (annotationView == null) {
                annotationView = new MKPinAnnotationView(annotation, customPin.Id);
                if (customPin.BluePin) {
                    annotationView.PinTintColor = UIColor.Blue;
                } else {
                    annotationView.PinTintColor = UIColor.Orange;
                }
            }

            annotationView.CanShowCallout = true;

            return annotationView;
        }

        CustomPin GetCustomPin(CLLocationCoordinate2D coordinate) {
            int nOdx = 0;
            int nCount = this.customPins.Count;

            Position aPosition = new Position(coordinate.Latitude, coordinate.Longitude);

            for (nOdx = 0; nOdx < nCount; nOdx++) {
                Position aForPosition = new Position(this.customPins[nOdx].Latitude, this.customPins[nOdx].Longitude);
                if (aPosition == aForPosition) {
                    return this.customPins[nOdx];
                }
            }
            return null;
        }
    }
}

