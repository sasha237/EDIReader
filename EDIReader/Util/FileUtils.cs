using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EDIReader
{
    public static class FileUtils
    {
        const string tags = "tags";
        const string messages = "messages";
        const string components = "components";
        const string elements = "elements";
        const string templates = "templates";
        public static string GetPath(string sId)
        {
            if (string.IsNullOrEmpty(sId))
                return "";
            if (sId.Length == 3)
                return GetTagPath(sId);
            if (sId.Length == 6)
                return GetMessagePath(sId);
            if (sId.IndexOfAny("0123456789".ToCharArray()) == 0)
                return GetElementPath(sId);
            return GetComponentPath(sId);
        }
        static string GetTagPath(string sId)
        {
            return GetFullPath(sId, tags);
        }
        static string GetMessagePath(string sId)
        {
            return GetFullPath(sId, messages);
        }
        static string GetComponentPath(string sId)
        {
            return GetFullPath(sId, components);
        }
        static string GetElementPath(string sId)
        {
            return GetFullPath(sId, elements);
        }
        static string GetFullPath(string sId, string sSubFolder)
        {
            string sPath = templates + "\\" + sSubFolder + "\\";
            if (!Directory.Exists(sPath))
                Directory.CreateDirectory(sPath);
            return sPath + "_" +sId + ".xml";
        }

        public static List<string> GetAllFilesByType(string sType)
        {
            List<string> files = new List<string>();

            foreach (string el in System.IO.Directory.GetFiles(templates + "\\" + sType))
            {
                files.Add(el);
            }
            return files;
        }

        public static Dictionary<System.Type,List<string>> GetAllFiles()
        {
            Dictionary<System.Type, List<string>> dict = new Dictionary<System.Type, List<string>>();

            dict.Add(typeof(TagItem), GetAllFilesByType(tags));
            dict.Add(typeof(MessageItemContainer), GetAllFilesByType(messages));
            dict.Add(typeof(ComponentItem), GetAllFilesByType(components));
            dict.Add(typeof(ElementItem), GetAllFilesByType(elements));
            return dict;
        }
    }
}
