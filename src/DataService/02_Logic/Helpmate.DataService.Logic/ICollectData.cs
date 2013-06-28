using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpmate.DataService.Entity;

namespace Helpmate.DataService.Logic
{
    /// <summary>
    /// 采集数据接口
    /// </summary>
    public interface ICollectData
    {
        /// <summary>
        /// 采集数据
        /// </summary>
        /// <param name="periodNum">期号</param>
        /// <returns></returns>
        CollectResultEntity Collect(long periodNum);

        /// <summary>
        /// 采集期号
        /// </summary>
        /// <returns></returns>
        CollectResultEntity CollectPeriodNum();
    }
}
