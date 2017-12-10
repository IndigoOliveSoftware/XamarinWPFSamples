using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMaps2017App.WPF;

using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

[assembly: Dependency(typeof(PlatformServices_WPF))]
namespace SampleMaps2017App.WPF {
    public class PlatformServices_WPF : IWPFPlatformServices {
        public string GetCLRNamespace() {
            return "SampleMaps2017App.WPF";
        }
    }
}
