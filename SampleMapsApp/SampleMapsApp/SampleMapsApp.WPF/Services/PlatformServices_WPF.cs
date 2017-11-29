using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMapsApp.WPF;

using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

[assembly: Dependency(typeof(PlatformServices_WPF))]
namespace SampleMapsApp.WPF {
    public class PlatformServices_WPF : IWPFPlatformServices {
        public string GetCLRNamespace() {
            return "SampleMapsApp.WPF";
        }
    }
}
