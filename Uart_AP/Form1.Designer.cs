﻿namespace Uart_AP
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reg_datagrid = new System.Windows.Forms.DataGridView();
            this.address_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ADC_DATo_MUX_1_rbn = new System.Windows.Forms.RadioButton();
            this.ADC_DATo_MUX_0_rbn = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EN_0_rbn = new System.Windows.Forms.RadioButton();
            this.EN_1_rbn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TH_1_rbn = new System.Windows.Forms.RadioButton();
            this.TH_0_rbn = new System.Windows.Forms.RadioButton();
            this.reg0x0b_tb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.reg0x0a_tb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.reg0x09_tb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.reg0x08_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.reg0x07_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.reg0x06_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.reg0x05_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.reg0x04_tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.reg0x03_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ADC_EN_1_rtn = new System.Windows.Forms.RadioButton();
            this.ADC_EN_0_rbn = new System.Windows.Forms.RadioButton();
            this.reg0x01_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reg0x00_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Write_all_btn = new System.Windows.Forms.Button();
            this.Get_value_btn = new System.Windows.Forms.Button();
            this.FIFO_reg_db = new System.Windows.Forms.DataGridView();
            this.Set_EN_btn = new System.Windows.Forms.Button();
            this.FIFO_Read_btn = new System.Windows.Forms.Button();
            this.Rst_FIFO_btn = new System.Windows.Forms.Button();
            this.savecsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reg_datagrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FIFO_reg_db)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(509, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comportToolStripMenuItem,
            this.testToolStripMenuItem,
            this.savecsvToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // comportToolStripMenuItem
            // 
            this.comportToolStripMenuItem.Name = "comportToolStripMenuItem";
            this.comportToolStripMenuItem.RightToLeftAutoMirrorImage = true;
            this.comportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.comportToolStripMenuItem.Text = "Comport";
            this.comportToolStripMenuItem.Click += new System.EventHandler(this.comportToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(35, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 375);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reg_datagrid);
            this.tabPage1.Controls.Add(this.address_tb);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(430, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Register";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reg_datagrid
            // 
            this.reg_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reg_datagrid.Location = new System.Drawing.Point(10, 48);
            this.reg_datagrid.Name = "reg_datagrid";
            this.reg_datagrid.RowTemplate.Height = 24;
            this.reg_datagrid.Size = new System.Drawing.Size(409, 282);
            this.reg_datagrid.TabIndex = 0;
            // 
            // address_tb
            // 
            this.address_tb.Location = new System.Drawing.Point(65, 18);
            this.address_tb.Name = "address_tb";
            this.address_tb.Size = new System.Drawing.Size(61, 22);
            this.address_tb.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Address : ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.reg0x0b_tb);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.reg0x0a_tb);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.reg0x09_tb);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.reg0x08_tb);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.reg0x07_tb);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.reg0x06_tb);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.reg0x05_tb);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.reg0x04_tb);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.reg0x03_tb);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.reg0x01_tb);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.reg0x00_tb);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(430, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "UI";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ADC_DATo_MUX_1_rbn);
            this.groupBox4.Controls.Add(this.ADC_DATo_MUX_0_rbn);
            this.groupBox4.Location = new System.Drawing.Point(263, 244);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(150, 44);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ADC_DATo_MUX (0x0C): ";
            // 
            // ADC_DATo_MUX_1_rbn
            // 
            this.ADC_DATo_MUX_1_rbn.AutoSize = true;
            this.ADC_DATo_MUX_1_rbn.Location = new System.Drawing.Point(11, 20);
            this.ADC_DATo_MUX_1_rbn.Name = "ADC_DATo_MUX_1_rbn";
            this.ADC_DATo_MUX_1_rbn.Size = new System.Drawing.Size(29, 16);
            this.ADC_DATo_MUX_1_rbn.TabIndex = 1;
            this.ADC_DATo_MUX_1_rbn.TabStop = true;
            this.ADC_DATo_MUX_1_rbn.Text = "1";
            this.ADC_DATo_MUX_1_rbn.UseVisualStyleBackColor = true;
            this.ADC_DATo_MUX_1_rbn.CheckedChanged += new System.EventHandler(this.ADC_DATo_MUX_1_rbn_CheckedChanged);
            // 
            // ADC_DATo_MUX_0_rbn
            // 
            this.ADC_DATo_MUX_0_rbn.AutoSize = true;
            this.ADC_DATo_MUX_0_rbn.Location = new System.Drawing.Point(58, 20);
            this.ADC_DATo_MUX_0_rbn.Name = "ADC_DATo_MUX_0_rbn";
            this.ADC_DATo_MUX_0_rbn.Size = new System.Drawing.Size(29, 16);
            this.ADC_DATo_MUX_0_rbn.TabIndex = 0;
            this.ADC_DATo_MUX_0_rbn.TabStop = true;
            this.ADC_DATo_MUX_0_rbn.Text = "0";
            this.ADC_DATo_MUX_0_rbn.UseVisualStyleBackColor = true;
            this.ADC_DATo_MUX_0_rbn.CheckedChanged += new System.EventHandler(this.ADC_DATo_MUX_0_rbn_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.EN_0_rbn);
            this.groupBox3.Controls.Add(this.EN_1_rbn);
            this.groupBox3.Location = new System.Drawing.Point(263, 290);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(111, 53);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SATK01_EN";
            // 
            // EN_0_rbn
            // 
            this.EN_0_rbn.AutoSize = true;
            this.EN_0_rbn.Enabled = false;
            this.EN_0_rbn.Location = new System.Drawing.Point(59, 24);
            this.EN_0_rbn.Name = "EN_0_rbn";
            this.EN_0_rbn.Size = new System.Drawing.Size(29, 16);
            this.EN_0_rbn.TabIndex = 3;
            this.EN_0_rbn.TabStop = true;
            this.EN_0_rbn.Text = "0";
            this.EN_0_rbn.UseVisualStyleBackColor = true;
            this.EN_0_rbn.CheckedChanged += new System.EventHandler(this.EN_0_rbn_CheckedChanged);
            // 
            // EN_1_rbn
            // 
            this.EN_1_rbn.AutoSize = true;
            this.EN_1_rbn.Enabled = false;
            this.EN_1_rbn.Location = new System.Drawing.Point(14, 24);
            this.EN_1_rbn.Name = "EN_1_rbn";
            this.EN_1_rbn.Size = new System.Drawing.Size(29, 16);
            this.EN_1_rbn.TabIndex = 2;
            this.EN_1_rbn.TabStop = true;
            this.EN_1_rbn.Text = "1";
            this.EN_1_rbn.UseVisualStyleBackColor = true;
            this.EN_1_rbn.CheckedChanged += new System.EventHandler(this.EN_1_rbn_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TH_1_rbn);
            this.groupBox1.Controls.Add(this.TH_0_rbn);
            this.groupBox1.Location = new System.Drawing.Point(146, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 44);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TH (0x02) bit0 :";
            // 
            // TH_1_rbn
            // 
            this.TH_1_rbn.AutoSize = true;
            this.TH_1_rbn.Location = new System.Drawing.Point(6, 20);
            this.TH_1_rbn.Name = "TH_1_rbn";
            this.TH_1_rbn.Size = new System.Drawing.Size(29, 16);
            this.TH_1_rbn.TabIndex = 1;
            this.TH_1_rbn.TabStop = true;
            this.TH_1_rbn.Text = "1";
            this.TH_1_rbn.UseVisualStyleBackColor = true;
            this.TH_1_rbn.CheckedChanged += new System.EventHandler(this.TH_1_rbn_CheckedChanged);
            // 
            // TH_0_rbn
            // 
            this.TH_0_rbn.AutoSize = true;
            this.TH_0_rbn.Location = new System.Drawing.Point(63, 20);
            this.TH_0_rbn.Name = "TH_0_rbn";
            this.TH_0_rbn.Size = new System.Drawing.Size(29, 16);
            this.TH_0_rbn.TabIndex = 0;
            this.TH_0_rbn.TabStop = true;
            this.TH_0_rbn.Text = "0";
            this.TH_0_rbn.UseVisualStyleBackColor = true;
            this.TH_0_rbn.CheckedChanged += new System.EventHandler(this.TH_0_rbn_CheckedChanged);
            // 
            // reg0x0b_tb
            // 
            this.reg0x0b_tb.Location = new System.Drawing.Point(263, 216);
            this.reg0x0b_tb.Name = "reg0x0b_tb";
            this.reg0x0b_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x0b_tb.TabIndex = 23;
            this.reg0x0b_tb.TextChanged += new System.EventHandler(this.reg0x0b_tb_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(261, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(141, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "AFE_SAMPLE_NO (0x0B): ";
            // 
            // reg0x0a_tb
            // 
            this.reg0x0a_tb.Location = new System.Drawing.Point(263, 170);
            this.reg0x0a_tb.Name = "reg0x0a_tb";
            this.reg0x0a_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x0a_tb.TabIndex = 21;
            this.reg0x0a_tb.TextChanged += new System.EventHandler(this.reg0x0a_tb_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(261, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "MUX_AFE_2 (0x0A): ";
            // 
            // reg0x09_tb
            // 
            this.reg0x09_tb.Location = new System.Drawing.Point(263, 126);
            this.reg0x09_tb.Name = "reg0x09_tb";
            this.reg0x09_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x09_tb.TabIndex = 19;
            this.reg0x09_tb.TextChanged += new System.EventHandler(this.reg0x09_tb_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(261, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "Capture_ADC3_DAT (0x09): ";
            // 
            // reg0x08_tb
            // 
            this.reg0x08_tb.Location = new System.Drawing.Point(263, 78);
            this.reg0x08_tb.Name = "reg0x08_tb";
            this.reg0x08_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x08_tb.TabIndex = 17;
            this.reg0x08_tb.TextChanged += new System.EventHandler(this.reg0x08_tb_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(261, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "Capture_ADC2_DAT (0x08): ";
            // 
            // reg0x07_tb
            // 
            this.reg0x07_tb.Location = new System.Drawing.Point(263, 28);
            this.reg0x07_tb.Name = "reg0x07_tb";
            this.reg0x07_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x07_tb.TabIndex = 15;
            this.reg0x07_tb.TextChanged += new System.EventHandler(this.reg0x07_tb_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(261, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "Capture_ADC1_DAT (0x07): ";
            // 
            // reg0x06_tb
            // 
            this.reg0x06_tb.Location = new System.Drawing.Point(8, 305);
            this.reg0x06_tb.Name = "reg0x06_tb";
            this.reg0x06_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x06_tb.TabIndex = 13;
            this.reg0x06_tb.TextChanged += new System.EventHandler(this.reg0x06_tb_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(6, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Capture_ADC0_DAT (0x06): ";
            // 
            // reg0x05_tb
            // 
            this.reg0x05_tb.Location = new System.Drawing.Point(8, 262);
            this.reg0x05_tb.Name = "reg0x05_tb";
            this.reg0x05_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x05_tb.TabIndex = 11;
            this.reg0x05_tb.TextChanged += new System.EventHandler(this.reg0x05_tb_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(6, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "ADC_START_NUM (0x05): ";
            // 
            // reg0x04_tb
            // 
            this.reg0x04_tb.Location = new System.Drawing.Point(8, 219);
            this.reg0x04_tb.Name = "reg0x04_tb";
            this.reg0x04_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x04_tb.TabIndex = 9;
            this.reg0x04_tb.TextChanged += new System.EventHandler(this.reg0x04_tb_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(6, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "ADC_START_1st (0x04): ";
            // 
            // reg0x03_tb
            // 
            this.reg0x03_tb.Location = new System.Drawing.Point(8, 170);
            this.reg0x03_tb.Name = "reg0x03_tb";
            this.reg0x03_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x03_tb.TabIndex = 7;
            this.reg0x03_tb.TextChanged += new System.EventHandler(this.reg0x03_tb_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(6, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "ADC_EN_Dly (0x03): ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ADC_EN_1_rtn);
            this.groupBox2.Controls.Add(this.ADC_EN_0_rbn);
            this.groupBox2.Location = new System.Drawing.Point(8, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 44);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADC_EN (0x02) bit4 :";
            // 
            // ADC_EN_1_rtn
            // 
            this.ADC_EN_1_rtn.AutoSize = true;
            this.ADC_EN_1_rtn.Location = new System.Drawing.Point(10, 20);
            this.ADC_EN_1_rtn.Name = "ADC_EN_1_rtn";
            this.ADC_EN_1_rtn.Size = new System.Drawing.Size(29, 16);
            this.ADC_EN_1_rtn.TabIndex = 3;
            this.ADC_EN_1_rtn.TabStop = true;
            this.ADC_EN_1_rtn.Text = "1";
            this.ADC_EN_1_rtn.UseVisualStyleBackColor = true;
            this.ADC_EN_1_rtn.CheckedChanged += new System.EventHandler(this.ADC_EN_1_rtn_CheckedChanged);
            // 
            // ADC_EN_0_rbn
            // 
            this.ADC_EN_0_rbn.AutoSize = true;
            this.ADC_EN_0_rbn.Location = new System.Drawing.Point(67, 20);
            this.ADC_EN_0_rbn.Name = "ADC_EN_0_rbn";
            this.ADC_EN_0_rbn.Size = new System.Drawing.Size(29, 16);
            this.ADC_EN_0_rbn.TabIndex = 2;
            this.ADC_EN_0_rbn.TabStop = true;
            this.ADC_EN_0_rbn.Text = "0";
            this.ADC_EN_0_rbn.UseVisualStyleBackColor = true;
            this.ADC_EN_0_rbn.CheckedChanged += new System.EventHandler(this.ADC_EN_rbn_CheckedChanged);
            // 
            // reg0x01_tb
            // 
            this.reg0x01_tb.Location = new System.Drawing.Point(8, 78);
            this.reg0x01_tb.Name = "reg0x01_tb";
            this.reg0x01_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x01_tb.TabIndex = 3;
            this.reg0x01_tb.TextChanged += new System.EventHandler(this.reg0x01_tb_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "TH_HEN_High_time (0x01) : ";
            // 
            // reg0x00_tb
            // 
            this.reg0x00_tb.Location = new System.Drawing.Point(8, 28);
            this.reg0x00_tb.Name = "reg0x00_tb";
            this.reg0x00_tb.Size = new System.Drawing.Size(91, 22);
            this.reg0x00_tb.TabIndex = 1;
            this.reg0x00_tb.TextChanged += new System.EventHandler(this.reg0x00_tb_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "TH_HEN Init (0x00) : ";
            // 
            // Write_all_btn
            // 
            this.Write_all_btn.Location = new System.Drawing.Point(119, 411);
            this.Write_all_btn.Name = "Write_all_btn";
            this.Write_all_btn.Size = new System.Drawing.Size(70, 31);
            this.Write_all_btn.TabIndex = 2;
            this.Write_all_btn.Text = "Write_All";
            this.Write_all_btn.UseVisualStyleBackColor = true;
            this.Write_all_btn.Click += new System.EventHandler(this.Write_all_btn_Click);
            // 
            // Get_value_btn
            // 
            this.Get_value_btn.Location = new System.Drawing.Point(38, 411);
            this.Get_value_btn.Name = "Get_value_btn";
            this.Get_value_btn.Size = new System.Drawing.Size(70, 31);
            this.Get_value_btn.TabIndex = 1;
            this.Get_value_btn.Text = "Get_Value";
            this.Get_value_btn.UseVisualStyleBackColor = true;
            this.Get_value_btn.Click += new System.EventHandler(this.Get_Value_btn_Click);
            // 
            // FIFO_reg_db
            // 
            this.FIFO_reg_db.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FIFO_reg_db.Location = new System.Drawing.Point(38, 453);
            this.FIFO_reg_db.Name = "FIFO_reg_db";
            this.FIFO_reg_db.RowTemplate.Height = 24;
            this.FIFO_reg_db.Size = new System.Drawing.Size(434, 323);
            this.FIFO_reg_db.TabIndex = 3;
            // 
            // Set_EN_btn
            // 
            this.Set_EN_btn.Location = new System.Drawing.Point(278, 411);
            this.Set_EN_btn.Name = "Set_EN_btn";
            this.Set_EN_btn.Size = new System.Drawing.Size(115, 31);
            this.Set_EN_btn.TabIndex = 4;
            this.Set_EN_btn.Text = "SET SATK01_EN(S)";
            this.Set_EN_btn.UseVisualStyleBackColor = true;
            this.Set_EN_btn.Click += new System.EventHandler(this.Set_EN_btn_Click);
            // 
            // FIFO_Read_btn
            // 
            this.FIFO_Read_btn.Location = new System.Drawing.Point(399, 411);
            this.FIFO_Read_btn.Name = "FIFO_Read_btn";
            this.FIFO_Read_btn.Size = new System.Drawing.Size(70, 31);
            this.FIFO_Read_btn.TabIndex = 5;
            this.FIFO_Read_btn.Text = "FIFO_Read";
            this.FIFO_Read_btn.UseVisualStyleBackColor = true;
            this.FIFO_Read_btn.Click += new System.EventHandler(this.FIFO_Read_btn_Click);
            // 
            // Rst_FIFO_btn
            // 
            this.Rst_FIFO_btn.Location = new System.Drawing.Point(200, 411);
            this.Rst_FIFO_btn.Name = "Rst_FIFO_btn";
            this.Rst_FIFO_btn.Size = new System.Drawing.Size(70, 31);
            this.Rst_FIFO_btn.TabIndex = 6;
            this.Rst_FIFO_btn.Text = "Reset FIFO";
            this.Rst_FIFO_btn.UseVisualStyleBackColor = true;
            this.Rst_FIFO_btn.Click += new System.EventHandler(this.Rst_FIFO_btn_Click);
            // 
            // savecsvToolStripMenuItem
            // 
            this.savecsvToolStripMenuItem.Name = "savecsvToolStripMenuItem";
            this.savecsvToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.savecsvToolStripMenuItem.Text = "Save .csv";
            this.savecsvToolStripMenuItem.Click += new System.EventHandler(this.savecsvToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 788);
            this.Controls.Add(this.Rst_FIFO_btn);
            this.Controls.Add(this.FIFO_Read_btn);
            this.Controls.Add(this.Set_EN_btn);
            this.Controls.Add(this.Write_all_btn);
            this.Controls.Add(this.FIFO_reg_db);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Get_value_btn);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Uart AP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reg_datagrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FIFO_reg_db)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button Write_all_btn;
        private System.Windows.Forms.Button Get_value_btn;
        private System.Windows.Forms.DataGridView reg_datagrid;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox address_tb;
        private System.Windows.Forms.TextBox reg0x06_tb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox reg0x05_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox reg0x04_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox reg0x03_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox reg0x01_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reg0x00_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView FIFO_reg_db;
        private System.Windows.Forms.Button Set_EN_btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox reg0x0b_tb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox reg0x0a_tb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox reg0x09_tb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox reg0x08_tb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox reg0x07_tb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton TH_1_rbn;
        private System.Windows.Forms.RadioButton TH_0_rbn;
        private System.Windows.Forms.RadioButton EN_0_rbn;
        private System.Windows.Forms.RadioButton EN_1_rbn;
        private System.Windows.Forms.RadioButton ADC_EN_1_rtn;
        private System.Windows.Forms.RadioButton ADC_EN_0_rbn;
        private System.Windows.Forms.Button FIFO_Read_btn;
        private System.Windows.Forms.Button Rst_FIFO_btn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton ADC_DATo_MUX_1_rbn;
        private System.Windows.Forms.RadioButton ADC_DATo_MUX_0_rbn;
        private System.Windows.Forms.ToolStripMenuItem savecsvToolStripMenuItem;
    }
}
