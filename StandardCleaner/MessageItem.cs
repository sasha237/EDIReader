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
        public string Line;
        [XmlAttribute("Position")]
        public string sPos;
        [XmlAttribute("Id")]
        public string sTag;
        [XmlAttribute("Name")]
        public string sName;
        [XmlAttribute("Rep")]
        public string sS;
        [XmlIgnoreAttribute]
        public string sTail;
        [XmlAttribute("Count")]
        public int iR;
        [XmlIgnoreAttribute]
        public MessageItem parent;
        [XmlElement("Item")]
        public List<MessageItem> childs;
        public void Parse(string sInputLine)
        {
            childs = new List<MessageItem>();
            parent = null;
            Line = sInputLine;
            string sLine = Line.Trim();
            if (string.IsNullOrEmpty(sLine))
                return;
            int iPos = sLine.IndexOf(" ");
            if (iPos == -1)
                return;
            sPos = sLine.Substring(0, iPos).Trim();
            sLine = sLine.Substring(iPos).Trim();
            if (sLine[1] == ' ')
                sLine = sLine.Substring(2);
            if (sLine[0] != '-')
            {
                sTag = sLine.Substring(0, 3).Trim();
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
            sS = sLine.Substring(iPos2, 1).Trim();
            string sBuf = sLine.Substring(iPos2 + 1, iPos - iPos2).Trim();
            sTail = sLine.Substring(iPos + 1).Trim();
            sTail = new string(sTail.ToCharArray().Reverse().ToArray());
            int.TryParse(sBuf, out iR);
            sName = sLine.Substring(0, iPos2).Trim();
        }
    }
}
