using System;
using System.Collections.Generic;
using System.Data;
using Foosun.Model;
using Foosun.DALFactory;
using System.IO;
using Foosun.IDAL;

namespace Foosun.CMS
{
    public class DropTemplet
    {
        private IDropTemplet dal = DataAccess.CreateDropTemplet();

        /// <summary>
        /// 添加模版
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="templet"></param>
        /// <param name="readNewsTemplet"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int AddTemplet(string classId, string templet, string readNewsTemplet, string type)
        {
            return dal.AddTemplet(classId, templet, readNewsTemplet, type);
        }

        /// <summary>
        /// 删除模版
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int DeleteTemplet(string classId, string type)
        {
            return dal.DeleteTemplet(classId, type);
        }

        /// <summary>
        /// 获取新闻模版
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public string GetNewsTemplet(string newsId)
        {
            return dal.GetNewsTemplet(newsId);
        }

        /// <summary>
        /// 获取栏目下新闻模版
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetReadNewsTemplet(string classId)
        {
            return dal.GetReadNewsTemplet(classId);
        }

        /// <summary>
        /// 修改模版
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="templet"></param>
        /// <param name="readNewsTemplet"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int UpdateTemplet(string classId, string templet, string readNewsTemplet, string type)
        {
            return dal.UpdateTemplet(classId, templet, readNewsTemplet, type);
        }

        /// <summary>
        /// 修改新闻模版
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="templet"></param>
        public void UpdateNewsTemplet(string classID, string templet)
        {
            dal.UpdateNewsTemplet(classID, templet);
        }

        /// <summary>
        /// 修改栏目模版
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="templet"></param>
        /// <param name="readNewsTemplet"></param>
        public void UpdateClassTemplet(string classID, string templet, string readNewsTemplet)
        {
            dal.UpdateClassTemplet(classID, templet, readNewsTemplet);
        }

        /// <summary>
        /// 获取栏目模版
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetClassTemplet(string classId)
        {
            return dal.GetClassTemplet(classId);
        }

        /// <summary>
        /// 获取专题模版
        /// </summary>
        /// <param name="specialId"></param>
        /// <returns></returns>
        public string GetSpecialTemplet(string specialId)
        {
            return dal.GetSpecialTemplet(specialId);
        }
    }
}
