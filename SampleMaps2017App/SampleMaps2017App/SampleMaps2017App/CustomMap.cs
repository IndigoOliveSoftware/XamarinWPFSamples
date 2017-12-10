/**
 * CustomMap
 * Comes from Xamarin Samples:
 * https://github.com/xamarin/xamarin-forms-samples/blob/master/CustomRenderers/Map/CustomRenderer/MapPage.xaml.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SampleMaps2017App {
    public class CustomMap : Map {
        public List<CustomPin> CustomPins { get; set; }

        //public IList<CustomPin> CustomPins
        //{
        //    get { return (IList<CustomPin>)GetValue(CustomPinsProperty); }
        //    set { SetValue(CustomPinsProperty, value); }
        //}

        ///// <summary>
        ///// Item source property
        ///// </summary>
        //public static readonly BindableProperty CustomPinsProperty =
        //    BindableProperty.Create("CustomPins",
        //        typeof(IList<CustomPin>),
        //        typeof(CustomMap),
        //        null,
        //        propertyChanged: CustomMap.OnCustomPinsChanged);

        public void UpdateAllPins() {
            OnPropertyChanged("UpdateAllPins");
        }

        public void ClearAllPins() {
            this.CustomPins.Clear();
            OnPropertyChanged("ClearAllPins");
        }

        public void ClearPin(string sId) {
            if (this.CustomPins != null) {
                int nOdx = 0;
                int nIndexToClear = -1;
                int nCount = this.CustomPins.Count;
                for (nOdx = 0; nOdx < nCount; nOdx++) {
                    if (this.CustomPins[nOdx].Id.CompareTo(sId) == 0) {
                        nIndexToClear = nOdx;
                    }
                }
                if (nIndexToClear != -1) {
                    this.CustomPins.RemoveAt(nIndexToClear);
                }
            }
        }

        //private static void OnCustomPinsChanged(BindableObject bindable, object oldValue, object newValue) {
        //    try {
        //        List < CustomPin > newCustomPins = ( List < CustomPin > )newValue;
        //        var map = bindable as CustomMap;

        //        if (map != null) {
        //            int nOdx = 0;
        //            int nCount = newCustomPins.Count;

        //            map.CustomPins.Clear();
        //            for (nOdx = 0; nOdx < nCount; nOdx++) {
        //                map.CustomPins.Add(newCustomPins[nOdx]);
        //            }

        //            map.OnPropertyChanged("UpdateAllPins");
        //        }
        //    } catch (NullReferenceException) {
        //        // happens when the page is being disposed.
        //    }
        //}
    }

    public class CustomPin
    {
        public Pin Pin { get; set; }
        public bool BluePin { get; set; }
        public string Id { get; set; }
        public string Label { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
