using System;
using System.Collections.Generic;

namespace Foosun.Model
{
    [Serializable]
    public class AdminGroup
    {
        public int Id;
        public string AdminGroupNumber;
        public string GroupName;
        public string ClassList;
        public string SpecialList;
        public string channelList;
        public DateTime CreatTime;
        public string SiteID;
    }
}
