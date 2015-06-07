using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foosun.PageView.manage.publish
{
    public partial class PublishState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string state = Request.QueryString["state"];
                if (Foosun.Publish.UltiPublish.ths.ThreadState == System.Threading.ThreadState.Running && state == "suspen")
                {
                    Foosun.Publish.UltiPublish.ths.Suspend();
                    Response.Write("0|OK");
                }
                else if (Foosun.Publish.UltiPublish.ths.ThreadState == System.Threading.ThreadState.Suspended && state == "resume")
                {
                    Foosun.Publish.UltiPublish.ths.Resume();
                    Response.Write("1|OK");
                }
            }
        }
    }
}