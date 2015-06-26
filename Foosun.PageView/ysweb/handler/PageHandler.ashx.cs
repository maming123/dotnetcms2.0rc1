using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DMedia.FetionActivity.Data;
using DMedia.FetionActivity.Module;
using DMedia.FetionActivity.Module.Utils;
using Foosun.PageView.ysbusiness.SignUp;

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
            long phone = RequestKeeper.GetFormLong(Request["phone"]);
            string wxCode = RequestKeeper.GetFormString(Request["wxCode"]);
            string address = RequestKeeper.GetFormString(Request["address"]);
            string company = RequestKeeper.GetFormString(Request["company"]);
            string className = RequestKeeper.GetFormString(Request["className"]);


          int r =  SignUpBusiness.Add(new SignUpItem() { 
                 NickName=nickName,
                  Sex =sex,
                   Mobile = phone,
                    WxCode =wxCode,
                     Address =address,
                      Company =company,
                       ClassName =className,
                        CreateDateTime= DateTime.Now,
                         IPAddress =BaseCommon.GetUserIP()
            });

          if (r == 1)
          {
              Response.Write(BaseCommon.ObjectToJson(new ReturnJsonType<string>() { code = r, m = "报名成功" }));
              return;
          }
          else
          {
              Response.Write(BaseCommon.ObjectToJson(new ReturnJsonType<string>() { code = r, m = "报名失败" }));
              return;
          }
        
            
           
        }


    }
}