using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public class BaseParsedItem
    {
        List<Tuple<string, string>> values;
        List<BaseParsedItem> childs;
        BaseParsedItem parent;
        public BaseParsedItem()
        {
            values = new List<Tuple<string, string>>();
            childs = new List<BaseParsedItem>();
            parent = null;
        }
    }
}
