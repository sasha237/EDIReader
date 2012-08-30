﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EDIReader
{
    [XmlRoot("Root")]
    public class TagItem : BaseItem
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
        public override string GetRegexString()
        {
            return "";
        }
    }

    [XmlRoot("Item")]
    public class TagElementItem : BaseItem
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
        public override string GetRegexString()
        {
            return "";
        }
    }
}
