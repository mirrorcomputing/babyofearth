using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicIPServer
{
    public class SpaceNameDictionary : Dictionary<string, SpaceName>
    {
        public void Add(SpaceName value)
        {
            Add(value.NameHead,value);
        }
    }
    public class SpaceName : Dictionary<string, string>
    {
   
        //<(1983&1&1,###,###)>≡◐IPv4:port◑
        //<(1991&10,###,###)>≡◐李鹏◑ 
        //<>≡◐李鹏◑
        string namehead;
        public SpaceName()
        {

        }
        string trim(string s) 
        {
            string value = "";
            bool init=false;
            for(int i=0;i<s.Length;i++)
            {
                if (init == true)
                {
                    value += s[i];
                    if (s[i] == '◐')
                    {
                        init = true;
                    }
                }
                else
                {
                    if (s[i] == ' ' || s[i] == '\n' || s[i] == '\r' || s[i] == '\t')
                    {
                       
                    } 
                    else
                    {
                        value += s[i];
                    }
                    
                    if (s[i] == '◑')
                    {
                        init = false;
                    }
                }


            }
            return value;
        }
        public string NameHead
        {
            get { return namehead; }
            set { namehead = value; }
        }
        public SpaceName(string _namedata)
        {
            _namedata = trim(_namedata);
            if (_namedata.Contains("{") == true)
            {
                string _head = _namedata.Substring(0, _namedata.IndexOf("{"));
                string _body = _namedata.Substring(_namedata.IndexOf("{") + 1, _namedata.LastIndexOf("}") - _namedata.IndexOf("{") - 1);

                namehead = _head;
                string Body = _body;
                string[] nodes = Body.Split(';');

                for (int i = 0; i < nodes.Length; i++)
                {
                    nodes[i] = nodes[i].Trim();
                    if (nodes[i].Contains("<") && nodes[i].Contains(">"))
                    {
                        string nodename = nodes[i].Substring(nodes[i].IndexOf('<') + 1, nodes[i].IndexOf('>') - nodes[i].IndexOf('<') - 1);

                        string nodebody = nodes[i].Substring(nodes[i].IndexOf('>') + 1);
                        this.Add(nodename, nodebody);
                    }
                }
            }
            else
            {
                string _head = _namedata;
                namehead = _head;
            }
        }

        public SpaceName(string _namehead, string _namebody)
        {
            namehead = trim(_namehead);
            _namebody = trim(_namebody);
            string Body = _namebody.Substring(_namebody.IndexOf("{")+1, _namebody.LastIndexOf("}") - _namebody.IndexOf("{")-1);
            Body = Body.Trim();
            string[] nodes = Body.Split(';');
            
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = nodes[i].Trim();
                if(nodes[i].Contains("<")&&nodes[i].Contains(">")&&nodes[i].Contains("≡"))
                {
                    string nodename = nodes[i].Substring(nodes[i].IndexOf('<') + 1, nodes[i].IndexOf('>') - nodes[i].IndexOf('<') - 1);
                    string nodebody = nodes[i].Substring(nodes[i].IndexOf('≡'));
                    this.Add(nodename, nodebody);
                }
            }
        }
        public override string ToString()
        {
            string value = NameHead+"{";
            foreach (KeyValuePair<string, string> m in this)
            {
                value += '<'+m.Key +'>'+ m.Value + ";";
            }
            value += "}";
            return value;
        }
    }
}
