using System;
using System.Data;
using System.Reflection;
using Foosun.Model;

namespace Foosun.IDAL
{
    public interface IRss
    {
        int sel(string ClassID);
        DataTable getxmllist(string ClassID);
    }
}
