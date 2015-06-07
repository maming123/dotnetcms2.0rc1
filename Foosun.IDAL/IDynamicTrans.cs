using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Foosun.IDAL
{
    public interface IDynamicTrans
    {
        IDataReader GetNewsInfo(string NewsID, int Num, int ChID, string DTable);
        IDataReader getUserInfo(string UserNum);
        int UpdateHistory(int InfoType, string InfoID, int iPoint, int Gpoint, string UserNum, string IP);
        bool getUserNote(string UserNum, string infoID, int Num);
    }
}
