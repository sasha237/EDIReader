using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public class TemplateDictionary
    {
        private static TemplateDictionary instance;

        ElementTemplateDictionary m_els;
        TagTemplateDictionary m_tags;
        MessageTemplateDictionary m_mess;
        private TemplateDictionary()
        {
            m_els = new ElementTemplateDictionary();
            m_tags = new TagTemplateDictionary();
            m_mess = new MessageTemplateDictionary();
        }

        public static TemplateDictionary Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TemplateDictionary();
                }
                return instance;
            }
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
            string sFileName = @"templates\messages\" + sName + @".txt";
            if (!System.IO.File.Exists(sFileName))
                return "";
            if (string.IsNullOrEmpty(GetMessageDescription(sName)))
                return "";
            try
            {
                MessageItemContainer cod = new MessageItemContainer(System.IO.File.ReadAllText(sFileName));
                return cod.GetRegexString();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
    }
}
