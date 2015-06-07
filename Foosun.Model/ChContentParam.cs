using System;
using System.Collections.Generic;
using System.Text;

namespace Foosun.Model
{
    public class ChContentParam
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int ID;
        /// <summary>
        /// 新闻权重。1-50的数字。0为置顶。数字越小，权重越高
        /// </summary>
        public int OrderID;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title;
        /// <summary>
        /// 标题颜色
        /// </summary>
        public string TitleColor;
        /// <summary>
        /// 是否斜体，1是，0否
        /// </summary>
        public int TitleITF;
        /// <summary>
        /// 是否粗体，1是，0否
        /// </summary>
        public int TitleBTF;
        /// <summary>
        /// 图片地址(大)
        /// </summary>
        public string PicURL;
        /// <summary>
        /// 所属栏目
        /// </summary>
        public int ClassID;
        /// <summary>
        /// 所属专题
        /// </summary>
        public string SpecialID;
        /// <summary>
        /// 作者
        /// </summary>
        public string Author;
        /// <summary>
        /// 来源
        /// </summary>
        public string Souce;
        /// <summary>
        /// Tags,多个用”，”分开
        /// </summary>
        public string Tags;
        /// <summary>
        /// 新闻属性推荐,滚动,热点,幻灯,头条(头条可以直接生成图片头条),公告,WAP,精彩格式如:0,1,1,0,1,0,0,1
        /// </summary>
        public string ContentProperty;

        /// <summary>
        /// 模板
        /// </summary>
        public string Templet;
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Content;
        /// <summary>
        /// 点击
        /// </summary>
        public int Click;
        /// <summary>
        /// META关键字
        /// </summary>
        public string Metakeywords;
        /// <summary>
        /// META描述
        /// </summary>
        public string Metadesc;
        /// <summary>
        /// 导航内容
        /// </summary>
        public string naviContent;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreatTime;
        /// <summary>
        /// 保存路径
        /// </summary>
        public string SavePath;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName;

        /// <summary>
        /// 如果频道有浏览权限.则有效.0 表示都可以查看,1扣出G,2扣除点数,3扣除G和点,4要达到G,5到点数,6要达到G和点
        /// </summary>
        public int isDelPoint;
        /// <summary>
        /// 浏览需要G币
        /// </summary>
        public int Gpoint;
        /// <summary>
        /// 浏览需要积分
        /// </summary>
        public int iPoint;
        /// <summary>
        /// 需要某个权限组才能查看.
        /// </summary>
        public string GroupNumber;
        /// <summary>
        /// 是否锁定，0否，1是
        /// </summary>
        public int isLock;
        /// <summary>
        /// 频道
        /// </summary>
        public int ChID;
        /// <summary>
        /// 编辑
        /// </summary>
        public string Editor;
        /// <summary>
        /// 是否已生成静态文件
        /// </summary>
        public int isHtml;
        /// <summary>
        /// 是否投稿
        /// </summary>
        public int isConstr;
    }
}
