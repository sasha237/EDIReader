namespace StandardCleaner
{
    partial class StandardCleanerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Allbutton = new System.Windows.Forms.Button();
            this.FoldertextBox = new System.Windows.Forms.TextBox();
            this.Folderbutton = new System.Windows.Forms.Button();
            this.SuffixtextBox = new System.Windows.Forms.TextBox();
            this.Suffixlabel = new System.Windows.Forms.Label();
            this.Closebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Allbutton
            // 
            this.Allbutton.Location = new System.Drawing.Point(259, 48);
            this.Allbutton.Name = "Allbutton";
            this.Allbutton.Size = new System.Drawing.Size(106, 30);
            this.Allbutton.TabIndex = 2;
            this.Allbutton.Text = "Generate";
            this.Allbutton.UseVisualStyleBackColor = true;
            this.Allbutton.Click += new System.EventHandler(this.Allbutton_Click);
            // 
            // FoldertextBox
            // 
            this.FoldertextBox.Location = new System.Drawing.Point(12, 16);
            this.FoldertextBox.Name = "FoldertextBox";
            this.FoldertextBox.ReadOnly = true;
            this.FoldertextBox.Size = new System.Drawing.Size(465, 22);
            this.FoldertextBox.TabIndex = 0;
            this.FoldertextBox.TabStop = false;
            // 
            // Folderbutton
            // 
            this.Folderbutton.Location = new System.Drawing.Point(147, 48);
            this.Folderbutton.Name = "Folderbutton";
            this.Folderbutton.Size = new System.Drawing.Size(106, 30);
            this.Folderbutton.TabIndex = 0;
            this.Folderbutton.Text = "Select folder";
            this.Folderbutton.UseVisualStyleBackColor = true;
            // 
            // SuffixtextBox
            // 
            this.SuffixtextBox.Location = new System.Drawing.Point(67, 52);
            this.SuffixtextBox.Name = "SuffixtextBox";
            this.SuffixtextBox.Size = new System.Drawing.Size(74, 22);
            this.SuffixtextBox.TabIndex = 1;
            // 
            // Suffixlabel
            // 
            this.Suffixlabel.AutoSize = true;
            this.Suffixlabel.Location = new System.Drawing.Point(15, 55);
            this.Suffixlabel.Name = "Suffixlabel";
            this.Suffixlabel.Size = new System.Drawing.Size(46, 17);
            this.Suffixlabel.TabIndex = 0;
            this.Suffixlabel.Text = "Suffix:";
            // 
            // Closebutton
            // 
            this.Closebutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Closebutton.Location = new System.Drawing.Point(371, 48);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(106, 30);
            this.Closebutton.TabIndex = 3;
            this.Closebutton.Text = "Close";
            this.Closebutton.UseVisualStyleBackColor = true;
            this.Closebutton.Click += new System.EventHandler(this.Closebutton_Click);
            // 
            // StandardCleanerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Closebutton;
            this.ClientSize = new System.Drawing.Size(485, 91);
            this.Controls.Add(this.Closebutton);
            this.Controls.Add(this.Suffixlabel);
            this.Controls.Add(this.SuffixtextBox);
            this.Controls.Add(this.Folderbutton);
            this.Controls.Add(this.FoldertextBox);
            this.Controls.Add(this.Allbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StandardCleanerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Standard cleaner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Allbutton;
        private System.Windows.Forms.TextBox FoldertextBox;
        private System.Windows.Forms.Button Folderbutton;
        private System.Windows.Forms.TextBox SuffixtextBox;
        private System.Windows.Forms.Label Suffixlabel;
        private System.Windows.Forms.Button Closebutton;
    }
}

