using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public class MessageItemContainer
    {
        List<MessageItem> m_items;
        MessageItem m_parent;
        string[] m_sLines;
        public MessageItemContainer(string sLine)
        {
            m_items = new List<MessageItem>();
            if (string.IsNullOrEmpty(sLine))
                return;
            m_sLines = sLine.Split("\r\n".ToCharArray());
            Parse();
        }
        void Parse()
        {
            m_parent = new MessageItem("");
            MessageItem cur = m_parent;
            int iLevel = -1;
            foreach (string el in m_sLines)
            {
                string sLine = el.Trim();
                if (string.IsNullOrEmpty(sLine))
                    continue;
                MessageItem item = new MessageItem(sLine);
                if (string.IsNullOrEmpty(item.m_sName))
                    continue;
                m_items.Add(item);
                cur.m_childs.Add(item);
                item.m_parent = cur;
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
        public string GetRegexString()
        {
            return m_parent.GetRegexString();
        }
    }
}
