using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BeamModelPlugin
{
    public class LogManager
    {
        static List<string> _strList = new List<string>();

        public static List<string> LogList
        {
            get { return LogManager._strList; }
        }

        public static void Write(string msg, bool skipSame = true)
        {
            if (skipSame && _strList.Contains(msg))
                return;
            _strList.Add(msg);
        }

        internal static void Clear()
        {
            _strList.Clear();
        }

        internal static void ShowLog()
        {
            if (_strList.Count == 0)
                return;

            string logPath = GlobalOption.INSTANCE.GetValue("LOG");

            if (string.IsNullOrEmpty(logPath))
            {
                StringBuilder sb = new StringBuilder();
                foreach (string str in _strList)
                    sb.AppendLine(str);
                MessageBox.Show(sb.ToString());
            }
            else
            {
                var file = new FileInfo(logPath);
                if (!file.Directory.Exists)
                    file.Directory.Create();
                StreamWriter sw = new StreamWriter(logPath);
                foreach (string str in _strList)
                    sw.WriteLine(str);
                sw.Close();
            }
        }
    }
}