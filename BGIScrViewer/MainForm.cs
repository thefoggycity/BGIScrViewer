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
using MSTranslateUtils;
/*
 * Here is a class library records my appSecret for API Auth.
 * Please replace this reference with your own appSecret.
 * You can write a class:
 * 1. In your namespace (and remember to change the "using" below);
 * 2. Named as MSTranslatorAuthSec;
 * 3. Provide attributions including: ClientId and ClientSecret;
 * Recommended Example:
 * namespace MSTranslatorAuthSec_YourName
 * {
 *     public class MSTranslatorAuthSec
 *     {
 *         public const string ClientId = "[Your appid]";
 *         public const string ClientSecret = "[Your appsec]";
 *     }
 * }
 * You can get your API key on: https://datamarket.azure.com/developer/applications/
 */
using MSTranslatorAuthSec_tfc;

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
            toolStripComboBox_src.SelectedItem = Translator.LangCodes.Japanese;
            toolStripComboBox_dst.SelectedItem = Translator.LangCodes.ChineseSimplified;
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
                toolStripMenuItem_trans.Enabled = true;
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

        private void toolStripMenuItem_trans_Click(object sender, EventArgs e)
        {
            string src = toolStripComboBox_src.SelectedItem.ToString(),
                dst = toolStripComboBox_dst.SelectedItem.ToString();
            if ( Translator.ChkLangCode(src) && Translator.ChkLangCode(dst))
            {
                Translator tr = new Translator(MSTranslatorAuthSec.ClientId, MSTranslatorAuthSec.ClientSecret);
                if (textBox1.SelectionLength == 0)
                {
                    string[] scr = textBox1.Lines;
                    string[]
                        offset_data = new string[20],
                        content = new string[20];
                    for (int i = 0; i < 20; i++)
                    {
                        int splitpos = scr[i].IndexOf('>') + 1;
                        offset_data[i] = scr[i].Substring(0, splitpos);
                        content[i] = scr[i].Substring(splitpos);
                    }
                    content = tr.TranslateArray(content, src, dst, false);
                    for (int i = 0; i < 20; i++)
                    {
                        scr[i] = offset_data[i] + content[i];
                    }
                    textBox1.Lines = scr;
                }
                else
                {
                    //ToolTip tt = new ToolTip();
                    //tt.Show(tr.TranslateArray(new string[] { textBox1.SelectedText }, src, dst, false)[0], this);
                    //label1.Text = "译文：" + tr.TranslateArray(new string[] { textBox1.SelectedText }, src, dst, false)[0];
                    label1.Text = "" + tr.Translate(textBox1.SelectedText, src, dst, false);
                }
            }
            else
            {
                MessageBox.Show("选择的语言参数有误。");
            }
        }
    }
}
