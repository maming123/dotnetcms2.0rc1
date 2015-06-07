using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Foosun.IDAL
{
    /// <summary>
    /// 接口层NewsClass
    /// </summary>
    public interface INewsClass
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录(ClassID)
        /// </summary>
        int ExistsByClassId(string ClassID);
        /// <summary>
        /// 是否存在该记录(EName)
        /// </summary>
        int ExistsByClassEName(string eName);
          /// <summary>
        /// 通用判断是否存在该记录
        /// </summary>
        int Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Foosun.Model.NewsClass model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Foosun.Model.NewsClass model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int Id);
        bool DeleteList(string Idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Foosun.Model.NewsClass GetModel(string ClassID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataTable GetList(string strWhere);
        /// <summary>
        /// 得到栏目信息
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        DataTable GetClassContent(string classID);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataTable GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 复位栏目(复位选中栏目)
        /// </summary>
        /// <param name="ids">栏目编号</param>
        /// <returns></returns>
        int ResetClass(string ids);
        /// <summary>
        /// 合并栏目
        /// </summary>
        /// <param name="sourceClassId">源栏目编号</param>
        /// <param name="targetClassId">目标栏目编号</param>
        /// <returns></returns>
        int MergerClass(string sourceClassId, string targetClassId);
        /// <summary>
        /// 栏目转移
        /// </summary>
        /// <param name="sourceClassId">源栏目编号</param>
        /// <param name="targetClassId">目标栏目编号</param>
        /// <returns></returns>
        int TransferClass(string sourceClassId, string targetClassId);
        /// <summary>
        /// 初始化栏目
        /// </summary>
        /// <returns></returns>
        int InitializeClass();
        /// <summary>
        /// 设置栏目属性
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <param name="classTemplet">栏目列表模版</param>
        /// <param name="readNewTemplet">新闻浏览模版</param>
        /// <param name="isUpdate">是否更新栏目下的新闻模版</param>
        /// <returns></returns>
        int SetClassAttribute(string classId, string classTemplet, string readNewTemplet, bool isUpdate);
        /// <summary>
        /// 锁定/解锁栏目
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        int SetLock(string classId);
        /// <summary>
        /// 放入\还原回收站
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        int SetRecyle(string classId);
        /// <summary>
        /// 得到栏目下的子类并删除到回收站
        /// </summary>
        /// <param name="parentID"></param>
        void SetChildClassRecyle(string parentID);
        /// <summary>
        /// 彻底删除栏目下的子栏目
        /// </summary>
        /// <param name="parentID"></param>
        void DelChildClass(string parentID);
        /// <summary>
        /// 清空栏目
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <returns></returns>
        int ClearNews(string classId);
        /// <summary>
        /// 设置栏目权重
        /// </summary>
        /// <param name="classId">栏目编号</param>
        /// <param name="orderId">权重</param>
        /// <returns></returns>
        int SetOrder(string classId, int orderId);
        /// <summary>
        /// 得到导航内容
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        IDataReader GetNaviClass(string ClassID);
        /// <summary>
        /// 更新导航
        /// </summary>
        /// <param name="classID"></param>
        void UpdateReplaceNavi(string classID);
         /// <summary>
        /// 得到该栏目新闻的数据表名
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        string GetDataLib(string ClassID);
         /// <summary>
        /// 通用获取栏目的内容
        /// </summary>
        /// <param name="field">要获取的字段名，多个字段用，隔开</param>
        /// <param name="where">查询的条件</param>
        /// <returns></returns>
        DataTable GetContent(string field, string where,string order);
         /// <summary>
        /// 通用更新栏目方法
        /// </summary>
        /// <param name="ClassID">栏目的classid</param>
        /// <param name="type">字段类型：1为整型，0为字符串</param>
        /// <param name="value">要更新的字段值</param>
        /// <param name="field">字段名</param>
        /// <returns></returns>
        int UpdateClass(string ClassID, int type, string value, string field);

        /// <summary>
        /// 新闻栏目分页
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        DataTable GetPage(string siteId, int pageSize, int pageIndex, out int recordCount, out int pageCount);

        /// <summary>
        /// 获取是否有子栏目
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        int ExistsChild(string classId);

        /// <summary>
        /// 获取该栏目下的新闻条数
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        DataTable GetNewsCount();
        /// <summary>
        /// `得到栏目下的子栏目
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        DataTable GetChildList(string parentID);
        /// <summary>
        /// 得到源栏目列表
        /// </summary>
        /// <returns></returns>
        DataTable GetSouceClass();

        /// <summary>
        /// 删除源栏目
        /// </summary>
        /// <param name="classID"></param>
        void DelSouce(string classID);

        /// <summary>
        /// 更新源栏目
        /// </summary>
        /// <param name="sClassID"></param>
        /// <param name="tClassID"></param>
        void UpdateSouce(string sClassID, string tClassID);

        /// <summary>
        /// 更改目标下新闻
        /// </summary>
        /// <param name="sClassID"></param>
        /// <param name="tClassID"></param>
        void ChangeParent(string sClassID, string tClassID);

        /// <summary>
        /// 得到栏信息（批量设置属性）
        /// </summary>
        /// <returns></returns>
        DataTable GetClassInfoTemplet();
        /// <summary>
        /// 更新栏目
        /// </summary>
        /// <param name="strUpdate"></param>
        /// <param name="str"></param>
        void UpdateClassInfo(string strUpdate, string str);

        /// <summary>
        /// 更新所有的表
        /// </summary>
        /// <param name="templet"></param>
        /// <param name="str"></param>
        void UpdateClassNewsInfo(string templet, string str);

        /// <summary>
        /// 得到栏目列表的子类
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        DataTable GetLock(string classID);

        /// <summary>
        /// 得到栏目是否是单页
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        int GetClassPage(string classID);
        /// <summary>
        /// 得到自定义字段类型（修改）
        /// </summary>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        DataTable GetDefineEditTable(string ClassID);

        /// <summary>
        /// 得到父类是否合法
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        DataTable GetParentClass(string classID);

        /// <summary>
        /// 更改栏目状态
        /// </summary>
        /// <param name="Num"></param>
        /// <param name="ClassID"></param>
        void UpdateClassStat(int Num, string ClassID);

        /// <summary>
        /// 得到栏目中文名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        string GetNewsClassCName(string classId);

        /// <summary>
        /// 更新单页面
        /// </summary>
        /// <param name="NewsClassModel"></param>
        void UpdatePage(Foosun.Model.NewsClass NewsClassModel);

        /// <summary>
        /// 添加单页面
        /// </summary>
        /// <param name="NewsClassModel"></param>
        void InsertPage(Foosun.Model.NewsClass NewsClassModel);
        #endregion  成员方法
    } 
}
