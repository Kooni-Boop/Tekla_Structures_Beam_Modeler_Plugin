using System.Collections.Generic;
using TSPlugins = Tekla.Structures.Plugins;

namespace BeamModelPlugin
{
    public class StructuresData
    {
        [TSPlugins.StructuresField("TopLeftCut")] public double TopLeftCut = 0;
        [TSPlugins.StructuresField("TopWidth")] public double TopWidth = 0;
        [TSPlugins.StructuresField("TopRightCut")] public double TopRightCut = 0;
        [TSPlugins.StructuresField("TopWedgeCut")] public double TopWedgeCut = 0;
        [TSPlugins.StructuresField("RightHeight")] public double RightHeight = 0;
        [TSPlugins.StructuresField("BotWedgeCut")] public double BotWedgeCut = 0;
        [TSPlugins.StructuresField("CentHeight")] public double CentHeight = 0;
        [TSPlugins.StructuresField("LeftHeight")] public double LeftHeight = 0;

        public static Dictionary<string, object> GetDefaultValueDic()
        {
            var dic = new Dictionary<string, object>();
            dic.Add("TopLeftCut", 0);
            dic.Add("TopWidth", 600);
            dic.Add("TopRightCut", 0);
            dic.Add("TopWedgeCut", 0);
            dic.Add("RightHeight", 0);
            dic.Add("BotWedgeCut", 0);
            dic.Add("CentHeight", 800);
            dic.Add("LeftHeight", 0);
            return dic;
        }
    }

    //public static Dictionary<string, object> GetDefaultValueDic()
    //{
    //var dic = new Dictionary<string, object>();
    //dic.Add("Att1", "");
    //return dic;
    //}
}