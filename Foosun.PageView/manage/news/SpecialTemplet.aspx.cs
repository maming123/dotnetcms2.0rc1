using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Foosun.CMS;

namespace Foosun.PageView.manage.news
{
    public partial class SpecialTemplet : Foosun.PageBasic.ManagePage
    {
        Foosun.CMS.NewsSpecial NewsSpecialCMS = new NewsSpecial();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassRender(this.splist, "0", 0);
        }

        private void ClassRender(ListBox lst, string PID, int Layer)
        {
            IDataReader dts = NewsSpecialCMS.GetSpecialByParentId(PID);
            while (dts.Read())
            {
                    ListItem it = new ListItem();
                    string stxt = "";
                    it.Value = dts["SpecialID"].ToString();
                    if (Layer > 0)
                        stxt = "┝";
                    for (int i = 1; i < Layer; i++)
                    {
                        stxt += "┉";
                    }
                    it.Text = stxt + dts["SpecialCName"].ToString();
                    lst.Items.Add(it);
                    ClassRender(lst, dts["SpecialID"].ToString(), Layer + 1);
            }
            dts.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string templet = this.txt_templet.Text;
            string spid = string.Empty;
            if (templet == string.Empty)
            {
                PageError("请选择模板!", "SpecialTemplet.aspx");
            }
            if (this.splist.SelectedValue.Trim().Equals(""))
            {
                PageError("请选择要移动到的专题!", "NewsList.aspx");
                return;
            }

            for (int i = 0; i < this.splist.Items.Count; i++)
            {
                if (this.splist.Items[i].Selected == true)
                {
                    if (i > 0) spid += ",";
                    spid += "'" + this.splist.Items[i].Value + "'";
                }
            }

            NewsSpecialCMS.UpdateTemplet(spid, templet);
            PageRight("捆绑专题模板成功", "SpecialList.aspx", true);
        }
    }
}
