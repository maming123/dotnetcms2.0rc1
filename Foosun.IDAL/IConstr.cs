using System;
using System.Data;
using System.Reflection;
using Foosun.Model;

namespace Foosun.IDAL
{
	public interface IConstr
	{
		#region 前台
		int Add(STConstr Con);
		int SelGroupNumber(string UserNum);
		DataTable SelConstrClass(string UserNum);
		int Update(STConstr Con, string ConIDs);
		string SelcName(string u_ClassID);
		string SelSiteID(string u_SiteID);
		DataTable Sel1(string ConID);
		int Sel2();
		int Delete(string ID);
		int Sel3(string UserNum);
		int Add1(STuserother Con, string UserNum);
		int Update1(STuserother Con, string ConIDs);
		DataTable Sel4(string ConIds);
		int Delete1(string ID);
		DataTable Sel5(string ID);
		DataTable Sel6();
		int Add2(STConstrClass Con, string Ccid, string UserNum);
		DataTable Sel7(string Ccid);
		int Update2(STConstrClass Con, string Ccid);
		string Sel_cName(string Ccid);
		string Sel_Tags(string ID);
		int Update_Tage1(string tagsd, string ID);
		int Delete2(string ID);
		int Delete3(string ID);
		DataTable Sel8(string ID);
		string Sel9(string ClassID);
		string Sel19(string UserNum);
		DataTable GetPage(string UserNum, string ClassID, int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition);
		DataTable GetPage1(int PageIndex, int PageSize, out int RecordCount, out int PageCount, params SQLConditionInfo[] SqlCondition);
		string ConstrTF();
		#endregion

		#region 后台
		#region Constr_chicklist.aspx
		DataTable Sel10(string ID);
		int Update3(string ID);
		int Delete4(string ID);
		#endregion

		#region Constr_Edit.aspx
		DataTable Sel11(string ConIDs);
		DataTable Sel12();
		DataTable Sel13(string ConIDp);

		int Add3(string NewsID, int NewsType, string NewsTitle, string PicURL, string ClassID, string Author, string Editor, string Souce, string Content, string CreatTime, string SiteID, string Tags, string DataLib, string NewsTemplet, string strSavePath, string strfileName, string strfileexName, string strCheckInt, byte isFiles);

		int Add4(string NewsID, int gPoint, int iPoint, int Money1, DateTime CreatTime1, string UserNum, string content4);
		int Update5(int iPoint2, int gPoint2, Decimal Money3, int cPoint2, int aPoint2, string UserNum);
		int Update4(string ConIDp);
		DataTable Sel14(string PCIdsa);
		DataTable Sel15(string UserNum);
		DataTable Sel16();
		DataTable Sel17();
		string Sel18(string ClassID);
		void UpdateConstrStrat(string ConID);
		int GetParmConstrNum(string UserNum);
		#endregion

		#region Constr_Pay.aspx
		DataTable Sel20(string UserNum);
		DataTable Sel21(string UserNum);
		DataTable Sel22();
		int Add5(string UserNum1, int ParmConstrNums, DateTime payTime, string constrPayID);
		int Update5(string UserNum1);
		#endregion

		#region Constr_Return.aspx
		DataTable Sel23(string ConID);
		int Update6(string passcontent, string ConIDs);
		#endregion

		#region Constr_SetParam.aspx
		int Add6(string PCId, string ConstrPayName, string gpoint, string ipoint, int moneys1, string Gunit);
		DataTable Sel24();
		#endregion

		#region Constr_SetParamlist.aspx
		int Delete5(string ID);
		#endregion

		#region Constr_SetParamup.aspx
		DataTable Sel25(string PCIdup);
		int Update6(string ConstrPayName, string gpoint, string ipoint, int moneys1, string Gunit, string PCIdup);
		#endregion

		#region Constr_Stat.aspx
		int Sel26(string UserNum);
		int Sel27(string UserNum);
		DataTable Sel28(string UserNum);
		int Sel29(string UserNum, int m1);
		#endregion

		#region paymentannals.aspx
		DataTable Sel30(string UserNum);
		string Sel31(string UserNum);
		int Delete6(string ID);
		#endregion
		#endregion
		DataTable GetClassInfo(string ClassID);
	}
}
