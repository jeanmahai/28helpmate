using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Application.Framework.Data.DataAccess;
using Model.DataModel;

namespace DataAccess
{
    public class LotteryDAO
    {
        public List<LotteryDM> QueryLotteryByTwenty()
        {
            var cmd = DataCommandManager.GetDataCommand("QueryLotteryByTwenty");
            return cmd.ExecuteEntityList<LotteryDM>();
        }

        public List<LotteryDM> QueryLotteryByDay()
        {
            var cmd = DataCommandManager.GetDataCommand("QueryLotteryByDay");
            
            return cmd.ExecuteEntityList<LotteryDM>();
        }

        public List<LotteryDM> QueryLotteryByHourStep()
        {
            var cmd = DataCommandManager.GetDataCommand("QueryLotteryByHourStep");

            return cmd.ExecuteEntityList<LotteryDM>();
        }

        public List<LotteryDM> QueryNextLotteryWithSameNumber()
        {
            var cmd = DataCommandManager.GetDataCommand("QueryNextLotteryWithSameNumber");

            return cmd.ExecuteEntityList<LotteryDM>();
        }
    }
}
