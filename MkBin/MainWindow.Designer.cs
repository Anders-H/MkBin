
namespace MkBin
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTextDescriptionOfBinaryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBinaryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTextDescriptionOfBinaryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBinaryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.newDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDocumentToolStripMenuItem,
            this.loadTextDescriptionOfBinaryFileToolStripMenuItem,
            this.loadBinaryFileToolStripMenuItem,
            this.saveTextDescriptionOfBinaryFileToolStripMenuItem,
            this.saveBinaryFileToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadTextDescriptionOfBinaryFileToolStripMenuItem
            // 
            this.loadTextDescriptionOfBinaryFileToolStripMenuItem.Name = "loadTextDescriptionOfBinaryFileToolStripMenuItem";
            this.loadTextDescriptionOfBinaryFileToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.loadTextDescriptionOfBinaryFileToolStripMenuItem.Text = "Load text description of binary file...";
            this.loadTextDescriptionOfBinaryFileToolStripMenuItem.Click += new System.EventHandler(this.loadTextDescriptionOfBinaryFileToolStripMenuItem_Click);
            // 
            // loadBinaryFileToolStripMenuItem
            // 
            this.loadBinaryFileToolStripMenuItem.Name = "loadBinaryFileToolStripMenuItem";
            this.loadBinaryFileToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.loadBinaryFileToolStripMenuItem.Text = "Load binary file...";
            this.loadBinaryFileToolStripMenuItem.Click += new System.EventHandler(this.loadBinaryFileToolStripMenuItem_Click);
            // 
            // saveTextDescriptionOfBinaryFileToolStripMenuItem
            // 
            this.saveTextDescriptionOfBinaryFileToolStripMenuItem.Name = "saveTextDescriptionOfBinaryFileToolStripMenuItem";
            this.saveTextDescriptionOfBinaryFileToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.saveTextDescriptionOfBinaryFileToolStripMenuItem.Text = "Save text description of binary file...";
            this.saveTextDescriptionOfBinaryFileToolStripMenuItem.Click += new System.EventHandler(this.saveTextDescriptionOfBinaryFileToolStripMenuItem_Click);
            // 
            // saveBinaryFileToolStripMenuItem
            // 
            this.saveBinaryFileToolStripMenuItem.Name = "saveBinaryFileToolStripMenuItem";
            this.saveBinaryFileToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.saveBinaryFileToolStripMenuItem.Text = "Save binary file...";
            this.saveBinaryFileToolStripMenuItem.Click += new System.EventHandler(this.saveBinaryFileToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(933, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(19, 17);
            this.lblStatus.Text = "    ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtInput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtOutput);
            this.splitContainer1.Size = new System.Drawing.Size(933, 473);
            this.splitContainer1.SplitterDistance = 310;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtInput
            // 
            this.txtInput.AcceptsReturn = true;
            this.txtInput.AcceptsTab = true;
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInput.Size = new System.Drawing.Size(310, 473);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(618, 473);
            this.txtOutput.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // newDocumentToolStripMenuItem
            // 
            this.newDocumentToolStripMenuItem.Name = "newDocumentToolStripMenuItem";
            this.newDocumentToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.newDocumentToolStripMenuItem.Text = "New document";
            this.newDocumentToolStripMenuItem.Click += new System.EventHandler(this.newDocumentToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainWindow";
            this.Text = "MkBin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTextDescriptionOfBinaryFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBinaryFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTextDescriptionOfBinaryFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBinaryFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem newDocumentToolStripMenuItem;
    }
}