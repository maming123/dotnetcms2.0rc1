//===========================================================
//==     (c)2013 Foosun Inc. by dotNETCMS 2.0              ==
//==             Forum:bbs.foosun.net                      ==
//==            website:www.foosun.net                     ==
//===========================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Foosun.IDAL;
using Foosun.DALFactory;
namespace Foosun.CMS.Style
{
    public class Style
    {
        private readonly IStyle dal = DataAccess.CreateStyle();
        public Style()
        {
        }
        public int SytleClassAdd(Foosun.Model.StyleClassInfo sc)
        {
            int result = dal.SytleClassAdd(sc);
            return result;
        }
        public int StyleClassEdit(Foosun.Model.StyleClassInfo sc)
        {
            int result = dal.StyleClassEdit(sc);
            return result;
        }
        public void StyleClassDel(string id)
        {
            dal.StyleClassDel(id);
        }
        public void StyleClassRDel(string id)
        {
            dal.StyleClassRDel(id);
        }
        public int StyleAdd(Foosun.Model.StyleInfo sc)
        {
            int result = dal.StyleAdd(sc);
            return result;
        }

        public int StyleNametf(string CName)
        {
            return dal.StyleNametf(CName);
        }

        public int StyleEdit(Foosun.Model.StyleInfo sc)
        {
            int result = dal.StyleEdit(sc);
            return result;
        }
        public void StyleDel(string id)
        {
            dal.StyleDel(id);
        }
        public void StyleRdel(string id)
        {
            dal.StyleRdel(id);
        }
        public DataTable GetstyleClassInfo(string id)
        {
            DataTable dt = dal.GetstyleClassInfo(id);
            return dt;
        }
        public DataTable GetstyleInfo(string id)
        {
            DataTable dt = dal.GetstyleInfo(id);
            return dt;
        }
        public DataTable Styledefine()
        {
            DataTable dt = dal.Styledefine();
            return dt;
        }
        public DataTable StyleClassList()
        {
            DataTable dt = dal.StyleClassList();
            return dt;
        }
        /// <summary>
        /// 获取全部标签样式
        /// </summary>
        /// <returns></returns>
        public DataTable GetLabelStyle()
        {
            return dal.GetLabelStyle();
        }
    }
}
