﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Common.Utility.DataAccess.Database.DbProvider
{
    public interface IDbFactory
    {
        DbCommand CreateCommand();
        DbConnection CreateConnection();
        DbConnection CreateConnection(string connectionString);
        DbDataAdapter CreateDataAdapter();
        DbParameter CreateParameter();
    }
}
