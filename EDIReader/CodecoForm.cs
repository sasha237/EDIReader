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
    partial class CodecoForm : Form
    {
        public CodecoForm()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            Match mth = Regex.Match(@"a:b:c", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
            int ic = mth.Groups.Count;

            mth = Regex.Match(@"a:b", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
            ic = mth.Groups.Count;
            mth = Regex.Match(@"a::c", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
            ic = mth.Groups.Count;
            mth = Regex.Match(@":b:c", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
            ic = mth.Groups.Count;
            mth = Regex.Match(@"a", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
            ic = mth.Groups.Count;
            mth = Regex.Match(@"::c", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
            ic = mth.Groups.Count;
            mth = Regex.Match(@":b:", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
            ic = mth.Groups.Count;
            mth = Regex.Match(@"a::", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
            ic = mth.Groups.Count;
            mth = Regex.Match(@":b", @"^(\w+)(:\w*){0,1}(:\w*){0,1}");
            ic = mth.Groups.Count;


            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string sFileName = openFileDialog1.FileName;

//             string str = TemplateDictionary.Instance().GetMessageRegexp(sFileName);
// 
//             CODECOItem item = new CODECOItem(System.IO.File.ReadAllText(@"C:\Program Files (x86)\Baplie\Sample1.Edi"), str);
        }

        private void CheckDictionarybutton_Click(object sender, EventArgs e)
        {
            TemplateDictionary.Instance().LoadAll();
        }
    }
}
