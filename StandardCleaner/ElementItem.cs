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
        public string m_Id { get; set; }
        [XmlAttribute("Name")]
        public string m_Name { get; set; }
        [XmlAttribute("Description")]
        public string m_Description { get; set; }
        [XmlAttribute("Count")]
        public string m_Count { get; set; }

        public ElementItem()
        {
            m_Id = null;
            m_Name = null;
            m_Description = null;
            m_Count = null;
        }
        public ElementItem(string id, string name, string descr, string count)
        {
            m_Id = id;
            m_Name = name;
            m_Description = descr;
            m_Count = count;
        }
    }
}
