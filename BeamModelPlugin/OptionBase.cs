using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using BeamModelPlugin.Tools;

namespace BeamModelPlugin
{
    [System.Reflection.Obfuscation(Feature = "renaming", Exclude = true)]
    public abstract class OptionBase<T> where T : new()
    {
        private static T _instance = default(T);
        private static DateTime _fileDateTime = DateTime.Now;

        public static string FilePath { get; set; }

        public static T INSTANCE
        {
            get
            {
                if (_instance == null || !IsSameDateTime())
                {
                    _instance = Read();
                }

                return _instance;
            }
        }

        private static bool IsSameDateTime()
        {
            string path = string.IsNullOrEmpty(FilePath) ? AppUtil.GetOptionPath() : FilePath;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = string.Format("{0}\\{1}.xml", path, typeof(T).Name);
            if (File.Exists(fileName))
            {
                DateTime date = File.GetLastWriteTime(fileName);

                return date.CompareTo(_fileDateTime) == 0;
            }
            else
                return false;
        }

        protected OptionBase()
        {

        }

        public static DateTime FileDateTime
        {
            get => _fileDateTime;
            set => _fileDateTime = value;
        }

        public static T Read()
        {
            string path = string.IsNullOrEmpty(FilePath) ? AppUtil.GetOptionPath() : FilePath;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = string.Format("{0}\\{1}.xml", path, typeof(T).Name);

            T data = default(T);

#if DEBUG

            Attribute attr = Attribute.GetCustomAttribute(typeof(T), typeof(ObfuscationAttribute));
            bool sucess = false;
            ObfuscationAttribute attOfuscation = attr as ObfuscationAttribute;
            if (attr != null && attOfuscation.Exclude && attOfuscation.Feature == "renaming")
            {
                sucess = true;
            }

            if (!sucess)
            {
                string msg = string.Format("옵션 클래스 {0}에 난독 제외 특성이 부여되지 않았습니다." +
                                           "\n다음 속성을 정의해주세요\n[Obfuscation(Feature = \"renaming\", Exclude = true)]\n",
                    typeof(T));

                MessageBox.Show(msg, "이 메세지는 DEBUG에서만 나타납니다.");
                //throw new CmdExeception(msg);
            }
#endif

            TextReader reader = null;
            try
            {
                if (File.Exists(fileName))
                {
                    reader = new StreamReader(fileName);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    data = (T) serializer.Deserialize(reader);
                    reader.Close();
                    serializer = null;
                    reader = null;

                    _fileDateTime = File.GetLastWriteTime(fileName);
                }
                else
                {
                    data = new T();
                    var data2 = data as OptionBase<T>;
                    data2.Initialize();
                }
            }
            catch

            {
                data = new T();
                var data2 = data as OptionBase<T>;
                data2.Initialize();
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                reader = null;
            }

            return data;
            }

            public void Write()
            {
                string path = string.IsNullOrEmpty(FilePath) ? AppUtil.GetOptionPath() : FilePath;

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileName = string.Format("{0}\\{1}.xml", path, typeof(T).Name);

                FileStream fstream = File.Open(fileName, FileMode.Create, FileAccess.Write);

                TextWriter writer = new StreamWriter(fstream);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, this);

                writer.Close();
                writer = null;
                serializer = null;

                fstream.Close();
                fstream = null;

                // Update Singleton
                _instance = Read();
            }
        
        protected virtual void Initialize()
        {
            //?
        }
    }
}