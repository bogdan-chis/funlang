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

namespace ABC_IDE
{
    public class Buffer
    {
        public string path;
        public string name;
        public string content;
        public int navigationBtnIndex;

        public Buffer(string _path, int _navigationBtnIndex)
        {
            path = _path;
            content = File.ReadAllText(path);
            string fullPath = Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar);
            name = Path.GetFileName(fullPath);
            navigationBtnIndex = _navigationBtnIndex;
        }
    }
}
