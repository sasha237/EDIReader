using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public static class Separators
    {
        public static char ComponentDataElementSeparator = ':';
        public static char DataElementSeparator = '+';
        public static char ReleaseIndicator = '?';
        public static char DecimalNotification = '.';
        public static char SegmentTerminator = '\''; 
    }
}
