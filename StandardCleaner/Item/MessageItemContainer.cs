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
        public string Name;
        [XmlElement("Item")]
        public List<MessageItem> items;
        [XmlIgnoreAttribute]
        string[] sLines;
        public void Parse(string sName, string sInputLine)
        {
            Name = sName;
            items = new List<MessageItem>();
            if (string.IsNullOrEmpty(sInputLine))
                return;
            sLines = sInputLine.Split("\r\n".ToCharArray());
            MessageItem cur = null;
            int iLevel = -1;
            foreach (string el in sLines)
            {
                string sLine = el.Trim();
                if (string.IsNullOrEmpty(sLine))
                    continue;
                MessageItem item = new MessageItem();
                item.Parse(sLine);
                if (string.IsNullOrEmpty(item.sName))
                    continue;
                item.parent = cur;
                if (cur == null)
                    items.Add(item);
                else
                    cur.childs.Add(item);
                if (!string.IsNullOrEmpty(item.sTail))
                {
                    int iCount = item.sTail.Count(c => c == '+');
                    if (iCount != 0)
                    {
                        for (int i = item.sTail.Length - 1; i >= 0; i--)
                        {
                            if (item.sTail[i] == '+')
                            {
                                if (iLevel < i)
                                {
                                    iLevel = i;
                                    cur = item;
                                    break;
                                }
                                if (iLevel == i)
                                {
                                    cur = cur.parent;
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
