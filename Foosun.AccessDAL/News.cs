using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Foosun.DALProfile;
using Foosun.IDAL;
using Foosun.Model;
using System.Data.OleDb;
namespace Foosun.AccessDAL
{
    //News
    public partial class News : DbBase, INews
    {
        #region 新闻
        public bool Exists(string NewsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + Pre + "News");
            strSql.Append(" where ");
            strSql.Append(" NewsID = @NewsID  ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@NewsID", OleDbType.VarWChar,12)			};
            parameters[0].Value = NewsID;

            return DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) == 1;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Foosun.Model.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + Pre + "News(");
            strSql.Append("CommLinkTF,SubNewsTF,URLaddress,PicURL,SPicURL,ClassID,SpecialID,Author,Souce,Tags,NewsID,NewsProperty,NewsPicTopline,Templet,Content,Metakeywords,Metadesc,naviContent,Click,CreatTime,EditTime,NewsType,SavePath,FileName,FileEXName,isDelPoint,Gpoint,iPoint,GroupNumber,ContentPicTF,ContentPicURL,ContentPicSize,OrderID,CommTF,DiscussTF,TopNum,VoteTF,CheckStat,isLock,isRecyle,SiteID,DataLib,DefineID,NewsTitle,isVoteTF,Editor,isHtml,isConstr,isFiles,vURL,sNewsTitle,TitleColor,TitleITF,TitleBTF");
            strSql.Append(") values (");
            strSql.Append("@CommLinkTF,@SubNewsTF,@URLaddress,@PicURL,@SPicURL,@ClassID,@SpecialID,@Author,@Souce,@Tags,@NewsID,@NewsProperty,@NewsPicTopline,@Templet,@Content,@Metakeywords,@Metadesc,@naviContent,@Click,@CreatTime,@EditTime,@NewsType,@SavePath,@FileName,@FileEXName,@isDelPoint,@Gpoint,@iPoint,@GroupNumber,@ContentPicTF,@ContentPicURL,@ContentPicSize,@OrderID,@CommTF,@DiscussTF,@TopNum,@VoteTF,@CheckStat,@isLock,@isRecyle,@SiteID,@DataLib,@DefineID,@NewsTitle,@isVoteTF,@Editor,@isHtml,@isConstr,@isFiles,@vURL,@sNewsTitle,@TitleColor,@TitleITF,@TitleBTF");
            strSql.Append(") ");

            OleDbParameter[] parameters = {
			            new OleDbParameter("@CommLinkTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@SubNewsTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@URLaddress", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@PicURL", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@SPicURL", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@ClassID", OleDbType.VarWChar,12) ,            
                        new OleDbParameter("@SpecialID", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@Author", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@Souce", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@Tags", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@NewsID", OleDbType.VarWChar,12) ,            
                        new OleDbParameter("@NewsProperty", OleDbType.VarWChar,30) ,            
                        new OleDbParameter("@NewsPicTopline", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@Templet", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@Content", OleDbType.VarWChar) ,            
                        new OleDbParameter("@Metakeywords", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@Metadesc", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@naviContent", OleDbType.VarWChar,255) ,            
                        new OleDbParameter("@Click", OleDbType.Integer,4) ,            
                        new OleDbParameter("@CreatTime", OleDbType.Date) ,            
                        new OleDbParameter("@EditTime", OleDbType.Date) ,            
                        new OleDbParameter("@NewsType", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@SavePath", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@FileName", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@FileEXName", OleDbType.VarWChar,6) ,            
                        new OleDbParameter("@isDelPoint", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@Gpoint", OleDbType.Integer,4) ,            
                        new OleDbParameter("@iPoint", OleDbType.Integer,4) ,            
                        new OleDbParameter("@GroupNumber", OleDbType.VarWChar) ,            
                        new OleDbParameter("@ContentPicTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@ContentPicURL", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@ContentPicSize", OleDbType.VarWChar,10) ,            
                        new OleDbParameter("@OrderID", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@CommTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@DiscussTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@TopNum", OleDbType.Integer,4) ,            
                        new OleDbParameter("@VoteTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@CheckStat", OleDbType.VarWChar,10) ,            
                        new OleDbParameter("@isLock", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@isRecyle", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@SiteID", OleDbType.VarWChar,12) ,            
                        new OleDbParameter("@DataLib", OleDbType.VarWChar,20) ,            
                        new OleDbParameter("@DefineID", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@NewsTitle", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@isVoteTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@Editor", OleDbType.VarWChar,18) ,            
                        new OleDbParameter("@isHtml", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@isConstr", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@isFiles", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@vURL", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@sNewsTitle", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@TitleColor", OleDbType.VarWChar,10) ,            
                        new OleDbParameter("@TitleITF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@TitleBTF", OleDbType.TinyInt,1)             
              
            };

            parameters[0].Value = model.CommLinkTF;
            parameters[1].Value = model.SubNewsTF;
            parameters[2].Value = model.URLaddress;
            parameters[3].Value = model.PicURL;
            parameters[4].Value = model.SPicURL;
            parameters[5].Value = model.ClassID;
            parameters[6].Value = model.SpecialID;
            parameters[7].Value = model.Author;
            parameters[8].Value = model.Souce;
            parameters[9].Value = model.Tags;
            parameters[10].Value = model.NewsID;
            parameters[11].Value = model.NewsProperty;
            parameters[12].Value = model.NewsPicTopline;
            parameters[13].Value = model.Templet;
            parameters[14].Value = model.Content;
            parameters[15].Value = model.Metakeywords;
            parameters[16].Value = model.Metadesc;
            parameters[17].Value = model.naviContent;
            parameters[18].Value = model.Click;
            parameters[19].Value = model.CreatTime;
            parameters[20].Value = model.EditTime;
            parameters[21].Value = model.NewsType;
            parameters[22].Value = model.SavePath;
            parameters[23].Value = model.FileName;
            parameters[24].Value = model.FileEXName;
            parameters[25].Value = model.isDelPoint;
            parameters[26].Value = model.Gpoint;
            parameters[27].Value = model.iPoint;
            parameters[28].Value = model.GroupNumber;
            parameters[29].Value = model.ContentPicTF;
            parameters[30].Value = model.ContentPicURL;
            parameters[31].Value = model.ContentPicSize;
            parameters[32].Value = model.OrderID;
            parameters[33].Value = model.CommTF;
            parameters[34].Value = model.DiscussTF;
            parameters[35].Value = model.TopNum;
            parameters[36].Value = model.VoteTF;
            parameters[37].Value = model.CheckStat;
            parameters[38].Value = model.isLock;
            parameters[39].Value = model.isRecyle;
            parameters[40].Value = model.SiteID;
            parameters[41].Value = model.DataLib;
            parameters[42].Value = model.DefineID;
            parameters[43].Value = model.NewsTitle;
            parameters[44].Value = model.isVoteTF;
            parameters[45].Value = model.Editor;
            parameters[46].Value = model.isHtml;
            parameters[47].Value = model.isConstr;
            parameters[48].Value = model.isFiles;
            parameters[49].Value = model.vURL;
            parameters[50].Value = model.sNewsTitle;
            parameters[51].Value = model.TitleColor;
            parameters[52].Value = model.TitleITF;
            parameters[53].Value = model.TitleBTF;
            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Foosun.Model.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + Pre + "News set ");

            strSql.Append(" CommLinkTF = @CommLinkTF , ");
            strSql.Append(" SubNewsTF = @SubNewsTF , ");
            strSql.Append(" URLaddress = @URLaddress , ");
            strSql.Append(" PicURL = @PicURL , ");
            strSql.Append(" SPicURL = @SPicURL , ");
            strSql.Append(" ClassID = @ClassID , ");
            strSql.Append(" SpecialID = @SpecialID , ");
            strSql.Append(" Author = @Author , ");
            strSql.Append(" Souce = @Souce , ");
            strSql.Append(" Tags = @Tags , ");
            strSql.Append(" NewsID = @NewsID , ");
            strSql.Append(" NewsProperty = @NewsProperty , ");
            strSql.Append(" NewsPicTopline = @NewsPicTopline , ");
            strSql.Append(" Templet = @Templet , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" Metakeywords = @Metakeywords , ");
            strSql.Append(" Metadesc = @Metadesc , ");
            strSql.Append(" naviContent = @naviContent , ");
            strSql.Append(" Click = @Click , ");
            strSql.Append(" CreatTime = @CreatTime , ");
            strSql.Append(" EditTime = @EditTime , ");
            strSql.Append(" NewsType = @NewsType , ");
            strSql.Append(" SavePath = @SavePath , ");
            strSql.Append(" FileName = @FileName , ");
            strSql.Append(" FileEXName = @FileEXName , ");
            strSql.Append(" isDelPoint = @isDelPoint , ");
            strSql.Append(" Gpoint = @Gpoint , ");
            strSql.Append(" iPoint = @iPoint , ");
            strSql.Append(" GroupNumber = @GroupNumber , ");
            strSql.Append(" ContentPicTF = @ContentPicTF , ");
            strSql.Append(" ContentPicURL = @ContentPicURL , ");
            strSql.Append(" ContentPicSize = @ContentPicSize , ");
            strSql.Append(" OrderID = @OrderID , ");
            strSql.Append(" CommTF = @CommTF , ");
            strSql.Append(" DiscussTF = @DiscussTF , ");
            strSql.Append(" TopNum = @TopNum , ");
            strSql.Append(" VoteTF = @VoteTF , ");
            strSql.Append(" CheckStat = @CheckStat , ");
            strSql.Append(" isLock = @isLock , ");
            strSql.Append(" isRecyle = @isRecyle , ");
            strSql.Append(" SiteID = @SiteID , ");
            strSql.Append(" DataLib = @DataLib , ");
            strSql.Append(" DefineID = @DefineID , ");
            strSql.Append(" NewsTitle = @NewsTitle , ");
            strSql.Append(" isVoteTF = @isVoteTF , ");
            strSql.Append(" Editor = @Editor , ");
            strSql.Append(" isHtml = @isHtml , ");
            strSql.Append(" isConstr = @isConstr , ");
            strSql.Append(" isFiles = @isFiles , ");
            strSql.Append(" vURL = @vURL , ");
            strSql.Append(" sNewsTitle = @sNewsTitle , ");
            strSql.Append(" TitleColor = @TitleColor , ");
            strSql.Append(" TitleITF = @TitleITF , ");
            strSql.Append(" TitleBTF = @TitleBTF  ");
            strSql.Append(" where NewsID=@NewsID  ");

            OleDbParameter[] parameters = {
			            new OleDbParameter("@Id", OleDbType.Integer,4) ,            
                        new OleDbParameter("@CommLinkTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@SubNewsTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@URLaddress", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@PicURL", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@SPicURL", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@ClassID", OleDbType.VarWChar,12) ,            
                        new OleDbParameter("@SpecialID", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@Author", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@Souce", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@Tags", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@NewsID", OleDbType.VarWChar,12) ,            
                        new OleDbParameter("@NewsProperty", OleDbType.VarWChar,30) ,            
                        new OleDbParameter("@NewsPicTopline", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@Templet", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@Content", OleDbType.VarWChar) ,            
                        new OleDbParameter("@Metakeywords", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@Metadesc", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@naviContent", OleDbType.VarWChar,255) ,            
                        new OleDbParameter("@Click", OleDbType.Integer,4) ,            
                        new OleDbParameter("@CreatTime", OleDbType.Date) ,            
                        new OleDbParameter("@EditTime", OleDbType.Date) ,            
                        new OleDbParameter("@NewsType", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@SavePath", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@FileName", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@FileEXName", OleDbType.VarWChar,6) ,            
                        new OleDbParameter("@isDelPoint", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@Gpoint", OleDbType.Integer,4) ,            
                        new OleDbParameter("@iPoint", OleDbType.Integer,4) ,            
                        new OleDbParameter("@GroupNumber", OleDbType.VarWChar) ,            
                        new OleDbParameter("@ContentPicTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@ContentPicURL", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@ContentPicSize", OleDbType.VarWChar,10) ,            
                        new OleDbParameter("@OrderID", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@CommTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@DiscussTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@TopNum", OleDbType.Integer,4) ,            
                        new OleDbParameter("@VoteTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@CheckStat", OleDbType.VarWChar,10) ,            
                        new OleDbParameter("@isLock", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@isRecyle", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@SiteID", OleDbType.VarWChar,12) ,            
                        new OleDbParameter("@DataLib", OleDbType.VarWChar,20) ,            
                        new OleDbParameter("@DefineID", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@NewsTitle", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@isVoteTF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@Editor", OleDbType.VarWChar,18) ,            
                        new OleDbParameter("@isHtml", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@isConstr", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@isFiles", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@vURL", OleDbType.VarWChar,200) ,            
                        new OleDbParameter("@sNewsTitle", OleDbType.VarWChar,100) ,            
                        new OleDbParameter("@TitleColor", OleDbType.VarWChar,10) ,            
                        new OleDbParameter("@TitleITF", OleDbType.TinyInt,1) ,            
                        new OleDbParameter("@TitleBTF", OleDbType.TinyInt,1)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.CommLinkTF;
            parameters[2].Value = model.SubNewsTF;
            parameters[3].Value = model.URLaddress;
            parameters[4].Value = model.PicURL;
            parameters[5].Value = model.SPicURL;
            parameters[6].Value = model.ClassID;
            parameters[7].Value = model.SpecialID;
            parameters[8].Value = model.Author;
            parameters[9].Value = model.Souce;
            parameters[10].Value = model.Tags;
            parameters[11].Value = model.NewsID;
            parameters[12].Value = model.NewsProperty;
            parameters[13].Value = model.NewsPicTopline;
            parameters[14].Value = model.Templet;
            parameters[15].Value = model.Content;
            parameters[16].Value = model.Metakeywords;
            parameters[17].Value = model.Metadesc;
            parameters[18].Value = model.naviContent;
            parameters[19].Value = model.Click;
            parameters[20].Value = model.CreatTime;
            parameters[21].Value = model.EditTime;
            parameters[22].Value = model.NewsType;
            parameters[23].Value = model.SavePath;
            parameters[24].Value = model.FileName;
            parameters[25].Value = model.FileEXName;
            parameters[26].Value = model.isDelPoint;
            parameters[27].Value = model.Gpoint;
            parameters[28].Value = model.iPoint;
            parameters[29].Value = model.GroupNumber;
            parameters[30].Value = model.ContentPicTF;
            parameters[31].Value = model.ContentPicURL;
            parameters[32].Value = model.ContentPicSize;
            parameters[33].Value = model.OrderID;
            parameters[34].Value = model.CommTF;
            parameters[35].Value = model.DiscussTF;
            parameters[36].Value = model.TopNum;
            parameters[37].Value = model.VoteTF;
            parameters[38].Value = model.CheckStat;
            parameters[39].Value = model.isLock;
            parameters[40].Value = model.isRecyle;
            parameters[41].Value = model.SiteID;
            parameters[42].Value = model.DataLib;
            parameters[43].Value = model.DefineID;
            parameters[44].Value = model.NewsTitle;
            parameters[45].Value = model.isVoteTF;
            parameters[46].Value = model.Editor;
            parameters[47].Value = model.isHtml;
            parameters[48].Value = model.isConstr;
            parameters[49].Value = model.isFiles;
            parameters[50].Value = model.vURL;
            parameters[51].Value = model.sNewsTitle;
            parameters[52].Value = model.TitleColor;
            parameters[53].Value = model.TitleITF;
            parameters[54].Value = model.TitleBTF;
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 得到保存的路径
        /// </summary>
        /// <param name="Templet"></param>
        /// <returns></returns>
        private string GetSavePath(string Templet)
        {
            DateTime now = DateTime.Now;
            Templet = Templet.Replace("{@year04}", now.Year.ToString());
            Templet = Templet.Replace("{@year02}", now.Year.ToString().Substring(2));
            Templet = Templet.Replace("{@month}", now.Month.ToString());
            Templet = Templet.Replace("{@day}", now.Day.ToString());
            return Templet;
        }
        /// <summary>
        /// 复制新闻
        /// </summary>
        /// <param name="ClassID"></param>
        /// <param name="sOrgNews"></param>
        /// <param name="NewsID"></param>
        /// <param name="FileName"></param>
        public void Copy_news(string ClassID, string sOrgNews, string NewsID, string FileName)
        {
            string Sql = "insert into " + Pre + "News(NewsID,NewsType,OrderID,NewsTitle,sNewsTitle,TitleColor,TitleITF,TitleBTF,CommLinkTF,SubNewsTF,URLaddress,PicURL,SPicURL,ClassID,SpecialID,Author,Souce,Tags,NewsProperty,NewsPicTopline,Templet,Content,naviContent,Click,CreatTime,EditTime,SavePath,FileName,FileEXName,ContentPicTF,ContentPicURL,ContentPicSize,CommTF,DiscussTF,TopNum,VoteTF,CheckStat,isLock,isRecyle,SiteID,DataLib,DefineID,isVoteTF,Editor,isHtml,isDelPoint,Gpoint,iPoint,GroupNumber,isConstr,Metakeywords,Metadesc,isFiles,vURL)select '" + NewsID + "',NewsType,OrderID,NewsTitle,sNewsTitle,TitleColor,TitleITF,TitleBTF,CommLinkTF,SubNewsTF,URLaddress,PicURL,SPicURL,'" + ClassID + "',SpecialID,Author,Souce,Tags,NewsProperty,NewsPicTopline,Templet,Content,naviContent,Click,CreatTime,EditTime,SavePath,FileName,FileEXName,ContentPicTF,ContentPicURL,ContentPicSize,CommTF,DiscussTF,TopNum,VoteTF,CheckStat,isLock,isRecyle,SiteID,'" + Pre + "News',DefineID,isVoteTF,Editor,isHtml,isDelPoint,Gpoint,iPoint,GroupNumber,isConstr,Metakeywords,Metadesc,isFiles,vURL from " + Pre + "News where Newsid =" + sOrgNews;
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
            Foosun.AccessDAL.NewsClass sNewclass = new NewsClass();
            DataTable table = sNewclass.GetContent("NewsSavePath,ReadNewsTemplet", "ClassID='" + ClassID + "'", "");
            string savePathTemplet = table.Rows[0][0].ToString();
            savePathTemplet = GetSavePath(savePathTemplet);
            string tSQL = "update " + Pre + "News set isHtml=0,Templet='" + table.Rows[0]["ReadNewsTemplet"] + "',SavePath='" + savePathTemplet + "'";
            if (FileName.Trim() != "")
            {
                string gSQL = "select id from " + Pre + "News where ClassID='" + ClassID + "' and FileName='" + FileName + "'";
                DataTable dt = DbHelper.ExecuteTable(CommandType.Text, gSQL, null);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0) { FileName = FileName + "1"; }
                    dt.Clear(); dt.Dispose();
                }
                tSQL += " ,FileName='" + FileName + "'";
            }
            tSQL += " where NewsID='" + NewsID + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, tSQL, null);
            Sql = "insert into " + Pre + "define_save(DsNewsID,DsEname,DsNewsTable,DsType,DsContent,DsApiID,SiteID)select'" + NewsID + "',DsEname,DsNewsTable,DsType,DsContent,DsApiID,SiteID from " + Pre + "define_save where DsNewsID=" + sOrgNews;
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 彻底删除一条数据
        /// </summary>
        public bool Delete(string NewsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Pre + "News ");
            strSql.Append(" where NewsID=@NewsID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@NewsID", OleDbType.VarWChar,12)			};
            parameters[0].Value = NewsID;


            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 彻底删除新闻
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int DelNew(string where)
        {
            string Sql = "delete from " + Pre + "News where " + where + Common.Public.getSessionStr() + "";
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Foosun.Model.News GetModel(string NewsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, CommLinkTF, SubNewsTF, URLaddress, PicURL, SPicURL, ClassID, SpecialID, Author, Souce, Tags, NewsID, NewsProperty, NewsPicTopline, Templet, Content, Metakeywords, Metadesc, naviContent, Click, CreatTime, EditTime, NewsType, SavePath, FileName, FileEXName, isDelPoint, Gpoint, iPoint, GroupNumber, ContentPicTF, ContentPicURL, ContentPicSize, OrderID, CommTF, DiscussTF, TopNum, VoteTF, CheckStat, isLock, isRecyle, SiteID, DataLib, DefineID, NewsTitle, isVoteTF, Editor, isHtml, isConstr, isFiles, vURL, sNewsTitle, TitleColor, TitleITF, TitleBTF  ");
            strSql.Append("  from " + Pre + "News ");
            strSql.Append(" where NewsID=@NewsID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@NewsID", OleDbType.VarWChar,12)			};
            parameters[0].Value = NewsID;


            Foosun.Model.News model = new Foosun.Model.News();
            DataTable ds = DbHelper.ExecuteTable(CommandType.Text, strSql.ToString(), parameters);

            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Rows[0]["Id"].ToString());
                }
                if (ds.Rows[0]["CommLinkTF"].ToString() != "")
                {
                    model.CommLinkTF = int.Parse(ds.Rows[0]["CommLinkTF"].ToString());
                }
                if (ds.Rows[0]["SubNewsTF"].ToString() != "")
                {
                    model.SubNewsTF = int.Parse(ds.Rows[0]["SubNewsTF"].ToString());
                }
                model.URLaddress = ds.Rows[0]["URLaddress"].ToString();
                model.PicURL = ds.Rows[0]["PicURL"].ToString();
                model.SPicURL = ds.Rows[0]["SPicURL"].ToString();
                model.ClassID = ds.Rows[0]["ClassID"].ToString();
                model.SpecialID = ds.Rows[0]["SpecialID"].ToString();
                model.Author = ds.Rows[0]["Author"].ToString();
                model.Souce = ds.Rows[0]["Souce"].ToString();
                model.Tags = ds.Rows[0]["Tags"].ToString();
                model.NewsID = ds.Rows[0]["NewsID"].ToString();
                model.NewsProperty = ds.Rows[0]["NewsProperty"].ToString();
                if (ds.Rows[0]["NewsPicTopline"].ToString() != "")
                {
                    model.NewsPicTopline = int.Parse(ds.Rows[0]["NewsPicTopline"].ToString());
                }
                model.Templet = ds.Rows[0]["Templet"].ToString();
                model.Content = ds.Rows[0]["Content"].ToString();
                model.Metakeywords = ds.Rows[0]["Metakeywords"].ToString();
                model.Metadesc = ds.Rows[0]["Metadesc"].ToString();
                model.naviContent = ds.Rows[0]["naviContent"].ToString();
                if (ds.Rows[0]["Click"].ToString() != "")
                {
                    model.Click = int.Parse(ds.Rows[0]["Click"].ToString());
                }
                if (ds.Rows[0]["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(ds.Rows[0]["CreatTime"].ToString());
                }
                if (ds.Rows[0]["EditTime"].ToString() != "")
                {
                    model.EditTime = DateTime.Parse(ds.Rows[0]["EditTime"].ToString());
                }
                if (ds.Rows[0]["NewsType"].ToString() != "")
                {
                    model.NewsType = int.Parse(ds.Rows[0]["NewsType"].ToString());
                }
                model.SavePath = ds.Rows[0]["SavePath"].ToString();
                model.FileName = ds.Rows[0]["FileName"].ToString();
                model.FileEXName = ds.Rows[0]["FileEXName"].ToString();
                if (ds.Rows[0]["isDelPoint"].ToString() != "")
                {
                    model.isDelPoint = int.Parse(ds.Rows[0]["isDelPoint"].ToString());
                }
                if (ds.Rows[0]["Gpoint"].ToString() != "")
                {
                    model.Gpoint = int.Parse(ds.Rows[0]["Gpoint"].ToString());
                }
                if (ds.Rows[0]["iPoint"].ToString() != "")
                {
                    model.iPoint = int.Parse(ds.Rows[0]["iPoint"].ToString());
                }
                model.GroupNumber = ds.Rows[0]["GroupNumber"].ToString();
                if (ds.Rows[0]["ContentPicTF"].ToString() != "")
                {
                    model.ContentPicTF = int.Parse(ds.Rows[0]["ContentPicTF"].ToString());
                }
                model.ContentPicURL = ds.Rows[0]["ContentPicURL"].ToString();
                model.ContentPicSize = ds.Rows[0]["ContentPicSize"].ToString();
                if (ds.Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Rows[0]["OrderID"].ToString());
                }
                if (ds.Rows[0]["CommTF"].ToString() != "")
                {
                    model.CommTF = int.Parse(ds.Rows[0]["CommTF"].ToString());
                }
                if (ds.Rows[0]["DiscussTF"].ToString() != "")
                {
                    model.DiscussTF = int.Parse(ds.Rows[0]["DiscussTF"].ToString());
                }
                if (ds.Rows[0]["TopNum"].ToString() != "")
                {
                    model.TopNum = int.Parse(ds.Rows[0]["TopNum"].ToString());
                }
                if (ds.Rows[0]["VoteTF"].ToString() != "")
                {
                    model.VoteTF = int.Parse(ds.Rows[0]["VoteTF"].ToString());
                }
                model.CheckStat = ds.Rows[0]["CheckStat"].ToString();
                if (ds.Rows[0]["isLock"].ToString() != "")
                {
                    model.isLock = int.Parse(ds.Rows[0]["isLock"].ToString());
                }
                if (ds.Rows[0]["isRecyle"].ToString() != "")
                {
                    model.isRecyle = int.Parse(ds.Rows[0]["isRecyle"].ToString());
                }
                model.SiteID = ds.Rows[0]["SiteID"].ToString();
                model.DataLib = ds.Rows[0]["DataLib"].ToString();
                if (ds.Rows[0]["DefineID"].ToString() != "")
                {
                    model.DefineID = int.Parse(ds.Rows[0]["DefineID"].ToString());
                }
                model.NewsTitle = ds.Rows[0]["NewsTitle"].ToString();
                if (ds.Rows[0]["isVoteTF"].ToString() != "")
                {
                    model.isVoteTF = int.Parse(ds.Rows[0]["isVoteTF"].ToString());
                }
                model.Editor = ds.Rows[0]["Editor"].ToString();
                if (ds.Rows[0]["isHtml"].ToString() != "")
                {
                    model.isHtml = int.Parse(ds.Rows[0]["isHtml"].ToString());
                }
                if (ds.Rows[0]["isConstr"].ToString() != "")
                {
                    model.isConstr = int.Parse(ds.Rows[0]["isConstr"].ToString());
                }
                if (ds.Rows[0]["isFiles"].ToString() != "")
                {
                    model.isFiles = int.Parse(ds.Rows[0]["isFiles"].ToString());
                }
                model.vURL = ds.Rows[0]["vURL"].ToString();
                model.sNewsTitle = ds.Rows[0]["sNewsTitle"].ToString();
                model.TitleColor = ds.Rows[0]["TitleColor"].ToString();
                if (ds.Rows[0]["TitleITF"].ToString() != "")
                {
                    model.TitleITF = int.Parse(ds.Rows[0]["TitleITF"].ToString());
                }
                if (ds.Rows[0]["TitleBTF"].ToString() != "")
                {
                    model.TitleBTF = int.Parse(ds.Rows[0]["TitleBTF"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM " + Pre + "News ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM " + Pre + "News ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="SpecialID">专题编号</param>
        /// <param name="Editor">作者</param>
        /// <param name="NewsDbTbs">表名</param>
        /// <param name="ClassID">栏目</param>
        /// <param name="sKeywrd">关键字</param>
        /// <param name="DdlKwdType">关键字类型</param>
        /// <param name="sChooses">提交的类型</param>
        /// <param name="SiteID">站点</param>
        /// <param name="TablePrefix">表扩展名</param>
        /// <param name="PageIndex">每页数量</param>
        /// <param name="PageSize">每页数量</param>
        /// <param name="RecordCount">总记录数</param>
        /// <param name="PageCount"></param>
        /// <param name="SqlCondition">SQL</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetPage(string SpecialID, string Editor, string ClassID, string sKeywrd, string DdlKwdType, string sChooses, string SiteID, int PageIndex, int PageSize, out int RecordCount, out int PageCount)
        {
            string sFilter = " a.isRecyle=0";
            if (ClassID != null && ClassID != "")
                sFilter += " and a.ClassID='" + ClassID + "'";
            if (SpecialID != null && SpecialID != "")
                sFilter += " and a.NewsID In (Select NewsID From " + Pre + "special_news Where SpecialID='" + SpecialID + "') ";
            string sKeywrds = sKeywrd;
            if (sKeywrds != "" && sKeywrds != null)
            {
                switch (DdlKwdType)
                {
                    case "content":
                        sFilter += " and Content like '%" + sKeywrds + "%'";
                        break;
                    case "author":
                        sFilter += " and Author like '%" + sKeywrds + "%'";
                        break;
                    case "editor":
                        sFilter += " and NewsTitle like '%" + sKeywrds + "%'";
                        break;
                    default:
                        sFilter += " and NewsTitle like '%" + sKeywrds + "%'";
                        break;
                }
            }
            string sChoose = sChooses;
            switch (sChoose)
            {
                case "Auditing":
                    sFilter += " and (CheckStat is null or CheckStat='0|0|0|0' or CheckStat='1|0|0|0' or  CheckStat='2|0|0|0' or  CheckStat='3|0|0|0')";
                    break;
                case "UnAuditing":
                    sFilter += " and (CheckStat<>'0|0|0|0' and CheckStat<>'1|0|0|0' and CheckStat<>'2|0|0|0' and CheckStat<>'3|0|0|0' and CheckStat is not null)";
                    break;
                case "All":
                    break;
                case "Contribute":
                    sFilter += " and a.isConstr=1";
                    break;
                case "Commend":
                    sFilter += " and Mid(NewsProperty,1,1)='1'";
                    break;
                case "Lock":
                    sFilter += " and a.isLock=1";
                    break;
                case "UnLock":
                    sFilter += " and a.isLock=0";
                    break;
                case "Top":
                    sFilter += " and a.OrderID=10";
                    break;
                case "Hot":
                    sFilter += " and Mid(NewsProperty,5,1)='1'";
                    break;
                case "Splendid":
                    sFilter += " and Mid(NewsProperty,15,1)='1'";
                    break;
                case "Headline":
                    sFilter += " and Mid(NewsProperty,9,1)='1'";
                    break;
                case "Slide":
                    sFilter += " and Mid(NewsProperty,7,1)='1'";
                    break;
                case "my":
                    sFilter += " and Editor='" + Foosun.Global.Current.UserName + "'";
                    break;
                case "isHtml":
                    sFilter += " and a.isHtml=1";
                    break;
                case "unisHtml":
                    sFilter += " and a.isHtml=0";
                    break;
                case "discuzz":
                    sFilter += " and a.DiscussTF=1";
                    break;
                case "commat":
                    sFilter += " and a.CommTF=1";
                    break;
                case "voteTF":
                    sFilter += " and a.VoteTF=1";
                    break;
                case "contentPicTF":
                    sFilter += " and a.ContentPicTF=1";
                    break;
                case "POPTF":
                    sFilter += " and a.isDelPoint<>0";
                    break;
                case "Pic":
                    sFilter += " and a.NewsType=1";
                    break;
                case "FilesURL":
                    sFilter += " and a.isFiles=1";
                    break;
            }
            if (SiteID != "" && SiteID != null)
            {
                sFilter += " and a.SiteID='" + SiteID + "'";
            }
            else
            {
                sFilter += " and a.SiteID='" + Foosun.Global.Current.SiteID + "'";
            }

            if (Editor != "")
            {
                sFilter += " and a.Editor='" + Editor + "'";
            }
            string AllFields = "a.Id,a.NewsID,a.NewsType,a.TitleColor,a.TitleITF,a.TitleBTF,a.Author,a.DataLib,a.OrderID,a.NewsTitle,a.ishtml,a.Editor,a.Click,a.isConstr,a.ClassID,a.SpecialID,a.isLock,a.NewsProperty,a.CheckStat,a.URLaddress,b.UserName,c.ClassCName";
            string Condition = "(" + Pre + "News a left join " + Pre + "sys_User b on a.[Editor]=b.[UserName]) left join " + Pre + "News_Class c  on a.ClassID=c.ClassID where " + sFilter;
            string IndexField = "a.Id";
            string OrderFields = "order by a.OrderID desc,a.Id desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, PageIndex, PageSize, out RecordCount, out PageCount, null);
        }
        public DataTable GetPageByClass(string where, int PageIndex, int PageSize, out int RecordCount, out int PageCount)
        {
            string AllFields = "*";
            string Condition = Pre + "News where" + where;
            string IndexField = "Id";
            string OrderFields = "order by OrderID desc,Id desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, PageIndex, PageSize, out RecordCount, out PageCount, null);
        }
        /// <summary>
        /// 子新闻列表
        /// </summary>
        /// <param name="DdlClass"></param>
        /// <param name="sKeywrds"></param>
        /// <param name="sChoose"></param>
        /// <param name="DdlKwdType"></param>
        /// <param name="pageindex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataTable GetPageiframe(string DdlClass, string sKeywrds, string sChoose, string DdlKwdType, int pageindex, int PageSize, out int RecordCount, out int PageCount)
        {
            string sFilter = " where a.isRecyle=0";
            if (DdlClass != "0")
            {
                sFilter += " and a.ClassID='" + DdlClass + "'";
            }
            string sKeywrdsd = sKeywrds;
            if (sKeywrdsd != "")
            {
                switch (DdlKwdType)
                {
                    case "content":
                        sFilter += " and Content like '%" + sKeywrds + "%'";
                        break;
                    case "author":
                        sFilter += " and Author like '%" + sKeywrds + "%'";
                        break;
                    case "editor":
                        sFilter += " and NewsTitle like '%" + sKeywrds + "%'";
                        break;
                    default:
                        sFilter += " and NewsTitle like '%" + sKeywrds + "%'";
                        break;
                }
            }
            string sChooses = sChoose;
            switch (sChooses)
            {
                case "All":
                    break;
                case "Contribute":
                    sFilter += " and isAdmin=0";
                    break;
                case "Commend":
                    sFilter += " and NewsProperty like '1%'";
                    break;
                case "Top":
                    sFilter += " and a.OrderID=0";
                    break;
                case "Hot":
                    sFilter += " and NewsProperty like '____1%'";
                    break;
                case "Splendid":
                    sFilter += " and NewsProperty like '______________1%'";
                    break;
                case "Headline":
                    sFilter += " and NewsProperty like '________1%'";
                    break;
                case "Slide":
                    sFilter += " and NewsProperty like '______1%'";
                    break;
                case "Pic":
                    sFilter += " and NewsType=1";
                    break;
            }
            sFilter += " and a.isLock=0";
            string AllFields = "a.Id,a.NewsID,a.NewsType,a.OrderID,a.NewsTitle,a.Author,a.Click,a.CheckStat,b.UserName,c.ClassCName";
            string Condition = "(" + Pre + "News a left join " + Pre + "sys_User b on a.Editor=b.UserNum) left join " + Pre + "News_Class c on a.ClassID=c.ClassID " + sFilter;
            string IndexField = "a.Id";
            string OrderFields = "order by a.OrderID asc,a.Id desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, pageindex, PageSize, out RecordCount, out PageCount, null);
        }
        /// <summary>
        /// 不规则新闻分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="PageCount"></param>
        /// <param name="SqlCondition"></param>
        /// <returns></returns>
        public DataTable GetPages(int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition)
        {
            string AllFields = "*";
            string Condition = "(SELECT DISTINCT Unid,(Select top 1 UnName from [" + Pre + "News_unNews] where unid=a.unid order by [rows],id desc) as UnName from [" + Pre + "News_unNews] a where 1=1" + Common.Public.getSessionStr() + ") Unnews";
            string IndexField = "Unid";
            string OrderFields = "order by Unid Desc";
            return DbHelper.ExecutePage(AllFields, Condition, IndexField, OrderFields, PageIndex, PageSize, out RecordCount, out PageCount, null);
        }
        /// <summary>
        /// 通用更新新闻方法
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="type">字段类型：1为整型，0为字符串</param>
        /// <param name="value">要更新的字段值</param>
        /// <param name="field">字段名</param>
        public int UpdateNews(string NewsID, int type, string value, string field)
        {
            string _value = value;
            if (type == 0)
            {
                _value = "'" + value + "'";
            }
            string Sql = "update " + Pre + "News Set " + field + "=" + _value + " where NewsID ='" + NewsID + "' " + Common.Public.getSessionStr() + "";
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 批量更新新闻
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="num">条件字段：0为NewsID,1为ClassID</param>
        /// <param name="type">字段类型：0为字符串，1为整型</param>
        /// <param name="field">要更新的字段名</param>
        /// <param name="value">字段值</param>
        public int UpdateNews(string NewsID, int num, int type, string field, string value)
        {
            string _value = value;
            if (type == 0)
            {
                _value = "'" + value + "'";
            }
            string Sql = "";
            if (num == 0)
            {
                Sql = "Update " + Pre + "news Set " + field + "=" + _value + " Where NewsID In (" + NewsID + ")" + Common.Public.getSessionStr() + "";
            }
            else
            {
                Sql = "Update " + Pre + "news Set " + field + "=" + _value + " Where ClassID In (" + NewsID + ")" + Common.Public.getSessionStr() + "";
            }
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 设置新闻属性
        /// </summary>
        public int UpdateNews(int CommTF, int DiscussTF, string NewsProperty, string Templet, string OrderID, int CommLinkTF, string Click, string FileEXName, string Tags, string Souce, string where)
        {
            string Sql = "Update " + Pre + "News set ";
            Sql += "CommTF=" + CommTF;
            Sql += ",DiscussTF=" + DiscussTF;
            if (NewsProperty != "")
            {
                Sql += ",NewsProperty='" + NewsProperty + "'";
            }
            if (Templet != "")
            {
                Sql += ",Templet='" + Templet + "'";
            }
            if (OrderID != "")
            {
                Sql += ",OrderID=" + OrderID + "";
            }
            Sql += ",CommLinkTF=" + CommLinkTF + "";
            if (Click != "")
            {
                Sql += ",Click=" + Click + "";
            }
            if (FileEXName != "")
            {
                Sql += ",FileEXName='" + FileEXName + "'";
            }
            Sql += ",Tags='" + Tags + "'";
            Sql += ",Souce='" + Souce + "'";
            Sql += " where " + where;
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 获取新闻页面的静态页面路径
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetDeleteNewsContent(string NewsID)
        {
            OleDbParameter param = new OleDbParameter("@NewsID", NewsID);
            string Sql = "select a.SavePath as NewsSavePath,a.NewsType,a.FileName,a.FileEXName,b.SaveClassframe,b.SavePath as ClassSavePath,b.ClassCName from " + Pre + "News a left join " + Pre + "news_Class b ";
            Sql += " on a.ClassID=b.ClassID  where a.NewsID=@NewsID";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, param);
        }
        /// <summary>
        /// 彻底删除新闻并删除附件、自定义字段、所属专题、子新闻、不规则新闻
        /// </summary>
        /// <param name="NewsID">新闻的NewsID</param>
        public void DelNews(string NewsID)
        {
           int row= DbHelper.ExecuteNonQuery(CommandType.Text, "delete from " + Pre + "News_URL where NewsID ='" + NewsID + "'", null);
           row = DbHelper.ExecuteNonQuery(CommandType.Text, "delete from " + Pre + "define_save where DsNewsID ='" + NewsID + "'", null);
           row = DbHelper.ExecuteNonQuery(CommandType.Text, "delete from " + Pre + "special_news where NewsID ='" + NewsID + "'", null);
           row = DbHelper.ExecuteNonQuery(CommandType.Text, "delete from " + Pre + "news_sub where NewsID ='" + NewsID + "'", null);
           row = DbHelper.ExecuteNonQuery(CommandType.Text, "delete from " + Pre + "news_unNews where ONewsID ='" + NewsID + "'", null);
           row = DbHelper.ExecuteNonQuery(CommandType.Text, "delete from " + Pre + "News where NewsID ='" + NewsID + "'", null);
        }
        /// <summary>
        /// 终极审核
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        public void AllCheck(string NewsID)
        {
            string Sql = "update " + Pre + "news SET checkstat = iif(checkstat IS NULL or checkstat<>'0|0|0|0','0|0|0|0',checkstat)";
            Sql += ",islock=0";
            Sql += " where NewsID in (" + NewsID + ") ";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 按等级审核
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="levelsID">审核等级</param>
        public void UpCheckStat(string NewsID, int levelsID)
        {
            string _CheckStat = "0|0|0|0";
            string GSql = "select CheckStat from " + Pre + "News where NewsID = '" + NewsID + "'";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, GSql, null);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    _CheckStat = dt.Rows[0]["CheckStat"].ToString();
                }
                dt.Clear(); dt.Dispose();
            }
            string[] checkStatARR = _CheckStat.Split('|');
            string cSTR1 = checkStatARR[0];
            string cSTR2 = checkStatARR[1];
            string cSTR3 = checkStatARR[2];
            string cSTR4 = checkStatARR[3];
            switch (levelsID)
            {
                case 1:
                    cSTR2 = "0";
                    break;
                case 2:
                    cSTR3 = "0";
                    break;
                case 3:
                    cSTR4 = "0";
                    break;
            }

            string RCheckStat = cSTR1 + "|" + cSTR2 + "|" + cSTR3 + "|" + cSTR4;
            string Sql = "update " + Pre + "News set CheckStat='" + RCheckStat + "' where NewsID = '" + NewsID + "' ";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);

            string gSQL = "select NewsProperty,CheckStat,islock,NewsID,NewsType,CreatTime,DataLib,NewsType,isConstr,ClassID from " + Pre + "News where NewsID='" + NewsID + "'";
            DataTable dts = DbHelper.ExecuteTable(CommandType.Text, gSQL, null);
            if (dts != null && dts.Rows.Count > 0)
            {
                string[] TCheckStat = dts.Rows[0]["CheckStat"].ToString().Split('|');
                string Tmp1 = TCheckStat[1] + "|";
                Tmp1 += TCheckStat[2] + "|";
                Tmp1 += TCheckStat[3];
                if (Tmp1 == "0|0|0")
                {
                    string Sqls = "update " + Pre + "News set islock=0 where NewsID = '" + NewsID + "' ";
                    DbHelper.ExecuteNonQuery(CommandType.Text, Sqls, null);
                }
                dts.Clear(); dts.Dispose();
            }
        }
        /// <summary>
        /// 得到指定新闻的IDataReader
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public IDataReader GetNewsID(string NewsID)
        {
            OleDbParameter param = new OleDbParameter("@NewsID", NewsID);
            string Sql = "select a.*,b.ClassCName from " + Pre + "News a left join " + Pre + "news_Class b ";
            Sql += " on a.ClassID=b.ClassID  where a.NewsID=@NewsID";
            return DbHelper.ExecuteReader(CommandType.Text, Sql, param);
        }
        /// <summary>
        /// 得到子新闻
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetUNews(string NewsID)
        {
            string Sql = "Select NewsID,NewsTitle,getNewsID,colsNum,DataLib,titleCSS From [" + Pre + "news_Sub] where NewsID='" + NewsID + "'" + Common.Public.getSessionStr() + "";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 删除子新闻
        /// </summary>
        /// <param name="UnID"></param>
        public void DelSubID(string UnID)
        {
            string Sql = "delete from " + Pre + "News_Sub where NewsID='" + UnID + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 插入子新闻
        /// </summary>
        /// <param name="unNewsid">编号</param>
        /// <param name="Arr_OldNewsId">新闻ID</param>
        /// <param name="NewsRow">行</param>
        /// <param name="NewsTitle">标题</param>
        /// <param name="NewsTable">新闻表</param>
        /// <param name="SiteID">站点ID</param>
        /// <returns></returns>
        public int Add_SubNews(string unNewsid, string Arr_OldNewsId, string NewsRow, string NewsTitle, string NewsTable, string SiteID, string titleCSS)
        {
            string Sql = "INSERT INTO " + Pre + "News_Sub(NewsID,getNewsID,colsNum,NewsTitle,DataLib,CreatTime,SiteID,titleCSS) VALUES('" + unNewsid + "','" + Arr_OldNewsId + "'," + NewsRow + ",'" + NewsTitle + "','" + NewsTable + "','" + DateTime.Now + "','" + SiteID + "','" + titleCSS + "')";
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 取得专题与新闻的对应表
        /// </summary>
        /// <param name="NewsID">新闻编号</param>
        /// <returns></returns>
        public DataTable GetSpecialNews(string NewsID)
        {
            OleDbParameter param = new OleDbParameter("@NewsID", NewsID);
            string Sql = "Select a.SpecialID,b.SpecialCName From " + Pre + "special_news as a," + Pre + "news_special as b Where a.SpecialID=b.SpecialID And a.NewsID=@NewsID And b.isLock=0 And b.isRecyle=0";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, param);
        }
        /// <summary>
        /// 得到某条新闻的附件列表
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="DataTB"></param>
        /// <returns></returns>
        public DataTable GetFileList(string NewsID, string DataTB)
        {
            OleDbParameter param = new OleDbParameter("@NewsID", NewsID);
            string Sql = "select URLName,id,FileURL,OrderID from " + Pre + "news_URL where NewsID=@NewsID and DataLib='" + DataTB + "'";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, param);
        }

        public string GetNewsAccessory(int id)
        {
            OleDbParameter param = new OleDbParameter("@ID", id);
            string Sql = "select FileURL from " + Pre + "news_URL where ID=@ID";
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, param));
        }
        /// <summary>
        /// 根据id删除附件
        /// </summary>
        /// <param name="ids">多个id用，隔开</param>
        public void DeleteNewsFileByID(string ids)
        {
            DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + Pre + "news_URL WHERE [id] IN (" + ids + ")", null);
        }
        /// <summary>
        /// 根据newsid删除附件
        /// </summary>
        /// <param name="newsid"></param>
        public void DeleteNewsFileByNewsID(string NewsID)
        {
            DbHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + Pre + "news_URL WHERE NewsID=@newsid", new OleDbParameter("@newsid", NewsID));
        }
        /// <summary>
        /// 更新附件文件地址
        /// </summary>
        /// <param name="URLName"></param>
        /// <param name="DataLib"></param>
        /// <param name="FileURL"></param>
        /// <param name="OrderID"></param>
        /// <param name="ID"></param>
        public void UpdateFileURL(string URLName, string DataLib, string FileURL, int OrderID, int ID)
        {
            string Sql = "update " + Pre + "news_URL set ";
            Sql += "URLName=@URLName,DataLib=@DataLib,FileURL=@FileURL,OrderID=@OrderID where id=@UrlID";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, new OleDbParameter("URLName", URLName), new OleDbParameter("DataLib", DataLib), new OleDbParameter("FileURL", FileURL), new OleDbParameter("OrderID", OrderID), new OleDbParameter("UrlID", ID));
        }
        /// <summary>
        /// 插入附件
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="DataLib"></param>
        /// <param name="FileURL"></param>
        /// <param name="OrderID"></param>
        public void InsertFileURL(string URLName, string NewsID, string DataLib, string FileURL, int OrderID)
        {
            string Sql = "insert into " + Pre + "news_URL(";
            Sql += "URLName,NewsID,DataLib,FileURL,CreatTime,OrderID";
            Sql += ") values (";
            Sql += "'" + URLName + "','" + NewsID + "','" + DataLib + "','" + FileURL + "','" + DateTime.Now + "'," + OrderID + ")";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 检查新闻标题
        /// </summary>
        /// <param name="NewsTitle"></param>
        /// <param name="tb"></param>
        /// <returns></returns>
        public int NewsTitletf(string NewsTitle, string dtable, string EditAction, string NewsID)
        {
            int intflg = 0;
            OleDbParameter param = new OleDbParameter("@NewsTitle", NewsTitle);
            string Sql = "";
            if (EditAction == "Edit")
            {
                Sql = "select ID from " + dtable + " where NewsTitle=@NewsTitle and NewsID!='" + NewsID + "'";
            }
            else
            {
                Sql = "select ID from " + dtable + " where NewsTitle=@NewsTitle";
            }
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            if (rdr != null)
            {
                if (rdr.Rows.Count > 0) { intflg = 1; }
                rdr.Clear(); rdr.Dispose();
            }
            return intflg;
        }
        /// <summary>
        /// 通用获取新闻内容
        /// </summary>
        /// <param name="field">要查询的字段名，多个字段用，隔开</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataTable GetNewsConent(string field, string where, string order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  " + field);
            strSql.Append(" FROM " + Pre + "News ");
            if (where.Trim() != "")
            {
                strSql.Append(" where " + where);
            }
            if (order.Trim() != "")
            {
                strSql.Append(" order by " + order);
            }
            return DbHelper.ExecuteTable(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 获取NewsContent构造(插入)
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        private OleDbParameter[] insertNewsContentParameters(Foosun.Model.News uc)
        {
            OleDbParameter[] param = new OleDbParameter[54];
            param[0] = new OleDbParameter("@NewsID", OleDbType.VarChar, 12);
            param[0].Value = uc.NewsID;
            param[1] = new OleDbParameter("@NewsType", OleDbType.TinyInt, 1);
            param[1].Value = uc.NewsType;
            param[2] = new OleDbParameter("@OrderID", OleDbType.Integer, 4);
            param[2].Value = uc.OrderID;
            param[3] = new OleDbParameter("@NewsTitle", OleDbType.VarChar, 100);
            param[3].Value = uc.NewsTitle;
            param[4] = new OleDbParameter("@sNewsTitle", OleDbType.VarChar, 100);
            param[4].Value = uc.sNewsTitle;
            param[5] = new OleDbParameter("@TitleColor", OleDbType.VarChar, 10);
            param[5].Value = uc.TitleColor;
            param[6] = new OleDbParameter("@TitleITF", OleDbType.TinyInt, 1);
            param[6].Value = uc.TitleITF;
            param[7] = new OleDbParameter("@TitleBTF", OleDbType.TinyInt, 1);
            param[7].Value = uc.TitleBTF;
            param[8] = new OleDbParameter("@CommLinkTF", OleDbType.TinyInt, 1);
            param[8].Value = uc.CommLinkTF;
            param[9] = new OleDbParameter("@SubNewsTF", OleDbType.TinyInt, 1);
            param[9].Value = uc.SubNewsTF;
            param[10] = new OleDbParameter("@URLaddress", OleDbType.VarChar, 200);
            param[10].Value = uc.URLaddress;
            param[11] = new OleDbParameter("@PicURL", OleDbType.VarChar, 200);
            param[11].Value = uc.PicURL;
            param[12] = new OleDbParameter("@SPicURL", OleDbType.VarChar, 200);
            param[12].Value = uc.SPicURL;
            param[13] = new OleDbParameter("@ClassID", OleDbType.VarChar, 12);
            param[13].Value = uc.ClassID;
            param[14] = new OleDbParameter("@SpecialID", OleDbType.VarChar, 255);
            param[14].Value = uc.SpecialID;
            param[15] = new OleDbParameter("@Author", OleDbType.VarChar, 100);
            param[15].Value = uc.Author;
            param[16] = new OleDbParameter("@Souce", OleDbType.VarChar, 100);
            param[16].Value = uc.Souce;
            param[17] = new OleDbParameter("@Tags", OleDbType.VarChar, 100);
            param[17].Value = uc.Tags;
            param[18] = new OleDbParameter("@NewsProperty", OleDbType.VarChar, 30);
            param[18].Value = uc.NewsProperty;
            param[19] = new OleDbParameter("@Templet", OleDbType.VarChar, 200);
            param[19].Value = uc.Templet;
            param[20] = new OleDbParameter("@Content", OleDbType.VarChar);
            param[20].Value = uc.Content;
            param[21] = new OleDbParameter("@naviContent", OleDbType.VarChar, 255);
            param[21].Value = uc.naviContent;
            param[22] = new OleDbParameter("@CreatTime", OleDbType.Date, 8);
            param[22].Value = uc.CreatTime;
            param[23] = new OleDbParameter("@SavePath", OleDbType.VarChar, 200);
            param[23].Value = uc.SavePath;
            param[24] = new OleDbParameter("@FileName", OleDbType.VarChar, 100);
            param[24].Value = uc.FileName;
            param[25] = new OleDbParameter("@FileEXName", OleDbType.VarChar, 6);
            param[25].Value = uc.FileEXName;
            param[26] = new OleDbParameter("@ContentPicTF", OleDbType.TinyInt, 1);
            param[26].Value = uc.ContentPicTF;
            param[27] = new OleDbParameter("@ContentPicURL", OleDbType.VarChar, 200);
            param[27].Value = uc.ContentPicURL;
            param[28] = new OleDbParameter("@ContentPicSize", OleDbType.VarChar, 10);
            param[28].Value = uc.ContentPicSize;
            param[29] = new OleDbParameter("@CommTF", OleDbType.TinyInt, 1);
            param[29].Value = uc.CommTF;
            param[30] = new OleDbParameter("@DiscussTF", OleDbType.TinyInt, 1);
            param[30].Value = uc.DiscussTF;
            param[31] = new OleDbParameter("@TopNum", OleDbType.TinyInt, 4);
            param[31].Value = uc.TopNum;
            param[32] = new OleDbParameter("@VoteTF", OleDbType.TinyInt, 1);
            param[32].Value = uc.VoteTF;
            param[33] = new OleDbParameter("@NewsPicTopline", OleDbType.TinyInt, 1);
            param[33].Value = uc.NewsPicTopline;
            param[34] = new OleDbParameter("@CheckStat", OleDbType.VarChar, 10);
            param[34].Value = uc.CheckStat;
            param[35] = new OleDbParameter("@isLock", OleDbType.TinyInt, 1);
            param[35].Value = uc.isLock;
            param[36] = new OleDbParameter("@isRecyle", OleDbType.TinyInt, 1);
            param[36].Value = uc.isRecyle;
            param[37] = new OleDbParameter("@SiteID", OleDbType.VarChar, 12);
            param[37].Value = uc.SiteID;
            param[38] = new OleDbParameter("@DataLib", OleDbType.VarChar, 20);
            param[38].Value = uc.DataLib;
            param[39] = new OleDbParameter("@DefineID", OleDbType.TinyInt, 1);
            param[39].Value = uc.DefineID;
            param[40] = new OleDbParameter("@isVoteTF", OleDbType.TinyInt, 1);
            param[40].Value = uc.isVoteTF;
            param[41] = new OleDbParameter("@Editor", OleDbType.VarChar, 18);
            param[41].Value = uc.Editor;
            param[42] = new OleDbParameter("@isHtml", OleDbType.TinyInt, 1);
            param[42].Value = uc.isHtml;
            param[43] = new OleDbParameter("@Click", OleDbType.Integer, 4);
            param[43].Value = uc.Click;
            param[44] = new OleDbParameter("@isDelPoint", OleDbType.TinyInt, 1);
            param[44].Value = uc.isDelPoint;
            param[45] = new OleDbParameter("@Gpoint", OleDbType.TinyInt, 4);
            param[45].Value = uc.Gpoint;
            param[46] = new OleDbParameter("@iPoint", OleDbType.TinyInt, 4);
            param[46].Value = uc.iPoint;
            param[47] = new OleDbParameter("@GroupNumber", OleDbType.VarChar);
            param[47].Value = uc.GroupNumber;
            param[48] = new OleDbParameter("@Metakeywords", OleDbType.VarChar, 200);
            param[48].Value = uc.Metakeywords;
            param[49] = new OleDbParameter("@Metadesc", OleDbType.VarChar, 200);
            param[49].Value = uc.Metadesc;
            param[50] = new OleDbParameter("@isFiles", OleDbType.TinyInt, 1);
            param[50].Value = uc.isFiles;
            param[51] = new OleDbParameter("@vURL", OleDbType.VarChar, 200);
            param[51].Value = uc.vURL;
            param[52] = new OleDbParameter("@editTime", OleDbType.Date, 8);
            param[52].Value = DateTime.Now;
            param[53] = new OleDbParameter("@isConstr", OleDbType.TinyInt, 1);
            param[53].Value = 0;

            return param;
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="uc2"></param>
        public void UpdateNewsContent(Foosun.Model.News uc)
        {
            OleDbParameter[] parm = insertNewsContentParameters(uc);
            string Sql = "Update " + uc.DataLib + " set " + Database.GetModifyParam(parm) + " where NewsId='" + uc.NewsID + "' " + Common.Public.getSessionStr() + "";

            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, parm);
            string usql = "update " + uc.DataLib + " set islock=1 where NewsID='" + uc.NewsID + "' and Mid(CheckStat,3,5)<>'0|0|0'";
            DbHelper.ExecuteNonQuery(CommandType.Text, usql, parm);

            DbHelper.ExecuteNonQuery(CommandType.Text, "Delete From " + Pre + "special_news Where NewsID='" + uc.NewsID + "'", null);
            if (uc.SpecialID != null && uc.SpecialID != "")
            {
                string[] arr_specialID = uc.SpecialID.Split(',');
                for (int i = 0; i < arr_specialID.Length; i++)
                {
                    OleDbParameter[] param = new OleDbParameter[2];
                    param[0] = new OleDbParameter("@SpecialID", OleDbType.VarWChar, 20);
                    param[0].Value = arr_specialID[i].ToString();
                    param[1] = new OleDbParameter("@NewsID", OleDbType.VarWChar, 12);
                    param[1].Value = uc.NewsID;
                    Sql = "Insert Into " + Pre + "special_news(SpecialID,NewsID) Values(@SpecialID,@NewsID)";
                    DbHelper.ExecuteNonQuery(CommandType.Text, Sql, param);
                }
            }
        }
        /// <summary>
        /// 插入新记录
        /// </summary>
        /// <param name="uc2"></param>
        public void InsertNewsContent(Foosun.Model.News uc)
        {
            OleDbParameter[] parm = insertNewsContentParameters(uc);
            StringBuilder Sql = new StringBuilder();
            Sql.Append("insert into " + uc.DataLib + "(");
            Sql.Append(Database.GetParam(parm));
            Sql.Append(") values (");

            Sql.Append(Database.GetAParam(parm));
            Sql.Append(")");
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql.ToString(), parm);

            //添加专题
            if (uc.SpecialID != null && uc.SpecialID != "")
            {
                string[] arr_specialID = uc.SpecialID.Split(',');
                for (int i = 0; i < arr_specialID.Length; i++)
                {
                    OleDbParameter[] param = new OleDbParameter[2];
                    param[0] = new OleDbParameter("@SpecialID", OleDbType.Char, 20);
                    param[0].Value = arr_specialID[i].ToString();
                    param[1] = new OleDbParameter("@NewsID", OleDbType.Char, 12);
                    param[1].Value = uc.NewsID;
                    string inSql = "Insert Into " + Pre + "special_news(SpecialID,NewsID) Values(@SpecialID,@NewsID)";
                    DbHelper.ExecuteNonQuery(CommandType.Text, inSql, param);
                }
            }
        }
        /// <summary>
        /// 得到不规则新闻
        /// </summary>
        /// <param name="UnID"></param>
        /// <returns></returns>
        public DataTable GetUnNews(string UnID)
        {
            string Sql = "Select unName,titleCSS,SubCSS,UnID,ONewsID,[Rows],unTitle,NewsTable From [" + Pre + "news_unNews] where UnID='" + UnID + "'" + Common.Public.getSessionStr() + "";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 删除不规则新闻
        /// </summary>
        /// <param name="UnID"></param>
        public void DelUnNews(string UnID)
        {
            string Sql = "delete from  " + Pre + "News_unNews where UnID='" + UnID + "'" + Common.Public.getSessionStr() + "";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 插入不规则新闻
        /// </summary>
        /// <param name="unName"></param>
        /// <param name="titleCSS"></param>
        /// <param name="SubCSS"></param>
        /// <param name="unNewsid"></param>
        /// <param name="Arr_OldNewsId"></param>
        /// <param name="NewsRow"></param>
        /// <param name="NewsTitle"></param>
        /// <param name="NewsTable"></param>
        /// <param name="SiteID"></param>
        /// <returns></returns>
        public int AddUnNews(string unName, string titleCSS, string SubCSS, string unNewsid, string Arr_OldNewsId, string NewsRow, string NewsTitle, string NewsTable, string SiteID)
        {
            string Sql = "INSERT INTO " + Pre + "News_unNews(unName,titleCSS,SubCSS,UnID,ONewsID,[Rows],unTitle,NewsTable,CreatTime,SiteID) VALUES('" + unName + "','" + titleCSS + "','" + SubCSS + "','" + unNewsid + "','" + Arr_OldNewsId + "'," + NewsRow + ",'" + NewsTitle + "','" + NewsTable + "','" + DateTime.Now + "','" + SiteID + "')";
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 管理员发布新闻统计
        /// </summary>
        /// <param name="stime">开始时间</param>
        /// <param name="etime">结束时间</param>
        /// <param name="top">查询多少条</param>
        /// <returns></returns>
        public DataTable GetNewsStat(string stime, string etime, int top)
        {
            string sql = "select top " + top + " count([Id]) as NewsCount,Editor from " + Pre + "news";
            sql += " where CreatTime between #" + stime + "# and #" + etime + "# group by Editor";
            sql = "SELECT * FROM (" + sql + ") order by NewsCount desc";
            return DbHelper.ExecuteTable(CommandType.Text, sql, null);

        }
        /// <summary>
        /// 新闻点击排行
        /// </summary>
        /// <param name="stime">开始时间</param>
        /// <param name="etime">结束时间</param>
        /// <param name="top">查询多少条</param>
        /// <returns></returns>
        public DataTable GetNewsClick(string stime, string etime, int top)
        {
            string sql = "select top " + top + " id,NewsTitle,CreatTime,Editor,Click from " + Pre + "news where CreatTime between #" + stime + "# and #" + etime + "# order by click desc";
            return DbHelper.ExecuteTable(CommandType.Text, sql, null);


        }
        #endregion 新闻
        #region 自定义字段
        /// <summary>
        /// 得到自定义字段类型
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public DataTable GetdefineEditTable(string ClassID)
        {
            string Sql = "Select Defineworkey From " + Pre + "News_Class where ClassID='" + ClassID + "'";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }
        /// <summary>
        /// 得到某个自定义字段的值
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataTable GetdefineEditTablevalue(int ID)
        {
            string Sql = "Select id,defineInfoId,defineCname,defineColumns,defineType,IsNull,defineValue,defineExpr,definedvalue From " + Pre + "Define_Data where id=" + ID + "";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }
        /// <summary>
        /// 取得自定义字段的默认值
        /// </summary>
        /// <param name="defineColumns">英文名称</param>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="DataLib">数据库表</param>
        /// <param name="DsApiID">apiid</param>
        /// <returns></returns>
        public DataTable ModifyNewsDefineValue(string defineColumns, string NewsID, string DataLib, string DsApiID)
        {
            string Sql = "select DsContent from " + Pre + "define_save where DsEname='" + defineColumns + "' and DsNewsID='" + NewsID + "' and DsNewsTable='" + DataLib + "' and DsApiID='" + DsApiID + "' " + Common.Public.getSessionStr() + "";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return dt;
        }
        /// <summary>
        /// 插入/修改自定义字段
        /// </summary>
        /// <param name="DsNewsID"></param>
        /// <param name="DsEName"></param>
        /// <param name="DsNewsTable"></param>
        /// <param name="DsType"></param>
        /// <param name="DsContent"></param>
        /// <param name="DsApiID"></param>
        public void SetDefineSign(string DsNewsID, string DsEName, string DsNewsTable, int DsType, string DsContent, string DsApiID)
        {
            string TSql = "select ID from " + Pre + "define_save where DsNewsID='" + DsNewsID + "' and DsEName='" + DsEName + "' and DsNewsTable='" + DsNewsTable + "' and DsApiID='" + DsApiID + "'";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, TSql, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                string Sql = "update " + Pre + "define_save set DsNewsTable='" + DsNewsTable + "',DsContent='" + DsContent + "' where DsNewsID='" + DsNewsID + "' and DsEName='" + DsEName + "' and DsApiID='" + DsApiID + "' " + Common.Public.getSessionStr() + "";
                DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
                dt.Clear(); dt.Dispose();
            }
            else
            {
                string Sql = "insert into " + Pre + "define_save (DsNewsID,DsEname,DsNewsTable,DsType,DsContent,DsApiID,SiteID) VALUES ('" + DsNewsID + "','" + DsEName + "','" + DsNewsTable + "'," + DsType + ",'" + DsContent + "','" + DsApiID + "','" + Foosun.Global.Current.SiteID + "')";
                DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
            }
        }
        #endregion
        #region tag
        /// <summary>
        /// 得到最新的tag
        /// </summary>
        /// <returns></returns>
        public DataTable GetTagsList()
        {
            string Sql = "select top 15 CName from " + Pre + "news_Gen where gType=0 and islock=0 order by id desc";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }
        #endregion
        #region 新闻头条
        /// <summary>
        /// 得到头条(NewsID)
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="DataLib"></param>
        /// <returns></returns>
        public DataTable GetTopline(string NewsID, string DataLib, int NewsTFNum)
        {
            string Sql = "select NewsTF,NewsID,DataLib,tl_style,tl_font,tl_size,tl_color,tl_space,tl_PicColor,tl_Title,tl_Width,SiteID,tl_SavePath from " + Pre + "news_topline where NewsID='" + NewsID + "' and DataLib='" + DataLib + "' and NewsTF=" + NewsTFNum + "";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 获取NewsContentTT构造
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        private OleDbParameter[] intsertTTParameters(Foosun.Model.NewsContentTT uc)
        {
            OleDbParameter[] param = new OleDbParameter[14];
            param[0] = new OleDbParameter("@NewsTF", OleDbType.TinyInt, 1);
            param[0].Value = uc.NewsTF;
            param[1] = new OleDbParameter("@NewsID", OleDbType.VarWChar, 12);
            param[1].Value = uc.NewsID;
            param[2] = new OleDbParameter("@DataLib", OleDbType.VarWChar, 50);
            param[2].Value = uc.DataLib;
            param[3] = new OleDbParameter("@tl_font", OleDbType.VarWChar, 20);
            param[3].Value = uc.tl_font;
            param[4] = new OleDbParameter("@tl_style", OleDbType.TinyInt, 1);
            param[4].Value = uc.tl_style;
            param[5] = new OleDbParameter("@tl_size", OleDbType.TinyInt, 1);
            param[5].Value = uc.tl_size;
            param[6] = new OleDbParameter("@tl_color", OleDbType.VarWChar, 8);
            param[6].Value = uc.tl_color;
            param[7] = new OleDbParameter("@tl_space", OleDbType.TinyInt, 1);
            param[7].Value = uc.tl_space;
            param[8] = new OleDbParameter("@tl_PicColor", OleDbType.VarWChar, 8);
            param[8].Value = uc.tl_PicColor;
            param[9] = new OleDbParameter("@tl_SavePath", OleDbType.VarWChar, 220);
            param[9].Value = uc.tl_SavePath;
            param[10] = new OleDbParameter("@Creattime", OleDbType.Date, 8);
            param[10].Value = uc.Creattime;
            param[11] = new OleDbParameter("@tl_Title", OleDbType.VarWChar, 150);
            param[11].Value = uc.tl_Title;
            param[12] = new OleDbParameter("@tl_Width", OleDbType.Integer, 4);
            param[12].Value = uc.tl_Width;
            param[13] = new OleDbParameter("@SiteID", OleDbType.VarWChar, 12);
            param[13].Value = uc.SiteID;
            return param;
        }
        /// <summary>
        /// 插入头条
        /// </summary>
        /// <param name="uc2"></param>
        public void IntsertTT(Foosun.Model.NewsContentTT uc)
        {
            string Sql = "insert into " + Pre + "news_topline(";
            Sql += "NewsTF,NewsID,DataLib,tl_font,tl_style,tl_size,tl_color,tl_space,tl_PicColor,tl_SavePath,Creattime,tl_Title,tl_Width,SiteID";
            Sql += ") values (";
            Sql += "@NewsTF,@NewsID,@DataLib,@tl_font,@tl_style,@tl_size,@tl_color,@tl_space,@tl_PicColor,@tl_SavePath,@Creattime,@tl_Title,@tl_Width,@SiteID)";
            OleDbParameter[] parm = intsertTTParameters(uc);
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, parm);
        }

        /// <summary>
        /// 更新头条
        /// </summary>
        /// <param name="uc2"></param>
        public void UpdateTT(Foosun.Model.NewsContentTT uc)
        {
            string Sql = "update " + Pre + "news_topline set NewsTF=@NewsTF,NewsID=@NewsID,DataLib=@DataLib,tl_font=@tl_font,tl_style=@tl_style,tl_size=@tl_size,tl_color=@tl_color,tl_space=@tl_space,tl_PicColor=@tl_PicColor,tl_SavePath=@tl_SavePath,Creattime=@Creattime,tl_Title=@tl_Title,tl_Width=@tl_Width,SiteID=@SiteID where NewsID='" + uc.NewsID + "' and SiteID='" + Foosun.Global.Current.SiteID + "'";
            OleDbParameter[] parm = intsertTTParameters(uc);
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, parm);
        }
        #endregion 新闻头条
        #region 归档新闻
        /// <summary>
        /// 批量删除归档新闻
        /// </summary>
        /// <param name="idlist">归档新闻id列表</param>
        /// <returns></returns>
        public int DelOld(string idlist)
        {
            string His_Sql = "Delete From " + Pre + "old_News  where id in(" + idlist + ")";
            return DbHelper.ExecuteNonQuery(CommandType.Text, His_Sql, null);
        }
        /// <summary>
        /// 删除全部归档新闻
        /// </summary>
        /// <returns></returns>
        public int DelOld()
        {
            string His_Sql = "Delete From " + Pre + "old_News";
            return DbHelper.ExecuteNonQuery(CommandType.Text, His_Sql, null);
        }
        /// <summary>
        /// 通用更新归档新闻方法
        /// </summary>
        /// <param name="NewsID">新闻ID</param>
        /// <param name="type">字段类型：1为整型，0为字符串</param>
        /// <param name="value">要更新的字段值</param>
        /// <param name="field">字段名</param>
        public int UpdateOld(string idlist, int type, string value, string field)
        {
            string _value = value;
            if (type == 0)
            {
                _value = "'" + value + "'";
            }
            string Sql = "update " + Pre + "old_News Set " + field + "=" + _value + " where id  in(" + idlist + ") " + Common.Public.getSessionStr() + "";
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 插入归档新闻
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Add_old_News(string where)
        {
            string Sql = "insert into " + Pre + "old_News ([NewsID],[NewsType],[OrderID],[NewsTitle],[sNewsTitle],[TitleColor],[TitleITF],[TitleBTF],[CommLinkTF],[SubNewsTF],[URLaddress],[PicURL],[SPicURL],[ClassID],[SpecialID],[Author],[Souce],[Tags],[NewsProperty] ,[NewsPicTopline],[Templet],[Content],[Metakeywords],[Metadesc],[naviContent],[Click],[CreatTime],[EditTime],[SavePath],[FileName],[FileEXName],[isDelPoint],[Gpoint],[iPoint],[GroupNumber],[ContentPicTF],[ContentPicURL],[ContentPicSize],[CommTF],[DiscussTF] ,[TopNum],[VoteTF] ,[CheckStat] ,[isLock],[isRecyle],[SiteID],[DefineID],[isVoteTF],[Editor],[isHtml],[oldtime],datalib) select [NewsID],[NewsType],[OrderID],[NewsTitle],[sNewsTitle],[TitleColor],[TitleITF],[TitleBTF],[CommLinkTF],[SubNewsTF],[URLaddress],[PicURL],[SPicURL],[ClassID],[SpecialID],[Author],[Souce],[Tags],[NewsProperty] ,[NewsPicTopline],[Templet],[Content],[Metakeywords],[Metadesc],[naviContent],[Click],[CreatTime],[EditTime],[SavePath],[FileName],[FileEXName],[isDelPoint],[Gpoint],[iPoint],[GroupNumber],[ContentPicTF],[ContentPicURL],[ContentPicSize],[CommTF],[DiscussTF] ,[TopNum],[VoteTF] ,[CheckStat] ,[isLock],[isRecyle],[SiteID],[DefineID],[isVoteTF],[Editor],[isHtml],oldtime='" + DateTime.Now + "',DataLib='" + Pre + "News' from " + Pre + "News where " + where;
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }
        #endregion
        /// <summary>
        /// 得到继承栏目的DataTable
        /// </summary>      
        /// <returns></returns>
        public DataTable GetSysParam()
        {
            string Sql = "select * from " + Pre + "sys_param";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }
        /// <summary>
        /// 插入常规
        /// </summary>
        /// <param name="_TempStr"></param>
        /// <param name="_URL"></param>
        /// <param name="_EmailURL"></param>
        /// <param name="_num"></param>
        public void IGen(string _TempStr, string _URL, string _EmailURL, int _num)
        {
            string SQLTF = "select id from " + Pre + "News_Gen where Cname='" + _TempStr.Trim() + "' and gType=" + _num + " and SiteID='" + Foosun.Global.Current.SiteID + "'";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, SQLTF, null);
            if (rdr != null)
            {
                if (rdr.Rows.Count == 0)
                {
                    string Sql = "insert into " + Pre + "News_Gen(";
                    Sql += "Cname,gType,URL,EmailURL,isLock,SiteID";
                    Sql += ") values (";
                    Sql += "'" + _TempStr + "'," + _num + ",'" + _URL + "','" + _EmailURL + "',0,'" + Foosun.Global.Current.SiteID + "')";
                    DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
                }
                rdr.Clear(); rdr.Dispose();
            }
        }
        /// <summary>
        /// 得到内部连接地址
        /// </summary>
        /// <returns></returns>
        public DataTable GetGenContent()
        {
            string Sql = "select Cname,URL from " + Pre + "news_Gen where gType=3 and islock=0";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }
        /// <summary>
        /// 添加专题新闻
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="SpecialID"></param>
        public void AddSpecial(string NewsID, string SpecialID)
        {
            string Sql = "insert into " + Pre + "special_news(";
            Sql += "SpecialID,NewsID";
            Sql += ") values ('" + SpecialID + "','" + NewsID + "')";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, null);
        }

        public DataTable GetLastFormTB()
        {
            string Sql = "select id,NewsID,DataLib,NewsType from " + Pre + "news where islock=0 and isRecyle=0 and siteID='" + Foosun.Global.Current.SiteID + "' order by CreatTime desc,id desc";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, null);
        }

        public string GetNewsReview(string ID, string gType)
        {
            string newspath = string.Empty;
            string newspath1 = string.Empty;
            string sql = string.Empty;
            string dim = Foosun.Config.UIConfig.dirDumm.Trim();
            string ReadType = Common.Public.readparamConfig("ReviewType");
            if (dim != string.Empty) { dim = "/" + dim; }
            OleDbParameter param = new OleDbParameter("@ID", ID);
            if (gType != "special")
            {
                if (gType == "class")
                {
                    sql = "select IsURL,URLaddress,SavePath,SaveClassframe,ClassSaveRule,isDelPoint,ClassID,isPage from " + Pre + "news_class where ClassID=@ID";
                    IDataReader dt = DbHelper.ExecuteReader(CommandType.Text, sql, param);
                    while (dt.Read())
                    {
                        if (dt["isURL"].ToString() == "1")
                        {
                            if (dt["URLaddress"].ToString().IndexOf("http://") > -1)
                            {
                                newspath = dt["URLaddress"].ToString();
                            }
                            else
                            {
                                newspath = "http://" + dt["URLaddress"].ToString();
                            }
                        }
                        else
                        {
                            if (dt["isDelPoint"].ToString() != "0")
                            {
                                newspath1 = dim + "/list-" + dt["ClassID"].ToString() + Foosun.Config.UIConfig.extensions;
                            }
                            else
                            {
                                if (ReadType == "1")
                                {
                                    if (dt["isPage"].ToString() == "1")
                                    {
                                        newspath1 = dim + "/page-" + dt["ClassID"].ToString() + Foosun.Config.UIConfig.extensions;
                                    }
                                    else
                                    {
                                        newspath1 = dim + "/list-" + dt["ClassID"].ToString() + Foosun.Config.UIConfig.extensions;
                                    }
                                }
                                else
                                {
                                    if (dt["isPage"].ToString() == "1")
                                    {
                                        newspath1 = dim + "/" + dt["SavePath"].ToString();
                                    }
                                    else
                                    {
                                        newspath1 = dim + "/" + dt["SavePath"].ToString() + "/" + dt["SaveClassframe"].ToString() + "/" + dt["ClassSaveRule"].ToString();
                                    }
                                }
                            }
                            newspath = newspath1.Replace("//", "/").Replace(@"\\", @"\").Replace("//", "/");
                        }
                    }
                    dt.Close();
                }
                else
                {
                    sql = "select a.newsid,a.URLaddress,a.NewsType,a.SavePath,a.FileName,a.FileEXName,b.SavePath as SavePath1,b.SaveClassframe,a.isDelPoint from " + Pre + "news a," + Pre + "news_class b where a.classid=b.classid and a.NewsID=@ID";
                    IDataReader dt = DbHelper.ExecuteReader(CommandType.Text, sql, param);
                    while (dt.Read())
                    {
                        if (dt["NewsType"].ToString() != "2")
                        {
                            if (dt["isDelPoint"].ToString() != "0")
                            {
                                newspath1 = dim + "/content-" + dt["NewsID"].ToString() + Foosun.Config.UIConfig.extensions;
                            }
                            else
                            {
                                if (ReadType == "1")
                                {
                                    newspath1 = dim + "/content-" + dt["NewsID"].ToString() + Foosun.Config.UIConfig.extensions;
                                }
                                else
                                {
                                    newspath1 = dim + "/" + dt["SavePath1"].ToString() + "/" + dt["SaveClassframe"].ToString() + "/" + dt["SavePath"].ToString() + "/" + dt["FileName"].ToString() + dt["FileEXName"].ToString();
                                }
                            }
                            newspath = newspath1.Replace("//", "/").Replace(@"\\", @"\");
                        }
                        else
                        {
                            if (dt["URLaddress"].ToString().IndexOf("http://") > -1)
                            {
                                newspath = dt["URLaddress"].ToString();
                            }
                            else
                            {
                                newspath = "http://" + dt["URLaddress"].ToString();
                            }
                        }
                    }
                    dt.Close();
                }

            }
            else
            {
                //专题地址
                sql = "select SpecialID,SavePath,saveDirPath,FileName,FileEXName,isDelPoint from " + Pre + "news_special where SpecialID=@ID";
                IDataReader dt = DbHelper.ExecuteReader(CommandType.Text, sql, param);
                while (dt.Read())
                {
                    if (dt["isDelPoint"].ToString() != "0")
                    {
                        newspath1 = dim + "/special-" + dt["SpecialID"].ToString() + Foosun.Config.UIConfig.extensions;
                    }
                    else
                    {
                        if (ReadType == "1")
                        {
                            newspath1 = dim + "/special-" + dt["SpecialID"].ToString() + Foosun.Config.UIConfig.extensions;
                        }
                        else
                        {
                            newspath1 = dim + "/" + dt["SavePath"].ToString() + "/" + dt["saveDirPath"].ToString() + "/" + dt["FileName"].ToString() + dt["FileEXName"].ToString();
                        }
                    }
                    newspath = newspath1.Replace("//", "/").Replace(@"\\", @"\");
                }
                dt.Close();
            }
            return newspath;
        }

        /// <summary>
        /// 得到评论数量
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="Todays"></param>
        /// <returns></returns>
        public string GetCommCounts(string NewsID, string Todays)
        {
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@NewsID", OleDbType.VarWChar, 12);
            param[0].Value = NewsID;

            string whereSTR = "";
            if (Todays == "1")
            {
                whereSTR = "And DateDiff(Day,[creatTime] ,Getdate()) = 0 ";
            }
            string Sql = "Select Count(ID) From [" + Pre + "api_commentary] Where [InfoID]=@NewsID " + whereSTR + " and islock=0";
            return Convert.ToString(DbHelper.ExecuteScalar(CommandType.Text, Sql, param));
        }

        /// <summary>
        /// 得到评论列表
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetCommentList(string NewsID)
        {
            OleDbParameter param = new OleDbParameter("@NewsID", NewsID);
            string Sql = "Select Commid,Title,Content,UserNum,creatTime,IP,commtype,QID,id,GoodTitle From " + Pre + "api_commentary Where InfoID=@NewsID And isRecyle=0 And islock=0 Order By OrderID desc,creatTime Desc,id desc";
            return DbHelper.ExecuteTable(CommandType.Text, Sql, param);
        }

        public IDataReader GetNewsInfo(string NewsID, int ChID)
        {
            string Sql = string.Empty;
            OleDbParameter[] param = new OleDbParameter[1];
            if (ChID != 0)
            {
                param[0] = new OleDbParameter("@NewsID", OleDbType.Integer, 4);
                param[0].Value = int.Parse(NewsID);
                Sql = "Select * From [" + GetChannelTable(ChID) + "] Where [id]=@NewsID";
            }
            else
            {
                param[0] = new OleDbParameter("@NewsID", OleDbType.VarWChar, 12);
                param[0].Value = NewsID;
                Sql = "Select * From [" + Pre + "news] Where [NewsID]=@NewsID";
            }
            return DbHelper.ExecuteReader(CommandType.Text, Sql, param);
        }

        public string GetChannelTable(int ChID)
        {
            string TableStr = "#";
            string TmpTable = string.Empty;
            int GetTableRecord = 0;
            OleDbParameter param = new OleDbParameter("@ChID", ChID);
            string sql = "select DataLib from " + Pre + "sys_channel where ID=@ChID";
            IDataReader dr = DbHelper.ExecuteReader(CommandType.Text, sql, param);
            if (dr.Read())
            {
                TmpTable = dr["DataLib"].ToString();
                string TableSQL = "select count(*) from sysobjects where id = object_id(N'[" + TmpTable + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
                GetTableRecord = Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, TableSQL, null));
                if (GetTableRecord > 0)
                {
                    TableStr = TmpTable;
                }
            }
            dr.Close();
            return TableStr;
        }

        /// <summary>
        /// 添加评论信息
        /// </summary>
        /// <param name="ci">实体类</param>
        /// <returns>如果添加成功返回1</returns>
        public int AddComment(Foosun.Model.Comment ci)
        {
            OleDbParameter[] param = new OleDbParameter[18];
            param[0] = new OleDbParameter("@Id", OleDbType.Integer, 4);
            param[0].Value = ci.Id;
            param[1] = new OleDbParameter("@Commid", OleDbType.VarWChar, 12);
            param[1].Value = ci.Commid;
            param[2] = new OleDbParameter("@InfoID", OleDbType.VarWChar, 12);
            param[2].Value = ci.InfoID;

            param[3] = new OleDbParameter("@APIID", OleDbType.VarWChar, 20);
            param[3].Value = ci.APIID;
            param[4] = new OleDbParameter("@DataLib", OleDbType.VarWChar, 20);
            param[4].Value = ci.DataLib;
            param[5] = new OleDbParameter("@Title", OleDbType.VarWChar, 200);
            param[5].Value = ci.Title;
            param[6] = new OleDbParameter("@Content", OleDbType.VarWChar, 200);
            param[6].Value = ci.Content;

            param[7] = new OleDbParameter("@creatTime", OleDbType.Date, 8);
            param[7].Value = ci.creatTime;
            param[8] = new OleDbParameter("@IP", OleDbType.VarWChar, 20);
            param[8].Value = ci.IP;
            param[9] = new OleDbParameter("@QID", OleDbType.VarWChar, 12);
            param[9].Value = ci.QID;
            param[10] = new OleDbParameter("@UserNum", OleDbType.VarWChar, 15);
            param[10].Value = ci.UserNum;

            param[11] = new OleDbParameter("@isRecyle", OleDbType.Integer, 4);
            param[11].Value = ci.isRecyle;
            param[12] = new OleDbParameter("@islock", OleDbType.Integer, 4);
            param[12].Value = ci.islock;
            param[13] = new OleDbParameter("@OrderID", OleDbType.Integer, 4);
            param[13].Value = ci.OrderID;
            param[14] = new OleDbParameter("@GoodTitle", OleDbType.Integer, 4);
            param[14].Value = ci.GoodTitle;

            param[15] = new OleDbParameter("@isCheck", OleDbType.Integer, 4);
            param[15].Value = ci.isCheck;
            param[16] = new OleDbParameter("@SiteID", OleDbType.VarWChar, 12);
            param[16].Value = ci.SiteID;

            param[17] = new OleDbParameter("@commtype", OleDbType.TinyInt, 1);
            param[17].Value = ci.commtype;
            string Commid = Common.Rand.Number(12);
            while (true)
            {
                string checkSql = "select count(ID) from " + Pre + "api_commentary where Commid='" + Commid + "'";
                int recordCount = (int)DbHelper.ExecuteScalar(CommandType.Text, checkSql, null);
                if (recordCount < 1)
                    break;
                else
                    Commid = Common.Rand.Number(12, true);
            }

            string Sql = "Insert Into " + Pre + "api_commentary(Commid,InfoID,APIID,DataLib,Title,Content,creatTime,IP,QID,UserNum,isRecyle,islock,OrderID,GoodTitle,isCheck,SiteID,commtype) Values('" + Commid + "',@InfoID,@APIID,@DataLib,@Title,@Content,@creatTime,@IP,@QID,@UserNum,@isRecyle,@islock,@OrderID,@GoodTitle,@isCheck,@SiteID,@commtype)";
            return Convert.ToInt32(DbHelper.ExecuteNonQuery(CommandType.Text, Sql, param));
        }

        /// <summary>
        /// 得到评论数
        /// </summary>
        /// <param name="infoID"></param>
        /// <param name="num"></param>
        /// <param name="type">0为总数</param>
        /// <returns></returns>
        public int returncomment(string infoID, int num, int type)
        {
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@InfoID", OleDbType.VarWChar, 12);
            param[0].Value = infoID;
            param[1] = new OleDbParameter("@commtype", OleDbType.VarWChar, 4);
            param[1].Value = num;
            if (type == 0)
            {
                string sql = "select count(id) from " + Pre + "api_commentary where InfoID=@InfoID";
                return (int)DbHelper.ExecuteScalar(CommandType.Text, sql, param);
            }
            else
            {
                string sql1 = "select count(id) from " + Pre + "api_commentary where InfoID=@InfoID and commtype=@commtype";
                return (int)DbHelper.ExecuteScalar(CommandType.Text, sql1, param);
            }
        }

        /// <summary>
        /// 得到评论观点
        /// </summary>
        /// <param name="infoID"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int returnCommentGD(string infoID, int num)
        {
            OleDbParameter[] param = new OleDbParameter[2];
            param[0] = new OleDbParameter("@InfoID", OleDbType.VarWChar, 12);
            param[0].Value = infoID;
            param[1] = new OleDbParameter("@commtype", OleDbType.VarWChar, 4);
            param[1].Value = num;

            int perstr = 100;
            string sql = "select count(id) from " + Pre + "api_commentary where InfoID=@InfoID";
            int recordCount = (int)DbHelper.ExecuteScalar(CommandType.Text, sql, param);

            string sql1 = "select count(id) from " + Pre + "api_commentary where InfoID=@InfoID and commtype=@commtype";
            int recordCount1 = (int)DbHelper.ExecuteScalar(CommandType.Text, sql1, param);
            if (recordCount == 0)
            {
                return 0;
            }
            perstr = (recordCount1 * 100 / recordCount);
            return perstr;
        }

        /// <summary>
        /// 更新新闻状态
        /// </summary>
        /// <param name="Num">1为已生成，0表示未生成</param>
        public void UpdateNewsHTML(int Num, string NewsID)
        {
            string str_sql = "update " + Pre + "news set isHtml=" + Num + " where NewsID='" + NewsID + "' " + Common.Public.getSessionStr() + "";
            DbHelper.ExecuteNonQuery(CommandType.Text, str_sql, null);
        }

        /// <summary>
        /// 根据ID获得NewsID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNewsIDfromID1(string id)
        {
            string flg = "0|0";
            string sql = "select NewsID,ClassID from " + Pre + "news where NewsID='" + id + "'";
            IDataReader rd = DbHelper.ExecuteReader(CommandType.Text, sql, null);
            if (rd.Read())
            {
                flg = rd.GetString(0) + "|" + rd.GetString(1);
            }
            rd.Close();
            return flg;
        }

        /// <summary>
        /// 添加新闻点击
        /// </summary>
        /// <param name="NewsID">新闻编号</param>
        public int AddNewsClick(string NewsID)
        {
            OleDbParameter param = new OleDbParameter("@NewsID", NewsID);
            string Sql = "Update " + Pre + "news Set Click=Click+1 Where NewsID=@NewsID";
            DbHelper.ExecuteNonQuery(CommandType.Text, Sql, param);

            Sql = "Select Click From " + Pre + "news Where NewsID=@NewsID";
            return Convert.ToInt32(DbHelper.ExecuteScalar(CommandType.Text, Sql, param));
        }

        /// <summary>
        /// 得到新闻的DIG数
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public int GetTopNum(string NewsID, string getNum)
        {
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@NewsID", OleDbType.VarWChar, 12);
            param[0].Value = NewsID;

            int intnum = 0;
            if (getNum == "1")
            {
                string usql = "update " + Pre + "news set TopNum=TopNum+1 where NewsID=@NewsID";
                DbHelper.ExecuteNonQuery(CommandType.Text, usql, param);
            }
            string sql = "select TopNum from " + Pre + "news where NewsID=@NewsID";
            intnum = (int)DbHelper.ExecuteScalar(CommandType.Text, sql, param);
            return intnum;
        }

        /// <summary>
        /// 得到新闻的unDIG数
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public int GetUndigs(string NewsID, string Undigs)
        {
            try
            {
                OleDbParameter[] param = new OleDbParameter[1];
                param[0] = new OleDbParameter("@NewsID", OleDbType.VarWChar, 12);
                param[0].Value = NewsID;

                int intnum = 0;
                if (Undigs == "1")
                {
                    string usql = "update " + Pre + "news set Undigs=Undigs+1 where NewsID=@NewsID";
                    DbHelper.ExecuteNonQuery(CommandType.Text, usql, param);
                }
                string sql = "select Undigs from " + Pre + "news where NewsID=@NewsID";
                intnum = (int)DbHelper.ExecuteScalar(CommandType.Text, sql, param);
                return intnum;
            }
            catch (Exception)
            {

                string sql = "Alter table " + Pre + "news Add Undigs int DEFAULT(0) NOT NULL";
                DbHelper.ExecuteNonQuery(CommandType.Text, sql, null);
                return 0;
            }

        }
        /// <summary>
        /// 获得省份或城市的信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable GetProvinceOrCityList(string pid)
        {
            string Sql = "Select cityName,Cid From " + Pre + "sys_City where Pid = '" + pid + "'";
            DataTable rdr = DbHelper.ExecuteTable(CommandType.Text, Sql, null);
            return rdr;
        }

        /// <summary>
        /// 得到投票
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataTable GetVote(string NewsID)
        {
            OleDbParameter[] param = new OleDbParameter[1];
            param[0] = new OleDbParameter("@NewsID", OleDbType.VarWChar, 12);
            param[0].Value = NewsID;
            string Sql = "Select NewsID,voteTitle,voteContent,isTimeOutTime,ismTF,isMember,creattime From [" + Pre + "news_vote] Where [NewsID]=@NewsID and DateDiff('d',[isTimeOutTime] ,Now()) > 0";
            DataTable dt = DbHelper.ExecuteTable(CommandType.Text, Sql, param);
            return dt;
        }
    }
}

