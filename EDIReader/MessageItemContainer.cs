using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EDIReader
{
    [XmlRoot("Message")]
    public class MessageItemContainer : BaseItem
    {
        [XmlAttribute("Name")]
        public string m_sName;
        [XmlElement("Item")]
        public List<MessageItem> m_items;

        public override string GetRegexString() 
        {
            StringBuilder str = new StringBuilder();
            str.Append("(UNA){0,1}(UNB){1,1}");
            foreach (var el in m_items)
            {
                str.Append(el.GetRegexString());
            }
            str.Append("(UNZ){1,1}");
            return str.ToString();
        }
    }
}
