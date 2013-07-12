using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.BizEntity.Enum
{
    public enum MenuEnum
    {
        Home, User, Omission, NormalTrend, Special, Tools, Log, SuperTrend, Pay
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
}
