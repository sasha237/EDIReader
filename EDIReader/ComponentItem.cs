using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EDIReader
{
    [XmlRoot("Root")]
    public class ComponentItem : BaseItem
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
        public List<ComponenItemLine> Lines {get;set;}
        public override string GetRegexString()
        {
            return "";
        }
    }
    [XmlRoot("Element")]
    public class ComponenItemLine : BaseItem
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
        public override string GetRegexString()
        {
            return "";
        }
    }
}
