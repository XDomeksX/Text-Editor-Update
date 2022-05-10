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

namespace Text_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTNopen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string text = File.ReadAllText(openFileDialog.FileName);
                RTB.Text = text;
            }
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"D:\Visual Studio\C#\Text Editor\mojaDatoteka.txt", RTB.Text);
        }

        private void BTNnew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            try
            {
                sfd.Filter = "Text File|*.txt";
                sfd.FileName = "";
                sfd.Title = "Save Text File";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    String path = sfd.FileName;
                    StreamWriter  writer = new StreamWriter(File.Create(path));
                    try
                    {
                        writer.Write(RTB.Text);
                    }
                    finally
                    {
                        writer.Dispose();
                        RTB.Clear();
                    }
                }
            }
            finally
            {
                sfd.Dispose();
            }
        }

        private void CMBtools_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = CMBtools.Text;

            if (option == "Bold")
            {
                Font new1, old1;
                old1 = RTB.SelectionFont;
                if (old1.Bold)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Bold);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Bold);

                RTB.SelectionFont = new1;
                RTB.Focus();
            }

            if (option == "Italic")
            {
                Font new1, old1;
                old1 = RTB.SelectionFont;
                if (old1.Italic)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Italic);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Italic);

                RTB.SelectionFont = new1;

                RTB.Focus();
            }

            if (option == "Underline")
            {
                Font new1, old1;
                old1 = RTB.SelectionFont;
                if (old1.Underline)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Underline);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Underline);

                RTB.SelectionFont = new1;
                RTB.Focus();
            }
        }

        private void CMBfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = CMBfile.Text;
            if(option == "Open")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string text = File.ReadAllText(openFileDialog.FileName);
                    RTB.Text = text;
                }
            }

            if (option == "Save")
            {
                File.WriteAllText(@"D:\Visual Studio\C#\Text Editor\JustSave.txt", RTB.Text);
            }

            if (option == "Save as")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                try
                {
                    sfd.Filter = "Text File|*.txt";
                    sfd.FileName = "";
                    sfd.Title = "Save Text File";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        String path = sfd.FileName;
                        StreamWriter writer = new StreamWriter(File.Create(path));
                        try
                        {
                            writer.Write(RTB.Text);
                        }
                        finally
                        {
                            writer.Dispose();
                            RTB.Clear();
                        }
                    }
                }
                finally
                {
                    sfd.Dispose();
                }
            }
        }
    }
}
