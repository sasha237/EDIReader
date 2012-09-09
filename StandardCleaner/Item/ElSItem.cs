using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StandardCleaner
{ 
    [XmlRoot("Root")]
    public class ElSItem
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }
        [XmlAttribute("Count")]
        public string Count { get; set; }
        [XmlElement("Value")]
        public List<ELSValue> values { get; set; }

        public void Parse(List<string> sInputLines)
        {
            values = new List<ELSValue>();

            if (sInputLines.Count == 0)
                return;
            Queue<string> lineQ = new Queue<string>(sInputLines.ToArray());
            string sLine = "";
            string sLine2 = "";

            sLine = lineQ.Dequeue().Trim();
            Id = sLine.Substring(0, 4);
            Name = sLine.Substring(4).Trim();

            sLine = lineQ.Dequeue().Trim();
            int iPos = sLine.IndexOf("Repr:");
            if (iPos == -1)
                return;
            Count = sLine.Substring(iPos + "Repr:".Length).Trim();

            sLine = lineQ.Dequeue().Trim();
            iPos = sLine.IndexOf("Desc:");
            if (iPos == -1)
                return;
            Description = sLine.Substring(iPos + "Desc:".Length).Trim();

            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue().Trim();
                if (string.IsNullOrEmpty(sLine))
                    continue;
                if (lineQ.Count > 0)
                    sLine2 = lineQ.Dequeue().Trim();
                else 
                    break;
                iPos = sLine.IndexOf(" ");
                values.Add(new ELSValue(sLine.Substring(0, iPos), sLine.Substring(iPos).Trim(), sLine2));
            }
        }
    }
    [XmlRoot("Value")]
    public class ELSValue
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }

        public ELSValue()
        {
            Id = null;
            Name = null;
            Description = null;
        }
        public ELSValue(string sId, string sName, string sDescr)
        {
            // TODO: Complete member initialization
            Id = sId;
            Name = sName;
            Description = sDescr;
        }
    }
}
