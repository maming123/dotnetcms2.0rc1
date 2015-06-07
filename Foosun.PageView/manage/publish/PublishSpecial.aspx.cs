using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.publish
{
    public partial class PublishSpecial : System.Web.UI.Page
    {
        DataTable dataSpecialTable = null;
        Foosun.CMS.NewsSpecial SpecialCMS = new CMS.NewsSpecial();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataSpecialTable = SpecialCMS.GetList("isRecyle<>1 and SiteID='" + Foosun.Global.Current.SiteID + "' and isLock=0");
                InitialDivSpecial(DivSpecial);
            }
        }

        /// <summary>
        /// 初始化DivSpecial
        /// </summary>
        /// <param name="DivSpecial"></param>
        public void InitialDivSpecial(ListBox DivSpecial)
        {
            DataRow[] rows = dataSpecialTable.Select("ParentID='0'");

            for (int i = 0; i < rows.Length; i++)
            {
                ListItem tempListItem = new ListItem();
                tempListItem.Value = rows[i]["SpecialID"].ToString();
                tempListItem.Text = rows[i]["SpecialCName"].ToString();
                DivSpecial.Items.Add(tempListItem);
                InitialDivSpecialChild(tempListItem.Value, DivSpecial, "┉┉");
            }

        }
        public void InitialDivSpecialChild(string ParentId, ListBox DivSpecial, string strFlag)
        {
            DataRow[] rows = dataSpecialTable.Select(string.Format("ParentID='{0}'", ParentId.Replace("'", "''")));

            for (int i = 0; i < rows.Length; i++)
            {
                ListItem tempChildListItem = new ListItem();
                tempChildListItem.Value = rows[i]["SpecialID"].ToString();
                tempChildListItem.Text = strFlag + rows[i]["SpecialCName"].ToString();
                DivSpecial.Items.Add(tempChildListItem);
                InitialDivSpecialChild(tempChildListItem.Value, DivSpecial, strFlag + "┉┉");
            }

        }
    }
}