using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.configuration.system
{
    public partial class createLabelList : Foosun.PageBasic.ManagePage
    {
        public string APIID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            APIID = SiteID;
            if (!IsPostBack)
            {

                string _dirdumm = Foosun.Config.UIConfig.dirDumm;
                if (_dirdumm.Trim() != "") { _dirdumm = "/" + _dirdumm; }
                style_base.InnerHtml = Common.Public.getxmlstylelist("styleContent", _dirdumm + "/xml/cuslabeStyle/cstylebase.xml");
                style_class.InnerHtml = Common.Public.getxmlstylelist("styleContent1", _dirdumm + "/xml/cuslabeStyle/cstyleclass.xml");
                style_special.InnerHtml = Common.Public.getxmlstylelist("DropDownList2", _dirdumm + "/xml/cuslabeStyle/cstylespecial.xml");
                GetDefine();
            }
        }
        /// <summary>
        /// 读取自定义字段数据
        /// </summary>
        private void GetDefine()
        {
            Foosun.CMS.Style.Style stClass = new Foosun.CMS.Style.Style();
            DataTable dt = stClass.Styledefine();

            if (dt != null)
            {
                define.DataTextField = "defineCname";
                define.DataValueField = "defineColumns";
                define.DataSource = dt;
                define.DataBind();
                dt.Clear();
                dt.Dispose();
            }
            ListItem itm = new ListItem();
            itm.Value = "";
            itm.Text = "自定义字段";
            define.Items.Insert(0, itm);
            itm = null;

        }
    }
}