using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Common;
using System.Reflection;
using Foosun.IDAL;

namespace Foosun.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["WebDAL"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    DataCache.SetCache(ClassNamespace, objType);//写入缓存
                }
                catch
                { }
            }
            return objType;
        }
        /// <summary>
        /// 创建NewsClass数据层接口。
        /// </summary>
        public static Foosun.IDAL.INewsClass CreateNewsClass()
        {
            string ClassNamespace = AssemblyPath + ".NewsClass";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.INewsClass)objType;
        }

        /// <summary>
        /// 创建News数据层接口。
        /// </summary>
        public static Foosun.IDAL.INews CreateNews()
        {

            string ClassNamespace = AssemblyPath + ".News";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.INews)objType;
        }
        /// <summary>
        /// 创建专题数据层接口
        /// </summary>
        /// <returns></returns>
        public static Foosun.IDAL.INewsSpecial CreateNewsSpecial()
        {

            string ClassNamespace = AssemblyPath + ".NewsSpecial";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.INewsSpecial)objType;
        }
        /// <summary>
        /// 创建用户登录数据层接口
        /// </summary>
        /// <returns></returns>
        public static Foosun.IDAL.IUserLogin CreateUserLogin()
        {
            string ClassNamespace = AssemblyPath + ".UserLogin";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IUserLogin)objType;
        }

        public static Foosun.IDAL.IRootPublic CreaterootPublic() 
        {
            string ClassNamespace = AssemblyPath + ".RootPublic";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IRootPublic)objType;
        }

        /// <summary>
        /// 创建NewsJS数据层接口。
        /// </summary>
        public static Foosun.IDAL.INewsJS CreateNewsJS()
        {

            string ClassNamespace = AssemblyPath + ".NewsJS";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.INewsJS)objType;
        }

        /// <summary>
        /// 创建NewsJSFile数据层接口。
        /// </summary>
        public static Foosun.IDAL.INewsJSFile CreateNewsJSFile()
        {

            string ClassNamespace = AssemblyPath + ".NewsJSFile";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.INewsJSFile)objType;
        }

        /// <summary>
        /// 创建NewsJSTemplet数据层接口。
        /// </summary>
        public static Foosun.IDAL.INewsJSTemplet CreateNewsJSTemplet()
        {

            string ClassNamespace = AssemblyPath + ".NewsJSTemplet";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.INewsJSTemplet)objType;
        }

        /// <summary>
        /// 创建NewsJSTempletClass数据层接口。
        /// </summary>
        public static Foosun.IDAL.INewsJSTempletClass CreateNewsJSTempletClass()
        {

            string ClassNamespace = AssemblyPath + ".NewsJSTempletClass";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.INewsJSTempletClass)objType;
        }

        /// <summary>
        /// 创建DefineClass数据层接口。
        /// </summary>
        public static Foosun.IDAL.IDefineClass CreateDefineClass()
        {

            string ClassNamespace = AssemblyPath + ".DefineClass";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IDefineClass)objType;
        }

        /// <summary>
        /// 创建DefineData数据层接口。
        /// </summary>
        public static Foosun.IDAL.IDefineData CreateDefineData()
        {

            string ClassNamespace = AssemblyPath + ".DefineData";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IDefineData)objType;
        }

        /// <summary>
        /// 创建DefineSave数据层接口。
        /// </summary>
        public static Foosun.IDAL.IDefineSave CreateDefineSave()
        {

            string ClassNamespace = AssemblyPath + ".DefineSave";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IDefineSave)objType;
        }

        /// <summary>
        /// 创建Navi数据层接口。
        /// </summary>
        public static Foosun.IDAL.INavi CreateNavi()
        {

            string ClassNamespace = AssemblyPath + ".Navi";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.INavi)objType;
        }

        /// <summary>
        /// 创建UserConstr数据层接口。
        /// </summary>
        public static Foosun.IDAL.IUserConstr CreateUserConstr()
        {

            string ClassNamespace = AssemblyPath + ".UserConstr";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IUserConstr)objType;
        }

        /// <summary>
        /// 创建newsgen数据层接口。
        /// </summary>
        public static Foosun.IDAL.INewsGen CreateNewsGen()
        {

            string ClassNamespace = AssemblyPath + ".NewsGen";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.INewsGen)objType;
        }
        /// <summary>
        /// 创建newsgen数据层接口。
        /// </summary>
        public static Foosun.IDAL.Isys Createsys()
        {

            string ClassNamespace = AssemblyPath + ".sys";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.Isys)objType;
        }
        /// <summary>
        /// 创建style数据层接口。
        /// </summary>
        public static Foosun.IDAL.IStyle CreateStyle()
        {

            string ClassNamespace = AssemblyPath + ".Style";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IStyle)objType;
        }
        /// <summary>
        /// 通用分页
        /// </summary>
        public static IPagination CreatePagination()
        {
            string ClassNamespace = AssemblyPath + ".Pagination";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IPagination)objType;           
        }
        /// <summary>
        /// 稿件
        /// </summary>
        /// <returns></returns>
        public static IConstr CreateConstr()
        {
            string ClassNamespace = AssemblyPath + ".Constr";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IConstr)objType;  
        }

        public static IRecyle CreateRecyle()
        {
            string ClassNamespace = AssemblyPath + ".Recyle";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IRecyle)objType;  
        }

        /// <summary>
        /// 管理员组
        /// </summary>
        /// <returns></returns>
        public static IAdminGroup CreateAdminGroup()
        {
            string ClassNamespace = AssemblyPath + ".AdminGroup";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IAdminGroup)objType;
        }
        /// <summary>
        /// 用户
        /// </summary>
        /// <returns></returns>
        public static IUserMisc CreateUserMisc()
        {
            string ClassNamespace = AssemblyPath + ".UserMisc";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IUserMisc)objType;
        }
        /// <summary>
        /// 标签
        /// </summary>
        /// <returns></returns>
        public static ILabel CreateLabel()
        {
            string ClassNamespace = AssemblyPath + ".Label";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ILabel)objType;
        }
        /// <summary>
        /// 自由标签
        /// </summary>
        /// <returns></returns>
        public static IFreeLabel CreateFreeLabel()
        {
            string ClassNamespace = AssemblyPath + ".FreeLabel";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IFreeLabel)objType;
        }
        /// <summary>
        /// 自由标签
        /// </summary>
        /// <returns></returns>
        public static IFrindLink CreateFrindLink()
        {
            string ClassNamespace = AssemblyPath + ".FrindLink";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IFrindLink)objType;
        }

        /// <summary>
        /// 广告系统
        /// </summary>
        /// <returns></returns>
        public static IAds CreateAds()
        {
            string ClassNamespace = AssemblyPath + ".Ads";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IAds)objType;
        }

        /// <summary>
        /// 附件管理
        /// </summary>
        public static Foosun.IDAL.IAttachments CreateAttachments()
        {

            string ClassNamespace = AssemblyPath + ".Attachments";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IAttachments)objType;
        }

        /// <summary>
        /// 发布管理
        /// </summary>
        /// <returns></returns>
        public static Foosun.IDAL.IPublish CreatePublish()
        {
            string ClassNamespace = AssemblyPath + ".Publish";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IPublish)objType;
        }
        /// <summary>
        /// 会员列表
        /// </summary>
        /// <returns></returns>
        public static Foosun.IDAL.IUserList CreateUserList()
        {
            string ClassNamespace = AssemblyPath + ".UserList";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IUserList)objType;
        }
        /// <summary>
        /// 会员
        /// </summary>
        /// <returns></returns>
        public static Foosun.IDAL.IUser CreateUser()
        {
            string ClassNamespace = AssemblyPath + ".User";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IUser)objType;
        }
        public static Foosun.IDAL.IInfo CreateInfo()
        {
            string ClassNamespace = AssemblyPath + ".Info";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IInfo)objType;
        }
        /// <summary>
        /// 评论
        /// </summary>
        /// <returns></returns>
        public static Foosun.IDAL.IMycom CreateMycom()
        {
            string ClassNamespace = AssemblyPath + ".Mycom";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IMycom)objType;
        }
        /// <summary>
        /// 短消息
        /// </summary>
        /// <returns></returns>
        public static Foosun.IDAL.IMessage CreateMessage()
        {
            string ClassNamespace = AssemblyPath + ".Message";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IMessage)objType;
        }
        /// <summary>
        /// 自定义字段
        /// </summary>
        /// <returns></returns>
        public static Foosun.IDAL.IDefineTable CreateDefineTable()
        {
            string ClassNamespace = AssemblyPath + ".DefineTable";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.IDefineTable)objType;
        }

        /// <summary>
        /// 采集系统
        /// </summary>
        /// <returns></returns>
        public static Foosun.IDAL.ICollect CreateCollect()
        {
            string ClassNamespace = AssemblyPath + ".Collect";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Foosun.IDAL.ICollect)objType;
        }

        /// <summary>
        /// 管理员信息
        /// </summary>
        /// <returns></returns>
        public static IAdmin CreateAdmin()
        {
            string ClassNamespace = AssemblyPath + ".Admin";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IAdmin)objType;
        }

        /// <summary>
        /// 投票信息
        /// </summary>
        /// <returns></returns>
        public static ISurvey CreateSurvey()
        {
            string ClassNamespace = AssemblyPath + ".Survey";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISurvey)objType;
        }

        /// <summary>
        /// 数据库操作
        /// </summary>
        /// <returns></returns>
        public static IDatabase CreateDatabase()
        {
            string ClassNamespace = AssemblyPath + ".Database";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDatabase)objType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDynamicTrans CreateDynamicTrans()
        {
            string ClassNamespace = AssemblyPath + ".DynamicTrans";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDynamicTrans)objType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IFriend CreateFriend()
        {
            string ClassNamespace = AssemblyPath + ".Friend";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IFriend)objType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDiscuss CreateDiscuss()
        {
            string ClassNamespace = AssemblyPath + ".Discuss";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDiscuss)objType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IPhoto CreatePhoto()
        {
            string ClassNamespace = AssemblyPath + ".Photo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IPhoto)objType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IRss CreateRss()
        {
            string ClassNamespace = AssemblyPath + ".Rss";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IRss)objType;
        }

        /// <summary>
        /// 前台动态搜索
        /// </summary>
        /// <returns></returns>
        public static ISearch CreateSearch()
        {
            string ClassNamespace = AssemblyPath + ".Search";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISearch)objType;
        }
        /// <summary>
        /// 地区
        /// </summary>
        /// <returns></returns>
        public static IArealist CreateArealist()
        {
            string ClassNamespace = AssemblyPath + ".Arealist";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IArealist)objType;
        }
        /// <summary>
        /// 统计
        /// </summary>
        /// <returns></returns>
        public static IStat CreateStat()
        {
            string ClassNamespace = AssemblyPath + ".Stat";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IStat)objType;
        }

        /// <summary>
        /// 拖拽发布的模版绑定
        /// </summary>
        /// <returns></returns>
        public static IDropTemplet CreateDropTemplet()
        {
            string ClassNamespace = AssemblyPath + ".DropTemplet";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDropTemplet)objType;
        }

        /// <summary>
        /// 自定义表单
        /// </summary>
        /// <returns></returns>
        public static ICustomForm CreateCustomForm()
        {
            string ClassNamespace = AssemblyPath + ".CustomForm";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ICustomForm)objType;
        }
    }
}
