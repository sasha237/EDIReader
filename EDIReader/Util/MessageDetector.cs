using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public static class MessageDetector
    {
        public static string Parse(string[] sLines)
        {
            string sFormat = "";
            if (sLines.Length == 0)
                return sFormat;
            foreach (var el in sLines)
            {
                if (string.IsNullOrEmpty(el))
                    continue;
                if (el.Substring(0, 3) == "UNH")
                {
                    //TODO: Parse and return value
                    break;
                }
            }
            return sFormat;
        }
    }
}
