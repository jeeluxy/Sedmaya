using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        FileData data;
        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeHandlers(FileData data)
        {
            data.DidUpdateContent += OnContentUpdated;
        }

        private void OnContentUpdated(object sender, string e)
        {
            richTextBox1.Text = e;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (data == null)
            {
                data = new FileData();
                InitializeHandlers(data);
                richTextBox1.Text = "";
            }
            data.Content = richTextBox1.Text;

        }


        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data = new FileData();
            richTextBox1.Text = "";
            InitializeHandlers(data);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data == null)
            {
                data = new FileData();
                InitializeHandlers(data);
            }
            openFileDialog1.FileName = data.file.Name;
            openFileDialog1.ShowDialog(this);

        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (openFileDialog1.FilterIndex == 1)
                richTextBox1.LoadFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            if (openFileDialog1.FilterIndex == 2)
                richTextBox1.LoadFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            data.IsNotSaveOnce = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            if (data.IsNotSaveOnce || sender.Equals(saveasToolStripMenuItem))
            {
                saveFileDialog1.FileName = data.file.Name;
                saveFileDialog1.ShowDialog(this);
            }
            else
            {
                if (saveFileDialog1.FilterIndex == 1)
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                if (saveFileDialog1.FilterIndex == 2)
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.FilterIndex == 1)
                richTextBox1.SaveFile(saveFileDialog1.FileName,RichTextBoxStreamType.PlainText);
            if (saveFileDialog1.FilterIndex == 2)
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            data.IsNotSaveOnce = false;
        }

        

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region TODO: Изменения не сохранены
            //if (data.IsNotSaveOnce == true)
            //{
            //    var result = MessageBox.Show("Изменения не сохрпнены \nСохранить", "Warning", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes)
            //    {
            //        saveFileDialog1.FileName = data.file.Name;
            //        saveFileDialog1.ShowDialog(this);
            //        data.IsNotSaveOnce = false;
            //    }
            //}
            //else
            //{
            //    data.SaveFile(saveFileDialog1.FileName);
            //}
            #endregion
            Application.Exit();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object tag;
            try
            {                tag = (sender as ToolStripMenuItem).Tag;
            }
            catch(NullReferenceException)
            {
                tag = (sender as ToolStripButton).Tag;
            }
            switch (tag)
            {
                case "stepBack":
                    richTextBox1.Undo();
                    break;
                case "stepForward":
                    richTextBox1.Redo();
                    break;
                case "cut":
                    richTextBox1.Cut();
                    break;
                case "copy":
                    richTextBox1.Copy();
                    break;
                case "paste":
                    richTextBox1.Paste();
                    break;
                case "selectAll":
                    richTextBox1.SelectAll();
                    break;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog(this);
            richTextBox1.Font = fontDialog1.Font;

        }
    }
}
