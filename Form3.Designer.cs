namespace EruStudio
{
    partial class FormFileModifier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileModifier));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imtemplate = new System.Windows.Forms.Button();
            this.bntRun = new System.Windows.Forms.Button();
            this.txttemplate = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnbrows = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.dltemplate = new System.Windows.Forms.Button();
            this.chkfolders = new System.Windows.Forms.CheckBox();
            this.chkfiles = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(11, 63);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(284, 289);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "HOW TO USE 💡";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(484, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 362);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Window;
            this.progressBar1.Location = new System.Drawing.Point(12, 338);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(466, 31);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.imtemplate);
            this.groupBox2.Controls.Add(this.bntRun);
            this.groupBox2.Controls.Add(this.txttemplate);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 121);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // imtemplate
            // 
            this.imtemplate.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imtemplate.Location = new System.Drawing.Point(4, 23);
            this.imtemplate.Name = "imtemplate";
            this.imtemplate.Size = new System.Drawing.Size(166, 33);
            this.imtemplate.TabIndex = 6;
            this.imtemplate.Text = "📥 Import Template";
            this.imtemplate.UseVisualStyleBackColor = true;
            // 
            // bntRun
            // 
            this.bntRun.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntRun.Location = new System.Drawing.Point(142, 66);
            this.bntRun.Name = "bntRun";
            this.bntRun.Size = new System.Drawing.Size(194, 44);
            this.bntRun.TabIndex = 7;
            this.bntRun.Text = "📝 Run Modifier";
            this.bntRun.UseVisualStyleBackColor = true;
            // 
            // txttemplate
            // 
            this.txttemplate.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttemplate.Location = new System.Drawing.Point(176, 22);
            this.txttemplate.Name = "txttemplate";
            this.txttemplate.ReadOnly = true;
            this.txttemplate.Size = new System.Drawing.Size(284, 33);
            this.txttemplate.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnbrows);
            this.groupBox1.Controls.Add(this.txtpath);
            this.groupBox1.Controls.Add(this.cmbAction);
            this.groupBox1.Controls.Add(this.dltemplate);
            this.groupBox1.Controls.Add(this.chkfolders);
            this.groupBox1.Controls.Add(this.chkfiles);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 183);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnbrows
            // 
            this.btnbrows.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrows.Location = new System.Drawing.Point(2, 30);
            this.btnbrows.Name = "btnbrows";
            this.btnbrows.Size = new System.Drawing.Size(134, 38);
            this.btnbrows.TabIndex = 0;
            this.btnbrows.Text = "📁 Select Folder";
            this.btnbrows.UseVisualStyleBackColor = true;
            // 
            // txtpath
            // 
            this.txtpath.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpath.Location = new System.Drawing.Point(142, 34);
            this.txtpath.Name = "txtpath";
            this.txtpath.ReadOnly = true;
            this.txtpath.Size = new System.Drawing.Size(318, 29);
            this.txtpath.TabIndex = 1;
            // 
            // cmbAction
            // 
            this.cmbAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(160, 124);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(135, 28);
            this.cmbAction.TabIndex = 4;
            this.cmbAction.Text = "Select Modifier";
            // 
            // dltemplate
            // 
            this.dltemplate.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dltemplate.Location = new System.Drawing.Point(300, 111);
            this.dltemplate.Name = "dltemplate";
            this.dltemplate.Size = new System.Drawing.Size(160, 52);
            this.dltemplate.TabIndex = 5;
            this.dltemplate.Text = "📤 Export Template";
            this.dltemplate.UseVisualStyleBackColor = true;
            // 
            // chkfolders
            // 
            this.chkfolders.AutoSize = true;
            this.chkfolders.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkfolders.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkfolders.Location = new System.Drawing.Point(70, 126);
            this.chkfolders.Name = "chkfolders";
            this.chkfolders.Size = new System.Drawing.Size(83, 25);
            this.chkfolders.TabIndex = 3;
            this.chkfolders.Text = "Folders";
            this.chkfolders.UseVisualStyleBackColor = true;
            // 
            // chkfiles
            // 
            this.chkfiles.AutoSize = true;
            this.chkfiles.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkfiles.Location = new System.Drawing.Point(3, 126);
            this.chkfiles.Name = "chkfiles";
            this.chkfiles.Size = new System.Drawing.Size(61, 25);
            this.chkfiles.TabIndex = 2;
            this.chkfiles.Text = "Files";
            this.chkfiles.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(14, 307);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(6, 2);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "label2";
            this.lblStatus.Visible = false;
            // 
            // FormFileModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(797, 402);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFileModifier";
            this.Text = "File Modifier";
            this.Load += new System.EventHandler(this.FormFileModifier_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button imtemplate;
        private System.Windows.Forms.Button bntRun;
        private System.Windows.Forms.TextBox txttemplate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnbrows;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Button dltemplate;
        private System.Windows.Forms.CheckBox chkfolders;
        private System.Windows.Forms.CheckBox chkfiles;
        private System.Windows.Forms.Label lblStatus;
    }
}