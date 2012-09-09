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

        Dictionary<string, BaseItem> dict;
        private TemplateDictionary()
        {
            dict = new Dictionary<string, BaseItem>();
        }

        public static TemplateDictionary Instance()
        {
            if (instance == null)
            {
                instance = new TemplateDictionary();
            }
            return instance;
        }
        BaseItem LoadFromFile(string sFileName, System.Type itemType)
        {
            BaseItem item = null;
            if (System.IO.File.Exists(sFileName))
            {
                XmlSerializer serializer = new XmlSerializer(itemType);
                StreamReader reader = new StreamReader(sFileName);
                item = (BaseItem)serializer.Deserialize(reader);
                reader.Close();
            }
            return item;
        }
        string GetItemRegexp(string sName, System.Type itemType)
        {
            BaseItem item = null;
            if (dict.TryGetValue(sName, out item))
            {
                return item.GetRegexString();
            }
            string sFileName = FileUtils.GetPath(sName);
            item = LoadFromFile(sFileName, itemType);
            
            dict.Add(sName, item);
            return item.GetRegexString();
        }
        public string GetItemRegexp(string sId)
        {
            if (string.IsNullOrEmpty(sId))
                return "";
            if (sId.Length == 3)
                return GetTagRegexp(sId);
            if (sId.Length == 6)
                return GetMessageRegexp(sId);
            if (sId.IndexOfAny("0123456789".ToCharArray()) == 0)
                return GetElementRegexp(sId);
            return GetComponentRegexp(sId);
        }
        public BaseItem GetItem(string sName)
        {
            BaseItem item = null;
            if (!dict.TryGetValue(sName, out item))
            {
                if (string.IsNullOrEmpty(sName))
                    return item;
                System.Type itemType = null;
                string sFileName = FileUtils.GetPath(sName);

                if (sName.Length == 3)
                    itemType = typeof(TagItem);
                else
                    if (sName.Length == 6)
                        itemType = typeof(MessageItem);
                    else
                        if (sName.IndexOfAny("0123456789".ToCharArray()) == 0)
                            itemType = typeof(ElementItem);
                        else
                            itemType = typeof(ComponentItem);
                item = LoadFromFile(sFileName, itemType);
                dict.Add(sName, item);
            }
            return item;
        }
        string GetMessageRegexp(string sName)
        {
            return GetItemRegexp(sName, typeof(MessageItemContainer));
        }
        string GetComponentRegexp(string sName)
        {
            return GetItemRegexp(sName, typeof(ComponentItem));
        }
        string GetTagRegexp(string sName)
        {
            return GetItemRegexp(sName, typeof(TagItem));
        }
        string GetElementRegexp(string sName)
        {
            return GetItemRegexp(sName, typeof(ElementItem));
        }
        public void LoadAll()
        {
            try
            {
                BaseItem bufItem = null;
                Dictionary<System.Type, List<string>> dictFiles = FileUtils.GetAllFiles();
                foreach (var el in dictFiles)
                {
                    foreach (var item in el.Value)
                    {
                        bufItem = LoadFromFile(item, el.Key);
                        dict.Add(bufItem.GetId(), bufItem);
                    }
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
