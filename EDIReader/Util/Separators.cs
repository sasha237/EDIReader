using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public static class Separators
    {
        public static string ComponentDataElementSeparator = ":";
        public static string DataElementSeparator = "\\+";
        public static string ReleaseIndicator = "?";
        public static string DecimalNotification = ".";
        public static string SegmentTerminator = "'"; 
    }
}
