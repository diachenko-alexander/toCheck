using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string searchedFile;
        
        private List<string> GetDrives()
        {
            List <string> list = new List<string>();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                list.Add(string.Format(drive.RootDirectory.FullName));
            }

            return list;
        }


        private bool SearchFile (string fileName, string directory)
        {

            DirectoryInfo dir = new DirectoryInfo(directory);

            if (!dir.Exists)
            {
                return false;
            }

            FileInfo[] fileInfo = null;
            try
            {
                fileInfo = dir.GetFiles(fileName);
            }
            catch (Exception)
            {
                return false;
            }

            if (fileInfo.Length == 0)
            {
                DirectoryInfo[] dirInfo = dir.GetDirectories();

                if (dirInfo.Length == 0)
                {
                    return false;
                }

                foreach (var item in dirInfo)
                {
                    if (item.Attributes.Equals(FileAttributes.System | FileAttributes.Hidden | FileAttributes.Directory))
                    {
                        continue;
                    }

                    if (SearchFile(fileName, item.FullName))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                searchedFile = fileInfo[0].FullName;
                return true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var drives = GetDrives();
            foreach (var drive in drives)
            {
                if (SearchFile(textBox1.Text, drive))
                {
                    richTextBox1.Text = searchedFile;
                    break;
                } else
                {
                    searchedFile = null;
                    richTextBox1.Text = "No such file";
                }
            }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (searchedFile != null)
            {
                richTextBox1.Text = File.ReadAllText(searchedFile);
            } else
            {
                richTextBox1.Text = "No file searched";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream source = File.OpenRead(searchedFile);
            string fileName = Path.GetFileNameWithoutExtension(searchedFile);
            string directory = Path.GetDirectoryName(searchedFile);
            string newArchive = directory + @"\" + fileName + ".zip";

            FileStream destination = File.Create(newArchive);
            GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);
            int theByte = source.ReadByte();
            while (theByte != -1)
            {
                compressor.WriteByte((byte)theByte);
                theByte = source.ReadByte();
            }
            compressor.Close();
            MessageBox.Show("Archive created");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
