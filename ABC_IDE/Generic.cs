using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ABC_IDE
{
    public partial class Generic : Form
    {
        string path;

        public Generic()
        {
            InitializeComponent();
            CentreTitle();
            Fullscreen(this);
        }

        private void CentreTitle() {
            Title.Left = (this.Width - Title.Size.Width) / 2;
            Title.Top = this.Height / 2 - Title.Size.Height;

            Title_2.Left = (this.Width - Title_2.Size.Width) / 2 ;
            Title_2.Top = this.Height / 2 + 10;

            Background_2.Size = new Size(this.Width, this.Height / 2);
            Background_2.Top = this.Height / 2;
            Background_2.Left = 0;

            Authors.Top = this.Height - Authors.Size.Height - 30;
            Authors.Left = this.Width / 2 - Authors.Size.Width / 2;
        }

        private void Generic_Resize(object sender, EventArgs e)
        {
            CentreTitle();
        }

        static void Fullscreen(Generic generic)
        {
            if (generic.WindowState == FormWindowState.Maximized)
                generic.WindowState = FormWindowState.Normal;
            else if (generic.WindowState == FormWindowState.Normal)
                generic.WindowState = FormWindowState.Maximized;
        }

        private void ShowIDE()
        {
            IDE ide = new IDE(path);
            ide.Show();
            this.Visible = false;
        }

        public void Open_File()
        {
            OpenFileDialog opentext = new OpenFileDialog();
            if (opentext.ShowDialog() == DialogResult.OK)
            {
                path = opentext.FileName;// path e globala
            }
            else
            {
                path = "";
            }
        }

        public void Create_New_File()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TextFiles (*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = File.Create(saveFileDialog.FileName))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.WriteLine("/* Welcome to Funlang */");
                        writer.WriteLine("(");
                        writer.Write("\n)");
                    }
                }
                path = saveFileDialog.FileName;// path e globala

            }
            else {
                path = "";
            }
        }

        private void Button_open_file_Click(object sender, EventArgs e)
        {
            Open_File();
            if (File.Exists(path))
                ShowIDE();
        }

        private void Button_new_project_Click(object sender, EventArgs e)
        {
            Create_New_File();
            if (File.Exists(path))
                ShowIDE();
        }

        private void Generic_Load(object sender, EventArgs e)
        {

        }
    }
}
