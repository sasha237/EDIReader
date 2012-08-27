using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public class MessageItem
    {
        public string m_sLine;
        public string m_sPos;
        public string m_sTag;
        public string m_sName;
        public string m_sS;
        public string m_sTail;
        public int m_iR;
        public MessageItem m_parent;
        public List<MessageItem> m_childs;
        public MessageItem(string sLine)
        {
            m_childs = new List<MessageItem>();
            m_parent = null;
            m_sLine = sLine;
            Parse();
        }
        void Parse()
        {
            string sLine = m_sLine.Trim();
            if (string.IsNullOrEmpty(sLine))
                return;
            int iPos = sLine.IndexOf(" ");
            if (iPos == -1)
                return;
            m_sPos = sLine.Substring(0, iPos).Trim();
            sLine = sLine.Substring(iPos).Trim();
            if (sLine[0] != '-')
            {
                m_sTag = sLine.Substring(0, 3).Trim();
                sLine = sLine.Substring(3).Trim();
            }
            iPos = sLine.LastIndexOfAny("0123456789".ToCharArray());
            if (iPos == -1)
            {
                return;
            }
            int iPos2 = sLine.LastIndexOfAny("CM".ToCharArray(), iPos);
            if (iPos2==-1)
            {
                return;
            }
            m_sS = sLine.Substring(iPos2, 1).Trim();
            string sBuf = sLine.Substring(iPos2+1, iPos - iPos2).Trim();
            m_sTail = sLine.Substring(iPos+1).Trim();
            m_sTail = new string(m_sTail.ToCharArray().Reverse().ToArray());
            int.TryParse(sBuf, out m_iR);
            m_sName = sLine.Substring(0, iPos2).Trim();
        }
        public string GetRegexString()
        {
            StringBuilder str = new StringBuilder();
            if (m_parent == null)
            {
                str.Append("(UNA){0,1}(UNB){1,1}");
            }
            else
            str.Append("(");

            if (m_childs.Count>0)
            {
                foreach (MessageItem item in m_childs)
                {
                    str.Append(item.GetRegexString());
                }
            }
            else
            {
                str.Append(m_sTag);
            }
                       
            if (m_parent == null)
            {
                str.Append("(UNZ){1,1}");
            }
            else
            str.AppendFormat("){{{0},{1}}}", (m_sS == "M" ? 1 : 0), m_iR);
            return str.ToString();
        }
    }
}
