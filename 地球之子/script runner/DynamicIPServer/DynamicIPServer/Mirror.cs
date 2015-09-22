using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror
{
    public class Atom
    {
        public const char Unicode8start='◐';
        public const char Unicode8stop = '◑';
        public const char Equal = '≡';
    }
    public static class Unicode8
    {
        public static string getUnicode8(string MirrorText)
        {
            string value = MirrorText.Substring(MirrorText.IndexOf('◐'), MirrorText.IndexOf('◑'));
            return value;
        }
        public static string toMirror(string Unicode8Text)
        {
            return "◐" + Unicode8Text + "◑";
        }
    }
}
