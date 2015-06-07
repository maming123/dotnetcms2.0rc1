using System;
using System.IO;
using System.Web.UI;
using System.Xml;
using Foosun.CMS;

namespace Foosun.PageView.manage.sys
{
    public partial class AdminPopSet : Foosun.PageBasic.ManagePage
    {
        public AdminPopSet() 
        {
            Authority_Code = "Q015";
        }
        Admin rd = new Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //copyright.InnerHtml = CopyRight;
                Response.CacheControl = "no-cache";
                string ReqUNum = Request.QueryString["UserNum"];
                string Id = Request.QueryString["id"];
                if (ReqUNum == "" && ReqUNum == null && Id == string.Empty && Id == null)
                {
                    Common.MessageBox.Show(this, "参数传递错误!");
                }
                else
                {
                    if (ReqUNum == Foosun.Global.Current.UserNum)
                    {
                        Common.MessageBox.Show(this, "自己给自己设置权限?");
                    }
                    string[] getReturn = rd.GetAdminPopList(Common.Input.checkID(ReqUNum), int.Parse(Id)).Split('|');
                    if (getReturn[0] == "1")
                    {
                        Common.MessageBox.Show(this, "系统管理员不需要设置权限。拥有全部权限!");
                    }
                    string PopList1 = getReturn[1];
                    string PopList = "";
                    string _dirdumm = Foosun.Config.UIConfig.dirDumm;
                    if (_dirdumm.Trim() != "") { _dirdumm = "/" + _dirdumm; }
                    string _num = Request.QueryString["num"];
                    if (_num != null && _num != string.Empty)
                    {
                        switch (_num.ToString())
                        {
                            case "5":
                                PopList = getRoot(_dirdumm + "/xml/sys/pop/rootPop.xml", "5");
                                break;
                            case "4":
                                PopList = getRoot(_dirdumm + "/xml/sys/pop/rootPop.xml", "4"); ;
                                break;
                            case "3":
                                PopList = getRoot(_dirdumm + "/xml/sys/pop/rootPop.xml", "3"); ;
                                break;
                            case "2":
                                PopList = getRoot(_dirdumm + "/xml/sys/pop/rootPop.xml", "2"); ;
                                break;
                            case "1":
                                PopList = getRoot(_dirdumm + "/xml/sys/pop/rootPop.xml", "1"); ;
                                break;
                            case "0":
                                PopList = getRoot(_dirdumm + "/xml/sys/pop/rootPop.xml", "0"); ;
                                break;
                            default:
                                PopList = PopList1;
                                break;
                        }
                    }
                    else { PopList = PopList1; }
                    contentPop.InnerHtml = ContentPopList(_dirdumm + "/xml/sys/pop/content/index.xml", PopList);
                    UserPop.InnerHtml = ContentPopList(_dirdumm + "/xml/sys/pop/user/index.xml", PopList);
                    TempletPop.InnerHtml = ContentPopList(_dirdumm + "/xml/sys/pop/templet/index.xml", PopList);
                    PublishPop.InnerHtml = ContentPopList(_dirdumm + "/xml/sys/pop/Publish/index.xml", PopList);
                    sysPlusPop.InnerHtml = ContentPopList(_dirdumm + "/xml/sys/pop/sysPlus/index.xml", PopList);
                    ControlPop.InnerHtml = ContentPopList(_dirdumm + "/xml/sys/pop/Control/index.xml", PopList);
                    APIPop.InnerHtml = ContentPopList(_dirdumm + "/xml/sys/pop/API/index.xml", PopList);
                }
            }
        }

        protected string ContentPopList(string _xmlPath, string Poplist)
        {
            string _Str = "";
            try
            {
                if (!File.Exists(Server.MapPath(_xmlPath))) 
                {
                    Common.MessageBox.Show(this, "找不到配置文件(" + _xmlPath + ").可能是虚拟目录配置出错.请修改web.config!");
                }
                string xmlPath = Server.MapPath(_xmlPath);
                FileInfo finfo = new FileInfo(xmlPath);
                System.Xml.XmlDocument xdoc = new XmlDocument();
                xdoc.Load(xmlPath);
                XmlElement root = xdoc.DocumentElement;
                XmlNodeList elemList = root.GetElementsByTagName("popname");
                XmlNodeList elemList1 = root.GetElementsByTagName("popnumber");
                if (!string.IsNullOrEmpty(Poplist))
                {
                    Poplist = "," + Poplist + ",";
                }
                for (int i = 0; i < elemList.Count; i++)
                {
                    string CheckSTR = "", tempCode = string.IsNullOrEmpty(elemList1[i].InnerXml) ? "" : "," + elemList1[i].InnerXml + ",";
                    if (Poplist.IndexOf(tempCode) != -1) { CheckSTR = " checked"; } else { CheckSTR = ""; }
                    _Str += "<label class=\"label\"><input class=\"check1\" value=\"" + elemList1[i].InnerXml + "\"" + CheckSTR + " name=\"PopList\" type=\"checkbox\" /><span onclick=\"getPopCode('" + elemList1[i].InnerXml + "');\" style=\"font-size:10px;\" title=\"权限代码，点击复制权限代码，对FireFox浏览器无效\">(" + elemList1[i].InnerXml + ")&nbsp;</span>" + elemList[i].InnerXml + "</label>\r";
                }
            }
            catch
            {
                _Str = "配置文件出错:" + _xmlPath + "";
            }
            return _Str;
        }

        protected string getRoot(string _xmlPath, string flgs)
        {
            string _Str = "";
            try
            {
                if (!File.Exists(Server.MapPath(_xmlPath))) 
                {
                    Common.MessageBox.Show(this, "找不到配置文件(" + _xmlPath + ").可能是虚拟目录配置出错.请修改web.config!");
                }
                string xmlPath = Server.MapPath(_xmlPath);
                FileInfo finfo = new FileInfo(xmlPath);
                System.Xml.XmlDocument xdoc = new XmlDocument();
                xdoc.Load(xmlPath);
                XmlElement root = xdoc.DocumentElement;
                XmlNodeList elemList = root.GetElementsByTagName("popname");
                XmlNodeList elemList1 = root.GetElementsByTagName("poplist");
                for (int i = 0; i < elemList.Count; i++)
                {
                    if (elemList[i].InnerXml == flgs) { _Str += elemList1[i].InnerXml; } else { continue; }
                }
            }
            catch
            {
                Common.MessageBox.Show(this, "配置文件出错:" + _xmlPath + "!");
            }
            return _Str;
        }

        /// <summary>
        /// 保存权限列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string ReqUNum = Request.QueryString["UserNum"];
                string ID = Request.QueryString["id"];
                string PopList = Request.Form["PopList"];
                rd.UpdatePOPlist(Common.Input.checkID(ReqUNum), int.Parse(Common.Input.checkID(ID)), PopList);
                Common.MessageBox.ShowAndRedirect(this, "更新权限成功!", "AdminList.aspx");
            }
        }
    }
}