using System;
using System.Collections.Generic;
using System.Text;

namespace translate
{
    class Program
    {
        static void Main(string[] args)
        {
            string d = @"D:\☾☽";
            string[] di=System.IO.Directory.GetFiles(d);
            for(int i=0;i<di.Length;i++)
            {
                string txt=System.IO.File.ReadAllText(di[i],Encoding.UTF8);
                string tt=tran(txt);
                
                System.IO.File.WriteAllText(di[i],tt);
                string name=tran(di[i]);
                System.IO.File.Move(di[i],name);
            }
        }

        static string tran(string t)
        {
            string value=t;
            value = value.Replace("-660&,35,139", "-660⊙35°,139°");
            value = value.Replace("1983&1&1,###,###", "1983&1&1⊙37.87°,-122.27°");
            value = value.Replace('≡', ':');
            //value=value.Replace(')','》');
            //value=value.Replace('{','〔');
            //value=value.Replace('}','〕');
            //value = value.Replace('∈', '⊂');
            //value = value.Replace("《1991&10,###,###》", "《1991&10,46.2°,6.1°》");
            return value;
        }
    }
}
