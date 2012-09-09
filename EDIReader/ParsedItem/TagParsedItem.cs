using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public class TagParsedItem : BaseParsedItem
    {
        public override bool Parse(string sInputLine, string sName)
        {
            if (string.IsNullOrEmpty(sInputLine.Trim()))
                return false;
            Queue<string> sLines = new Queue<string>(sInputLine.Split(Separators.DataElementSeparator).ToArray());
            if (sLines.Count == 0)
                return false;
            _Id = sName;
            _Id = sLines.Dequeue();
            TagItem itemTree = TemplateDictionary.Instance().GetItem(_Id) as TagItem;
            _Id = itemTree.Id;
            _Name = itemTree.Name;
            _Description = itemTree.Function;
            Queue<TagElementItem> qItems = new Queue<TagElementItem>(itemTree.items.ToArray());
            foreach (string sLine in sLines)
            {
                TagElementItem elementItem = qItems.Dequeue();
                BaseParsedItem item = null;
                if(elementItem.Id.IndexOfAny("0123456789".ToCharArray())==0)
                    item = new ElementParsedItem();
                else
                    item = new ComponentParsedItem();
                if (item.Parse(sLine,elementItem.Id))
                    childs.Add(item);
            }
            return !string.IsNullOrEmpty(_Id);
        }
    }
}
