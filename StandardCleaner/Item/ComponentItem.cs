using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StandardCleaner
{
    [XmlRoot("Root")]
    public class ComponentItem
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }
        [XmlAttribute("Note")]
        public string Note { get; set; }
        [XmlElement("Element")]
        public List<ComponentItemLine> Lines {get;set;}
        public void Parse(string[] sInputLines)
        {
            Lines = new List<ComponentItemLine>();
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
            int iPos = sLine.IndexOf(" ");
            Id = sLine.Substring(0, iPos);
            Name = sLine.Substring(iPos).Trim();
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue().Trim();
                if (string.IsNullOrEmpty(sLine))
                    continue;
                break;
            }
            if (string.IsNullOrEmpty(sLine))
                return;
            iPos = sLine.IndexOf("Desc:");
            if (iPos == -1)
                return;
            Description = sLine.Substring(iPos + "Desc:".Length).Trim();
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue();
                if (string.IsNullOrEmpty(sLine))
                    break;
                if (sLine.IndexOf("            ") != -1)
                {
                    Description += " " + sLine.Trim();
                    continue;
                }
                break;
            }
            List<string> miniList = new List<string>();
            ComponentItemLine item = null;
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue();
                if (string.IsNullOrEmpty(sLine))
                    break;
                iPos = sLine.IndexOf("            ");
                
                if (iPos==0||(iPos != 0 && miniList.Count==0))
                {
                    miniList.Add(sLine);
                    continue;
                }
                else
                {
                    item = new ComponentItemLine();
                    item.Parse(miniList);
                    Lines.Add(item);
                    miniList = new List<string>();
                    miniList.Add(sLine);
                }
            }
            item = new ComponentItemLine();
            item.Parse(miniList);
            Lines.Add(item);
            miniList = new List<string>();
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue().Trim();
                if (string.IsNullOrEmpty(sLine))
                    break;
                if (sLine.IndexOf("Note:") != -1)
                    continue;
                Note += " " + sLine;
            }
        }
    } 
    [XmlRoot("Element")]
    public class ComponentItemLine
    {
        [XmlAttribute("Position")]
        public string Line { get; set; }
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
            string sLine = lineQ.Dequeue().Trim();
            string sLine2 = "";
            if (lineQ.Count > 0)
                sLine2 = lineQ.Dequeue().Trim();
            sLine += " " + sLine2;
            Line = sLine.Substring(0, 3);
            sLine = sLine.Substring(3).Trim();
            Id = sLine.Substring(0, 4);
            sLine = sLine.Substring(4).Trim();
            int iPos = sLine.LastIndexOf(" ");
            Count = sLine.Substring(iPos+1);
            sLine = sLine.Substring(0, iPos).Trim();
            Rep = sLine.Substring(sLine.Length - 1);
            Name = sLine.Substring(0, sLine.Length - 1).Trim();
            while (lineQ.Count > 0)
                Name += " " + lineQ.Dequeue().Trim();
        }
    }
}
