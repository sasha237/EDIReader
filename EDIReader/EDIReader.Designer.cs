namespace EDIReader
{
    partial class EDIReader
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
            this.OpenButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CheckDictionarybutton = new System.Windows.Forms.Button();
            this.ResultlistView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenButton.Location = new System.Drawing.Point(12, 49);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(715, 27);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open file";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CheckDictionarybutton
            // 
            this.CheckDictionarybutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckDictionarybutton.Location = new System.Drawing.Point(12, 12);
            this.CheckDictionarybutton.Name = "CheckDictionarybutton";
            this.CheckDictionarybutton.Size = new System.Drawing.Size(715, 27);
            this.CheckDictionarybutton.TabIndex = 1;
            this.CheckDictionarybutton.Text = "Check dictionary";
            this.CheckDictionarybutton.UseVisualStyleBackColor = true;
            this.CheckDictionarybutton.Click += new System.EventHandler(this.CheckDictionarybutton_Click);
            // 
            // ResultlistView
            // 
            this.ResultlistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultlistView.AutoArrange = false;
            this.ResultlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader6});
            this.ResultlistView.FullRowSelect = true;
            this.ResultlistView.GridLines = true;
            this.ResultlistView.Location = new System.Drawing.Point(12, 82);
            this.ResultlistView.Name = "ResultlistView";
            this.ResultlistView.Size = new System.Drawing.Size(715, 433);
            this.ResultlistView.TabIndex = 2;
            this.ResultlistView.UseCompatibleStateImageBehavior = false;
            this.ResultlistView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value Id";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Id";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Value Name";
            this.columnHeader5.Width = 110;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Value Description";
            this.columnHeader6.Width = 150;
            // 
            // EDIReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 527);
            this.Controls.Add(this.ResultlistView);
            this.Controls.Add(this.CheckDictionarybutton);
            this.Controls.Add(this.OpenButton);
            this.Name = "EDIReader";
            this.Text = "EDIReader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button CheckDictionarybutton;
        private System.Windows.Forms.ListView ResultlistView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

