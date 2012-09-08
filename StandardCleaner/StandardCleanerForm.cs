using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StandardCleaner
{
    public partial class StandardCleanerForm : Form
    {
        public StandardCleanerForm()
        {
            InitializeComponent();
        }

        private void Allbutton_Click(object sender, EventArgs e)
        {
            string sRootPath = FoldertextBox.Text;
            if (string.IsNullOrEmpty(sRootPath))
            {
                MessageBox.Show("You should select folder!");
                return;
            }
            if (!System.IO.Directory.Exists(sRootPath))
            {
                MessageBox.Show("Selected folder does not exists!");
                return;
            }
            string suffix = SuffixtextBox.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(suffix))
            {
                MessageBox.Show("You should provide suffix of files");
                return;
            }
            string sEDCD = sRootPath + "\\EDCD\\EDCD." + suffix;
            string sIDCD = sRootPath + "\\IDCD\\IDCD." + suffix;
            string sEDED = sRootPath + "\\EDED\\EDED." + suffix;
            string sEDMD = sRootPath + "\\EDMD";
            string sIDMD = sRootPath + "\\IDMD";
            string sEDSD = sRootPath + "\\EDSD\\EDSD." + suffix;
            string sIDSD = sRootPath + "\\IDSD\\IDSD." + suffix;
            string sUNCL = sRootPath + "\\UNCL\\UNCL." + suffix;
            string sELS = sRootPath + "\\ELS." + suffix;
            string sUUU = sRootPath + "\\UUU." + suffix;
            if (!CheckFile(sEDCD) ||
                !CheckFile(sIDCD) ||
                !CheckFile(sEDED) ||
                !CheckDir(sEDMD) ||
                !CheckDir(sIDMD) ||
                !CheckFile(sEDSD) ||
                !CheckFile(sIDSD) ||
                !CheckFile(sUNCL) ||
                !CheckFile(sELS) ||
                !CheckFile(sUUU))
                return;
            MessageCleaner.Parse(sEDMD);
            MessageCleaner.Parse(sIDMD);
            ComponentCleaner.Parse(sEDCD);
            ComponentCleaner.Parse(sIDCD);
            ElementCleaner.Parse(sEDED);
            ExpandElementCleaner.Parse(sUNCL);
            TagCleaner.Parse(sEDSD);
            TagCleaner.Parse(sIDSD);
            UUUCleaner.Parse(sUUU);
            ELSCleaner.Parse(sELS);
            MessageBox.Show("Done!");
        }

        private bool CheckFile(string sPath)
        {
            if (!System.IO.File.Exists(sPath))
            {
                MessageBox.Show("File not exists:" + Environment.NewLine + sPath);
                return false;
            }
            return true;
        }
        private bool CheckDir(string sPath)
        {
            if (!System.IO.Directory.Exists(sPath))
            {
                MessageBox.Show("Directory not exists:" + Environment.NewLine + sPath);
                return false;
            }
            return true;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Folderbutton_Click(object sender, EventArgs e)
        {
            if (SelectfolderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            FoldertextBox.Text = SelectfolderBrowserDialog.SelectedPath.TrimEnd('\\');
            SuffixtextBox.Text = FoldertextBox.Text.Substring(FoldertextBox.Text.Length - 3);
        }

    }
}
