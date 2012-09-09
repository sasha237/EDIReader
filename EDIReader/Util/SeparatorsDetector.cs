using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public static class SeparatorsDetector
    {
        public static void Parse(string sLine)
        {
            if (sLine.IndexOf("UNA") != 0)
                return;
            sLine = sLine.Substring(3);
            if (sLine.Length != 6)
                return;
            Separators.ComponentDataElementSeparator = sLine[0];
            Separators.DataElementSeparator = sLine[1];
            Separators.DecimalNotification = sLine[2];
            Separators.ReleaseIndicator = sLine[3];
            Separators.SegmentTerminator = sLine[5];
        }
        public static string CorrectString(string str)
        {
            return str.Replace("+", "\\+");
        }
    }
}
