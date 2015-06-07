using System;
using System.Collections.Generic;
using System.Data;
using Foosun.DALFactory;

namespace Foosun.CMS
{
    public class Recyle
    {
        private IRecyle dal;
        private string str_dirDumm = Foosun.Config.UIConfig.dirDumm;
        private string str_dirSite = Foosun.Config.UIConfig.dirSite;
        private string str_rootpath = Common.ServerInfo.GetRootPath();
        public Recyle()
        {
            dal = DataAccess.CreateRecyle();
            if (str_dirDumm != "" && str_dirDumm != null && str_dirDumm != string.Empty)
                str_dirDumm = "\\" + str_dirDumm;
        }
        public DataTable getList(string type)
        {
            DataTable dt = dal.GetList(type);
            return dt;
        }
        public void RallNCList()
        {
            dal.RallNCList();
        }
        public void RallNList(string classid)
        {
            dal.RallNList(classid);
        }
        public void RallCList()
        {
            dal.RallCList();
        }
        public void RallSList()
        {
            dal.RallSList();
        }
        public void RallLCList()
        {
            dal.RallLCList();
        }
        public void RallLList(string classid)
        {
            dal.RallLList(classid);
        }
        public void RallStCList()
        {
            dal.RallStCList();
        }
        public void RallStList(string classid)
        {
            dal.RallStList(classid);
        }
        public void RallPSFList()
        {
            dal.RallPSFList();
        }
        public void DallNCList()
        {
            DataTable dt = dal.GetNewsTable();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tbname = dt.Rows[i][0].ToString();
                    DataTable dv = dal.GetNewsClass(null);
                    if (dv != null)
                    {
                        for (int j = 0; j < dv.Rows.Count; j++)
                        {
                            string classid = dv.Rows[j]["ClassID"].ToString();
                            DataTable dc = dal.GetNews(classid, tbname);
                            if (dc != null)
                            {
                                for (int k = 0; k < dc.Rows.Count; k++)
                                {
                                    string newsid = dc.Rows[k]["NewsID"].ToString();
                                    string savepath = dc.Rows[k]["SavePath"].ToString();
                                    string filename = dc.Rows[k]["FileName"].ToString();
                                    string fileexname = dc.Rows[k]["FileEXName"].ToString();

                                    string filepath = str_rootpath + str_dirDumm + savepath + "\\" + filename + "." + fileexname;

                                    Common.Public.DelFile("", filepath);
                                    dal.RaDComment(newsid, true);
                                }
                                dc.Clear(); dc.Dispose();

                                string dirpath = str_rootpath + str_dirDumm + dv.Rows[j]["SavePath"].ToString() + "\\" + dv.Rows[j]["SaveClassframe"].ToString();
                                Common.Public.DelFile(dirpath, "");
                            }
                        }
                        dv.Clear(); dv.Dispose();  
                    }
                }
                dt.Clear(); dt.Dispose();
            }
            dal.DallNCList();
        }
        public void DallNList()
        {
            DataTable dt = dal.GetNewsTable();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tbname = dt.Rows[i][0].ToString();
                    DataTable dc = dal.GetNews("",tbname);
                    if (dc != null)
                    {
                        for (int k = 0; k < dc.Rows.Count; k++)
                        {
                            string newsid = dc.Rows[k]["NewsID"].ToString();
                            string savepath = dc.Rows[k]["SavePath"].ToString();
                            string filename = dc.Rows[k]["FileName"].ToString();
                            string fileexname = dc.Rows[k]["FileEXName"].ToString();

                            string filepath = str_rootpath + str_dirDumm + savepath + "\\" + filename + "." + fileexname;

                            Common.Public.DelFile("", filepath);
                            dal.RaDComment(newsid, true);
                        }
                        dc.Clear(); dc.Dispose();
                    }
                }
            }
            dal.DallNList();
        }
        public void DallCList()
        {
            DataTable dt = dal.GetSite(null);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string siteid = dt.Rows[i]["ChannelID"].ToString();
                    string siteename = dt.Rows[i]["EName"].ToString();
                    string sitepath = str_rootpath + str_dirDumm + "\\" + str_dirSite + "\\" + siteename;
                    Common.Public.DelFile(sitepath, "");
                }
                dt.Clear();dt.Dispose();
            }
            dal.DallCList();
        }
        public void DallSList()
        {
            DataTable dt = dal.GetSpeaciList(null);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string savepath = dt.Rows[i]["SavePath"].ToString();
                    string spename = dt.Rows[i]["specialEName"].ToString();
                    string savedirpath = dt.Rows[i]["saveDirPath"].ToString();
                    string filename = dt.Rows[i]["FileName"].ToString();
                    string fileexname = dt.Rows[i]["FileEXName"].ToString();

                    string FilePath = str_rootpath + str_dirDumm + savepath + "\\" + spename + "\\" + savedirpath + "\\" + filename + "." + fileexname;
                    string DirPath = str_rootpath + str_dirDumm + savepath + "\\" + spename + "\\" + savedirpath;
                    Common.Public.DelFile(DirPath, FilePath);
                }
                dt.Clear();dt.Dispose();
            }
            dal.DallSList();
        }
        public void DallLCList()
        {
            dal.DallLCList();
        }
        public void DallLList()
        {
            dal.DallLList();
        }
        public void DallStCList()
        {
            dal.DallStCList();
        }
        public void DallStList()
        {
            dal.DallStList();
        }
        public void DallPSFList()
        {
            dal.DallPSFList();
        }
        public void PRNCList(string idstr)
        {
            dal.PRNCList(idstr);
        }
        public void PRNList(string classid, string idstr)
        {
            dal.PRNList(classid,idstr);
        }
        public void PRCList(string idstr)
        {
            dal.PRCList(idstr);
        }
        public void PRSList(string idstr)
        {
            dal.PRSList(idstr);
        }
        public void PRStCList(string idstr)
        {
            dal.PRStCList(idstr);
        }
        public void PRStList(string classid, string idstr)
        {
            dal.PRStList(classid,idstr);
        }
        public void PRLCList(string idstr)
        {
            dal.PRLCList(idstr);
        }
        public void PRLList(string classid, string idstr)
        {
            dal.PRLList(classid,idstr);
        }
        public void PRPSFList(string idstr)
        {
            dal.PRPSFList(idstr);
        }
        public void PDNCList(string idstr)
        {
            DataTable dc = dal.GetNewsClass(idstr);
            if (dc != null)
            {
                for (int i = 0; i < dc.Rows.Count; i++)
                {
                    string classid = dc.Rows[i]["ClassID"].ToString();
                    DataTable dt = dal.GetNewsTable();
                    if (dt != null)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            string tbname = dt.Rows[j][0].ToString();
                            DataTable dv = dal.GetNews(classid, tbname);
                            if (dv != null)
                            {
                                for (int k = 0; k < dv.Rows.Count; k++)
                                {
                                    string newsid = dv.Rows[k]["NewsID"].ToString();
                                    string filepath = str_rootpath + str_dirDumm + dv.Rows[k]["SavePath"].ToString() + "\\" + dv.Rows[k]["FileName"].ToString() + "." + dv.Rows[k]["FileEXName"].ToString();

                                    Common.Public.DelFile("", filepath);
                                    dal.RaDComment(newsid, true);
                                }
                                dv.Clear(); dv.Dispose();
                            }
                        }
                        dt.Clear(); dt.Dispose();
                    }
                    string dirPath = str_rootpath + str_dirDumm + dc.Rows[0]["SavePath"].ToString() + "\\" + dc.Rows[0]["SaveClassframe"].ToString();
                    Common.Public.DelFile(dirPath, "");
                }
                dc.Clear(); dc.Dispose();
            }
            dal.PDNCList(idstr);
        }
        public void PDNList(string idstr)
        {
            DataTable dt = dal.GetNewsTable();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tbname = dt.Rows[i][0].ToString();
                    DataTable dv = dal.GetNews(null, tbname);
                    if (dv != null)
                    {
                        for (int k = 0; k < dv.Rows.Count; k++)
                        {
                            string newsid = dv.Rows[k]["NewsID"].ToString();
                            string savepath = dv.Rows[k]["SavePath"].ToString();
                            string filename = dv.Rows[k]["FileName"].ToString();
                            string fileexname = dv.Rows[k]["FileEXName"].ToString();

                            string filepath = str_rootpath + str_dirDumm + savepath + "\\" + filename + fileexname;

                            Common.Public.DelFile("", filepath);
                            dal.RaDComment(newsid, true);
                        }
                        dv.Clear(); dv.Dispose();
                    }
                }
                dt.Clear(); dt.Dispose();
            }
            dal.PDNList(idstr);
        }
        public void PDCList(string idstr)
        {
            DataTable dt = dal.GetSite(idstr);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string siteid = dt.Rows[i]["ChannelID"].ToString();
                    string siteename = dt.Rows[i]["EName"].ToString();
                    string sitepath = str_rootpath + str_dirDumm + "\\" + str_dirSite + "\\" + siteename;
                    Common.Public.DelFile(sitepath, "");
                }
                dt.Clear(); dt.Dispose();
            }
            dal.PDCList(idstr);
        }
        public void PDSList(string idstr)
        {
            DataTable dt = dal.GetSpeaciList(idstr);
            if (dt != null)
            { 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string savepath = dt.Rows[i]["SavePath"].ToString();
                    string specialEName = dt.Rows[i]["specialEName"].ToString();
                    string saveDirPath = dt.Rows[i]["saveDirPath"].ToString();
                    string filename = dt.Rows[i]["FileName"].ToString();
                    string fileexname = dt.Rows[i]["FileEXName"].ToString();

                    string FilePath = str_rootpath + str_dirDumm + savepath + "\\" + specialEName + "\\" + saveDirPath + "\\" + filename + "." + fileexname;
                    string DirPath = str_rootpath + str_dirDumm + savepath + "\\" + specialEName + "\\" + saveDirPath;
                    Common.Public.DelFile(DirPath, FilePath);
                }
                dt.Clear();
                dt.Dispose();
            }
            dal.PDSList(idstr);
        }
        public void PDStCList(string idstr)
        {
            dal.PDStCList(idstr);
        }
        public void PDStList(string idstr)
        {
            dal.PDStList(idstr);
        }
        public void PDLCList(string idstr)
        {
            dal.PDLCList(idstr);
        }
        public void PDLList(string idstr)
        {
            dal.PDLList(idstr);
        }
        public void PDPSFList(string idstr)
        {
            dal.PDPSFList(idstr);
        }
    }
}
