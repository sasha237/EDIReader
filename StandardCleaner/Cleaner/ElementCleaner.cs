using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace StandardCleaner
{
    public class ElementCleaner
    {
        public static void Parse(string sFilePath)
        {
            string[] sLines = System.IO.File.ReadAllLines(sFilePath);
            string sId = "";
            string sName = "";
            string sDescr = "";
            string sRepr = "";
            int iPos;
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
            while (lineQ.Count > 0)
            {
                string sLine = lineQ.Dequeue().Trim();
                if (string.IsNullOrEmpty(sLine))
                    continue;
                if (sLine[0] == '-')
                {
                    CreateFile(sId, sName, sDescr, sRepr);

                    sId = "";
                    sName = "";
                    sDescr = "";
                    sRepr = "";
                    continue;
                }
                sLine = sLine.Replace("[B]", "");
                sLine = sLine.Replace("[I]", "");
                sLine = sLine.Replace("[C]", "");
                if (sLine.IndexOfAny("0123456789".ToCharArray()) == 0)
                {
                    iPos = sLine.IndexOf(" ");
                    sId = sLine.Substring(0, iPos);
                    sName = sLine.Substring(iPos).Trim();
                    continue;
                }
                iPos = sLine.IndexOf("Desc:");
                if (iPos == 0)
                {
                    sDescr = sLine.Substring("Desc:".Length).Trim();
                    continue;
                }
                iPos = sLine.IndexOf("Repr:");
                if (iPos == 0)
                {
                    sRepr = sLine.Substring("Repr:".Length).Trim();
                    while (lineQ.Count > 0 && (string.IsNullOrEmpty(lineQ.Peek()) || !string.IsNullOrEmpty(lineQ.Peek()) && lineQ.Peek()[0] != '-'))
                        lineQ.Dequeue();
                    continue;
                }
                sDescr += " " + sLine;
            }
            CreateFile(sId, sName, sDescr, sRepr);
        }
        static void CreateFile(string sId, string sName, string sDescr, string sRepr)
        {
            ElementItem item = null;
            XmlSerializer s = null;
            TextWriter fileStream = null;
            item = new ElementItem(sId, sName, sDescr, sRepr);
            s = new XmlSerializer(item.GetType());
            fileStream = new StreamWriter(FileUtils.GetPath(item.Id));
            s.Serialize(fileStream, item);
            fileStream.Close();
        }
    }
}
