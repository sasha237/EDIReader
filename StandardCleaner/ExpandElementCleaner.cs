using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace StandardCleaner
{
    public class ExpandElementCleaner
    {
        public static void Parse(string sFilePath)
        {
            string[] sLines = System.IO.File.ReadAllLines(sFilePath);
            ExpandElementItem item = null;
            List<ElementValue> values = new List<ElementValue>();
            XmlSerializer s = null;
            TextWriter fileStream = null;
            string sId = "";
            string sName = "";
            string sDescr = "";
            string sRepr = "";
            string sValueId = "";
            string sValueName = "";
            string sValueDescr = "";
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
                string sLine = lineQ.Dequeue();
                if (lineQ.Count > 0 && lineQ.Peek().Trim().IndexOf("Note:") != -1)
                    continue;
                if (string.IsNullOrEmpty(sLine))
                {
                    if (!string.IsNullOrEmpty(sValueId)&&
                        !string.IsNullOrEmpty(sValueName)&&
                        !string.IsNullOrEmpty(sValueDescr))
                    {
                        values.Add(new ElementValue(sValueId.Trim(), sValueName.Trim(), sValueDescr.Trim()));
                    }
                    sValueId = "";
                    sValueName = "";
                    sValueDescr = "";
                    continue;
                }
                sLine = sLine.Substring(1);
                if (sLine[0] == '-')
                {
                    item = new ExpandElementItem(sId, sName, sDescr, sRepr);
                    if (!string.IsNullOrEmpty(sValueId) &&
                        !string.IsNullOrEmpty(sValueName) &&
                        !string.IsNullOrEmpty(sValueDescr))
                    {
                        values.Add(new ElementValue(sValueId.Trim(), sValueName.Trim(), sValueDescr.Trim()));
                    }
                    item.m_values = values;
                    sValueId = "";
                    sValueName = "";
                    sValueDescr = "";
                    s = new XmlSerializer(item.GetType());
                    fileStream = new StreamWriter(FileUtils.GetComponentPath(item.m_Id));
                    s.Serialize(fileStream, item);
                    fileStream.Close();
                    values = new List<ElementValue>();
                    sId = "";
                    sName = "";
                    sDescr = "";
                    sRepr = "";
                    continue;
                }
                if (string.IsNullOrEmpty(sId) ||
                    string.IsNullOrEmpty(sName) ||
                    string.IsNullOrEmpty(sDescr) ||
                    string.IsNullOrEmpty(sRepr))
                {
                    sLine = sLine.Trim();
                    if (string.IsNullOrEmpty(sLine))
                        continue;
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
                        continue;
                    }
                    sDescr += " " + sLine;
                }
                else
                {
                    iPos = sLine.IndexOf("             ");
                    sLine = sLine.Trim();
                    if (iPos == 0||sLine.IndexOf("Note:")!=-1)
                    {
                        sValueDescr += " " + sLine;
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(sValueId))
                        {
                            iPos = sLine.IndexOf(" ");
                            sValueId = sLine.Substring(0, iPos).Trim();
                            sValueName = sLine.Substring(iPos).Trim();
                        }
                        else
                        {
                            sValueName += " " + sLine;
                        }
                    }
                }

            }
            item = new ExpandElementItem(sId, sName, sDescr, sRepr);
            if (!string.IsNullOrEmpty(sValueId) &&
                !string.IsNullOrEmpty(sValueName) &&
                !string.IsNullOrEmpty(sValueDescr))
            {
                values.Add(new ElementValue(sValueId.Trim(), sValueName.Trim(), sValueDescr.Trim()));
            }
            s = new XmlSerializer(item.GetType());
            fileStream = new StreamWriter(FileUtils.GetComponentPath(item.m_Id));
            s.Serialize(fileStream, item);
            fileStream.Close();
        }
    }
}
