using System;
using System.Collections.Generic;
using System.Text;
using Foosun.DALProfile;
using System.Data.Common;
using Foosun.Config;
using System.Data.OleDb;

namespace Foosun.AccessDAL
{
    public class DbBase : IDbBase
    {
        DbCommand IDbBase.CreateCommand()
        {
            return new OleDbCommand();
        }
        DbConnection IDbBase.CreateConnection()
        {
            return new OleDbConnection();
        }
        DbDataAdapter IDbBase.CreateDataAdapter()
        {
            return new OleDbDataAdapter();
        }
        DbParameter IDbBase.CreateParameter()
        {
            return new OleDbParameter();
        }
        public string Pre;
        public DbBase()
        {
            Pre = DBConfig.TableNamePrefix;
            DbHelper.Provider = this;
        }
    }
}
