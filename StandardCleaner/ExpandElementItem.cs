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
        public string m_Id { get; set; }
        [XmlAttribute("Name")]
        public string m_Name { get; set; }
        [XmlAttribute("Description")]
        public string m_Description { get; set; }
        [XmlAttribute("Count")]
        public string m_Count { get; set; }
        [XmlElement("Value")]
        public List<ElementValue> m_values { get; set; }
        public ExpandElementItem()
        {
            m_Id = null;
            m_Name = null;
            m_Description = null;
            m_Count = null;
        }
        public ExpandElementItem(string id, string name, string descr, string count)
        {
            m_Id = id;
            m_Name = name;
            m_Description = descr;
            m_Count = count;
        }
    }
    [XmlRoot("Value")]
    public class ElementValue
    {
        [XmlAttribute("Id")]
        public string m_Id { get; set; }
        [XmlAttribute("Name")]
        public string m_Name { get; set; }
        [XmlAttribute("Description")]
        public string m_Description { get; set; }

        public ElementValue()
        {
            m_Id = null;
            m_Name = null;
            m_Description = null;
        }
        public ElementValue(string sId, string sName, string sDescr)
        {
            // TODO: Complete member initialization
            m_Id = sId;
            m_Name = sName;
            m_Description = sDescr;
        }
    }
}
