using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpmate.DataService.Entity;
using Helpmate.DataService.DataAccess;
using System.Threading;
using Helpmate.DataService.Utility;

namespace Helpmate.DataService.Logic
{
    /// <summary>
    /// 算法
    /// </summary>
    public class Arithmetic
    {
        #region 单例模式

        private Arithmetic()
        { }
        private static Arithmetic _Instance;
        public static Arithmetic Instance()
        {
            if (_Instance == null)
                _Instance = new Arithmetic();
            return _Instance;
        }

        #endregion

        /// <summary>
        /// 采集并计算
        /// </summary>
        /// <param name="source">采集计算源</param>
        /// <param name="periodNum">期号</param>
        /// <param name="retTime">开奖时间</param>
        /// <param name="dbOperateType">DB操作类型</param>
        /// <returns></returns>
        public bool CollectAndCalculate(Source source, long periodNum, DateTime retTime, DBOperateType dbOperateType)
        {
            bool result = true;

            string errorMessage = "{0}，方法：CollectAndCalculate，期号：" + periodNum.ToString();

            try
            {
                //[[采集数据
                ICollectData collectData = CreateCollectData(source);
                if (collectData == null)
                {
                    WriteLog.Write(string.Format(errorMessage, "创建采集实现类失败"));
                    return false;
                }
                int tryTimes = 3;
                CollectResultEntity collectResult = null;
                while (tryTimes > 0)
                {
                    collectResult = collectData.Collect(periodNum);
                    if (collectResult == null || collectResult.Group == null || collectResult.Group.Length != 20)
                    {
                        result = false;
                        tryTimes--;
                        //如果采集失败，则间隔5秒重试，重试2次
                        Thread.Sleep(5 * 1000);
                    }
                    tryTimes = 0;
                }
                if (!result)
                {
                    WriteLog.Write(string.Format(errorMessage, "采集数据失败"));
                    return result;
                }
                collectResult.PeriodNum = periodNum;
                collectResult.RetTime = retTime;
                //]]

                //[[计算数据
                //28数据
                List<SourceDataEntity> sourceDataList28 = Calculate28Data(collectResult);
                //16数据
                //List<SourceDataEntity> sourceDataList16 = Calculate16Data(collectResult);
                if (sourceDataList28 == null || sourceDataList28.Count == 0)
                {
                    WriteLog.Write(string.Format(errorMessage, "计算数据失败"));
                    return false;
                }
                //]]

                //[[DB持久化
                //28数据
                if (dbOperateType == DBOperateType.Insert)
                    result = Insert28Data(source, sourceDataList28);
                switch (dbOperateType)
                {
                    case DBOperateType.Insert:
                        result = Insert28Data(source, sourceDataList28);
                        break;
                    case DBOperateType.Update:
                        result = Update28Data(source, sourceDataList28);
                        break;
                }
                //16数据
                //result = Insert16Data(source, sourceDataList16);
                //]]
            }
            catch (Exception ex)
            {
                WriteLog.Write(string.Format(errorMessage, "异常，异常信息：" + ex.ToString()));
            }

            return result;
        }
        /// <summary>
        /// 读取下期期号
        /// </summary>
        /// <param name="source">采集计算源</param>
        /// <returns></returns>
        public CollectResultEntity GetNextPeriodNum(Source source)
        {
            CollectResultEntity result = new CollectResultEntity();

            switch (source)
            {
                case Source.Beijing:
                    result = SourceDataDA.Instance().GetBeijingNextPeriodNum();
                    break;
                case Source.Canadan:
                    result = SourceDataDA.Instance().GetCanadanNextPeriodNum();
                    break;
                default:
                    result.PeriodNum = -1;
                    break;
            }

            //如果期号为0，则需要从网站采集
            if (result.PeriodNum == 0)
            {
                ICollectData collectData = CreateCollectData(source);
                if (collectData != null)
                    result = collectData.CollectPeriodNum();
            }

            return result;
        }
        /// <summary>
        /// 读取失败的期
        /// </summary>
        /// <param name="source">采集计算源</param>
        /// <returns></returns>
        public List<CollectResultEntity> GetFailPeriodList(Source source)
        {
            switch (source)
            {
                case Source.Beijing:
                    return SourceDataDA.Instance().GetBeijingFailPeriodList();
                case Source.Canadan:
                    return SourceDataDA.Instance().GetCanadanFailPeriodList();
                default:
                    return null;
            }
        }
        /// <summary>
        /// 失败时写入失败的数据
        /// </summary>
        /// <param name="source">采集计算源</param>
        /// <param name="periodNum">期号</param>
        /// <param name="retTime">开奖时间</param>
        public void FailInsertData(Source source, long periodNum, DateTime retTime)
        {
            List<SourceDataEntity> dataList = new List<SourceDataEntity>();
            SourceDataEntity item = new SourceDataEntity();

            //[[龙虎网站数据
            item.SiteSysNo = (int)Site.LongHu;
            item.PeriodNum = periodNum;
            item.RetTime = retTime;
            dataList.Add(item);
            //]]
            //[[计算71豆网站数据
            item = new SourceDataEntity();
            item.SiteSysNo = (int)Site.QiYiDou;
            item.PeriodNum = periodNum;
            item.RetTime = retTime;
            dataList.Add(item);
            //]]
            //[[计算芝麻西西网站数据
            item = new SourceDataEntity();
            item.SiteSysNo = (int)Site.ZhiMaXiXi;
            item.PeriodNum = periodNum;
            item.RetTime = retTime;
            dataList.Add(item);
            //]]

            Insert28Data(source, dataList);
        }
        /// <summary>
        /// 创建采集实现类
        /// </summary>
        /// <param name="source">采集计算源</param>
        /// <returns></returns>
        private ICollectData CreateCollectData(Source source)
        {
            switch (source)
            {
                case Source.Beijing:
                    return CollectBeijingData.Instance();
                case Source.Canadan:
                    return CollectCanadanData.Instance();
                default:
                    return null;
            }
        }
        #region 28
        /// <summary>
        /// 计算28数据
        /// </summary>
        /// <param name="collectResult">采集结果</param>
        /// <returns></returns>
        private List<SourceDataEntity> Calculate28Data(CollectResultEntity collectResult)
        {
            List<SourceDataEntity> result = null;

            ICalculate28Data calculateData = null;

            //[[计算龙虎网站数据
            calculateData = CalculateLongHu28Data.Instance();
            SourceDataEntity itemLongHu = calculateData.Calculate(collectResult);
            if (itemLongHu != null)
            {
                result = new List<SourceDataEntity>();
                result.Add(itemLongHu);
            }
            //]]
            //[[计算71豆网站数据
            calculateData = CalculateQiYiDou28Data.Instance();
            SourceDataEntity itemQiYiDou = calculateData.Calculate(collectResult);
            if (itemQiYiDou != null)
            {
                if (result == null)
                    result = new List<SourceDataEntity>();
                result.Add(itemQiYiDou);
            }
            //]]
            //[[计算芝麻西西网站数据
            calculateData = CalculateZhiMaXiXi28Data.Instance();
            SourceDataEntity itemZhiMaXiXi = calculateData.Calculate(collectResult);
            if (itemZhiMaXiXi != null)
            {
                if (result == null)
                    result = new List<SourceDataEntity>();
                result.Add(itemZhiMaXiXi);
            }
            //]]
            
            return result;
        }
        /// <summary>
        /// 28数据持久化写入
        /// </summary>
        /// <param name="source">采集计算源</param>
        /// <param name="dataList">写入数据实体</param>
        /// <returns></returns>
        private bool Insert28Data(Source source, List<SourceDataEntity> dataList)
        {
            switch (source)
            {
                case Source.Beijing:
                    return SourceDataDA.Instance().InsertSourceDataToBeijing28(dataList);
                case Source.Canadan:
                    return SourceDataDA.Instance().InsertSourceDataToCanadan28(dataList);
                default:
                    return false;
            }
        }
        /// <summary>
        /// 28数据持久化更新
        /// </summary>
        /// <param name="source">采集计算源</param>
        /// <param name="dataList">写入数据实体</param>
        /// <returns></returns>
        private bool Update28Data(Source source, List<SourceDataEntity> dataList)
        {
            switch (source)
            {
                case Source.Beijing:
                    return SourceDataDA.Instance().UpdateSourceDataToBeijing28(dataList);
                case Source.Canadan:
                    return SourceDataDA.Instance().UpdateSourceDataToCanadan28(dataList);
                default:
                    return false;
            }
        }
        #endregion
    }
}
