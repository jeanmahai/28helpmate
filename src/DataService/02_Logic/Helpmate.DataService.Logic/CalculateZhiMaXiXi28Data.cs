using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpmate.DataService.Entity;

namespace Helpmate.DataService.Logic
{
    /// <summary>
    /// 计算芝麻西西网站数据实现类
    /// </summary>
    public class CalculateZhiMaXiXi28Data : ICalculate28Data
    {
        #region 单例模式

        private CalculateZhiMaXiXi28Data()
        { }
        private static CalculateZhiMaXiXi28Data _Instance;
        public static CalculateZhiMaXiXi28Data Instance()
        {
            if (_Instance == null)
                _Instance = new CalculateZhiMaXiXi28Data();
            return _Instance;
        }

        #endregion

        #region ICalculateData 成员

        /// <summary>
        /// 计算芝麻西西网站数据
        /// </summary>
        /// <param name="collectResult">采集结果</param>
        /// <returns></returns>
        public SourceDataEntity Calculate(CollectResultEntity collectResult)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
