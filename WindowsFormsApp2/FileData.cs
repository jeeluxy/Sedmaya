using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class FileData
    {
        public FileInfo file;
        public string Content;
        public bool IsNotSaveOnce = true;

        public event EventHandler<string> DidUpdateContent;
        public FileData()
        {
            file = new FileInfo("Unnamed");
            Content = "";
        }

        public FileData(string filename)
        {
            file = new FileInfo(filename);
            Content = file.OpenText().ReadToEnd();
        }

        //public void SaveFile(string path)
        //{
        //    StreamWriter sw = new StreamWriter(path);
        //    sw.Write(Content);
        //    sw.Close();
        //}
        //public void Load(string path)
        //{
        //        IsNotSaveOnce = false;
        //        StreamReader sr = new StreamReader(path);
        //        Content = sr.ReadToEnd();
        //        DidUpdateContent?.Invoke(this, Content);
            
        //}
    }
}
