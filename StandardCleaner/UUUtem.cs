using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace StandardCleaner
{
    public class UUUtem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Function { get; set; }
        public string Note { get; set; }
        public List<UUUElementItem> items;
        public void Parse(List<string> sInputLines)
        {
            items = new List<UUUElementItem>();
            if (sInputLines.Count == 0)
                return;
            Queue<string> lineQ = new Queue<string>(sInputLines.ToArray());
            string sLine = "";
            int iPos;
            if (lineQ.Count == 0)
                return;
            lineQ.Dequeue();
            if (lineQ.Count == 0)
                return;
            sLine = lineQ.Dequeue();
            Id = sLine.Substring(0, 3).Trim();
            Name = sLine.Substring(3).Trim();
            if (lineQ.Count == 0)
                return;
            lineQ.Dequeue();
            if (lineQ.Count == 0)
                return;
            sLine = lineQ.Dequeue();
            if (lineQ.Count == 0)
                return;
            iPos = sLine.IndexOf("Function:");
            if (iPos == -1)
                return;
            Function = sLine.Substring(iPos + "Function:".Length).Trim();
            lineQ.Dequeue();
            if (lineQ.Count == 0)
                return;
            List<string> miniList = new List<string>();
            while (lineQ.Count > 0)
            {
                sLine = lineQ.Dequeue().Trim();
                if (string.IsNullOrEmpty(sLine))
                {
                    UUUElementItem item = new UUUElementItem();
                    item.Parse(miniList);
                    items.Add(item);
                    miniList = new List<string>();
                }
                else
                {
                    miniList.Add(sLine);
                }
            }
        }
        public UUUTagItem GetTagItem()
        {
            UUUTagItem item = new UUUTagItem();
            item.Id = Id;
            item.Name = Name;
            item.Function = Function;
            item.Note = "";
            foreach (var el in items)
            {
                UUUTagElementItem child = new UUUTagElementItem();
                child.Id = el.Id;
                child.Name = el.Name;
                child.Rep = el.Rep;
                child.Count = el.Count1;
                child.Position = el.Position;
                item.items.Add(child);
            }
            return item;
        }
        public List<UUUComponentItem> GetComponentItem()
        {
            List<UUUComponentItem> itemsList = new List<UUUComponentItem>();
            foreach (var el in items)
            {
                UUUComponentItem item = new UUUComponentItem();
                item.Id = el.Id;
                item.Name = el.Name;
                item.Description = "";
                item.Note = "";
                if (item.Id[0] != 'S')
                    item.Count = el.Count;
                itemsList.Add(item);
                foreach (var elChild in el.items)
                {
                    UUUComponenItemLine child = new UUUComponenItemLine();
                    child.Id = elChild.Id;
                    child.Name = elChild.Name;
                    child.Rep = elChild.Rep;
                    child.Line = elChild.Position;
                    child.Count = elChild.Count;
                    item.Lines.Add(child);
                }
            }
            return itemsList;
        }
    }


    [XmlRoot("Root")]
    public class UUUComponentItem
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }
        [XmlAttribute("Note")]
        public string Note { get; set; }
        [XmlAttribute("Count")]
        public string Count { get; set; }
        [XmlElement("Element")]
        public List<UUUComponenItemLine> Lines { get; set; }
        public UUUComponentItem()
        {
            Id = Name = Description = Note = Count = "";
            Lines = new List<UUUComponenItemLine>();
        }
    }
    [XmlRoot("Element")]
    public class UUUComponenItemLine
    {
        [XmlAttribute("Position")]
        public string Line { get; set; }
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Rep")]
        public string Rep { get; set; }
        [XmlAttribute("Count")]
        public string Count { get; set; }
        public UUUComponenItemLine()
        {
            Line = Id = Name = Rep = Count = "";
        }
    }



    public class UUUElementItem
    {
        public string Position { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Rep { get; set; }
        public string Count { get; set; }
        public string Count1 { get; set; }
        public List<UUUElementItem> items;
        public void Parse(List<string> sInputLines)
        {
            items = new List<UUUElementItem>();
            if (sInputLines.Count == 0)
                return;
            Queue<string> lineQ = new Queue<string>(sInputLines.ToArray());
            string sLine = "";
            int iPos;
            sLine = lineQ.Dequeue();
            if (sLine[3] == ' ')
            {
                Position = sLine.Substring(0, 3).Trim();
                sLine = sLine.Substring(3).Trim();
            }
            Id = sLine.Substring(0, 4).Trim();
            sLine = sLine.Substring(4).Trim();
            if (Id[0] == 'S')
            {
                List<string> miniList = new List<string>();

                iPos = sLine.LastIndexOf(" ");
                Count1 = sLine.Substring(iPos).Trim();
                sLine = sLine.Substring(0, iPos).Trim();

                iPos = sLine.LastIndexOf(" ");
                Rep = sLine.Substring(iPos).Trim();
                sLine = sLine.Substring(0, iPos).Trim();
                Name = sLine;
                int iNum = 10;
                while (lineQ.Count > 0)
                {
                    sLine = lineQ.Dequeue().Trim();
                    miniList.Add(sLine);
                    UUUElementItem item = new UUUElementItem();
                    item.Parse(miniList);
                    item.Position = iNum.ToString("D3");
                    items.Add(item);
                    miniList = new List<string>();
                    iNum += 10;
                }
            }
            else
            {
                iPos = sLine.LastIndexOf(" ");
                Count = sLine.Substring(iPos).Trim();
                sLine = sLine.Substring(0, iPos).Trim();

                if (!string.IsNullOrEmpty(Position))
                {
                    iPos = sLine.LastIndexOf(" ");
                    Count1 = sLine.Substring(iPos).Trim();
                    sLine = sLine.Substring(0, iPos).Trim();
                }


                iPos = sLine.LastIndexOf(" ");
                Rep = sLine.Substring(iPos).Trim();
                sLine = sLine.Substring(0, iPos).Trim();
                Name = sLine;
            }
        }
    }

    [XmlRoot("Root")]
    public class UUUTagItem
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Function")]
        public string Function { get; set; }
        [XmlAttribute("Note")]
        public string Note { get; set; }
        [XmlElement("Item")]
        public List<UUUTagElementItem> items;
        public UUUTagItem()
        {
            Id = Name = Function = Note = "";
            items = new List<UUUTagElementItem>();
        }
    }

    [XmlRoot("Item")]
    public class UUUTagElementItem
    {
        [XmlAttribute("Position")]
        public string Position { get; set; }
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Rep")]
        public string Rep { get; set; }
        [XmlAttribute("Count")]
        public string Count { get; set; }
        public UUUTagElementItem()
        {
            Position = Id = Name = Rep = Count;
        }
    }
}
