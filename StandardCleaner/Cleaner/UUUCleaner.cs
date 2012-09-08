using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace StandardCleaner
{
    public class UUUCleaner
    {
        public static void Parse(string sFilePath)
        {
            string[] sLines = System.IO.File.ReadAllLines(sFilePath);
            string sLine = "";
            List<string> miniList = new List<string>();
            Queue<string> lineQ = new Queue<string>(sLines.ToArray());
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Peek().Trim();
                if (sLine.IndexOf("-----") != -1)
                {
                    lineQ.Dequeue();
                    continue;
                }
                break;
            }
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue().Trim();
                if (sLine.IndexOf("-----------------------") != -1)
                {
                    CreateFile(miniList);
                    miniList = new List<string>();
                    continue;
                }
                miniList.Add(sLine);
            }
            CreateFile(miniList);
        }
        static void CreateFile(List<string> miniList)
        {
            UUUtem item = new UUUtem();
            item.Parse(miniList);

            XmlSerializer s = null;
            TextWriter fileStream = null;
            UUUTagItem tagItem = item.GetTagItem();
            s = new XmlSerializer(tagItem.GetType());
            fileStream = new StreamWriter(FileUtils.GetPath(tagItem.Id));
            s.Serialize(fileStream, tagItem);
            fileStream.Close();
            List<UUUComponentItem> components = item.GetComponentItem();
            foreach (var el in components)
            {
                s = new XmlSerializer(el.GetType());
                fileStream = new StreamWriter(FileUtils.GetPath(el.Id));
                s.Serialize(fileStream, el);
                fileStream.Close();
            }
        }
    }
}
