namespace Foosun.Publish
{
    using System;
    using System.Collections;

    public class LabelStyle
    {
        private static Hashtable _CHStyle = new Hashtable();
        private static Hashtable _LabelStyle = new Hashtable();
        private string original = string.Empty;

        public LabelStyle(string style)
        {
            this.original = style;
        }

        public static void CatchClear()
        {
            _LabelStyle.Clear();
            _CHStyle.Clear();
        }

        public static string GetCHStyleByID(int id, int ChID)
        {
            string cHStyleContent = string.Empty;
            string key = id.ToString() + "|" + ChID.ToString();
            if (_CHStyle[key] == null)
            {
                cHStyleContent = CommonData.DalPublish.GetCHStyleContent(id, ChID);
                _CHStyle.Add(key, cHStyleContent);
                return cHStyleContent;
            }
            return _CHStyle[key].ToString();
        }

        public static string GetStyleByID(string id)
        {
            string styleContent = string.Empty;
            if (_LabelStyle[id] == null)
            {
                styleContent = CommonData.DalPublish.GetStyleContent(id);
                _LabelStyle.Add(id, styleContent);
                return styleContent;
            }
            return _LabelStyle[id].ToString();
        }
    }
}

