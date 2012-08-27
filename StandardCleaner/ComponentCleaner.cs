using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace StandardCleaner
{
    public class ComponentCleaner
    {
        public static void Parse(string sFilePath)
        {
            string[] sLines = System.IO.File.ReadAllLines(sFilePath);
            List<string> miniList = new List<string>();
            Queue<string> lineQ = new Queue<string>(sLines.ToArray());
            while (lineQ.Count > 0)
            {
                string sLine = lineQ.Peek().Trim();
                if (string.IsNullOrEmpty(sLine) || sLine.IndexOf("-----") != 0)
                {
                    lineQ.Dequeue();
                    continue;
                }
                lineQ.Dequeue();
                break;
            }
            while(lineQ.Count>0)
            {
                string sLine = lineQ.Dequeue();
                if (string.IsNullOrEmpty(sLine))
                {
                    miniList.Add(sLine);
                    continue;
                }
                if (sLine[0] != '-')
                {
                    miniList.Add(sLine);
                }
                else
                {
                    CreateFile(miniList.ToArray());
                    miniList = new List<string>();
                    continue;
                }
            }
            CreateFile(miniList.ToArray());
        }
        static void CreateFile(string[] sLines)
        {
            ComponentItem item = new ComponentItem();
            item.Parse(sLines);
            XmlSerializer s = new XmlSerializer(item.GetType());
            TextWriter fileStream = new StreamWriter(FileUtils.GetComponentPath(item.Id));
            s.Serialize(fileStream, item);
            fileStream.Close();
        }
    }
    
}
