using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StandardCleaner
{ 
    [XmlRoot("Root")]
    public class ExpandElementItem
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
        public ExpandElementItem()
        {
            Id = null;
            Name = null;
            Description = null;
            Count = null;
        }
        public ExpandElementItem(string id, string name, string descr, string count)
        {
            Id = id;
            Name = name;
            Description = descr;
            Count = count;
        }
    }
    [XmlRoot("Value")]
    public class ElementValue
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
    }
}
