using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StandardCleaner
{
    [XmlRoot("Message")]
    public class MessageItemContainer
    {
        [XmlAttribute("Name")]
        public string m_sName;
        [XmlElement("Item")]
        public List<MessageItem> m_items;
        [XmlIgnoreAttribute]
        string[] m_sLines;
        public void Parse(string sName, string sInputLine)
        {
            m_sName = sName;
            m_items = new List<MessageItem>();
            if (string.IsNullOrEmpty(sInputLine))
                return;
            m_sLines = sInputLine.Split("\r\n".ToCharArray());
            MessageItem cur = null;
            int iLevel = -1;
            foreach (string el in m_sLines)
            {
                string sLine = el.Trim();
                if (string.IsNullOrEmpty(sLine))
                    continue;
                MessageItem item = new MessageItem();
                item.Parse(sLine);
                if (string.IsNullOrEmpty(item.m_sName))
                    continue;
                item.m_parent = cur;
                if (cur == null)
                    m_items.Add(item);
                else
                    cur.m_childs.Add(item);
                if (!string.IsNullOrEmpty(item.m_sTail))
                {
                    int iCount = item.m_sTail.Count(c => c == '+');
                    if (iCount != 0)
                    {
                        for (int i = item.m_sTail.Length - 1; i >= 0; i--)
                        {
                            if (item.m_sTail[i] == '+')
                            {
                                if (iLevel < i)
                                {
                                    iLevel = i;
                                    cur = item;
                                    break;
                                }
                                if (iLevel == i)
                                {
                                    cur = cur.m_parent;
                                    iLevel--;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
