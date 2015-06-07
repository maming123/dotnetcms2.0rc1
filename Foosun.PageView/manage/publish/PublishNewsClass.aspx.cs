using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.publish
{
    public partial class PublishNewsClass : Foosun.PageBasic.ManagePage
    {
        DataTable DataClassTable = null;
        Foosun.CMS.NewsClass NewsClassCMS = new CMS.NewsClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Foosun.Config.verConfig.PublicType == "0")
                {
                    pIndex.Visible = false;
                }
                DataClassTable = NewsClassCMS.GetList("isRecyle<>1 and isPage = 0 and SiteID='" + Foosun.Global.Current.SiteID + "' and isLock=0");
                InitialDivClass(divClassClass);
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