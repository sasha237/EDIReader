using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EDIReader
{
    [XmlRoot("Root")]
    public class ElementItem : BaseItem
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
        public List<ElementValue> values { get; set; }
        public ElementItem()
        {
            Id = null;
            Name = null;
            Description = null;
            Count = null;
        }
        public ElementItem(string id, string name, string descr, string count)
        {
            Id = id;
            Name = name;
            Description = descr;
            Count = count;
        }
        public override string GetRegexString()
        {
            /*
             * a4
             * an4
             * n4
             * a..4
             * an..4
             * n..4
             */
            string sPre = "";
            string sCount = "";
            bool bMust = false;
            int iPos = Count.IndexOf("..");
            if (iPos != 0)
            {
                sPre = Count.Substring(0, iPos).Trim('.');
                sCount = Count.Substring(iPos + "..".Length).Trim('.');
            }
            else
            {
                iPos = Count.IndexOfAny("0123456789".ToCharArray());
                sPre = Count.Substring(0, iPos);
                sCount = Count.Substring(iPos);
                bMust = true;
            }

            StringBuilder str = new StringBuilder();

            if (sPre == "an" || sPre == "a")
                str.Append("[\\w\\s]");
            else
                str.Append("\\d");
            if (bMust)
            {
                str.AppendFormat("{{{0}}}", sCount);
            }
            else
                str.AppendFormat("{{0,{0}}}", sCount);
            return str.ToString();
        }
        public override string GetId()
        {
            return Id;
        }
    }
    [XmlRoot("Value")]
    public class ElementValue : BaseItem
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }

        public ElementValue()
        {
            Id = null;
            Name = null;
            Description = null;
        }
        public ElementValue(string sId, string sName, string sDescr)
        {
            // TODO: Complete member initialization
            Id = sId;
            Name = sName;
            Description = sDescr;
        }
        public override string GetRegexString()
        {
            return "";
        }
        public override string GetId()
        {
            return Id;
        }
    }
}
