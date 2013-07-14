using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.BizEntity.Enum
{
    public enum MenuEnum
    {
        Home, User, Omission, NormalTrend, Special, Tools, Log, SuperTrend, Pay, RemindSet
    }

    public enum MessageType
    {
        Loading = 0, Right = 1, Error = 2
    }

    public enum PageLevel
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4

    }

    public enum WeekDays
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Seturday = 6,
        Sunday = 7
    }

    public class ConsoleConst
    {
        public const string ERROR_SERVER = "无法连接到服务器，请稍后重试！";

        public const int ERROR_VALIDATE_TOKEN_CODE = 10001;
        public const string ERROR_VALIDATE_TOKEN_MSG = "您的帐号在其它地方登录，请重新登录！";
    }
}