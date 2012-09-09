using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StandardCleaner
{
    [XmlRoot("Root")]
    public class TagItem
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Function")]
        public string Function { get; set; }
        [XmlAttribute("Note")]
        public string Note { get; set; }
        [XmlElement("Item")]
        public List<TagElementItem> items;
        public void Parse(string[] sInputLines)
        {
            items = new List<TagElementItem>();
            if (sInputLines.Length == 0)
                return;
            Queue<string> lineQ = new Queue<string>(sInputLines.ToArray());
            string sLine = "";
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue().Trim();
                if (string.IsNullOrEmpty(sLine))
                    continue;
                break;
            }
            if (string.IsNullOrEmpty(sLine))
                return;
            Id = sLine.Substring(0, 3);
            Name = sLine.Substring(3).Trim();
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue().Trim();
                if (string.IsNullOrEmpty(sLine))
                    continue;
                break;
            }
            if (string.IsNullOrEmpty(sLine))
                return;
            int iPos = sLine.IndexOf("Function:");
            if (iPos == -1)
                return;
            Function = sLine.Substring(iPos + "Function:".Length).Trim();
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue();
                if (string.IsNullOrEmpty(sLine))
                    break;
                if (sLine.IndexOf("            ") != -1)
                {
                    Function += " " + sLine.Trim();
                    continue;
                }
                break;
            }


            List<string> miniList = new List<string>();
            TagElementItem item = null;
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue();
                if (!string.IsNullOrEmpty(sLine))
                {
                    if (sLine.IndexOf("Note:") != -1 || sLine.IndexOf("note:") != -1)
                    {
                        break;
                    }
                    miniList.Add(sLine);
                    continue;
                }
                else
                {
                    item = new TagElementItem();
                    item.Parse(miniList);
                    items.Add(item);
                    miniList = new List<string>();
                }
            }
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue().Trim();
                if (string.IsNullOrEmpty(sLine))
                    break;
                Note += " " + sLine;
            }
        }
    }

    [XmlRoot("Item")]
    public class TagElementItem
    {
        [XmlAttribute("Position")]
        public string Position { get; set; }
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Rep")]
        public string Rep { get; set; }
        [XmlAttribute("Count")]
        public string Count { get; set; }
        public void Parse(List<string> sInputLines)
        {
            if (sInputLines.Count == 0)
                return;
            Queue<string> lineQ = new Queue<string>(sInputLines.ToArray());
            string sLine = lineQ.Dequeue();
            string sLine2 = "";
            Position = sLine.Substring(0, 3);
            sLine = sLine.Substring(3).Trim();
            Id = sLine.Substring(0, 4);
            sLine = sLine.Substring(4).Trim();
            if (lineQ.Count > 0)
                sLine2 = lineQ.Dequeue();
            if (sLine2.IndexOf("          ") == 0)
                sLine += " " + sLine2.Trim();
            int iPos = sLine.LastIndexOf(" ");
            Count = sLine.Substring(iPos + 1);
            sLine = sLine.Substring(0, iPos).Trim();
            if (Count[0] == 'a' || Count[0] == 'n')
            {
                iPos = sLine.LastIndexOf(" ");
                Count = sLine.Substring(iPos + 1);
                sLine = sLine.Substring(0, iPos).Trim();
            }
            Rep = sLine.Substring(sLine.Length - 1);
            Name = sLine.Substring(0, sLine.Length - 1).Trim();
        }
    } 
}
