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
        string m_sInput;
        string m_sRegex;
        public CODECOItem(string sInput, string sRegex)
        {
            m_sInput = sInput;
            m_sRegex = sRegex;
            Parse();
        }
        private void Parse()
        {
            string[] sLines = m_sInput.Trim("\r\n ".ToCharArray()).Split('\'');
            string sSpecLine = sLines.Aggregate("", (s, i) => s + (string.IsNullOrEmpty(i) ? "" : i.Substring(0, 3)));
            Match mth = Regex.Match(sSpecLine, m_sRegex);
            int ic = mth.Groups.Count;
        }
    }
}
