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

public partial class ClassToTemplet : Foosun.PageBasic.ManagePage
{
    public ClassToTemplet()
    {
        Authority_Code = "C028";
    }
    Foosun.CMS.sys sysCMS = new sys();
    RootPublic pd = new RootPublic();
    DataTable dt = new DataTable();
    Foosun.CMS.NewsClass NewsClassCMS = new NewsClass();
    public string DirHtml = Foosun.Config.UIConfig.dirHtml;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (SiteID != "0")
            {
                DirHtml = Foosun.Config.UIConfig.dirSite;
            }
            #region 模版加载
            string publishType = sysCMS.GetParamBase("publishType");
            if (publishType == "0")
            {
                labelTemplet.Style.Add("display", "block");
                labelNewsTemplet.Style.Add("display", "block");
                dropTemplet.Style.Add("display", "none");
                dropNewsTemplet.Style.Add("display", "none");
            }
            else
            {
                labelTemplet.Style.Add("display", "none");
                labelNewsTemplet.Style.Add("display", "none");
                dropTemplet.Style.Add("display", "block");
                dropNewsTemplet.Style.Add("display", "block");
            }
            #endregion
            this.Itemtemplets.Text = sysCMS.GetParamBase("ClasslistTemplet");
            this.displaytemplets.Text = sysCMS.GetParamBase("ReadNewsTemplet");
            DataListTrivee();
        }
    }

    protected void DataListTrivee()
    {
        dt = NewsClassCMS.GetClassInfoTemplet();
        if (dt.Rows.Count > 0)
        {
            HistoryData("0", 0);
        }
    }

    /// <summary>
    /// 栏目递归处理
    /// </summary>
    /// <param name="dat"></param>
    /// <param name="div"></param>
    protected void HistoryData(string dat, int div)
    {
        DataRow[] dr = null;
        dr = dt.Select("ParentID='" + dat + "'");
        if (dr.Length < 1)
            return;
        else
        {
            string strText = null;
            foreach (DataRow row in dr)
            {
                this.ClassID = row["ClassID"].ToString();
                if (this.CheckAuthority())
                {
                    string strValue = "";
                    if (row["ParentID"].ToString() == "0")
                        strText = "";
                    else
                        strText = "├";

                    for (int j = 0; j < div; j++)
                    {
                        strText += "─";
                    }
                    strText += " " + row["ClassCname"].ToString();
                    strValue += row["ClassID"].ToString();
                    ListItem item = new ListItem();
                    item.Text = strText;
                    item.Value = strValue;
                    this.DataListBox.Items.Add(item);
                    HistoryData(row["ClassID"].ToString(), div + 1);
                }
            }
        }
    }

    protected void btn_Click(object sender, EventArgs e)
    {

        string str = "'";
        int i = 0;

        #region 获取listbox控件选中的值
        foreach (ListItem li in DataListBox.Items)
        {
            if (li.Selected)
            {
                if (i > 0)
                {
                    str += ",'";
                }
                str += li.Value + "'";
                i++;
            }
        }
        if (str == "," || str == "'" || (str == null && str == ""))
        {
            PageError("请选择栏目！", "");
        }
        #endregion

        #region 自动产生Update组合
        string strUpdate = "";

        //获取数据字段，此字段与Page TextBox的Index值对等
        string[] ColumnsData = { "ClassTemplet", "ReadNewsTemplet" };
        i = 0;
        foreach (Control cl in Controls[0].Controls)
        {
            if (cl.GetType().Name == "TextBox")
            {
                TextBox tb = (TextBox)this.FindControl(cl.ID);
                if (i > 0)
                {
                    strUpdate += ",";
                }
                strUpdate += "" + ColumnsData[i] + "='" + tb.Text + "'";
                i++;
            }
        }
        if (Itemtemplets.Text != "")
        {
            strUpdate = "" + ColumnsData[0] + "='" + Itemtemplets.Text + "'";
        }
        if (displaytemplets.Text != "")
        {
            if (strUpdate != "")
            {
                strUpdate += "," + ColumnsData[1] + "='" + displaytemplets.Text + "'";
            }
            else
            {
                strUpdate += ColumnsData[1] + "='" + displaytemplets.Text + "'";
            }
        }
        #endregion

        #region SQL语句执行
        if (strUpdate != null && strUpdate != "")
        {
            NewsClassCMS.UpdateClassInfo(strUpdate, str);

            if (this.isContent.Checked)
            {
                if ((this.displaytemplets.Text).Trim() != "")
                {
                    //更新栏目下新闻模板
                    NewsClassCMS.UpdateClassNewsInfo(this.displaytemplets.Text, str);
                }
            }
            pd.SaveUserAdminLogs(1, 1, UserNum, "批量设置属性", "批量设置属性,栏目ClassID:" + str + "");
            Common.MessageBox.ShowAndRedirect(this, "批量更新成功!如果更新了新闻模板，需要重新生成新闻!", "NewsClassList.aspx");
        }
        string publishType = sysCMS.GetParamBase("publishType");
        if (publishType == "1")
        {
            Foosun.CMS.DropTemplet dtemplet = new DropTemplet();
            string[] classIds = str.Split(',');
            foreach (string id in classIds)
            {
                dtemplet.UpdateClassTemplet(id.Replace("'", ""), dTemplet.Text, dListTemplets.Text);
            }
            if (isContent.Checked && displaytemplets.Text.Trim() != "")
            {
                dtemplet.UpdateNewsTemplet(str, dListTemplets.Text);
            }
            pd.SaveUserAdminLogs(1, 1, UserNum, "批量设置属性", "批量设置属性,栏目ClassID:" + str + "");
            Common.MessageBox.ShowAndRedirect(this, "批量更新成功!如果更新了新闻模板，需要重新生成新闻!", "NewsClassList.aspx");
        }
        #endregion
    }

    /// <summary>
    /// 检测为空的所有TextBox
    /// </summary>
    /// <param name="TextBoxName"></param>
    /// <returns>如是为空false;反之true</returns>
    protected bool TextBoxValue(TextBox TextBoxName)
    {
        bool flg = true;
        //检测控件是否有值
        if (TextBoxName.Text == "" || TextBoxName.Text == null)
            flg = false;
        return flg;
    }
}
