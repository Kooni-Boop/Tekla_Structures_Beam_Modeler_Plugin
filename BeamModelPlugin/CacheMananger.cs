using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace BeamModelPlugin.Base
{
    /// <summary>
    /// 성능 향상등을 이유로 메모리에 저장하는 캐쉬 관리
    /// </summary>
    public class CacheManager
    {
        private static CacheManager _instance = null;

        public static CacheManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CacheManager();
                return _instance;
            }
        }

        private CacheManager()
        {
            _timer = new Timer(2000);
            _timer.Elapsed += _timer_Elapsed;
        }

        private bool _enable = true;

        private Timer _timer = null;

        public void Begin()
        {
            if (!_enable)
                return;

            if (_timer.Enabled)
            {
                _timer.Stop();
            }
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();

            //LineSpliterBySolidMulti.ClearCache();
            //PourBreakSpliter.ClearCache();
            //PourObjectGeometryManager.ClearCache();
            LogManager.ShowLog();
            LogManager.Clear();
        }

        public void End()
        {
            if (!_enable)
                return;
            _timer.Start();
        }
    }
}