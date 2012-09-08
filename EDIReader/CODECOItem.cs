using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EDIReader
{
    public class CODECOItem
    {
        string Input;
        string m_Regex;
        public CODECOItem(string sInput, string sRegex)
        {
            Input = sInput;
            m_Regex = sRegex;
            Parse();
        }
        private void Parse()
        {
            string[] sLines = Input.Trim("\r\n ".ToCharArray()).Split('\'');
            string sSpecLine = sLines.Aggregate("", (s, i) => s + (string.IsNullOrEmpty(i) ? "" : i.Substring(0, 3)));
            Match mth = Regex.Match(sSpecLine, m_Regex);
            int ic = mth.Groups.Count;
        }
    }
}
