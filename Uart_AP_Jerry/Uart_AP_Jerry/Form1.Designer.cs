namespace Uart_AP_Jerry
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
            this.LoadCmdBtn = new System.Windows.Forms.Button();
            this.RunTestBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.CmdTb = new System.Windows.Forms.TextBox();
            this.DataTb = new System.Windows.Forms.TextBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(506, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // LoadCmdBtn
            // 
            this.LoadCmdBtn.Location = new System.Drawing.Point(28, 37);
            this.LoadCmdBtn.Name = "LoadCmdBtn";
            this.LoadCmdBtn.Size = new System.Drawing.Size(104, 56);
            this.LoadCmdBtn.TabIndex = 1;
            this.LoadCmdBtn.Text = "Load CMD";
            this.LoadCmdBtn.UseVisualStyleBackColor = true;
            this.LoadCmdBtn.Click += new System.EventHandler(this.LoadCmdBtn_Click);
            // 
            // RunTestBtn
            // 
            this.RunTestBtn.Location = new System.Drawing.Point(201, 37);
            this.RunTestBtn.Name = "RunTestBtn";
            this.RunTestBtn.Size = new System.Drawing.Size(104, 56);
            this.RunTestBtn.TabIndex = 2;
            this.RunTestBtn.Text = "Run Test";
            this.RunTestBtn.UseVisualStyleBackColor = true;
            this.RunTestBtn.Click += new System.EventHandler(this.RunTestBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(374, 37);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(104, 56);
            this.ClearBtn.TabIndex = 3;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // CmdTb
            // 
            this.CmdTb.Location = new System.Drawing.Point(28, 109);
            this.CmdTb.Multiline = true;
            this.CmdTb.Name = "CmdTb";
            this.CmdTb.Size = new System.Drawing.Size(450, 202);
            this.CmdTb.TabIndex = 4;
            // 
            // DataTb
            // 
            this.DataTb.Location = new System.Drawing.Point(28, 338);
            this.DataTb.Multiline = true;
            this.DataTb.Name = "DataTb";
            this.DataTb.Size = new System.Drawing.Size(450, 202);
            this.DataTb.TabIndex = 5;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comPortToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // comPortToolStripMenuItem
            // 
            this.comPortToolStripMenuItem.Name = "comPortToolStripMenuItem";
            this.comPortToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.comPortToolStripMenuItem.Text = "ComPort";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 569);
            this.Controls.Add(this.DataTb);
            this.Controls.Add(this.CmdTb);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.RunTestBtn);
            this.Controls.Add(this.LoadCmdBtn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button LoadCmdBtn;
        private System.Windows.Forms.Button RunTestBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.TextBox CmdTb;
        private System.Windows.Forms.TextBox DataTb;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comPortToolStripMenuItem;
    }
}

