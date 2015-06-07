using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Foosun.IDAL
{
    public interface IStyle
    {
        int SytleClassAdd(Foosun.Model.StyleClassInfo sc);
        int StyleClassEdit(Foosun.Model.StyleClassInfo sc);
        void StyleClassDel(string id);
        void StyleClassRDel(string id);
        int StyleAdd(Foosun.Model.StyleInfo sc);
        int StyleEdit(Foosun.Model.StyleInfo sc);
        void StyleDel(string id);
        void StyleRdel(string id);
        DataTable GetstyleClassInfo(string id);
        DataTable GetstyleInfo(string id);
        DataTable Styledefine();
        DataTable StyleClassList();
        int StyleNametf(string CName);
        DataTable GetLabelStyle();
    }
}
