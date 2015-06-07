using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;

namespace Foosun.PageView.Update
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string SqlPath = Server.MapPath("\\Update\\SQL\\UpdateTable.sql");
            string menuPath = Server.MapPath("\\Update\\SQL\\menu.sql");
            try
            {
                if (File.Exists(SqlPath))
                {
                    string connStr = string.Format("server={0};uid={1};pwd={2};database={3};", tbxServer.Text, tbxLoginId.Text, tbxPassword.Text, tbxDbName.Text);
                    StreamReader sr = File.OpenText(SqlPath);
                    string SqlContent = sr.ReadToEnd();
                    sr.Close();
                    SqlContent = replaceTablePre(SqlContent, tbx_uName.Text.Trim());
                    Foosun.Install.Comm.ExecuteSql(connStr, SqlContent);
                    sr = File.OpenText(menuPath);
                    string MenuContent = sr.ReadToEnd();
                    sr.Close();
                    Foosun.Install.Comm.ExecuteSql(connStr, MenuContent);
                    if (Directory.Exists(Server.MapPath("~/Update/SQL")))
                    {
                        Directory.Delete(Server.MapPath("~/Update/SQL"), true);
                    }
                    if (File.Exists(Server.MapPath("~/Update/index.aspx")))
                    {
                        File.Delete(Server.MapPath("~/Update/index.aspx"));
                    }
                    Common.MessageBox.ShowAndRedirect(this, "升级成功1", "../" + Foosun.Config.UIConfig.dirMana + "/login.aspx");
                }
                else
                {
                    Common.MessageBox.Show(this, "升级数据库脚本文件不存在!");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Common.MessageBox.Show(this, "发生错误:" + ex.Message);
            }
        }

        /// <summary>
        /// 替换数据表前缀以及数据库名称
        /// </summary>
        /// <param name="sqlscript">sql脚本</param>
        /// <param name="tbpre">数据表前缀</param>
        protected string replaceTablePre(string sqlscript, string tbpre)
        {
            string s_result = Regex.Replace(sqlscript, @"[Ff][Ss]_", tbpre, RegexOptions.Compiled);
            return s_result;
        }
    }
}