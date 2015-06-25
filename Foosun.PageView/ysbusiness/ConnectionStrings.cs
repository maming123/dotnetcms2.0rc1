using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace DMedia.FetionActivity.Data.DataAccess
{
    /// <summary>
    /// 新增数据库时，请在FetionActivity数据库中的DataBaseList表中增加记录，并在本类中增加相应的Field
    /// </summary>
    public static partial class ConnectionStrings
    {


        /// <summary>
        /// 从数据库中获取数据库相应连接字符串
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static string GetConnectString(string dbKey)
        {
            return ConfigurationManager.ConnectionStrings[dbKey].ConnectionString;
        }



        public static readonly string Core = ConfigurationManager.ConnectionStrings["foosun"].ConnectionString;


    }
}
