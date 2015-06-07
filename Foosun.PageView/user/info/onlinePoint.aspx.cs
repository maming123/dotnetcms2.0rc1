using System;
using System.Data;
using System.Web.UI;
using Common;

public partial class user_info_onlinePoint : Foosun.PageBasic.UserPage {
	Foosun.CMS.UserMisc rd = new Foosun.CMS.UserMisc();
	protected void Page_Load(object sender, EventArgs e) {

	}

	protected void Button1_Click(object sender, EventArgs e) {
		if (Page.IsValid) {
			DataTable dt = rd.getOnlinePay();
			if (dt != null && dt.Rows.Count > 0) {
				switch (dt.Rows[0]["onpayType"].ToString()) {
					case "0":
					default:
						AliPay alipay = new AliPay(Request.Url.Scheme + "://" + Request.Url.Authority);
						alipay.Config["partner"] = dt.Rows[0]["O_other1"].ToString();
						alipay.Config["key"] = dt.Rows[0]["O_key"].ToString();
						alipay.Config["seller_email"] = dt.Rows[0]["O_userName"].ToString();
						//alipay.Config["return_url"] = hosturl + "/user/info/AlipayNotify.aspx";
						//alipay.Config["notify_url"] = hosturl + "/user/info/AlipayNotify.aspx";
						//alipay.Config["show_url"] = hosturl + "/user/info/history.aspx?type=2";
						alipay.Config["mainname"] = "四川风讯科技发展有限公司";
						string tradeNo = Guid.NewGuid().ToString().Replace("-", "");
						try {
							//添加本站订单待续。
							if (dt.Rows[0]["O_other3"].ToString() == "0") {
								alipay.CreateDirectPayByUser(tradeNo, "在线充值", "", pointNumber.Text);
							}
							else {
								alipay.CreatePartnerTradeByBuyer(tradeNo, "在线充值", "", pointNumber.Text);
							}
							Response.Redirect(alipay.Build_GetUrl());
						}
						catch (Exception ex) {
							PageError(ex.Message, "");
						}
						break;
				}
			}
		}
	}
}
