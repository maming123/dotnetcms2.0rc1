using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.manage.publish
{
    public partial class PublishPage : System.Web.UI.Page
    {
        DataTable dataIspageTable = null;
        Foosun.CMS.NewsClass NewsClassCMS = new CMS.NewsClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataIspageTable = NewsClassCMS.GetList("isRecyle<>1 and isPage=1 and isLock=0");
                InitSingle();

            }
        }

        /// <summary>
        /// 初始化单页面
        /// </summary>
        public void InitSingle()
        {
            for (int i = 0; i < dataIspageTable.Rows.Count; i++)
            {
                ListItem tempListItem = new ListItem();
                tempListItem.Value = dataIspageTable.Rows[i]["ClassID"].ToString();
                tempListItem.Text = dataIspageTable.Rows[i]["ClassCName"].ToString();
                ListBox_singleness.Items.Add(tempListItem);
            }
        }
    }
}