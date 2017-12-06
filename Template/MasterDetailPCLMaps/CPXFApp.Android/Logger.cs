using System;

using Xamarin.Forms;

namespace $ext_safeprojectname$ {
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
            //int nSize = args.Length;
            //int nOdx = 0;
            //int nArgOdx = 0;
            //object[] argsend = new object[nSize + 1];

            string sTempZero = "ERROR: ";
            sTempZero += Logger.makeTimeComponent();
            sTempZero += sTag;
            sTempZero += " ";
            sTempZero += sFormat;
            // argsend[0] = sTempZero;

            //for (nOdx = 0; nOdx < nSize; nOdx++) {
            //    argsend[nOdx] = args[nArgOdx];
            //    nArgOdx++;
            //}

            System.Diagnostics.Debug.WriteLine(sTempZero, args);
        }

        public static void LogInfo(string sTag, string sFormat, params object[] args) {
            //int nSize = args.Length;
            //int nOdx = 0;
            //int nArgOdx = 0;
            //object[] argsend = new object[nSize + 1];

            //argsend[0] = sTag;

            //for (nOdx = 0; nOdx < nSize; nOdx++) {
            //    argsend[nOdx + 1] = args[nArgOdx];
            //    nArgOdx++;
            //}

            //System.Diagnostics.Debug.WriteLine(sFormat, argsend);
            string sTempZero = "INFO: ";
            sTempZero += Logger.makeTimeComponent();
            sTempZero += sTag;
            sTempZero += " ";
            sTempZero += sFormat;

            System.Diagnostics.Debug.WriteLine(sTempZero, args);
        }

        public static void LogWarning(string sTag, string sFormat, params object[] args) {
            //int nSize = args.Length;
            //int nOdx = 0;
            //int nArgOdx = 0;
            //object[] argsend = new object[nSize + 1];

            //string sTempZero = "WARNING: ";
            //sTempZero += sTag;
            //argsend[0] = sTempZero;

            //for (nOdx = 0; nOdx < nSize; nOdx++) {
            //    argsend[nOdx + 1] = args[nArgOdx];
            //    nArgOdx++;
            //}

            //System.Diagnostics.Debug.WriteLine(sFormat, argsend);
            string sTempZero = "WARNING: ";
            sTempZero += Logger.makeTimeComponent();
            sTempZero += sTag;
            sTempZero += " ";
            sTempZero += sFormat;

            System.Diagnostics.Debug.WriteLine(sTempZero, args);
        }
    }
}