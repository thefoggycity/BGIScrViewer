using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGIScrViewer
{
    public partial class MassConvert : Form
    {
        public MassConvert()
        {
            InitializeComponent();
        }

        private void MassConvert_Load(object sender, EventArgs e)
        {
            textBox1.Text = MainForm.WorkPath;
            textBox3.Text = MainForm.WorkPath;
            button3.Enabled = false;
        }

        /// <summary>
        /// Check the vaildity of input data.
        /// </summary>
        private void ChkValid()
        {
            if (textBox1.Text != "" &&
                textBox2.Text != "" &&
                textBox3.Text != "")
                button3.Enabled = true;
            else
                button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = MainForm.WorkPath;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBox1.Text = fbd.SelectedPath;
            fbd.Dispose();
            ChkValid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = MainForm.WorkPath;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBox3.Text = fbd.SelectedPath;
            fbd.Dispose();
            ChkValid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ChkValid();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ChkValid();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ChkValid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String[] src = BGIUtils.GetScr(textBox1.Text, textBox2.Text);
            if (src.GetLength(0)==0){
                MessageBox.Show(MassConvert.ActiveForm, "没有匹配的文件被转换。请检查匹配样式。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (src[0] == "err")
                return;

            button4.Enabled = false;
            progressBar1.Maximum = src.GetLength(0);

            var dstlist = new System.Collections.ArrayList();
            String[] dst;
            for (int i = 0; i < src.GetUpperBound(0); i++)
            {
                String tmp = "";
                if (textBox6.Text != "")
                    tmp = textBox3.Text + "\\" + textBox4.Text + BGIUtils.GetFileByPath(src[i], false) + textBox5.Text + "." + textBox6.Text;
                else
                    tmp = textBox3.Text + "\\" + textBox4.Text + BGIUtils.GetFileByPath(src[i], false) + textBox5.Text;
                dstlist.Add(tmp);
            }
            dst = (String[])dstlist.ToArray(typeof(string));

            for (int i = 0; i < src.GetUpperBound(0); i++)
            {
                BGIUtils.Process(src[i], dst[i], MainForm.cp);
                progressBar1.Value = i + 1;
            }

            button4.Enabled = true;

            if (src.GetUpperBound(0) == 0)
            {
                MessageBox.Show(MassConvert.ActiveForm, "没有匹配的文件被转换。请检查匹配样式。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                progressBar1.Value = 0;
                progressBar1.Refresh();
                return;
            }
            else
            {
                MessageBox.Show(MassConvert.ActiveForm, "共" + src.GetUpperBound(0).ToString() + "个匹配的文件被转换。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                progressBar1.Value = 0;
                progressBar1.Refresh();
                MassConvert.ActiveForm.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MassConvert.ActiveForm.Close();
        }
    }
}
