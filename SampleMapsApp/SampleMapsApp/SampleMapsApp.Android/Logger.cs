using System;

using Xamarin.Forms;

namespace SampleMapsApp {
    public class Logger {

        public Logger() {
        }

        private static string makeTimeComponent() {
            string sTempZero;
            DateTime localDate = DateTime.Now;

            sTempZero = localDate.Hour.ToString("D2");
            sTempZero += ":";
            sTempZero += localDate.Minute.ToString("D2");
            sTempZero += ":";
            sTempZero += localDate.Second.ToString("D2");
            sTempZero += ":";
            sTempZero += localDate.Millisecond.ToString("D4");
            sTempZero += " ";

            return sTempZero;
        }

        public static void LogError(string sTag, string sFormat, params object[] args) {
            string sTempZero = "ERROR: ";
            sTempZero += Logger.makeTimeComponent();
            sTempZero += sTag;
            sTempZero += " ";
            sTempZero += sFormat;

            System.Diagnostics.Debug.WriteLine(sTempZero, args);
        }

        public static void LogInfo(string sTag, string sFormat, params object[] args) {
            string sTempZero = "INFO: ";
            sTempZero += Logger.makeTimeComponent();
            sTempZero += sTag;
            sTempZero += " ";
            sTempZero += sFormat;

            System.Diagnostics.Debug.WriteLine(sTempZero, args);
        }

        public static void LogWarning(string sTag, string sFormat, params object[] args) {
            string sTempZero = "WARNING: ";
            sTempZero += Logger.makeTimeComponent();
            sTempZero += sTag;
            sTempZero += " ";
            sTempZero += sFormat;

            System.Diagnostics.Debug.WriteLine(sTempZero, args);
        }
    }
}