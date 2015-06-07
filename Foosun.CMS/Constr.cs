//===========================================================
//==     (c)2013 Foosun Inc. by dotNETCMS 2.0              ==
//==             Forum:bbs.foosun.net                      ==
//==            website:www.foosun.net                     ==
//===========================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Foosun.DALFactory;
using Foosun.IDAL;
using Foosun.Model;

namespace Foosun.CMS
{
	public class Constr
	{
        private readonly IConstr dal = DataAccess.CreateConstr();
        public Constr()
        {

        }
		#region 前台
		public int Add(STConstr Con)
		{
			return dal.Add(Con);
		}
		public int Update(STConstr Con, string ConIDs)
		{
			return dal.Update(Con, ConIDs);
		}
		public int SelGroupNumber(string UserNum)
		{
			return dal.SelGroupNumber(UserNum);
		}
		public DataTable SelConstrClass(string UserNum)
		{
			return dal.SelConstrClass(UserNum);
		}
		public string SelcName(string u_ClassID)
		{
			return dal.SelcName(u_ClassID);

		}
		public string SelSiteID(string u_SiteID)
		{
			return dal.SelcName(u_SiteID);
		}
		public DataTable Sel1(string ConID)
		{
			return dal.Sel1(ConID);
		}
		public int Sel2()
		{
			return dal.Sel2();
		}
		public int Delete(string ID)
		{
			return dal.Delete(ID);
		}
		public int Sel3(string UserNum)
		{
			return dal.Sel3(UserNum);
		}
		public int Add1(STuserother Con, string UserNum)
		{
			return dal.Add1(Con, UserNum);
		}
		public int Update1(STuserother Con, string ConIDs)
		{
			return dal.Update1(Con, ConIDs);
		}
		public DataTable Sel4(string ConIds)
		{
			return dal.Sel4(ConIds);
		}
		public string ConstrTF()
		{
			return dal.ConstrTF();
		}

		#region ConstrClass.aspx
		public int Delete1(string ID)
		{
			return dal.Delete1(ID);
		}
		public DataTable Sel5(string ID)
		{
			return dal.Sel5(ID);
		}
		#endregion

		#region ConstrClass_Add.aspx
		public DataTable Sel6()
		{
			return dal.Sel6();
		}
		public int Add2(STConstrClass Con, string Ccid, string UserNum)
		{
			return dal.Add2(Con, Ccid, UserNum);
		}
		#endregion

		#region ConstrClass_up.aspx
		public DataTable Sel7(string Ccid)
		{
			return dal.Sel7(Ccid);
		}
		public int Update2(STConstrClass Con, string Ccid)
		{
			return dal.Update2(Con, Ccid);
		}
		#endregion

		#region Constrlist.aspx
		public string Sel_cName(string Ccid)
		{
			return dal.Sel_cName(Ccid);
		}
		public string Sel_Tags(string ID)
		{
			return dal.Sel_Tags(ID);
		}
		public int Update_Tage1(string tagsd, string ID)
		{
			return dal.Update_Tage1(tagsd, ID);
		}
		public int Delete2(string ID)
		{
			return dal.Delete2(ID);
		}
		public DataTable GetPage(string UserNum, string ClassID, int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition)
		{
			return dal.GetPage(UserNum, ClassID, PageIndex, PageSize, out RecordCount, out PageCount, SqlCondition);
		}
		public DataTable GetPage1(int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition)
		{
			return dal.GetPage1(PageIndex, PageSize, out RecordCount, out PageCount, SqlCondition);
		}
		#endregion

		#region Constrlistpass.aspx
		public int Delete3(string ID)
		{
			return dal.Delete3(ID);
		}
		#endregion

		#region Constrlistpass_DC.aspx
		public DataTable Sel8(string ID)
		{
			return dal.Sel8(ID);
		}
		public string Sel9(string ClassID)
		{
			return dal.Sel9(ClassID);
		}
		public string Sel19(string UserNum)
		{
			return dal.Sel19(UserNum);
		}
		#endregion

		#endregion

		#region 后台

		#region Constr_chicklist.aspx
		public DataTable Sel10(string ID)
		{
			return dal.Sel10(ID);
		}
		public int Update3(string ID)
		{
			return dal.Update3(ID);
		}
		public int Delete4(string ID)
		{
			return dal.Delete4(ID);
		}
		#endregion

		#region Constr_Edit.aspx
		public DataTable Sel11(string ConIDs)
		{
			return dal.Sel11(ConIDs);
		}
		public DataTable Sel12()
		{
			return dal.Sel12();
		}
		public DataTable Sel13(string ConIDp)
		{
			return dal.Sel13(ConIDp);
		}

		public int Add3(string NewsID, int NewsType, string NewsTitle, string PicURL, string ClassID, string Author, string Editor, string Souce, string Content, string CreatTime, string SiteID, string Tags, string DataLib, string NewsTemplet, string strSavePath, string strfileName, string strfileexName, string strCheckInt, byte isFiles)
		{
			return dal.Add3(NewsID, NewsType, NewsTitle, PicURL, ClassID, Author, Editor, Souce, Content, CreatTime, SiteID, Tags, DataLib, NewsTemplet, strSavePath, strfileName, strfileexName, strCheckInt, isFiles);
		}

		public int Add4(string NewsID, int gPoint, int iPoint, int Money1, DateTime CreatTime1, string UserNum, string content4)
		{
			return dal.Add4(NewsID, gPoint, iPoint, Money1, CreatTime1, UserNum, content4);
		}
		public int Update5(int iPoint2, int gPoint2, Decimal Money3, int cPoint2, int aPoint2, string UserNum)
		{
			return dal.Update5(iPoint2, gPoint2, Money3, cPoint2, aPoint2, UserNum);
		}
		public int Update4(string ConIDp)
		{
			return dal.Update4(ConIDp);
		}
		public DataTable Sel14(string PCIdsa)
		{
			return dal.Sel14(PCIdsa);
		}
		public DataTable Sel15(string UserNum)
		{
			return dal.Sel15(UserNum);
		}
		public DataTable Sel16()
		{
			return dal.Sel16();
		}
		public DataTable Sel17()
		{
			return dal.Sel17();
		}
		public string Sel18(string ClassID)
		{
			return dal.Sel18(ClassID);
		}

		public void UpdateConstrStrat(string ConID)
		{
			dal.UpdateConstrStrat(ConID);
		}

		public int GetParmConstrNum(string UserNum)
		{
			return dal.GetParmConstrNum(UserNum);
		}

		#endregion

		#region Constr_Pay.aspx
		public DataTable Sel20(string UserNum)
		{
			return dal.Sel20(UserNum);
		}
		public DataTable Sel21(string UserNum)
		{
			return dal.Sel21(UserNum);
		}
		public DataTable Sel22()
		{
			return dal.Sel22();
		}
		public int Add5(string UserNum1, int ParmConstrNums, DateTime payTime, string constrPayID)
		{
			return dal.Add5(UserNum1, ParmConstrNums, payTime, constrPayID);
		}
		public int Update5(string UserNum1)
		{
			return dal.Update5(UserNum1);
		}
		#endregion

		#region Constr_Return.aspx
		public DataTable Sel23(string ConID)
		{
			return dal.Sel23(ConID);
		}
		public int Update6(string passcontent, string ConIDs)
		{
			return dal.Update6(passcontent, ConIDs);
		}
		#endregion

		#region Constr_SetParam.aspx
		public int Add6(string PCId, string ConstrPayName, string gpoint, string ipoint, int moneys1, string Gunit)
		{
			return dal.Add6(PCId, ConstrPayName, gpoint, ipoint, moneys1, Gunit);
		}
		public DataTable Sel24()
		{
			return dal.Sel24();
		}
		#endregion

		#region Constr_SetParamlist.aspx
		public int Delete5(string ID)
		{
			return dal.Delete5(ID);
		}
		#endregion

		#region Constr_SetParamup.aspx
		public DataTable Sel25(string PCIdup)
		{
			return dal.Sel25(PCIdup);
		}
		public int Update6(string ConstrPayName, string gpoint, string ipoint, int moneys1, string Gunit, string PCIdup)
		{
			return dal.Update6(ConstrPayName, gpoint, ipoint, moneys1, Gunit, PCIdup);
		}
		#endregion

		#region Constr_Stat.aspx
		public int Sel26(string UserNum)
		{
			return dal.Sel26(UserNum);
		}
		public int Sel27(string UserNum)
		{
			return dal.Sel27(UserNum);
		}
		public DataTable Sel28(string UserNum)
		{
			return dal.Sel28(UserNum);
		}
		public int Sel29(string UserNum, int m1)
		{
			return dal.Sel29(UserNum, m1);
		}
		#endregion

		#region paymentannals.aspx
		public DataTable Sel30(string UserNum)
		{
			return dal.Sel30(UserNum);
		}
		public string Sel31(string UserNum)
		{
			return dal.Sel31(UserNum);
		}
		public int Delete6(string ID)
		{
			return dal.Delete6(ID);
		}
		#endregion

		/// <summary>
		/// 得到栏目模板，扩展名等。
		/// </summary>
		/// <param name="ClassID"></param>
		/// <returns></returns>
		public DataTable GetClassInfo(string ClassID)
		{
			return dal.GetClassInfo(ClassID);
		}
		#endregion
	}
}
