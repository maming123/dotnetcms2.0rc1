using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DMedia.FetionActivity.Data;
using DMedia.FetionActivity.Module;
using DMedia.FetionActivity.Module.Utils;

namespace DMedia.FetionActivity.WebSite.HD15.SiMingPai.handler
{
    /// <summary>
    /// PageHandler 的摘要说明
    /// </summary>
    public class PageHandler : BaseHandler
    {

        public PageHandler()
        {
            dictAction.Add("SignUp", SignUp);

        }

        private void SignUp()
        {
            string nickName = RequestKeeper.GetFormString(Request["nickName"]);
            string sex = RequestKeeper.GetFormString(Request["sex"]);
            string phone = RequestKeeper.GetFormString(Request["phone"]);
            string wxCode = RequestKeeper.GetFormString(Request["wxCode"]);
            string address = RequestKeeper.GetFormString(Request["address"]);
            string company = RequestKeeper.GetFormString(Request["company"]);
            string className = RequestKeeper.GetFormString(Request["className"]);

            Response.Write(BaseCommon.ObjectToJson(new ReturnJsonType<string>() { code = 1, m = "报名成功" }));
             return;
            
           
        }


    }
}