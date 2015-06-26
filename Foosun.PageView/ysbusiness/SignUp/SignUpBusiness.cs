using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DMedia.FetionActivity.Data.DataAccess;
using DMedia.FetionActivity.Module.Utils;
using System.Data.SqlClient;

namespace Foosun.PageView.ysbusiness.SignUp
{
    public class SignUpBusiness
    {
        /// <summary>
        /// 1：添加成功 0 失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(SignUpItem model)
        {
            string strSql = string.Format(@"INSERT INTO [dbo].[ys_SignUp]
           ([NickName]
           ,[Sex]
           ,[Mobile]
           ,[WxCode]
           ,[Address]
           ,[Company]
           ,[ClassName]
           ,[CreateDateTime]
           ,[IPAddress])
     VALUES
           (@NickName--, nvarchar(50),>
           ,@Sex--, nvarchar(50),>
           ,@Mobile--, bigint,>
           ,@WxCode--, nvarchar(50),>
           ,@Address--, nvarchar(500),>
           ,@Company--, nvarchar(500),>
           ,@ClassName--, nvarchar(500),>
           ,@CreateDateTime--, datetime,>
           ,@IPAddress--, nvarchar(50),>
           )
            ");
           var parms = new[] { 
                new SqlParameter("@NickName",model.NickName),
                new SqlParameter("@Sex",model.Sex),
                new SqlParameter("@Mobile",model.Mobile),
                new SqlParameter("@WxCode",model.WxCode),
                new SqlParameter("@Address",model.Address),
                new SqlParameter("@Company",model.Company),
                new SqlParameter("@ClassName",model.ClassName),
                new SqlParameter("@CreateDateTime",model.CreateDateTime),
                new SqlParameter("@IPAddress",model.IPAddress)
            };
           int r =SqlHelper.ExecuteSql(strSql, parms, ConnectionStrings.Core);
           return r;
        }
    }
    public class SignUpItem
    {
        private string _NickName = "";
        private string _Sex = "";
        private long _Mobile = 0;
        private string _Address = "";
        private string _Company = "";
        private string _ClassName = "";
        private DateTime _CreateDateTime=DateTime.Now;
        private string _IPAddress = "";
        private string _WxCode = "";

        public string WxCode
        {
            get { return _WxCode; }
            set { _WxCode = value; }
        }
        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }
        public DateTime CreateDateTime
        {
            get { return _CreateDateTime; }
            set { _CreateDateTime = value; }
        }

        public string ClassName
        {
            get { return _ClassName; }
            set { _ClassName = value; }
        }

        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public long Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }

        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        public string NickName
        {
            get { return _NickName; }
            set { _NickName = value; }
        }
    }
}