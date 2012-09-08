namespace EDIReader
{
    partial class CodecoForm
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
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(12, 49);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(276, 27);
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
            this.CheckDictionarybutton.Location = new System.Drawing.Point(12, 12);
            this.CheckDictionarybutton.Name = "CheckDictionarybutton";
            this.CheckDictionarybutton.Size = new System.Drawing.Size(276, 27);
            this.CheckDictionarybutton.TabIndex = 1;
            this.CheckDictionarybutton.Text = "Check dictionary";
            this.CheckDictionarybutton.UseVisualStyleBackColor = true;
            this.CheckDictionarybutton.Click += new System.EventHandler(this.CheckDictionarybutton_Click);
            // 
            // CodecoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 88);
            this.Controls.Add(this.CheckDictionarybutton);
            this.Controls.Add(this.OpenButton);
            this.Name = "CodecoForm";
            this.Text = "CodecoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button CheckDictionarybutton;
    }
}

