using System;

namespace BeamModelPlugin.Tools
{
    class AppUtil
    {
        public static string GetOptionPath()
        {
            return string.Format("{0}\\{1}\\{2}\\{3}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), CompanyName, AppName, "Options");
        }

        internal static string GetAppPath()
        {
            return string.Format("{0}\\{1}\\{2}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), CompanyName, AppName);
        }

        internal static string GetAppLowPath()
        {
            return string.Format("{0}\\..\\LocalLow\\{1}\\{2}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), CompanyName, AppName);
        }

        internal static string GetProgramDataPath()
        {
            return string.Format("{0}\\{1}\\{2}", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CompanyName, AppName);
        }

        internal static string GetModelPath()
        {

            return string.Format("{0}\\{1}\\{2}\\{3}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), CompanyName, AppName, "Options");
        }

        private static string _appName = "ISPCComponents";
        private static string _companyName = "IS";
        private static string _version = "1.0";

        internal static string AppName
        {
            get
            {
                return _appName;
            }
        }

        internal static string CompanyName
        {
            get
            {
                return _companyName;
            }
        }

        internal static string Version
        {
            get
            {
                return _version;
            }
        }
    }
}
