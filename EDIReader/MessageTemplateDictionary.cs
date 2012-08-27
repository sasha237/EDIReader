﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public class MessageTemplateDictionary
    {
        Dictionary<string, string> m_dict;
        public MessageTemplateDictionary()
        {
            m_dict = new Dictionary<string, string>();
            Load();
        }
        void Load()
        {
            string[] sLines = System.IO.File.ReadAllLines(@"templates\messages\_dictionary.txt");
            foreach (var el in sLines)
            {
                string sName = el.Substring(0, 6);
                string sDescr = el.Substring(6).Trim();
                m_dict.Add(sName, sDescr);
            }
        }
        public string GetDescr(string sName)
        {
            string sDescr;
            m_dict.TryGetValue(sName, out sDescr);
            return sName;
        }
    }
}