using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BGIScrViewer;

namespace BGIScrViewer
{
    public partial class MainForm : Form
    {

        public static string WorkPath, DisplayedPath, DisplayedName;
        public static int cp;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form mc = new MassConvert();
            mc.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WorkPath = Application.StartupPath;
            listBox1.SelectedIndex = 0;         //default using Shift-JIS
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var opf = new OpenFileDialog();
            opf.CheckFileExists = true;
            opf.CheckPathExists = true;
            opf.Multiselect = false;
            opf.DefaultExt = "所有文件(*.*)|*.*";
            opf.InitialDirectory = WorkPath;

            var re_opf = opf.ShowDialog();
            if (re_opf == DialogResult.OK)
            {
                DisplayedPath = opf.FileName;
                DisplayedName = opf.SafeFileName;
                opf.Dispose();
                label1.Text = "当前文件：" + DisplayedPath;
                MainForm.ActiveForm.Text = "BGI脚本查看器" + " - " + DisplayedName;
                textBox1.Lines = BGIUtils.Process(DisplayedPath, "", cp);
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = WorkPath;
            sfd.AddExtension = true;
            sfd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            sfd.FileName = DisplayedName;

            if (sfd.ShowDialog() == DialogResult.OK)
                BGIUtils.WriteText(textBox1.Lines, sfd.FileName);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    cp = 932;   //Shift-JIS
                    break;
                case 1:
                    cp = 936;   //GB2312
                    break;
                case 2:
                    cp = 950;   //Big5
                    break;
                case 3:
                    cp = 65001; //UTF-8
                    break;
            }
            if (DisplayedPath!="" && button2.Enabled)
                textBox1.Lines = BGIUtils.Process(DisplayedPath, "", cp);   //Refresh encodings
        }
    }
}
