namespace BGIScrViewer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripComboBox_src = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox_dst = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_trans = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_src,
            this.toolStripComboBox_dst,
            this.toolStripSeparator1,
            this.toolStripMenuItem_trans});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // toolStripComboBox_src
            // 
            this.toolStripComboBox_src.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBox_src.Items"),
            resources.GetString("toolStripComboBox_src.Items1"),
            resources.GetString("toolStripComboBox_src.Items2"),
            resources.GetString("toolStripComboBox_src.Items3"),
            resources.GetString("toolStripComboBox_src.Items4"),
            resources.GetString("toolStripComboBox_src.Items5"),
            resources.GetString("toolStripComboBox_src.Items6"),
            resources.GetString("toolStripComboBox_src.Items7"),
            resources.GetString("toolStripComboBox_src.Items8"),
            resources.GetString("toolStripComboBox_src.Items9"),
            resources.GetString("toolStripComboBox_src.Items10"),
            resources.GetString("toolStripComboBox_src.Items11"),
            resources.GetString("toolStripComboBox_src.Items12"),
            resources.GetString("toolStripComboBox_src.Items13"),
            resources.GetString("toolStripComboBox_src.Items14"),
            resources.GetString("toolStripComboBox_src.Items15"),
            resources.GetString("toolStripComboBox_src.Items16"),
            resources.GetString("toolStripComboBox_src.Items17"),
            resources.GetString("toolStripComboBox_src.Items18"),
            resources.GetString("toolStripComboBox_src.Items19"),
            resources.GetString("toolStripComboBox_src.Items20"),
            resources.GetString("toolStripComboBox_src.Items21"),
            resources.GetString("toolStripComboBox_src.Items22"),
            resources.GetString("toolStripComboBox_src.Items23"),
            resources.GetString("toolStripComboBox_src.Items24"),
            resources.GetString("toolStripComboBox_src.Items25"),
            resources.GetString("toolStripComboBox_src.Items26"),
            resources.GetString("toolStripComboBox_src.Items27"),
            resources.GetString("toolStripComboBox_src.Items28"),
            resources.GetString("toolStripComboBox_src.Items29"),
            resources.GetString("toolStripComboBox_src.Items30"),
            resources.GetString("toolStripComboBox_src.Items31"),
            resources.GetString("toolStripComboBox_src.Items32"),
            resources.GetString("toolStripComboBox_src.Items33"),
            resources.GetString("toolStripComboBox_src.Items34"),
            resources.GetString("toolStripComboBox_src.Items35"),
            resources.GetString("toolStripComboBox_src.Items36"),
            resources.GetString("toolStripComboBox_src.Items37"),
            resources.GetString("toolStripComboBox_src.Items38"),
            resources.GetString("toolStripComboBox_src.Items39"),
            resources.GetString("toolStripComboBox_src.Items40"),
            resources.GetString("toolStripComboBox_src.Items41"),
            resources.GetString("toolStripComboBox_src.Items42"),
            resources.GetString("toolStripComboBox_src.Items43"),
            resources.GetString("toolStripComboBox_src.Items44"),
            resources.GetString("toolStripComboBox_src.Items45"),
            resources.GetString("toolStripComboBox_src.Items46"),
            resources.GetString("toolStripComboBox_src.Items47"),
            resources.GetString("toolStripComboBox_src.Items48"),
            resources.GetString("toolStripComboBox_src.Items49"),
            resources.GetString("toolStripComboBox_src.Items50"),
            resources.GetString("toolStripComboBox_src.Items51")});
            this.toolStripComboBox_src.Name = "toolStripComboBox_src";
            resources.ApplyResources(this.toolStripComboBox_src, "toolStripComboBox_src");
            // 
            // toolStripComboBox_dst
            // 
            this.toolStripComboBox_dst.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBox_dst.Items"),
            resources.GetString("toolStripComboBox_dst.Items1"),
            resources.GetString("toolStripComboBox_dst.Items2"),
            resources.GetString("toolStripComboBox_dst.Items3"),
            resources.GetString("toolStripComboBox_dst.Items4"),
            resources.GetString("toolStripComboBox_dst.Items5"),
            resources.GetString("toolStripComboBox_dst.Items6"),
            resources.GetString("toolStripComboBox_dst.Items7"),
            resources.GetString("toolStripComboBox_dst.Items8"),
            resources.GetString("toolStripComboBox_dst.Items9"),
            resources.GetString("toolStripComboBox_dst.Items10"),
            resources.GetString("toolStripComboBox_dst.Items11"),
            resources.GetString("toolStripComboBox_dst.Items12"),
            resources.GetString("toolStripComboBox_dst.Items13"),
            resources.GetString("toolStripComboBox_dst.Items14"),
            resources.GetString("toolStripComboBox_dst.Items15"),
            resources.GetString("toolStripComboBox_dst.Items16"),
            resources.GetString("toolStripComboBox_dst.Items17"),
            resources.GetString("toolStripComboBox_dst.Items18"),
            resources.GetString("toolStripComboBox_dst.Items19"),
            resources.GetString("toolStripComboBox_dst.Items20"),
            resources.GetString("toolStripComboBox_dst.Items21"),
            resources.GetString("toolStripComboBox_dst.Items22"),
            resources.GetString("toolStripComboBox_dst.Items23"),
            resources.GetString("toolStripComboBox_dst.Items24"),
            resources.GetString("toolStripComboBox_dst.Items25"),
            resources.GetString("toolStripComboBox_dst.Items26"),
            resources.GetString("toolStripComboBox_dst.Items27"),
            resources.GetString("toolStripComboBox_dst.Items28"),
            resources.GetString("toolStripComboBox_dst.Items29"),
            resources.GetString("toolStripComboBox_dst.Items30"),
            resources.GetString("toolStripComboBox_dst.Items31"),
            resources.GetString("toolStripComboBox_dst.Items32"),
            resources.GetString("toolStripComboBox_dst.Items33"),
            resources.GetString("toolStripComboBox_dst.Items34"),
            resources.GetString("toolStripComboBox_dst.Items35"),
            resources.GetString("toolStripComboBox_dst.Items36"),
            resources.GetString("toolStripComboBox_dst.Items37"),
            resources.GetString("toolStripComboBox_dst.Items38"),
            resources.GetString("toolStripComboBox_dst.Items39"),
            resources.GetString("toolStripComboBox_dst.Items40"),
            resources.GetString("toolStripComboBox_dst.Items41"),
            resources.GetString("toolStripComboBox_dst.Items42"),
            resources.GetString("toolStripComboBox_dst.Items43"),
            resources.GetString("toolStripComboBox_dst.Items44"),
            resources.GetString("toolStripComboBox_dst.Items45"),
            resources.GetString("toolStripComboBox_dst.Items46"),
            resources.GetString("toolStripComboBox_dst.Items47"),
            resources.GetString("toolStripComboBox_dst.Items48"),
            resources.GetString("toolStripComboBox_dst.Items49"),
            resources.GetString("toolStripComboBox_dst.Items50"),
            resources.GetString("toolStripComboBox_dst.Items51")});
            this.toolStripComboBox_dst.Name = "toolStripComboBox_dst";
            resources.ApplyResources(this.toolStripComboBox_dst, "toolStripComboBox_dst");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripMenuItem_trans
            // 
            resources.ApplyResources(this.toolStripMenuItem_trans, "toolStripMenuItem_trans");
            this.toolStripMenuItem_trans.Name = "toolStripMenuItem_trans";
            this.toolStripMenuItem_trans.Click += new System.EventHandler(this.toolStripMenuItem_trans_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.Items.AddRange(new object[] {
            resources.GetString("listBox1.Items"),
            resources.GetString("listBox1.Items1"),
            resources.GetString("listBox1.Items2"),
            resources.GetString("listBox1.Items3")});
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_src;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_dst;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_trans;
    }
}

