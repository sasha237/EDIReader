using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public class ElementParsedItem : BaseParsedItem
    {
        public override bool Parse(string sInputLine, string sName)
        {
            if (string.IsNullOrEmpty(sInputLine.Trim()))
                return false;
            ElementItem item = TemplateDictionary.Instance().GetItem(sName) as ElementItem;
            _Id = item.Id;
            _Name = item.Name;
            _Description = item.Description;
            _ValueId = sInputLine;
            foreach (var el in item.values)
            {
                if (el.Id == sInputLine)
                {
                    _ValueId = el.Id;
                    _ValueName = el.Name;
                    _ValueDescription = el.Description;
                    break;
                }
            }
            return true;
        }
    }
}
