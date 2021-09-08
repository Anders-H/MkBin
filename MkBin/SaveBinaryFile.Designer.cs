
namespace MkBin
{
    partial class SaveBinaryFile
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
            this.lblCompile = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtTargetFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkRunIfSuccessful = new System.Windows.Forms.CheckBox();
            this.txtRunIfSuccessful = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCompile
            // 
            this.lblCompile.AutoSize = true;
            this.lblCompile.Location = new System.Drawing.Point(12, 12);
            this.lblCompile.Name = "lblCompile";
            this.lblCompile.Size = new System.Drawing.Size(55, 15);
            this.lblCompile.TabIndex = 0;
            this.lblCompile.Text = "Compile:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(472, 23);
            this.textBox1.TabIndex = 1;
            // 
            // txtTargetFile
            // 
            this.txtTargetFile.Location = new System.Drawing.Point(12, 72);
            this.txtTargetFile.Name = "txtTargetFile";
            this.txtTargetFile.Size = new System.Drawing.Size(472, 23);
            this.txtTargetFile.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Target file:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(240, 176);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(324, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(408, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkRunIfSuccessful
            // 
            this.chkRunIfSuccessful.AutoSize = true;
            this.chkRunIfSuccessful.Location = new System.Drawing.Point(12, 103);
            this.chkRunIfSuccessful.Name = "chkRunIfSuccessful";
            this.chkRunIfSuccessful.Size = new System.Drawing.Size(117, 19);
            this.chkRunIfSuccessful.TabIndex = 4;
            this.chkRunIfSuccessful.Text = "Run if successful:";
            this.chkRunIfSuccessful.UseVisualStyleBackColor = true;
            this.chkRunIfSuccessful.CheckedChanged += new System.EventHandler(this.chkRunIfSuccessful_CheckedChanged);
            // 
            // txtRunIfSuccessful
            // 
            this.txtRunIfSuccessful.Enabled = false;
            this.txtRunIfSuccessful.Location = new System.Drawing.Point(12, 120);
            this.txtRunIfSuccessful.Name = "txtRunIfSuccessful";
            this.txtRunIfSuccessful.Size = new System.Drawing.Size(472, 23);
            this.txtRunIfSuccessful.TabIndex = 5;
            // 
            // SaveBinaryFile
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(496, 210);
            this.Controls.Add(this.txtRunIfSuccessful);
            this.Controls.Add(this.chkRunIfSuccessful);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtTargetFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCompile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveBinaryFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save binary file";
            this.Load += new System.EventHandler(this.SaveBinaryFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtTargetFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkRunIfSuccessful;
        private System.Windows.Forms.TextBox txtRunIfSuccessful;
    }
}