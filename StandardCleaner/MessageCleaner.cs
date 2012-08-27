using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace StandardCleaner
{
    public class MessageCleaner
    {
        public static void Parse(string sFilePath)
        {
            string sWrongFiles = "";
            foreach (var el in System.IO.Directory.GetFiles(sFilePath))
            {
                string sFile = System.IO.File.ReadAllText(el);
                int iPos = sFile.LastIndexOf("00010");
                if (iPos == -1)
                {
                    sWrongFiles += Environment.NewLine + el;
                    continue;
                }
                sFile = sFile.Substring(iPos).Replace("\r", "\n").Replace("\n\n", "\n");
                string[] sLines = sFile.Split('\n');
                List<string> newLines = new List<string>();
                foreach (string sLine in sLines)
                {
                    if (string.IsNullOrEmpty(sLine))
                        continue;
                    if (sLine.IndexOfAny("0123456789".ToCharArray())!=0)
                        continue;
                    newLines.Add(sLine);
                }
                string result = string.Join(Environment.NewLine, newLines);
                iPos = el.LastIndexOf("\\");
                string sName = "";
                if (iPos != -1)
                {
                    sName = el.Substring(iPos + 1).Substring(0, 6);
                }
                MessageItemContainer con = new MessageItemContainer();
                con.Parse(sName, result);
                XmlSerializer s = new XmlSerializer(con.GetType());
                TextWriter fileStream = new StreamWriter(FileUtils.GetMessagePath(con.m_sName));
                s.Serialize(fileStream, con);
                fileStream.Close();
            }
//             if (!string.IsNullOrEmpty(sWrongFiles))
//             {
//                 sWrongFiles = "There are some files with wrong format" + sWrongFiles;
//                 MessageBox.Show(sWrongFiles);
//             }
        }
    }

}
