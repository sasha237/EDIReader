using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StandardCleaner
{
    [XmlRoot("Root")]
    public class ElementItem
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }
        [XmlAttribute("Count")]
        public string Count { get; set; }

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
    }
}
