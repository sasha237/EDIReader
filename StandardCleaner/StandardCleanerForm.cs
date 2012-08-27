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

        private void Folderbutton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;
            MessageCleaner.Parse(folderBrowserDialog1.SelectedPath);

        }


        private void Componentbutton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            ComponentCleaner.Parse(openFileDialog1.FileName);
        }

        private void Elementbutton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            ElementCleaner.Parse(openFileDialog1.FileName);
        }

        private void ExpandElementbutton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            ExpandElementCleaner.Parse(openFileDialog1.FileName);
        }

        private void SelectTagbutton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            TagCleaner.Parse(openFileDialog1.FileName);
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
            if (!CheckFile(sEDCD) ||
                !CheckFile(sIDCD) ||
                !CheckFile(sEDED) ||
                !CheckDir(sEDMD) ||
                !CheckDir(sIDMD) ||
                !CheckFile(sEDSD) ||
                !CheckFile(sIDSD) ||
                !CheckFile(sUNCL))
                return;
            MessageCleaner.Parse(sEDMD);
            MessageCleaner.Parse(sIDMD);
            ComponentCleaner.Parse(sEDCD);
            ComponentCleaner.Parse(sIDCD);
            ElementCleaner.Parse(sEDED);
            ExpandElementCleaner.Parse(sUNCL);
            TagCleaner.Parse(sEDSD);
            TagCleaner.Parse(sIDSD);
            MessageBox.Show("Done!");
        }

        private void Folderbutton_Click_1(object sender, EventArgs e)
        {

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
    }
}
