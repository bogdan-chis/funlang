namespace ABC_IDE
{
    partial class Generic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generic));
            this.Title = new System.Windows.Forms.Label();
            this.Title_2 = new System.Windows.Forms.Label();
            this.Background_2 = new System.Windows.Forms.Label();
            this.Authors = new System.Windows.Forms.Label();
            this.Button_new_project = new System.Windows.Forms.Button();
            this.Button_open_file = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Fira Code SemiBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Title.Location = new System.Drawing.Point(315, 154);
            this.Title.MinimumSize = new System.Drawing.Size(189, 94);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(189, 94);
            this.Title.TabIndex = 0;
            this.Title.Text = "ABC\r\n";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Title_2
            // 
            this.Title_2.BackColor = System.Drawing.Color.Black;
            this.Title_2.Font = new System.Drawing.Font("Fira Code SemiBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Title_2.ForeColor = System.Drawing.Color.White;
            this.Title_2.Location = new System.Drawing.Point(315, 252);
            this.Title_2.MinimumSize = new System.Drawing.Size(189, 94);
            this.Title_2.Name = "Title_2";
            this.Title_2.Size = new System.Drawing.Size(189, 94);
            this.Title_2.TabIndex = 1;
            this.Title_2.Text = "IDE";
            this.Title_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Background_2
            // 
            this.Background_2.BackColor = System.Drawing.Color.Black;
            this.Background_2.Location = new System.Drawing.Point(0, 250);
            this.Background_2.Name = "Background_2";
            this.Background_2.Size = new System.Drawing.Size(774, 352);
            this.Background_2.TabIndex = 2;
            // 
            // Authors
            // 
            this.Authors.BackColor = System.Drawing.Color.Black;
            this.Authors.Font = new System.Drawing.Font("Fira Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Authors.ForeColor = System.Drawing.Color.White;
            this.Authors.Location = new System.Drawing.Point(205, 450);
            this.Authors.MinimumSize = new System.Drawing.Size(189, 94);
            this.Authors.Name = "Authors";
            this.Authors.Size = new System.Drawing.Size(436, 94);
            this.Authors.TabIndex = 3;
            this.Authors.Text = "{Andrei Covaci și Bogdan Chiș}\r\n{(C) 2023}\r\n";
            this.Authors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button_new_project
            // 
            this.Button_new_project.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Button_new_project.BackColor = System.Drawing.Color.Black;
            this.Button_new_project.FlatAppearance.BorderSize = 0;
            this.Button_new_project.Font = new System.Drawing.Font("Fira Code", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Button_new_project.ForeColor = System.Drawing.Color.White;
            this.Button_new_project.Location = new System.Drawing.Point(12, 385);
            this.Button_new_project.Name = "Button_new_project";
            this.Button_new_project.Size = new System.Drawing.Size(159, 39);
            this.Button_new_project.TabIndex = 4;
            this.Button_new_project.Text = "New project";
            this.Button_new_project.UseVisualStyleBackColor = false;
            this.Button_new_project.Click += new System.EventHandler(this.Button_new_project_Click);
            // 
            // Button_open_file
            // 
            this.Button_open_file.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Button_open_file.BackColor = System.Drawing.Color.Black;
            this.Button_open_file.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Button_open_file.Font = new System.Drawing.Font("Fira Code", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Button_open_file.ForeColor = System.Drawing.Color.White;
            this.Button_open_file.Location = new System.Drawing.Point(611, 385);
            this.Button_open_file.Name = "Button_open_file";
            this.Button_open_file.Size = new System.Drawing.Size(159, 39);
            this.Button_open_file.TabIndex = 5;
            this.Button_open_file.Text = "Open file";
            this.Button_open_file.UseVisualStyleBackColor = false;
            this.Button_open_file.Click += new System.EventHandler(this.Button_open_file_Click);
            // 
            // Generic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.Button_open_file);
            this.Controls.Add(this.Button_new_project);
            this.Controls.Add(this.Authors);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Title_2);
            this.Controls.Add(this.Background_2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Generic";
            this.Text = "Generic";
            this.Load += new System.EventHandler(this.Generic_Load);
            this.Resize += new System.EventHandler(this.Generic_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Title_2;
        private System.Windows.Forms.Label Background_2;
        private System.Windows.Forms.Label Authors;
        private System.Windows.Forms.Button Button_new_project;
        private System.Windows.Forms.Button Button_open_file;

    }
}