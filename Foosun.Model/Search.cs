using System;
using System.Collections.Generic;
using System.Text;

namespace Foosun.Model
{
    [Serializable]
    public class Search
    {
        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _tags;

        public string tags
        {
            get { return _tags; }
            set { _tags = value; }
        }
        private string _date;

        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _classid;

        public string classid
        {
            get { return _classid; }
            set { _classid = value; }
        }

    }
}
