using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foosun.CMS;
using Foosun.Model;
using System.Data;
using Foosun.Publish;

namespace Foosun.PageView.manage.publish
{
    public partial class PublishIndex : Foosun.PageBasic.ManagePage
    {
        DataTable DataClassTable = null;
        Foosun.CMS.NewsClass NewsClassCMS = new CMS.NewsClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ReadType = Common.Public.readparamConfig("ReviewType");
                if (ReadType == "1")
                {
                    PageError("整站动态调用，不需要生成 如果要开启静态生成，请在[控制面板--参数设置]里设置", "javascript:history.back();", true);
                }
                DataClassTable = NewsClassCMS.GetList("isRecyle<>1 and isPage = 0 and SiteID='" + Foosun.Global.Current.SiteID + "' and isLock=0");
                InitialDivClass(divClassNews);
            }
        }

        /// <summary>
        /// 初始化divClassClass
        /// </summary>
        public void InitialDivClass(ListBox divClassBox)
        {

            DataRow[] rows = DataClassTable.Select("ParentID='0'");

            for (int i = 0; i < rows.Length; i++)
            {
                ListItem tempListItem = new ListItem();
                tempListItem.Value = rows[i]["ClassID"].ToString();
                tempListItem.Text = rows[i]["ClassCName"].ToString();
                divClassBox.Items.Add(tempListItem);
                InitialChildItems(tempListItem.Value, divClassBox, "┉┉");
            }

        }

        public void InitialChildItems(string ParentID, ListBox divClassBox, string strFlag)
        {
            DataRow[] rows = DataClassTable.Select(string.Format("ParentID='{0}'", ParentID.Replace("'", "''")));

            for (int i = 0; i < rows.Length; i++)
            {
                ListItem tempListChildItem = new ListItem();
                tempListChildItem.Value = rows[i]["ClassID"].ToString();
                tempListChildItem.Text = strFlag + rows[i]["ClassCName"].ToString();
                divClassBox.Items.Add(tempListChildItem);
                InitialChildItems(tempListChildItem.Value, divClassBox, strFlag + "┉┉");
            }

        }
    }
}