
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadTextDescriptionOfBinaryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadBinaryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveTextDescriptionOfBinaryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveBinaryFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            hexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            decToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            autoUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            updateNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            txtInput = new System.Windows.Forms.TextBox();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            txtDisassembly = new System.Windows.Forms.TextBox();
            txtOutput = new System.Windows.Forms.TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(933, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { newDocumentToolStripMenuItem, loadTextDescriptionOfBinaryFileToolStripMenuItem, loadBinaryFileToolStripMenuItem, saveTextDescriptionOfBinaryFileToolStripMenuItem, saveBinaryFileToolStripMenuItem, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newDocumentToolStripMenuItem
            // 
            newDocumentToolStripMenuItem.Name = "newDocumentToolStripMenuItem";
            newDocumentToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            newDocumentToolStripMenuItem.Text = "New document";
            newDocumentToolStripMenuItem.Click += newDocumentToolStripMenuItem_Click;
            // 
            // loadTextDescriptionOfBinaryFileToolStripMenuItem
            // 
            loadTextDescriptionOfBinaryFileToolStripMenuItem.Name = "loadTextDescriptionOfBinaryFileToolStripMenuItem";
            loadTextDescriptionOfBinaryFileToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            loadTextDescriptionOfBinaryFileToolStripMenuItem.Text = "Load text description of binary file...";
            loadTextDescriptionOfBinaryFileToolStripMenuItem.Click += loadTextDescriptionOfBinaryFileToolStripMenuItem_Click;
            // 
            // loadBinaryFileToolStripMenuItem
            // 
            loadBinaryFileToolStripMenuItem.Name = "loadBinaryFileToolStripMenuItem";
            loadBinaryFileToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            loadBinaryFileToolStripMenuItem.Text = "Load binary file...";
            loadBinaryFileToolStripMenuItem.Click += loadBinaryFileToolStripMenuItem_Click;
            // 
            // saveTextDescriptionOfBinaryFileToolStripMenuItem
            // 
            saveTextDescriptionOfBinaryFileToolStripMenuItem.Name = "saveTextDescriptionOfBinaryFileToolStripMenuItem";
            saveTextDescriptionOfBinaryFileToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            saveTextDescriptionOfBinaryFileToolStripMenuItem.Text = "Save text description of binary file...";
            saveTextDescriptionOfBinaryFileToolStripMenuItem.Click += saveTextDescriptionOfBinaryFileToolStripMenuItem_Click;
            // 
            // saveBinaryFileToolStripMenuItem
            // 
            saveBinaryFileToolStripMenuItem.Name = "saveBinaryFileToolStripMenuItem";
            saveBinaryFileToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            saveBinaryFileToolStripMenuItem.Text = "Save binary file...";
            saveBinaryFileToolStripMenuItem.Click += saveBinaryFileToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { hexToolStripMenuItem, decToolStripMenuItem, toolStripMenuItem1, autoUpdateToolStripMenuItem, updateNowToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            viewToolStripMenuItem.Text = "&View";
            // 
            // hexToolStripMenuItem
            // 
            hexToolStripMenuItem.Checked = true;
            hexToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            hexToolStripMenuItem.Name = "hexToolStripMenuItem";
            hexToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            hexToolStripMenuItem.Text = "Hex";
            hexToolStripMenuItem.Click += hexToolStripMenuItem_Click;
            // 
            // decToolStripMenuItem
            // 
            decToolStripMenuItem.Name = "decToolStripMenuItem";
            decToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            decToolStripMenuItem.Text = "Dec";
            decToolStripMenuItem.Click += decToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(137, 6);
            // 
            // autoUpdateToolStripMenuItem
            // 
            autoUpdateToolStripMenuItem.Checked = true;
            autoUpdateToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            autoUpdateToolStripMenuItem.Name = "autoUpdateToolStripMenuItem";
            autoUpdateToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            autoUpdateToolStripMenuItem.Text = "Auto update";
            autoUpdateToolStripMenuItem.Click += autoUpdateToolStripMenuItem_Click;
            // 
            // updateNowToolStripMenuItem
            // 
            updateNowToolStripMenuItem.Enabled = false;
            updateNowToolStripMenuItem.Name = "updateNowToolStripMenuItem";
            updateNowToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            updateNowToolStripMenuItem.Text = "Update now";
            updateNowToolStripMenuItem.Click += updateNowToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblStatus });
            statusStrip1.Location = new System.Drawing.Point(0, 497);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip1.Size = new System.Drawing.Size(933, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(19, 17);
            lblStatus.Text = "    ";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 24);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtInput);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new System.Drawing.Size(933, 473);
            splitContainer1.SplitterDistance = 310;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            // 
            // txtInput
            // 
            txtInput.AcceptsReturn = true;
            txtInput.AcceptsTab = true;
            txtInput.AllowDrop = true;
            txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            txtInput.Font = new System.Drawing.Font("Courier New", 9.75F);
            txtInput.Location = new System.Drawing.Point(0, 0);
            txtInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtInput.Size = new System.Drawing.Size(310, 473);
            txtInput.TabIndex = 0;
            txtInput.Text = "# Input:\r\n\r\n";
            txtInput.TextChanged += txtInput_TextChanged;
            txtInput.DragDrop += txtInput_DragDrop;
            txtInput.DragOver += txtInput_DragOver;
            // 
            // splitContainer2
            // 
            splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(txtDisassembly);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(txtOutput);
            splitContainer2.Size = new System.Drawing.Size(618, 473);
            splitContainer2.SplitterDistance = 227;
            splitContainer2.TabIndex = 2;
            // 
            // txtDisassembly
            // 
            txtDisassembly.AllowDrop = true;
            txtDisassembly.Dock = System.Windows.Forms.DockStyle.Fill;
            txtDisassembly.Font = new System.Drawing.Font("Courier New", 9.75F);
            txtDisassembly.Location = new System.Drawing.Point(0, 0);
            txtDisassembly.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtDisassembly.Multiline = true;
            txtDisassembly.Name = "txtDisassembly";
            txtDisassembly.ReadOnly = true;
            txtDisassembly.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtDisassembly.Size = new System.Drawing.Size(227, 473);
            txtDisassembly.TabIndex = 2;
            txtDisassembly.WordWrap = false;
            // 
            // txtOutput
            // 
            txtOutput.AllowDrop = true;
            txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            txtOutput.Font = new System.Drawing.Font("Courier New", 9.75F);
            txtOutput.Location = new System.Drawing.Point(0, 0);
            txtOutput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtOutput.Size = new System.Drawing.Size(387, 473);
            txtOutput.TabIndex = 1;
            txtOutput.WordWrap = false;
            txtOutput.DragDrop += txtOutput_DragDrop;
            txtOutput.DragOver += txtOutput_DragOver;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            aboutToolStripMenuItem.Text = "&About...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainWindow";
            Text = "MkBin";
            FormClosing += MainWindow_FormClosing;
            Load += MainWindow_Load;
            Shown += MainWindow_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem autoUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateNowToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtDisassembly;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}