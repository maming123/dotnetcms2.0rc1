﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Foosun.PageView.configuration.system
{
    public partial class createLabel_Browse : Foosun.PageBasic.ManagePage
    {
        public string APIID = "0";
        Foosun.CMS.Label rd = new Foosun.CMS.Label();
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
                getDefine();
                GetStyleList(this.StyleClassID);
            }
        }

        protected void GetStyleList(DropDownList lst)
        {
            IDataReader dr = rd.GetStyleList(SiteID);
            while (dr.Read())
            {
                ListItem it = new ListItem();
                it.Value = dr["ClassID"].ToString();
                it.Text = dr["Sname"].ToString();
                lst.Items.Add(it);
            }
            dr.Close();
        }
        /// <summary>
        /// 获得自定义字段列表
        /// </summary>

        protected void getDefine()
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