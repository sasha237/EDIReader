using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EDIReader
{
    [XmlRoot("Item")]
    public class MessageItem : BaseItem
    {
        [XmlIgnoreAttribute]
        public string sLine;
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
        public override string GetRegexString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("(");
            if (childs.Count > 0)
            {
                foreach (MessageItem item in childs)
                {
                    str.Append(item.GetRegexString());
                }
            }
            else
            {
                str.Append(sTag);
            }
            str.AppendFormat("){{{0},{1}}}", (sS == "M" ? 1 : 0), iR);
            return str.ToString();
        }
        public override string GetId()
        {
            return sTag;
        }
    }
}
