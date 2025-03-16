using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ABC_IDE
{
    public partial class IDE : Form
    {
        // aici e safe de lucrat. Suntem in ABC_IDE_2.0
        List <Buffer> buffers = new List <Buffer>();
        int currentBuffer = 0;
        List <Button> navigationBtns = new List<Button>();

        AeButton openFileBtn = new AeButton();
        AeButton closeFileBtn = new AeButton();
        AeButton runBtn = new AeButton();
        AeButton saveBtn = new AeButton();
        AeButton newfileBtn = new AeButton();

        public IDE(string _path)
        {
            InitializeComponent();
            Fullscreen(this);

            navigationBtns.Add(file1Btn);
            navigationBtns.Add(file2Btn);
            navigationBtns.Add(file3Btn);
            navigationBtns.Add(file4Btn);
            navigationBtns.Add(file5Btn);

            var newBuffer = new Buffer(_path, 0);
            buffers.Add(newBuffer);
            currentBuffer = -1;
            UpdateBuffer(0, false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Coding_Area.LoadFile(path, RichTextBoxStreamType.PlainText);
            Coding_Area.Text = buffers[currentBuffer].content;
            Coding_Area.Font = new Font("Fira Code", 12);


            int x_AeButton = Coding_Area.Left / 6;
            int y_AeButton = 10;

            int y_open = y_AeButton + newfileBtn.Width / 2;
            int y_run = y_open + openFileBtn.Width / 2;
            int y_save = y_run + runBtn.Width / 2;
            int y_close = y_save + closeFileBtn.Width / 2;

            newfileBtn.Location = new Point(x_AeButton, y_AeButton);
            newfileBtn.Parent = this;
            newfileBtn.Parent = this;
            newfileBtn.Text = "New file";
            newfileBtn.Click += newfileBtn_Click;

            openFileBtn.Location = new Point(x_AeButton, y_open);
            openFileBtn.Parent = this;
            openFileBtn.Text = "Open file";
            openFileBtn.Click += openFileBtn_Click;

            runBtn.Location = new Point(x_AeButton, y_run);
            runBtn.Parent = this;
            runBtn.Text = "Run";
            runBtn.Click += runBtn_Click;

            saveBtn.Location = new Point(x_AeButton, y_save);
            saveBtn.Parent = this;
            saveBtn.Text = "Save file";
            saveBtn.Click += saveBtn_Click;

            closeFileBtn.Location = new Point(x_AeButton, y_close);
            closeFileBtn.Parent = this;
            closeFileBtn.Text = "Close file";
            closeFileBtn.Click += closeFileBtn_Click;

            
        }

        
        static void Fullscreen(IDE ide)
        {
            if (ide.WindowState == FormWindowState.Maximized)
                ide.WindowState = FormWindowState.Normal;
            else if (ide.WindowState == FormWindowState.Normal)
                ide.WindowState = FormWindowState.Maximized;
        }


        private void Compile()
        {
            SaveFile();
            if (currentBuffer == -1) return;
            using (MemoryStream rStream = new MemoryStream())
            {
                if (inputTextBox.Text.Length > 0 && inputTextBox.Text[inputTextBox.Text.Length - 1] != '\n')
                    inputTextBox.AppendText(Environment.NewLine);

                inputTextBox.SaveFile(rStream, RichTextBoxStreamType.PlainText);
                rStream.Position = 0;
                using (StreamReader reader = new StreamReader(rStream))
                {
                    using (MemoryStream wStream = new MemoryStream())
                    {
                        using (StreamWriter writer = new StreamWriter(wStream))
                        {
                            FunLang pr = new FunLang(Coding_Area.Text, writer, writer, reader);
                            try
                            {
                                pr.Evaluate();
                            }
                            catch (InvalidFunProgram e)
                            {
                                writer.WriteLine(pr.ReportErrorFromToken(e.tok));
                                writer.Write(e.Message);
                                
                            }

                            writer.Flush();
                            wStream.Position = 0;
                            outputTextBox.Clear();
                            outputTextBox.LoadFile(wStream, RichTextBoxStreamType.PlainText);
                        }
                    }
                }
            }
        }

        private void OpenFile()
        {
            string path;
            OpenFileDialog opentext = new OpenFileDialog();
            if (opentext.ShowDialog() == DialogResult.OK)
            {
                path = opentext.FileName;
                bool opened = false;
                foreach (var buf in buffers)
                {
                    if (buf.path == path)
                    {
                        opened = true;
                        MessageBox.Show("Already opened");
                        break;
                    }
                }
                if (!opened)
                {
                    var newBuffer = new Buffer(path, buffers.Count);
                    buffers.Add(newBuffer);
                    UpdateBuffer(buffers.Count - 1, true);
                    navigationBtns[buffers.Count - 1].FlatAppearance.BorderSize = 1;
                }
            }
        }

        public void CreateNewFile()
        {
            string path = "";
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

                var newBuffer = new Buffer(path, buffers.Count);
                buffers.Add(newBuffer);
                UpdateBuffer(buffers.Count - 1, true);
                navigationBtns[buffers.Count - 1].FlatAppearance.BorderSize = 1;
            }
        }

        public void SaveFile()
        {
            if (currentBuffer == -1) return;
            buffers[currentBuffer].content = Coding_Area.Text;
            using (Stream stream = File.Open(buffers[currentBuffer].path, FileMode.Truncate))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(buffers[currentBuffer].content);
                }
            }
        }


        void newfileBtn_Click(object sender, EventArgs e)
        {
            CreateNewFile();
        }

        void runBtn_Click(object sender, EventArgs e)
        {
            Compile();
        }

        void closeFileBtn_Click(object sender, EventArgs e)
        {
            foreach (var buf in buffers)
            {
                if (buf.navigationBtnIndex > buffers[currentBuffer].navigationBtnIndex)
                {
                    buf.navigationBtnIndex--;
                }
            }
            if (buffers.Count > 1)
            {
                if (currentBuffer == 0)
                {
                    UpdateBuffer(currentBuffer + 1, false);
                    buffers.RemoveAt(currentBuffer - 1);
                    currentBuffer--;
                    UpdateNavigationButtons();
                }
                else
                {
                    UpdateBuffer(currentBuffer - 1, false);
                    buffers.RemoveAt(currentBuffer + 1);
                    UpdateNavigationButtons();
                }
            }
            else if (buffers.Count == 1)
            {
                UpdateBuffer(currentBuffer - 1, false);
                buffers.RemoveAt(0);
                UpdateNavigationButtons();
            }
            
        }

        void openFileBtn_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFile();
        }



        private void HighlightString(string searchString, Color highlightColor)
        {
            int initialPos = Coding_Area.SelectionStart;
            int index = Coding_Area.Text.IndexOf(searchString);
            while (index >= 0)
            {
                Coding_Area.SelectionStart = index;
                Coding_Area.SelectionLength = searchString.Length;
                Coding_Area.SelectionColor = highlightColor;
        
                index = Coding_Area.Text.IndexOf(searchString, index + 1);
            }

            Coding_Area.DeselectAll();
            Coding_Area.Select(initialPos, 0);
        }

        private void UpdateBuffer(int newBuffer, bool save) {
            if (currentBuffer != -1 && save)
            {
                buffers[currentBuffer].content = Coding_Area.Text;
            }
            currentBuffer = newBuffer;
            if (currentBuffer != -1)
            {
                Coding_Area.Text = buffers[currentBuffer].content;
            }
            else {
                Coding_Area.Text = "";
            }
            HighlightString("define", Color.Yellow);
            UpdateNavigationButtons();

        }

        private void changeButton(int btnIndex) {
            for (int index = 0; index < buffers.Count; ++index )
            {
                if (buffers[index].navigationBtnIndex == btnIndex)
                {
                    UpdateBuffer(index, true);
                    break;
                }
            }
        }

        private void UpdateNavigationButtons() {
            foreach (var btn in navigationBtns)
            {
                btn.Visible = false;
            }
            foreach (var buf in buffers)
            {
                navigationBtns[buf.navigationBtnIndex].Text = buf.name;
                navigationBtns[buf.navigationBtnIndex].Visible = true;
                navigationBtns[buf.navigationBtnIndex].FlatAppearance.BorderSize = 0;
            }
            if (currentBuffer != -1)
            { navigationBtns[buffers[currentBuffer].navigationBtnIndex].FlatAppearance.BorderSize = 1; }
        }


        private void file1Btn_Click(object sender, EventArgs e)
        {
            changeButton(0);
            navigationBtns[0].FlatAppearance.BorderSize = 1;
        }

        private void file2Btn_Click(object sender, EventArgs e)
        {
            changeButton(1);
            navigationBtns[1].FlatAppearance.BorderSize = 1;
        }

        private void file3Btn_Click(object sender, EventArgs e)
        {
            changeButton(2);
            navigationBtns[2].FlatAppearance.BorderSize = 1;
        }

        private void file4Btn_Click(object sender, EventArgs e)
        {
            changeButton(3);
            navigationBtns[3].FlatAppearance.BorderSize = 1;
        }

        private void file5Btn_Click(object sender, EventArgs e)
        {
            changeButton(4);
            navigationBtns[4].FlatAppearance.BorderSize = 1;
        }



        private bool CTRL_S(object sender, KeyEventArgs e)
        {
            return (e.KeyData == (Keys.Control | Keys.S));
        }

        private bool CTRL_O(object sender, KeyEventArgs e)
        {
            return (e.KeyData == (Keys.Control | Keys.O));
        }

        private bool CTRL_N(object sender, KeyEventArgs e)
        {
            return (e.KeyData == (Keys.Control | Keys.N));
        }

        private bool F10(object sender, KeyEventArgs e)
        {
            return (e.KeyCode == Keys.F10);
        }
        
        private void Coding_Area_TextChanged(object sender, EventArgs e)
        {
            if (currentBuffer == -1) return;

            buffers[currentBuffer].content = Coding_Area.Text;

            int originalIndex = Coding_Area.SelectionStart;
            int originalLength = Coding_Area.SelectionLength;

            newfileBtn.Focus();

            Coding_Area.SelectAll();
            Coding_Area.SelectionColor = Color.White;

            ColorRegex("if|then|else", Color.Aqua);
            ColorRegex("define", Color.Magenta);
            ColorRegex("lambda|=>", Color.Cyan);

            ColorRegex(@"\$", Color.LightBlue);

            ColorRegex("\".*\"", Color.BlueViolet);

            ColorRegex(@"\(|\)", Color.Orange);

            ColorRegex("Tate|Covaci|Chis", Color.Gold);

            ColorRegex(@"/\*.*?\*/", Color.LimeGreen);

            Coding_Area.SelectionStart = originalIndex;
            Coding_Area.SelectionLength = originalLength;
            Coding_Area.SelectionColor = Color.White;

            // giving back the focus
            Coding_Area.Focus();
        }

        private void ColorRegex(string regex, Color color)
        {
            var matchRegex = new Regex(regex, RegexOptions.Multiline);
            foreach (Match match in matchRegex.Matches(Coding_Area.Text))
            {
                Coding_Area.Select(match.Index, match.Length);
                Coding_Area.SelectionColor = color;
            }
        }

        private void IDE_KeyDown(object sender, KeyEventArgs e)
        {
            if (CTRL_S(sender, e))
            {
                SaveFile();
            }

            if (CTRL_N(sender, e))
            {
                CreateNewFile();
            }

            if (CTRL_O(sender, e))
            {
                OpenFile();
            }

            if (F10(sender, e))
            {
                Compile();
            }
        
        }

        private void IDE_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
