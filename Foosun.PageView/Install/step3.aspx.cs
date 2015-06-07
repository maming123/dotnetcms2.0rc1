using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Foosun.PageView.Install
{
    public partial class step3 : System.Web.UI.Page
    {
        private string sitedir = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.CacheControl = "no-cache";
            sitedir = Server.MapPath("~");
            Page.Server.ScriptTimeout = 1000;
            string GetSet = Request.QueryString["set"];
            string gSN = Request.QueryString["sn"];

            string foosunPath = Request.QueryString["foosunPath"];
            string helpkeyPath = Request.QueryString["helpkeypath"];
            string collectPath = Request.QueryString["collectpath"];
            if (!(string.IsNullOrEmpty(foosunPath) && string.IsNullOrEmpty(helpkeyPath) && string.IsNullOrEmpty(collectPath)))
            {
                string errmsg = "";
                if (!existFile(foosunPath))
                {
                    errmsg += "<li>" + "主数据库路径不正确" + "</li>";
                }
                if (!existFile(helpkeyPath))
                {
                    errmsg += "<li>" + "帮助数据库路径不正确" + "</li>";
                }
                if (!existFile(collectPath))
                {
                    errmsg += "<li>" + "采集数据库路径不正确" + "</li>";
                }
                if (errmsg == "")
                {
                    errmsg += setWebConfig(foosunPath, helpkeyPath, collectPath);
                }
                StartInstall_Access(errmsg);
            }

            if (GetSet != null && GetSet != string.Empty)
            {
                //if (gSN.Length != 29)
                //{
                //    Response.Write("请正确填写序列号&nbsp; &nbsp; <a href=\"javascript:closediv();\"> <span style=\"color:Blue\">重新操作</span>");
                //    Response.End();
                //}
                //Foosun.Config.UIConfig osn = new Foosun.Config.UIConfig();
                //string snpass = osn.snportpass();
                //Foosun.Config.Series sn = new Foosun.Config.Series();
                //string Inputpass = sn.EnPas(gSN).ToUpper();
                //if (Inputpass != snpass)
                //{
                //    Response.Write("序列号错误&nbsp; &nbsp; <a href=\"javascript:closediv();\"> <span style=\"color:Blue\">重新操作</span>");
                //    Response.End();
                //}
                StartInstall_Click();
            }
        }

        protected void StartInstall_Click()
        {
            string s_DbType = Request.QueryString["DbType"];
            string s_datasource = Request.QueryString["datasource"];
            string s_initialcatalog = Request.QueryString["initialcatalog"];
            string s_userid = Request.QueryString["userid"];
            string s_password = Request.QueryString["password"];
            string s_tableprefix = Request.QueryString["gtableprefix"];

            string ResultStr = CreateDataBase(s_datasource, s_userid, s_password, s_initialcatalog, s_tableprefix);
            if (ResultStr != "0")
            {
                Response.Write(ResultStr + "&nbsp; &nbsp; <a href=\"javascript:closediv();\"> <span style=\"color:Blue\">重新操作</span>");
                Response.End();
            }
            ResultStr = setWebConfig(s_datasource, s_userid, s_password, s_initialcatalog, s_tableprefix);
            if (ResultStr != "0")
            {
                Response.Write("创建数据库成功!但：" + ResultStr + " &nbsp; &nbsp; <a href=\"javascript:closediv();\"><span style=\"color:Blue\">重新操作</span>&nbsp; &nbsp; <a href=\"step4.aspx\"><span style=\"color:Blue\">下一步</span>");
                Response.End();
            }
            else
            {
                ResultStr = "<span style=\"font-weight:bold;font-size:16px;color:Green;\">恭喜！操作成功!</span><a href=\"step4.aspx\"> &nbsp; <span style=\"color:blue\">进行下一步操作</span>";
            }
            Response.Write(ResultStr);
            Response.End();
        }

        protected void StartInstall_Access(string errMSG)
        {
            string ResultStr = "";
            if (errMSG == "")
            {
                ResultStr = "<span style=\"font-weight:bold;font-size:16px;color:Green;\">恭喜！操作成功!</span><a href=\"step4.aspx\"> &nbsp; <span style=\"color:blue\">进行下一步操作</span>";
            }
            else
            {
                ResultStr = errMSG + "<a href=\"javascript:closediv();\"><span style=\"color:blue\">重新操作</span></a>";
            }
            Response.Write(ResultStr);
            Response.End();
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="server">数据库服务器地址</param>
        /// <param name="user">数据库用户名</param>
        /// <param name="pwd">数据库用户密码</param>
        /// <param name="dbname">要创建的数据库名称</param>
        /// <param name="tbpre">数据库表前缀</param>
        /// <param name="adminname">管理员帐号</param>
        /// <param name="adminpwd">管理员密码</param>
        protected string CreateDataBase(string server, string user, string pwd, string dbname, string tbpre)
        {
            string GetResultStr = "0";
            string s_dbsqlpath = sitedir.TrimEnd('\\') + "\\Install\\SQL\\CreatData.sql";
            try
            {
                if (File.Exists(s_dbsqlpath))
                {
                    //------------------------建立数据库----------------------------
                    string connStr = string.Format("data source={0};user id={1};password={2};persist security info=false;packet size=4096", server, user, pwd);

                    Foosun.Install.Comm.ExecuteSql(connStr, "master", "IF Not EXISTS (select name from master.dbo.sysdatabases where name = N'" + dbname + "') CREATE DATABASE " + "[" + dbname + "]" + " COLLATE Chinese_PRC_CI_AS");

                    //用dbhelper执行方式
                    StreamReader sr1 = File.OpenText(s_dbsqlpath);
                    string s_sqlcontent = sr1.ReadToEnd();
                    sr1.Close();
                    s_sqlcontent = replaceTablePre(s_sqlcontent, dbname, tbpre);
                    Foosun.Install.Comm.ExecuteSql(connStr, dbname, s_sqlcontent);

                    //执行创建存储过程
                    Foosun.Install.Comm.ExecuteSql(connStr, dbname, "CREATE PROCEDURE [" + tbpre + "publish_CHupdateishtml] @tablename varchar(30),@filedname varchar(30),@idtype varchar(30),@id int AS begin declare @sql varchar(500) set @sql='update '+@tablename +' set '+@filedname+'=1 where '+@idtype+'='+'''+@id+''' exec (@sql) end");
                    Foosun.Install.Comm.ExecuteSql(connStr, dbname, "CREATE PROCEDURE [" + tbpre + "publish_updateishtml] @tablename varchar(30),@filedname varchar(30),@idtype varchar(30),@newsid varchar(12) AS begin declare @sql varchar(500) set @sql='update '+@tablename +' set '+@filedname+'=1 where '+@idtype+'='+''''+@newsid+'''' exec (@sql) end");

                }
                else
                {
                    GetResultStr = "数据库脚本文件不存在!";
                }
            }
            catch (Exception e)
            {
                GetResultStr = "" + e.Message + "";
            }
            return GetResultStr;
        }

        /// <summary>
        /// 替换数据表前缀以及数据库名称
        /// </summary>
        /// <param name="sqlscript">sql脚本</param>
        /// <param name="dbname">数据库名称</param>
        /// <param name="tbpre">数据表前缀</param>
        protected string replaceTablePre(string sqlscript, string dbname, string tbpre)
        {
            string s_result = Regex.Replace(sqlscript, @"[Ff][Ss]_", tbpre, RegexOptions.Compiled);
            s_result = Regex.Replace(s_result, @"DO_NET_CMS", dbname, RegexOptions.Compiled);
            return s_result;
        }

        /// <summary>
        /// 设置Web.Config数据库参数
        /// </summary>
        protected string setWebConfig(string server, string user, string pwd, string dbname, string tbpre)
        {
            string ResultStr = "0";
            try
            {
                System.IO.FileInfo FileInfo = new System.IO.FileInfo(sitedir + "/web.config");
                System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
                xmlDocument.Load(FileInfo.FullName);
                bool FoundIt = false;
                foreach (System.Xml.XmlNode Node in xmlDocument["configuration"]["connectionStrings"])
                {
                    if (Node.Name == "add")
                    {
                        if (Node.Attributes.GetNamedItem("name").Value.ToLower() == "foosun")
                        {
                            Node.Attributes.GetNamedItem("connectionString").Value = String.Format("server={0};uid={1};pwd={2};database={3};", server, user, pwd, dbname);
                            FoundIt = true;
                        }
                        if (Node.Attributes.GetNamedItem("name").Value.ToLower() == "helpkey")
                        {
                            Node.Attributes.GetNamedItem("connectionString").Value = String.Format("server={0};uid={1};pwd={2};database={3};", server, user, pwd, dbname);
                            FoundIt = true;
                        }
                        if (Node.Attributes.GetNamedItem("name").Value.ToLower() == "collect")
                        {
                            Node.Attributes.GetNamedItem("connectionString").Value = String.Format("server={0};uid={1};pwd={2};database={3};", server, user, pwd, dbname);
                            FoundIt = true;
                        }
                    }
                }

                foreach (System.Xml.XmlNode Node in xmlDocument["configuration"]["appSettings"])
                {
                    if (Node.Name == "add")
                    {
                        if (Node.Attributes.GetNamedItem("key").Value.ToLower() == "dataRe")
                        {
                            Node.Attributes.GetNamedItem("value").Value = "FS_";
                            FoundIt = true;
                        }
                        if (Node.Attributes.GetNamedItem("key").Value.ToLower() == "webdal")
                        {
                            Node.Attributes.GetNamedItem("value").Value = "Foosun.SQLServerDAL";
                            FoundIt = true;
                        }
                        if (Node.Attributes.GetNamedItem("key").Value.ToLower() == "mssql")
                        {
                            Node.Attributes.GetNamedItem("value").Value = "1";
                            FoundIt = true;
                        }
                    }
                }

                if (!FoundIt)
                {
                    ResultStr = "配置Web.Config文件出错!";
                }
                xmlDocument.Save(FileInfo.FullName);
            }
            catch (Exception e)
            {
                ResultStr = "" + e.Message + "";
            }
            //写域名
            try
            {
                string siteDomain = Request.ServerVariables["SERVER_NAME"];
                string DomainPort = Request.ServerVariables["SERVER_PORT"];
                Common.Public.SaveXmlConfig("siteDomain", siteDomain, "xml/sys/base.config");
            }
            catch { }
            return ResultStr;
        }


        /// <summary>
        /// 设置Web.Config数据库参数
        /// </summary>
        /// <param name="foosunPath">主数据库路径</param>
        /// <param name="helpkeyPath">帮助数据库路径</param>
        /// <param name="CollectPath">采集数据库路径</param>
        /// <returns></returns>
        protected string setWebConfig(string foosunPath, string helpkeyPath, string CollectPath)
        {
            string ResultStr = "";
            try
            {
                System.IO.FileInfo FileInfo = new System.IO.FileInfo(sitedir + "/web.config");
                System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
                xmlDocument.Load(FileInfo.FullName);
                bool FoundIt = false;
                foreach (System.Xml.XmlNode Node in xmlDocument["configuration"]["connectionStrings"])
                {
                    if (Node.Name == "add")
                    {
                        if (Node.Attributes.GetNamedItem("name").Value.ToLower() == "foosun")
                        {
                            Node.Attributes.GetNamedItem("connectionString").Value = foosunPath;
                            FoundIt = true;
                        }
                        if (Node.Attributes.GetNamedItem("name").Value.ToLower() == "helpkey")
                        {
                            Node.Attributes.GetNamedItem("connectionString").Value = helpkeyPath;
                            FoundIt = true;
                        }
                        if (Node.Attributes.GetNamedItem("name").Value.ToLower() == "collect")
                        {
                            Node.Attributes.GetNamedItem("connectionString").Value = CollectPath;
                            FoundIt = true;
                        }
                    }
                }

                foreach (System.Xml.XmlNode Node in xmlDocument["configuration"]["appSettings"])
                {
                    if (Node.Name == "add")
                    {
                        if (Node.Attributes.GetNamedItem("key").Value.ToLower() == "dataRe")
                        {
                            Node.Attributes.GetNamedItem("value").Value = "FS_";
                            FoundIt = true;
                        }
                        if (Node.Attributes.GetNamedItem("key").Value.ToLower() == "webdal")
                        {
                            Node.Attributes.GetNamedItem("value").Value = "Foosun.AccessDAL";
                            FoundIt = true;
                        }
                        if (Node.Attributes.GetNamedItem("key").Value.ToLower() == "mssql")
                        {
                            Node.Attributes.GetNamedItem("value").Value = "0";
                            FoundIt = true;
                        }
                    }
                }

                if (!FoundIt)
                {
                    ResultStr = "配置Web.Config文件出错!";
                }
                xmlDocument.Save(FileInfo.FullName);
            }
            catch (Exception e)
            {
                ResultStr = "" + e.Message + "";
            }
            //写域名
            try
            {
                string siteDomain = Request.ServerVariables["SERVER_NAME"];
                string DomainPort = Request.ServerVariables["SERVER_PORT"];
                if (DomainPort != string.Empty && DomainPort != "80")
                {
                    siteDomain = siteDomain + ":" + DomainPort;
                }
                Common.Public.SaveXmlConfig("siteDomain", siteDomain, "xml/sys/base.config");
            }
            catch { }
            return ResultStr;
        }
        /// <summary>
        /// 显示错误信息，并中止操作
        /// </summary>
        /// <param name="errinfo">错误信息</param>
        protected void showError(string errinfo)
        {
            Response.Write(errinfo);
            Response.End();
        }


        protected bool existFile(string path)
        {
            FileInfo fi = new FileInfo(sitedir + path);
            if (fi.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
