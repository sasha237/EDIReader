using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;


namespace StandardCleaner
{
    public class ELSCleaner
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
                if (string.IsNullOrEmpty(sLine) || sLine.IndexOf("-----") != -1)
                {
                    lineQ.Dequeue();
                    continue;
                }
                break;
            }
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue().Trim();
                if (string.IsNullOrEmpty(sLine))
                    continue;
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
            ElSItem item = new ElSItem();
            item.Parse(miniList);

            XmlSerializer s = null;
            TextWriter fileStream = null;
            s = new XmlSerializer(item.GetType());
            fileStream = new StreamWriter(FileUtils.GetPath(item.Id));
            s.Serialize(fileStream, item);
            fileStream.Close();
        }

    }
}
