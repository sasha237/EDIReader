using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace EDIReader
{
    public class TemplateDictionary
    {
        private static TemplateDictionary instance;

        ElementTemplateDictionary m_els;
        TagTemplateDictionary m_tags;
        MessageTemplateDictionary m_mess;
        Dictionary<string, BaseItem> m_dict;
        private TemplateDictionary()
        {
            m_els = new ElementTemplateDictionary();
            m_tags = new TagTemplateDictionary();
            m_mess = new MessageTemplateDictionary();
            m_dict = new Dictionary<string, BaseItem>();
        }

        public static TemplateDictionary Instance()
        {
            if (instance == null)
            {
                instance = new TemplateDictionary();
            }
            return instance;
        }
        public string GetElementDescription(string sName)
        {
            return m_els.GetDescr(sName);
        }
        public string GetTagDescription(string sName)
        {
            return m_tags.GetDescr(sName);
        }
        public string GetMessageDescription(string sName)
        {
            return m_mess.GetDescr(sName);
        }
        public string GetMessageRegexp(string sName)
        {
            BaseItem item = null;
            if (m_dict.TryGetValue(sName, out item))
            {
                return item.GetRegexString();
            }
            string sFileName = @"templates\messages\_" + sName + @".txt";
            if (!System.IO.File.Exists(sFileName))
                return "";
            if (string.IsNullOrEmpty(GetMessageDescription(sName)))
                return "";
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MessageItemContainer));
                StreamReader reader = new StreamReader(sFileName);
                item = (BaseItem)serializer.Deserialize(reader);
                reader.Close();
                m_dict.Add(sName, item);
                return item.GetRegexString();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
        public string GetComponentRegexp(string sName)
        {
            BaseItem item = null;
            if (m_dict.TryGetValue(sName, out item))
            {
                return item.GetRegexString();
            }
            string sFileName = @"templates\components\_" + sName + @".txt";
            if (!System.IO.File.Exists(sFileName))
                return "";
            if (string.IsNullOrEmpty(GetMessageDescription(sName)))
                return "";
            try
            {
                XmlSerializer serializer = null;
                switch (sName[0])
                {
                    case 'E':
                        new XmlSerializer(typeof(ComponentItem));
                        break;
                    case 'C':
                        new XmlSerializer(typeof(ComponentItem));
                        break;
                    case 'S':
                        new XmlSerializer(typeof(ComponentItem));
                        break;
                    default:
                        new XmlSerializer(typeof(ExpandElementItem));
                        break;
                }
                    
                StreamReader reader = new StreamReader(sFileName);
                item = (BaseItem)serializer.Deserialize(reader);
                reader.Close();
                m_dict.Add(sName, item);
                return item.GetRegexString();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
        public string GetTagRegexp(string sName)
        {
            BaseItem item = null;
            if (m_dict.TryGetValue(sName, out item))
            {
                return item.GetRegexString();
            }
            string sFileName = @"templates\tags\_" + sName + @".txt";
            if (!System.IO.File.Exists(sFileName))
                return "";
            if (string.IsNullOrEmpty(GetMessageDescription(sName)))
                return "";
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TagItem));
                StreamReader reader = new StreamReader(sFileName);
                item = (BaseItem)serializer.Deserialize(reader);
                reader.Close();
                m_dict.Add(sName, item);
                return item.GetRegexString();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
    }
}
