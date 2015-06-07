using System;
using Common;

namespace Foosun.PageView.user.info {
	public partial class AlipayNotify : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			AliPay alipay = new AliPay();
			alipay.LogFilePath = Server.MapPath("/Logs/alipay" + DateTime.Now.ToString().Replace(":", "").Replace("/", "")) + ".txt";
			var request = Request.Form;
			if (Request.HttpMethod == "GET") {
				request = Request.QueryString;
			}
			if (alipay.Notify(alipay.RequestToDic(request))) {
				string trade_no = request["trade_no"];         //支付宝交易号
				string order_no = request["out_trade_no"];     //获取订单号
				string total_fee = request["total_fee"];       //获取总金额
				string subject = request["subject"];           //商品名称、订单名称
				string body = request["body"];                 //商品描述、订单备注、描述
				string buyer_email = request["buyer_email"];   //买家支付宝账号
				string trade_status = request["trade_status"]; //交易状态

				if (request["trade_status"] == "TRADE_FINISHED" || request["trade_status"] == "TRADE_SUCCESS") {
					//处理订单
					//如果有做过处理，不执行业务程序
					
				}
				if (Request.HttpMethod == "POST") {
					Response.Write("success");
				}
				else {
					Response.Redirect("Financial.aspx");
				}
			}
		}
	}
}