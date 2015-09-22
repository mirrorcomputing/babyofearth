using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;

namespace 地球之子
{
    public class loadsetting
    {
        static string settingfile = "setting.json";
        public static IDictionary<string, object> set;
        public loadsetting()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string text = System.IO.File.ReadAllText(settingfile,Encoding.UTF8);
            set = new Dictionary<string, object>();
            set = (IDictionary<string, object>)serializer.Deserialize(text, set.GetType());
        }

    }
}
