using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StandardCleaner
{
    public static class FileUtils
    {
        public static string GetTagPath(string sId)
        {
            return GetPath(sId, "tags");
        }
        public static string GetMessagePath(string sId)
        {
            return GetPath(sId, "messages");
        }
        public static string GetComponentPath(string sId)
        {
            return GetPath(sId, "components");
        }
        public static string GetElementPath(string sId)
        {
            return GetPath(sId, "elements");
        }
        static string GetPath(string sId, string sSubFolder)
        {
            string sPath = "templates\\"+sSubFolder+"\\";
            if (!Directory.Exists(sPath))
                Directory.CreateDirectory(sPath);
            return sPath + "_" +sId + ".xml";
        }
    }
}
