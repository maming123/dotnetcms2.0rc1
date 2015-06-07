using System;
using System.Collections.Generic;
using System.Text;

namespace Foosun.IDAL
{
    public interface IDropTemplet
    {
        /// <summary>
        /// 添加模版
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="templet"></param>
        /// <returns></returns>
        int AddTemplet(string classId, string templet, string readNewsTemplet, string type);
        /// <summary>
        /// 删除模版
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="templet"></param>
        /// <returns></returns>
        int DeleteTemplet(string classId, string type);

        /// <summary>
        /// 修改模版
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="tmeplet"></param>
        /// <param name="readNewsTemplet"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        int UpdateTemplet(string classId, string tmeplet, string readNewsTemplet, string type);
        /// <summary>
        /// 修改新闻模版
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="templet"></param>
        void UpdateNewsTemplet(string classID, string templet);
        /// <summary>
        /// 修改栏目模版
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="templet"></param>
        /// <param name="readNewsTemplet"></param>
        void UpdateClassTemplet(string classID, string templet, string readNewsTemplet);
        /// <summary>
        /// 获取新闻模版
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        string GetNewsTemplet(string newsId);

        /// <summary>
        /// 获取栏目下的新闻模版
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        string GetReadNewsTemplet(string classId);

        /// <summary>
        /// 获取栏目模版
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        string GetClassTemplet(string classId);

        /// <summary>
        /// 获取专题模版
        /// </summary>
        /// <param name="specialId"></param>
        /// <returns></returns>
        string GetSpecialTemplet(string specialId);
    }
}
