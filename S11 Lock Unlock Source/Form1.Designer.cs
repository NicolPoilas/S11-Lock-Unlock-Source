namespace S11_Lock_Unlock_Source
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BusButton = new System.Windows.Forms.Button();
            this.comboBoxCanDevice = new System.Windows.Forms.ComboBox();
            this.comboBoxCanBaudRate = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReadButton = new System.Windows.Forms.Button();
            this.BusLoad = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxDisplay = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BusButton
            // 
            this.BusButton.Location = new System.Drawing.Point(236, 20);
            this.BusButton.Name = "BusButton";
            this.BusButton.Size = new System.Drawing.Size(75, 23);
            this.BusButton.TabIndex = 2;
            this.BusButton.Text = "Bus On";
            this.BusButton.UseVisualStyleBackColor = true;
            this.BusButton.Click += new System.EventHandler(this.BusButton_Click);
            // 
            // comboBoxCanDevice
            // 
            this.comboBoxCanDevice.FormattingEnabled = true;
            this.comboBoxCanDevice.Location = new System.Drawing.Point(9, 22);
            this.comboBoxCanDevice.Name = "comboBoxCanDevice";
            this.comboBoxCanDevice.Size = new System.Drawing.Size(220, 20);
            this.comboBoxCanDevice.TabIndex = 8;
            // 
            // comboBoxCanBaudRate
            // 
            this.comboBoxCanBaudRate.FormattingEnabled = true;
            this.comboBoxCanBaudRate.Items.AddRange(new object[] {
            "50",
            "100",
            "200",
            "250",
            "500"});
            this.comboBoxCanBaudRate.Location = new System.Drawing.Point(9, 51);
            this.comboBoxCanBaudRate.Name = "comboBoxCanBaudRate";
            this.comboBoxCanBaudRate.Size = new System.Drawing.Size(82, 20);
            this.comboBoxCanBaudRate.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReadButton);
            this.groupBox1.Controls.Add(this.BusLoad);
            this.groupBox1.Controls.Add(this.comboBoxCanBaudRate);
            this.groupBox1.Controls.Add(this.comboBoxCanDevice);
            this.groupBox1.Controls.Add(this.BusButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 83);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CAN ";
            // 
            // ReadButton
            // 
            this.ReadButton.Location = new System.Drawing.Point(236, 49);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(75, 23);
            this.ReadButton.TabIndex = 3;
            this.ReadButton.Text = "Read";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // BusLoad
            // 
            this.BusLoad.AutoSize = true;
            this.BusLoad.Location = new System.Drawing.Point(119, 54);
            this.BusLoad.Name = "BusLoad";
            this.BusLoad.Size = new System.Drawing.Size(65, 12);
            this.BusLoad.TabIndex = 10;
            this.BusLoad.Text = "Bus Load：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBoxDisplay);
            this.groupBox2.Location = new System.Drawing.Point(12, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 277);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lock Unlock Source";
            // 
            // richTextBoxDisplay
            // 
            this.richTextBoxDisplay.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBoxDisplay.Location = new System.Drawing.Point(9, 20);
            this.richTextBoxDisplay.Name = "richTextBoxDisplay";
            this.richTextBoxDisplay.Size = new System.Drawing.Size(302, 248);
            this.richTextBoxDisplay.TabIndex = 0;
            this.richTextBoxDisplay.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 26);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 389);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "S11 Lock Unlock Source";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BusButton;
        private System.Windows.Forms.ComboBox comboBoxCanDevice;
        private System.Windows.Forms.ComboBox comboBoxCanBaudRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label BusLoad;
        private System.Windows.Forms.Button ReadButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBoxDisplay;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}

