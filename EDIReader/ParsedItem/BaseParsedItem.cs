using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDIReader
{
    public abstract class BaseParsedItem
    {
        public List<BaseParsedItem> childs;
        public string _Id;
        public string _Name;
        public string _Description;
        public string _ValueId;
        public string _ValueName;
        public string _ValueDescription;
        public BaseParsedItem()
        {
            childs = new List<BaseParsedItem>();
        }
        public abstract bool Parse(string sInputLine, string sName);
        public virtual void FillList(ref List<BaseParsedItem> items)
        {
            items.Add(this);
            foreach (var el in childs)
            {
                el.FillList(ref items);
            }
        }
    }
}
