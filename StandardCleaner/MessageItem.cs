using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StandardCleaner
{
    [XmlRoot("Item")]
    public class MessageItem
    {
        [XmlIgnoreAttribute]
        public string m_sLine;
        [XmlAttribute("Position")]
        public string m_sPos;
        [XmlAttribute("Id")]
        public string m_sTag;
        [XmlAttribute("Name")]
        public string m_sName;
        [XmlAttribute("Rep")]
        public string m_sS;
        [XmlIgnoreAttribute]
        public string m_sTail;
        [XmlAttribute("Count")]
        public int m_iR;
        [XmlIgnoreAttribute]
        public MessageItem m_parent;
        [XmlElement("Item")]
        public List<MessageItem> m_childs;
        public void Parse(string sInputLine)
        {
            m_childs = new List<MessageItem>();
            m_parent = null;
            m_sLine = sInputLine;
            string sLine = m_sLine.Trim();
            if (string.IsNullOrEmpty(sLine))
                return;
            int iPos = sLine.IndexOf(" ");
            if (iPos == -1)
                return;
            m_sPos = sLine.Substring(0, iPos).Trim();
            sLine = sLine.Substring(iPos).Trim();
            if (sLine[1] == ' ')
                sLine = sLine.Substring(2);
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
            if (iPos2 == -1)
            {
                return;
            }
            m_sS = sLine.Substring(iPos2, 1).Trim();
            string sBuf = sLine.Substring(iPos2 + 1, iPos - iPos2).Trim();
            m_sTail = sLine.Substring(iPos + 1).Trim();
            m_sTail = new string(m_sTail.ToCharArray().Reverse().ToArray());
            int.TryParse(sBuf, out m_iR);
            m_sName = sLine.Substring(0, iPos2).Trim();
        }
    }
}
