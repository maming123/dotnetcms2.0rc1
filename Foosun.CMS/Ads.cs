using System;
using System.Collections.Generic;
using System.Data;
using Foosun.Model;
using Foosun.DALFactory;
using System.IO;

namespace Foosun.CMS
{
    public class Ads
    {
        private string str_dirDumm = Foosun.Config.UIConfig.dirDumm;
        private string str_rootpath = Common.ServerInfo.GetRootPath();
        private IAds ac;
        public Ads()
        {
            ac = DataAccess.CreateAds();
        }

        public DataTable list(Foosun.Model.AdsListInfo ali)
        {
            DataTable dt = ac.list(ali);
            return dt;
        }
        public DataTable childlist(string classid)
        {
            DataTable dt = ac.childlist(classid);
            return dt;
        }
        public void Lock(string id)
        {
            ac.Lock(id);
        }

        public void UnLock(string id)
        {
            ac.UnLock(id);
        }
        public void DelAllAds()
        {
            DataTable dt = ac.AdsDt(null);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string classid = dt.Rows[i]["ClassID"].ToString();
                    string adsid = dt.Rows[i]["AdID"].ToString();
                    string adspath = str_rootpath + str_dirDumm + "\\jsfiles\\ads\\" + classid + "\\" + adsid + ".js";
                    Common.Public.DelFile("", adspath);
                }
                dt.Clear(); dt.Dispose();
            }
            ac.DelAllAds();
        }
        public void DelPAds(string id)
        {
            DataTable dt = ac.AdsDt(id);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string classid = dt.Rows[i]["ClassID"].ToString();
                    string adsid = dt.Rows[i]["AdID"].ToString();
                    string adspath = str_rootpath + str_dirDumm + "\\jsfiles\\ads\\" + classid + "\\" + adsid + ".js";
                    Common.Public.DelFile("", adspath);
                }
                dt.Clear(); dt.Dispose();
            }
            ac.DelPAds(id);
        }
        public void DelAllAdsClass()
        {
            DataTable dt = ac.adsClassDt(null);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string classid = dt.Rows[i]["AcID"].ToString();
                    string classpath = str_rootpath + str_dirDumm + "\\jsfiles\\ads\\" + classid;
                    Common.Public.DelFile(classpath, "");
                }
                dt.Clear(); dt.Dispose();
            }
            ac.DelAllAdsClass();
        }

        public void DelPAdsClass(string classid)
        {
            DataTable dt = ac.adsClassDt(classid);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string str_classid = dt.Rows[i]["AcID"].ToString();
                    string classpath = str_rootpath + str_dirDumm + "\\jsfiles\\ads\\" + str_classid;
                    Common.Public.DelFile(classpath, "");
                }
                dt.Clear(); dt.Dispose();
            }
            ac.DelPAdsClass(classid);
        }
        public int AddClass(Foosun.Model.AdsClassInfo aci)
        {
            int result = 0;
            result = ac.AddClass(aci);
            return result;
        }
        public int EditClass(Foosun.Model.AdsClassInfo aci)
        {
            int result = 0;
            result = ac.EditClass(aci);
            return result;
        }

        public DataTable getAdsClassInfo(string classid)
        {
            DataTable dt = ac.getAdsClassInfo(classid);
            return dt;
        }
        public void statDelAll()
        {
            ac.statDelAll();
        }
        public void statDel(string idstr)
        {
            ac.statDel(idstr);
        }
        public DataTable getAdsClassList()
        {
            DataTable dt = ac.getAdsClassList();
            return dt;
        }
        public DataTable getAdsList(string id)
        {
            DataTable dt = ac.getAdsList(id);
            return dt;
        }

        public int adsAdd(Foosun.Model.AdsInfo ai)
        {
            string AdID = ac.adsAdd(ai);
            createJS(ai.adType.ToString(),AdID,ai.ClassID);
            return 1;
        }
        public DataTable getAdsDomain()
        {
            DataTable dt = ac.getAdsDomain();
            return dt;
        }
        public DataTable getAdsPicInfo(string col, string tbname, string id)
        {
            DataTable dt = ac.getAdsPicInfo(col,tbname,id);
            return dt;
        }
        public DataTable getAdsInfo(string id)
        {
            DataTable dt = ac.getAdsInfo(id);
            return dt;
        }
        public int adsEdit(Foosun.Model.AdsInfo ai)
        {
            int result = ac.adsEdit(ai);
            string str_jspath = str_rootpath + str_dirDumm + "\\jsfiles\\ads\\" + ai.OldClass + "\\" + ai.AdID + ".js";
            Common.Public.DelFile("", str_jspath);
            
            createJS(ai.adType.ToString(), ai.AdID, ai.ClassID);
            return result;
        }

        protected void createJS(string adType,string AdID,string classID)
        {
            switch (adType)
            {
                case "0":
                    CreateJs.CreateAds0(AdID, classID);
                    break;
                case "1":
                    CreateJs.CreateAds1(AdID, classID);
                    break;
                case "2":
                    CreateJs.CreateAds2(AdID, classID);
                    break;
                case "3":
                    CreateJs.CreateAds3(AdID, classID);
                    break;
                case "4":
                    CreateJs.CreateAds4(AdID, classID);
                    break;
                case "5":
                    CreateJs.CreateAds5(AdID, classID);
                    break;
                case "6":
                    CreateJs.CreateAds6(AdID, classID);
                    break;
                case "7":
                    CreateJs.CreateAds7(AdID, classID, 0);
                    break;
                case "8":
                    CreateJs.CreateAds7(AdID, classID, 1);
                    break;
                case "9":
                    CreateJs.CreateAds8(AdID, classID);
                    break;
                case "10":
                    CreateJs.CreateAds9(AdID, classID);
                    break;
                case "11":
                    CreateJs.CreateAds10(AdID, classID);
                    break;
                case "12":
                    CreateJs.CreateAds11(AdID, classID);
                    break;
            }
        }

        public DataTable get24HourStat(string type, string id)
        {
            DataTable dt = ac.get24HourStat(type, id);
            return dt;
        }
        public DataTable getDayStat(string type, string id, string mday)
        {
            DataTable dt = ac.getDayStat(type, id, mday);
            return dt;
        }
        public DataTable getMonthStat(string type, string id)
        {
            DataTable dt = ac.getMonthStat(type, id);
            return dt;
        }
        public DataTable getYearStat(string id)
        {
            DataTable dt = ac.getYearStat(id);
            return dt;
        }
        public DataTable getWeekStat(string type, string id)
        {
            DataTable dt = ac.getWeekStat(type, id);
            return dt;
        }
        public DataTable getSourceStat(string id)
        {
            DataTable dt = ac.getSourceStat(id);
            return dt;
        }
        public DataTable getDbNull()
        {
            DataTable dt = ac.getDbNull();
            return dt;
        }
        public void upStat(string adress, string id)
        {
            ac.upStat(adress, id);
        }
        public void upShowNum(string id)
        {
            ac.upShowNum(id);
        }
        public void upClickNum(string id, string type)
        {
            ac.upClickNum(id, type);
        }
        public void addStat(string id, string ip)
        {
            ac.addStat(id, ip);
        }
        public DataTable getClassAdprice(string classid)
        {
            DataTable dt = ac.getClassAdprice(classid);
            return dt;
        }
        public DataTable getuserG()
        {
            DataTable dt = ac.getuserG();
            return dt;
        }
        public void DelUserG(int Gnum)
        {
            ac.DelUserG(Gnum);
        }
    }
}
