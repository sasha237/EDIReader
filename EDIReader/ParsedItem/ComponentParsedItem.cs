using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public class ComponentParsedItem : BaseParsedItem
    {
        public override bool Parse(string sInputLine, string sName)
        {
            if (string.IsNullOrEmpty(sInputLine.Trim()))
                return false;
            string[] sLines = sInputLine.Split(Separators.ComponentDataElementSeparator);
            if (sLines.Length == 0)
                return false;
            _Id = sName;
            ComponentItem itemTree = TemplateDictionary.Instance().GetItem(_Id) as ComponentItem;
            _Id = itemTree.Id;
            _Name = itemTree.Name;
            _Description = itemTree.Description;
            Queue<ComponentItemLine> qItems = new Queue<ComponentItemLine>(itemTree.Lines.ToArray());
            foreach (string sLine in sLines)
            {
                ComponentItemLine componentItem = qItems.Dequeue();
                ElementParsedItem item = new ElementParsedItem();
                if (item.Parse(sLine, componentItem.Id))
                    childs.Add(item);
            }
            return !string.IsNullOrEmpty(_Id);
        }
    }
}
