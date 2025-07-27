namespace EruStudio
{
    partial class FormFileFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileFinder));
            this.btnbrows = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.imtemplate = new System.Windows.Forms.Button();
            this.txttemplate = new System.Windows.Forms.TextBox();
            this.Progresult = new System.Windows.Forms.TextBox();
            this.btndownload = new System.Windows.Forms.Button();
            this.btnCopyto = new System.Windows.Forms.Button();
            this.txtto = new System.Windows.Forms.TextBox();
            this.chkfolders = new System.Windows.Forms.CheckBox();
            this.chkfiles = new System.Windows.Forms.CheckBox();
            this.bntfind = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnbrows
            // 
            this.btnbrows.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrows.Location = new System.Drawing.Point(25, 30);
            this.btnbrows.Name = "btnbrows";
            this.btnbrows.Size = new System.Drawing.Size(134, 38);
            this.btnbrows.TabIndex = 2;
            this.btnbrows.Text = "📁 Select Folder";
            this.btnbrows.UseVisualStyleBackColor = true;
            // 
            // txtpath
            // 
            this.txtpath.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpath.Location = new System.Drawing.Point(165, 35);
            this.txtpath.Name = "txtpath";
            this.txtpath.ReadOnly = true;
            this.txtpath.Size = new System.Drawing.Size(316, 29);
            this.txtpath.TabIndex = 3;
            // 
            // imtemplate
            // 
            this.imtemplate.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imtemplate.Location = new System.Drawing.Point(25, 81);
            this.imtemplate.Name = "imtemplate";
            this.imtemplate.Size = new System.Drawing.Size(166, 33);
            this.imtemplate.TabIndex = 9;
            this.imtemplate.Text = "📥 Import Template";
            this.imtemplate.UseVisualStyleBackColor = true;
            // 
            // txttemplate
            // 
            this.txttemplate.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttemplate.Location = new System.Drawing.Point(197, 80);
            this.txttemplate.Name = "txttemplate";
            this.txttemplate.ReadOnly = true;
            this.txttemplate.Size = new System.Drawing.Size(284, 33);
            this.txttemplate.TabIndex = 10;
            // 
            // Progresult
            // 
            this.Progresult.Location = new System.Drawing.Point(25, 205);
            this.Progresult.Multiline = true;
            this.Progresult.Name = "Progresult";
            this.Progresult.ReadOnly = true;
            this.Progresult.Size = new System.Drawing.Size(456, 94);
            this.Progresult.TabIndex = 11;
            // 
            // btndownload
            // 
            this.btndownload.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndownload.Location = new System.Drawing.Point(315, 315);
            this.btndownload.Name = "btndownload";
            this.btndownload.Size = new System.Drawing.Size(166, 33);
            this.btndownload.TabIndex = 12;
            this.btndownload.Text = "💾 Download Result";
            this.btndownload.UseVisualStyleBackColor = true;
            // 
            // btnCopyto
            // 
            this.btnCopyto.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyto.Location = new System.Drawing.Point(25, 126);
            this.btnCopyto.Name = "btnCopyto";
            this.btnCopyto.Size = new System.Drawing.Size(166, 33);
            this.btnCopyto.TabIndex = 13;
            this.btnCopyto.Text = "📁 Copy Files To";
            this.btnCopyto.UseVisualStyleBackColor = true;
            // 
            // txtto
            // 
            this.txtto.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtto.Location = new System.Drawing.Point(197, 125);
            this.txtto.Name = "txtto";
            this.txtto.ReadOnly = true;
            this.txtto.Size = new System.Drawing.Size(284, 33);
            this.txtto.TabIndex = 14;
            // 
            // chkfolders
            // 
            this.chkfolders.AutoSize = true;
            this.chkfolders.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkfolders.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkfolders.Location = new System.Drawing.Point(91, 168);
            this.chkfolders.Name = "chkfolders";
            this.chkfolders.Size = new System.Drawing.Size(83, 25);
            this.chkfolders.TabIndex = 16;
            this.chkfolders.Text = "Folders";
            this.chkfolders.UseVisualStyleBackColor = true;
            // 
            // chkfiles
            // 
            this.chkfiles.AutoSize = true;
            this.chkfiles.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkfiles.Location = new System.Drawing.Point(25, 168);
            this.chkfiles.Name = "chkfiles";
            this.chkfiles.Size = new System.Drawing.Size(61, 25);
            this.chkfiles.TabIndex = 15;
            this.chkfiles.Text = "Files";
            this.chkfiles.UseVisualStyleBackColor = true;
            // 
            // bntfind
            // 
            this.bntfind.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntfind.Location = new System.Drawing.Point(25, 315);
            this.bntfind.Name = "bntfind";
            this.bntfind.Size = new System.Drawing.Size(149, 33);
            this.bntfind.TabIndex = 17;
            this.bntfind.Text = "🔎 Run Finder";
            this.bntfind.UseVisualStyleBackColor = true;
            // 
            // btnexport
            // 
            this.btnexport.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexport.Location = new System.Drawing.Point(208, 168);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(166, 33);
            this.btnexport.TabIndex = 18;
            this.btnexport.Text = "📤 Export Template";
            this.btnexport.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(487, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 336);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "HOW TO USE 💡";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(11, 63);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(284, 253);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // FormFileFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(797, 402);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.bntfind);
            this.Controls.Add(this.chkfolders);
            this.Controls.Add(this.chkfiles);
            this.Controls.Add(this.btnCopyto);
            this.Controls.Add(this.txtto);
            this.Controls.Add(this.btndownload);
            this.Controls.Add(this.Progresult);
            this.Controls.Add(this.imtemplate);
            this.Controls.Add(this.txttemplate);
            this.Controls.Add(this.btnbrows);
            this.Controls.Add(this.txtpath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFileFinder";
            this.Text = "File Finder";
            this.Load += new System.EventHandler(this.FormFileFinder_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnbrows;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Button imtemplate;
        private System.Windows.Forms.TextBox txttemplate;
        private System.Windows.Forms.TextBox Progresult;
        private System.Windows.Forms.Button btndownload;
        private System.Windows.Forms.Button btnCopyto;
        private System.Windows.Forms.TextBox txtto;
        private System.Windows.Forms.CheckBox chkfolders;
        private System.Windows.Forms.CheckBox chkfiles;
        private System.Windows.Forms.Button bntfind;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}