using System;
using System.Data;
using Foosun.Model;
namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层News
    /// </summary>
    public interface INews
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string NewsID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(Foosun.Model.News model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Foosun.Model.News model);
        /// <summary>
        /// 复制新闻
        /// </summary>
        /// <param name="ClassID"></param>
        /// <param name="sOrgNews"></param>
        /// <param name="NewsID"></param>
        /// <param name="FileName"></param>
        void Copy_news(string ClassID, string sOrgNews, string NewsID, string FileName);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string NewsID);
        /// <summary>
        /// 彻底删除新闻
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int DelNew(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.News GetModel(string NewsID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataTable GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 新闻列表
        /// </summary>      
        DataTable GetPage(string SpecialID, string Editor, string ClassID, string sKeywrd, string DdlKwdType, string sChooses, string SiteID, int PageIndex, int PageSize, out int RecordCount, out int PageCount);
        DataTable GetPageByClass(string where, int PageIndex, int PageSize, out int RecordCount, out int PageCount);
        /// <summary>
        /// 子新闻列表
        /// </summary>      
        DataTable GetPageiframe(string DdlClass, string sKeywrds, string sChoose, string DdlKwdType, int pageindex, int PageSize, out int RecordCount, out int PageCount);
          /// <summary>
        /// 不规则新闻分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="RecordCount"></param>
        /// <param name="PageCount"></param>
        /// <param name="SqlCondition"></param>
        /// <returns></returns>
        DataTable GetPages(int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition);
         /// <summary>
        /// 通用更新新闻方法
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="type">字段类型：1为整型，0为字符串</param>
        /// <param name="value">要更新的字段值</param>
        /// <param name="field">字段名</param>
        int UpdateNews(string NewsID, int type, string value, string field);
         /// <summary>
        /// 通用批量更新新闻
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="num">条件字段：0为NewsID,1为ClassID</param>
        /// <param name="type">字段类型：0为字符串，1为整型</param>
        /// <param name="field">要更新的字段名</param>
        /// <param name="value">字段值</param>
        int UpdateNews(string NewsID, int num, int type, string field, string value);
         /// <summary>
        /// 设置新闻属性
        /// </summary>
        int UpdateNews(int CommTF, int DiscussTF, string NewsProperty, string Templet, string OrderID, int CommLinkTF, string Click, string FileEXName, string Tags, string Souce, string where);
         /// <summary>
        /// 获取新闻页面的静态页面路径
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        DataTable GetDeleteNewsContent(string NewsID);
         /// <summary>
        /// 彻底删除新闻并删除附件、自定义字段、所属专题、子新闻、不规则新闻
       /// </summary>
       /// <param name="NewsID">新闻的NewsID</param>
        void DelNews(string NewsID);
          /// <summary>
        /// 终极审核
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        void AllCheck(string NewsID);
         /// <summary>
        /// 按等级审核
        /// </summary>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="levelsID">审核等级</param>
        void UpCheckStat(string NewsID, int levelsID);
        /// <summary>
        /// 得到指定新闻的IDataReader
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        IDataReader GetNewsID(string NewsID);
         /// <summary>
        /// 得到子新闻
        /// </summary>     
        DataTable GetUNews(string NewsID);
         /// <summary>
        /// 删除不规则新闻
        /// </summary>
        /// <param name="UnID"></param>
        void DelSubID(string UnID);
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
        int Add_SubNews(string unNewsid, string Arr_OldNewsId, string NewsRow, string NewsTitle, string NewsTable, string SiteID, string titleCSS);
        /// <summary>
        /// 取得专题与新闻的对应表
        /// </summary>
        /// <param name="NewsID">新闻编号</param>
        /// <returns></returns>
        DataTable GetSpecialNews(string NewsID);
         /// <summary>
        /// 得到某条新闻的附件列表
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="DataTB"></param>
        /// <returns></returns>
        DataTable GetFileList(string NewsID, string DataTB);
          /// <summary>
        /// 根据id删除附件
        /// </summary>
        /// <param name="ids">多个id用，隔开</param>
        void DeleteNewsFileByID(string ids);
         /// <summary>
        /// 根据newsid删除附件
        /// </summary>
        /// <param name="newsid"></param>
        void DeleteNewsFileByNewsID(string NewsID);
        /// <summary>
        /// 更新附件文件地址
        /// </summary>
        /// <param name="URLName"></param>
        /// <param name="DataLib"></param>
        /// <param name="FileURL"></param>
        /// <param name="OrderID"></param>
        /// <param name="ID"></param>
        void UpdateFileURL(string URLName, string DataLib, string FileURL, int OrderID, int ID);
         /// <summary>
        /// 插入附件
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="DataLib"></param>
        /// <param name="FileURL"></param>
        /// <param name="OrderID"></param>
        void InsertFileURL(string URLName, string NewsID, string DataLib, string FileURL, int OrderID);
         /// <summary>
        /// 检查新闻标题
        /// </summary>
        /// <param name="NewsTitle"></param>
        /// <param name="tb"></param>
        /// <returns></returns>
        int NewsTitletf(string NewsTitle, string dtable, string EditAction, string NewsID);
         /// <summary>
        /// 通用获取新闻内容
        /// </summary>
        /// <param name="field">要查询的字段名，多个字段用，隔开</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
         DataTable GetNewsConent(string field, string where,string order);
          /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="uc2"></param>
        void UpdateNewsContent(Foosun.Model.News uc);
         /// <summary>
        /// 插入新记录
        /// </summary>
        /// <param name="uc2"></param>
        void InsertNewsContent(Foosun.Model.News uc);
        /// <summary>
        /// 得到不规则新闻
        /// </summary>
        /// <param name="UnID"></param>
        /// <returns></returns>
        DataTable GetUnNews(string UnID);
        /// <summary>
        /// 删除不规则新闻
        /// </summary>
        /// <param name="UnID"></param>
         void DelUnNews(string UnID);
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
        int AddUnNews(string unName, string titleCSS, string SubCSS, string unNewsid, string Arr_OldNewsId, string NewsRow, string NewsTitle, string NewsTable, string SiteID);
        /// <summary>
        /// 管理员发布新闻统计
        /// </summary>
        /// <param name="stime">开始时间</param>
        /// <param name="etime">结束时间</param>
        /// <param name="top">查询多少条</param>
        /// <returns></returns>
        DataTable GetNewsStat(string stime, string etime, int top);
        /// <summary>
        /// 新闻点击排行
        /// </summary>
        /// <param name="stime">开始时间</param>
        /// <param name="etime">结束时间</param>
        /// <param name="top">查询多少条</param>
        /// <returns></returns>
        DataTable GetNewsClick(string stime, string etime, int top);
        #region 自定义字段
        /// <summary>
        /// 得到自定义字段类型
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        DataTable GetdefineEditTable(string ClassID);
         /// <summary>
        /// 得到某个自定义字段的值
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        DataTable GetdefineEditTablevalue(int ID);
        /// <summary>
        /// 自定义字段的默认值
        /// </summary>
        /// <param name="defineColumns">英文名称</param>
        /// <param name="NewsID">新闻NewsID</param>
        /// <param name="DataLib">数据库表</param>
        /// <param name="DsApiID">apiid</param>
        /// <returns></returns>
        DataTable ModifyNewsDefineValue(string defineColumns, string NewsID, string DataLib, string DsApiID);
         /// <summary>
        /// 插入/修改自定义字段
        /// </summary>
        /// <param name="DsNewsID"></param>
        /// <param name="DsEName"></param>
        /// <param name="DsNewsTable"></param>
        /// <param name="DsType"></param>
        /// <param name="DsContent"></param>
        /// <param name="DsApiID"></param>
        void SetDefineSign(string DsNewsID, string DsEName, string DsNewsTable, int DsType, string DsContent, string DsApiID);
        #endregion
        #region tag
        /// <summary>
        /// 得到最新的tag
        /// </summary>
        /// <returns></returns>
         DataTable GetTagsList();
        #endregion
            /// <summary>
        /// 得到头条(NewsID)
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="DataLib"></param>
        /// <returns></returns>
         DataTable GetTopline(string NewsID, string DataLib, int NewsTFNum);   
          /// <summary>
        /// 插入头条
        /// </summary>
        /// <param name="uc2"></param>
        void IntsertTT(Foosun.Model.NewsContentTT uc);    
        /// <summary>
        /// 更新头条
        /// </summary>
        /// <param name="uc2"></param>
        void UpdateTT(Foosun.Model.NewsContentTT uc);
        #region 归档新闻
        /// <summary>
        /// 批量删除归档新闻
        /// </summary>
        /// <param name="idlist">归档新闻id列表</param>
        /// <returns></returns>
        int DelOld(string idlist);        
        /// <summary>
        /// 删除全部归档新闻
        /// </summary>
        /// <returns></returns>
        int DelOld();       
        /// <summary>
        /// 通用更新归档新闻方法
        /// </summary>
        /// <param name="NewsID">新闻ID</param>
        /// <param name="type">字段类型：1为整型，0为字符串</param>
        /// <param name="value">要更新的字段值</param>
        /// <param name="field">字段名</param>
        int UpdateOld(string idlist, int type, string value, string field);
          /// <summary>
        /// 插入归档新闻
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int Add_old_News(string where);
        #endregion
        /// <summary>
        /// 得到继承栏目的DataTable
        /// </summary>      
        /// <returns></returns>
         DataTable GetSysParam();
        /// <summary>
        /// 插入常规
        /// </summary>
        /// <param name="_TempStr"></param>
        /// <param name="_URL"></param>
        /// <param name="_EmailURL"></param>
        /// <param name="_num"></param>
        void IGen(string _TempStr, string _URL, string _EmailURL, int _num);
         /// <summary>
        /// 得到内部连接地址
        /// </summary>
        /// <returns></returns>
        DataTable GetGenContent();
         /// <summary>
        /// 添加专题新闻
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="SpecialID"></param>
        void AddSpecial(string NewsID, string SpecialID);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);

        DataTable GetLastFormTB();

        /// <summary>
        /// 新闻预览
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="gType"></param>
        /// <returns></returns>
        string GetNewsReview(string ID, string gType);

        /// <summary>
        /// 获取新闻评论
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="Todays"></param>
        /// <returns></returns>
        string GetCommCounts(string NewsID, string Todays);

        /// <summary>
        /// 得到评论列表
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        DataTable GetCommentList(string NewsID);

        IDataReader GetNewsInfo(string NewsID, int ChID);
        string GetChannelTable(int ChID);
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        int AddComment(Foosun.Model.Comment ci);

        /// <summary>
        /// 得到评论数
        /// </summary>
        /// <param name="infoID"></param>
        /// <param name="num"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        int returncomment(string infoID, int num, int type);

        /// <summary>
        /// 得到评论观点
        /// </summary>
        /// <param name="infoID"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        int returnCommentGD(string infoID, int num);

        /// <summary>
        /// 更新新闻状态
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="NewsID"></param>
        void UpdateNewsHTML(int Num, string NewsID);

        /// <summary>
        /// 根据ID获得NewsID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetNewsIDfromID1(string id);

        /// <summary>
        /// 添加新闻点击
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        int AddNewsClick(string NewsID);

        /// <summary>
        /// 得到新闻的DIG数
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="getNum"></param>
        /// <returns></returns>
        int GetTopNum(string NewsID, string getNum);

        /// <summary>
        /// 得到新闻的unDIG数
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="Undigs"></param>
        /// <returns></returns>
        int GetUndigs(string NewsID, string Undigs);
        DataTable GetProvinceOrCityList(string pid);
        string GetNewsAccessory(int id);
        DataTable GetVote(string NewsID);
        #endregion  成员方法
    }
}
