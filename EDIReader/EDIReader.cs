using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

namespace EDIReader
{
    partial class EDIReader : Form
    {
        public EDIReader()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
//             Match mth = Regex.Match(@"a:b:c", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
//             int ic = mth.Groups.Count;
// 
//             mth = Regex.Match(@"a:b", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
//             ic = mth.Groups.Count;
//             mth = Regex.Match(@"a::c", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
//             ic = mth.Groups.Count;
//             mth = Regex.Match(@":b:c", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
//             ic = mth.Groups.Count;
//             mth = Regex.Match(@"a", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
//             ic = mth.Groups.Count;
//             mth = Regex.Match(@"::c", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
//             ic = mth.Groups.Count;
//             mth = Regex.Match(@":b:", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
//             ic = mth.Groups.Count;
//             mth = Regex.Match(@"a::", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
//             ic = mth.Groups.Count;
//             mth = Regex.Match(@":b", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
//             ic = mth.Groups.Count;
//             string str EDIReader= TemplateDictionary.Instance().GetMessageRegexp(sFileName);
// 
//             CODECOItem item = new CODECOItem(System.IO.File.ReadAllText(@"C:\Program Files (x86)\Baplie\Sample1.Edi"), str);


            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string sFileName = openFileDialog1.FileName;
            MessageParsedItem item = new MessageParsedItem();
            item.Parse(System.IO.File.ReadAllText(sFileName), "");
            ResultlistView.Items.Clear();
            List<BaseParsedItem> items = new List<BaseParsedItem>();
            item.FillList(ref items);
            foreach (var el in items)
            {
                ListViewItem listItem = ResultlistView.Items.Add(el._Id);
                listItem.SubItems.Add(el._Name);
                listItem.SubItems.Add(el._Description);
                listItem.SubItems.Add(el._ValueId);
                listItem.SubItems.Add(el._ValueName);
                listItem.SubItems.Add(el._ValueDescription);
            }
        }

        private void CheckDictionarybutton_Click(object sender, EventArgs e)
        {
            TemplateDictionary.Instance().LoadAll();
        }
    }
}
