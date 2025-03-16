namespace ABC_IDE
{
    partial class IDE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDE));
            this.Coding_Area = new System.Windows.Forms.RichTextBox();
            this.inputTextBox = new System.Windows.Forms.RichTextBox();
            this.file1Btn = new System.Windows.Forms.Button();
            this.file2Btn = new System.Windows.Forms.Button();
            this.file3Btn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.file4Btn = new System.Windows.Forms.Button();
            this.file5Btn = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Coding_Area
            // 
            this.Coding_Area.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Coding_Area.BackColor = System.Drawing.Color.Black;
            this.Coding_Area.Font = new System.Drawing.Font("Fira Code Retina", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Coding_Area.ForeColor = System.Drawing.Color.White;
            this.Coding_Area.Location = new System.Drawing.Point(294, 49);
            this.Coding_Area.Name = "Coding_Area";
            this.Coding_Area.Size = new System.Drawing.Size(1019, 642);
            this.Coding_Area.TabIndex = 1;
            this.Coding_Area.Text = "";
            this.Coding_Area.TextChanged += new System.EventHandler(this.Coding_Area_TextChanged);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputTextBox.BackColor = System.Drawing.Color.Black;
            this.inputTextBox.Font = new System.Drawing.Font("Fira Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputTextBox.ForeColor = System.Drawing.Color.White;
            this.inputTextBox.Location = new System.Drawing.Point(0, 126);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(288, 245);
            this.inputTextBox.TabIndex = 3;
            this.inputTextBox.Text = "";
            // 
            // file1Btn
            // 
            this.file1Btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.file1Btn.FlatAppearance.BorderSize = 0;
            this.file1Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.file1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file1Btn.ForeColor = System.Drawing.Color.White;
            this.file1Btn.Location = new System.Drawing.Point(294, 12);
            this.file1Btn.Name = "file1Btn";
            this.file1Btn.Size = new System.Drawing.Size(199, 31);
            this.file1Btn.TabIndex = 7;
            this.file1Btn.Text = "File 1";
            this.file1Btn.UseVisualStyleBackColor = true;
            this.file1Btn.Click += new System.EventHandler(this.file1Btn_Click);
            // 
            // file2Btn
            // 
            this.file2Btn.FlatAppearance.BorderSize = 0;
            this.file2Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.file2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file2Btn.ForeColor = System.Drawing.Color.White;
            this.file2Btn.Location = new System.Drawing.Point(499, 12);
            this.file2Btn.Name = "file2Btn";
            this.file2Btn.Size = new System.Drawing.Size(199, 31);
            this.file2Btn.TabIndex = 8;
            this.file2Btn.Text = "File 2";
            this.file2Btn.UseVisualStyleBackColor = true;
            this.file2Btn.Click += new System.EventHandler(this.file2Btn_Click);
            // 
            // file3Btn
            // 
            this.file3Btn.FlatAppearance.BorderSize = 0;
            this.file3Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.file3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file3Btn.ForeColor = System.Drawing.Color.White;
            this.file3Btn.Location = new System.Drawing.Point(704, 12);
            this.file3Btn.Name = "file3Btn";
            this.file3Btn.Size = new System.Drawing.Size(199, 31);
            this.file3Btn.TabIndex = 9;
            this.file3Btn.Text = "File 3";
            this.file3Btn.UseVisualStyleBackColor = true;
            this.file3Btn.Click += new System.EventHandler(this.file3Btn_Click);
            // 
            // file4Btn
            // 
            this.file4Btn.FlatAppearance.BorderSize = 0;
            this.file4Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.file4Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file4Btn.ForeColor = System.Drawing.Color.White;
            this.file4Btn.Location = new System.Drawing.Point(909, 12);
            this.file4Btn.Name = "file4Btn";
            this.file4Btn.Size = new System.Drawing.Size(199, 31);
            this.file4Btn.TabIndex = 12;
            this.file4Btn.Text = "File 4";
            this.file4Btn.UseVisualStyleBackColor = true;
            this.file4Btn.Click += new System.EventHandler(this.file4Btn_Click);
            // 
            // file5Btn
            // 
            this.file5Btn.FlatAppearance.BorderSize = 0;
            this.file5Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.file5Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file5Btn.ForeColor = System.Drawing.Color.White;
            this.file5Btn.Location = new System.Drawing.Point(1114, 12);
            this.file5Btn.Name = "file5Btn";
            this.file5Btn.Size = new System.Drawing.Size(199, 31);
            this.file5Btn.TabIndex = 13;
            this.file5Btn.Text = "File 5";
            this.file5Btn.UseVisualStyleBackColor = true;
            this.file5Btn.Click += new System.EventHandler(this.file5Btn_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.outputTextBox.BackColor = System.Drawing.Color.Black;
            this.outputTextBox.Font = new System.Drawing.Font("Fira Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputTextBox.ForeColor = System.Drawing.Color.White;
            this.outputTextBox.Location = new System.Drawing.Point(0, 377);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(288, 314);
            this.outputTextBox.TabIndex = 15;
            this.outputTextBox.Text = "";
            // 
            // IDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1325, 687);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.file5Btn);
            this.Controls.Add(this.file4Btn);
            this.Controls.Add(this.file3Btn);
            this.Controls.Add(this.file2Btn);
            this.Controls.Add(this.file1Btn);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.Coding_Area);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "IDE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IDE_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IDE_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Coding_Area;
        private System.Windows.Forms.RichTextBox inputTextBox;
        private System.Windows.Forms.Button file1Btn;
        private System.Windows.Forms.Button file2Btn;
        private System.Windows.Forms.Button file3Btn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button file4Btn;
        private System.Windows.Forms.Button file5Btn;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;

    }
}

