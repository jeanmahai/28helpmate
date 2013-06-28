using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpmate.DataService.Entity;

namespace Helpmate.DataService.Logic
{
    /// <summary>
    /// 采集加拿大数据实现类
    /// </summary>
    public class CollectCanadanData : ICollectData
    {
        #region 单例模式

        private CollectCanadanData()
        { }
        private static CollectCanadanData _Instance;
        public static CollectCanadanData Instance()
        {
            if (_Instance == null)
                _Instance = new CollectCanadanData();
            return _Instance;
        }

        #endregion

        #region ICollectData 成员

        /// <summary>
        /// 采集加拿大数据
        /// </summary>
        /// <param name="periodNum">期号</param>
        /// <returns></returns>
        public CollectResultEntity Collect(long periodNum)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 采集期号
        /// </summary>
        /// <returns></returns>
        public CollectResultEntity CollectPeriodNum()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
