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
            Separators.ComponentDataElementSeparator = sLine[0].ToString();
            Separators.DataElementSeparator = sLine[1].ToString();
            Separators.DecimalNotification = sLine[2].ToString();
            Separators.ReleaseIndicator = sLine[3].ToString();
            Separators.SegmentTerminator = sLine[5].ToString();
            CorrectString(ref Separators.ComponentDataElementSeparator);
            CorrectString(ref Separators.DataElementSeparator);
            CorrectString(ref Separators.DecimalNotification);
            CorrectString(ref Separators.ReleaseIndicator);
            CorrectString(ref Separators.SegmentTerminator);
        }
        static void CorrectString(ref string str)
        {
            str = str.Replace("+", "\\+");
        }
    }
}
