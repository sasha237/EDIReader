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
        public override string GetRegexString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("(");
            if (m_childs.Count > 0)
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
            str.AppendFormat("){{{0},{1}}}", (m_sS == "M" ? 1 : 0), m_iR);
            return str.ToString();
        }
    }
}
