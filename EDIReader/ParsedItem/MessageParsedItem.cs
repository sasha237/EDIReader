using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public class MessageParsedItem : BaseParsedItem
    {
        public override bool Parse(string sInputLine, string sName)
        {
            if (string.IsNullOrEmpty(sInputLine.Trim()))
                return false;
            SeparatorsDetector.Parse(sInputLine);
            string[] sLines = sInputLine.Split(Separators.SegmentTerminator);
            if (sLines.Length == 0)
                return false;
            _Id = sName;
            foreach (string sLine in sLines)
            {
                TagParsedItem item = new TagParsedItem();
                if (item.Parse(sLine, ""))
                    childs.Add(item);
                if (item._Id == "UNH")
                {
                    foreach (var cmp in item.childs)
                    {
                        if(cmp._Id=="S009")
                        {
                            foreach (var el in cmp.childs)
                            {
                                if (el._Id == "0065")
                                {
                                    _Id = el._ValueId;
                                    _Name = el._ValueName;
                                    _Description = el._ValueDescription;
                                }
                            }
                        }
                    }
                }
            }
            return !string.IsNullOrEmpty(_Id);
        }
    }
}
