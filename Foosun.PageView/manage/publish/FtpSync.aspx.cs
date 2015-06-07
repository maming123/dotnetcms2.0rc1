using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.IO;
using Foosun.NetTransmission;

namespace Foosun.PageView.manage.publish
{
    public partial class FtpSync : System.Web.UI.Page
    {
        protected List<string> queue = Common.Public.GetFTPQueue();
        protected Model.FtpConfig ftpInfo = (Model.FtpConfig)System.Web.HttpContext.Current.Application["FTPInfo"];
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFtpEnabled.Text = ftpInfo.Enabled == 1 ? "启用" : "禁用";
            if (ftpInfo.Enabled == 1)
            {
                if (ftpInfo.IsSynchronized)
                {
                    lblFtpEnabled.Text = ftpInfo.Operator + "正在同步";
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                    Button4.Enabled = true;
                }
                else
                {
                    lblFtpEnabled.Text = "启用";
                }
            }
            else
            {
                lblFtpEnabled.Text = "禁用";
            }
            if (!IsPostBack)
            {
                showQueueList();
            }
            if (ftpInfo.Enabled != 1)
            {
                Button1.Enabled = false;
                Button2.Enabled = false;
            }
        }

        private void showQueueList()
        {
            lblQueueCount.Text = queue.Count.ToString();
            Repeater1.DataSource = queue;
            Repeater1.DataBind();
        }

        /// <summary>
        /// 仅同步列队的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (queue.Count > 0 && ftpInfo.Enabled == 1)
            {
                Application.Lock();
                ftpInfo.Operator = Foosun.Global.Current.UserName;
                Application.UnLock();
                FtpTransmission ftp = new FtpTransmission(ftpInfo.IP, ftpInfo.Port, ftpInfo.UserName, ftpInfo.Password);
                if (ftp.IsConnected)
                {
                    ftp.FileQueue = queue;
                    ftp.FtpConfg = ftpInfo;
                    Thread workerThread = new Thread(new ThreadStart(ftp.UploadFile));
                    workerThread.Priority = ThreadPriority.AboveNormal;
                    Application.Lock();
                    Application["FTPThread"] = workerThread;
                    Application.UnLock();
                    workerThread.Start();
                    Response.Redirect("FTPSync.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('FTP服务器无法连接\\n请检查你的FTP服务器配置信息！');location.href='FTPSync.aspx';", true);
                }
            }

        }

        /// <summary>
        /// 同步所有需要同步的静态文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            #region 模板目录
            string[] temp = Directory.GetFiles(Server.MapPath("~/" + Foosun.Config.UIConfig.dirTemplet), "*", SearchOption.AllDirectories);
            for (int c = 0; c < temp.Length; c++)
            {
                if (!queue.Contains(temp[c]))
                {
                    queue.Add(temp[c]);
                }
            }
            #endregion

            #region 文件管理目录
            temp = Directory.GetFiles(Server.MapPath("~/configuration/js"), "*", SearchOption.AllDirectories);
            for (int c = 0; c < temp.Length; c++)
            {
                if (!queue.Contains(temp[c]))
                {
                    queue.Add(temp[c]);
                }
            }
            #endregion

            #region 管理员附件
            temp = Directory.GetFiles(Server.MapPath("~/" + Foosun.Config.UIConfig.dirFile), "*", SearchOption.AllDirectories);
            for (int c = 0; c < temp.Length; c++)
            {
                if (!queue.Contains(temp[c]))
                {
                    queue.Add(temp[c]);
                }
            }
            #endregion
            #region 用户附件目录
            temp = Directory.GetFiles(Server.MapPath("~/" + Foosun.Config.UIConfig.UserdirFile), "*", SearchOption.AllDirectories);
            for (int c = 0; c < temp.Length; c++)
            {
                if (!queue.Contains(temp[c]))
                {
                    queue.Add(temp[c]);
                }
            }
            #endregion
            #region 文件管理目录
            temp = Directory.GetFiles(Server.MapPath("~/" + Foosun.Config.UIConfig.filePath), "*", SearchOption.AllDirectories);
            for (int c = 0; c < temp.Length; c++)
            {
                if (!queue.Contains(temp[c]))
                {
                    queue.Add(temp[c]);
                }
            }
            #endregion

            if (queue.Count > 0 && ftpInfo.Enabled == 1)
            {
                Application.Lock();
                ftpInfo.Operator = Foosun.Global.Current.UserName;
                Application.UnLock();
                FtpTransmission ftp = new FtpTransmission(ftpInfo.IP, ftpInfo.Port, ftpInfo.UserName, ftpInfo.Password);
                if (ftp.IsConnected)
                {
                    ftp.FileQueue = queue;
                    ftp.FtpConfg = ftpInfo;
                    Thread workerThread = new Thread(new ThreadStart(ftp.UploadFile));
                    workerThread.Priority = ThreadPriority.AboveNormal;
                    Application.Lock();
                    Application["FTPThread"] = workerThread;
                    Application.UnLock();
                    workerThread.Start();
                    Response.Redirect("FTPSync.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('FTP服务器无法连接\n请检查你的FTP服务器配置信息！');location.href='FTPSync.aspx';", true);
                }
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Application.Lock();
            (Application["FTPThread"] as Thread).Abort();
            ftpInfo.IsSynchronized = false;
            Application.UnLock();
            Response.Redirect("FTPSync.aspx");
        }
    }
}