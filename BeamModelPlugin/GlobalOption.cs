using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamModelPlugin
{
    [System.Reflection.Obfuscation(Feature = "renaming", Exclude = true)]
    public class GlobalOption : OptionBase<GlobalOption>
    {
        public SerializableDictionary<string, string> Dic = new SerializableDictionary<string, string>();

        protected override void Initialize()
        {
        }

        public void SetValue(string key, string value)
        {
            key = key.ToUpper();
            if (Dic.ContainsKey(key))
                Dic[key] = value;
            else
                Dic.Add(key, value);
        }

        public string GetValue(string key)
        {
            key = key.ToUpper();
            if (!Dic.ContainsKey(key)) 
                return string.Empty;
            return Dic[key];
        }
    }
}