namespace EruStudio
{
    partial class pdfrenamer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pdfrenamer));
            this.btnbrows = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.txtbefore = new System.Windows.Forms.TextBox();
            this.textafter = new System.Windows.Forms.TextBox();
            this.txtadd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Progresult = new System.Windows.Forms.TextBox();
            this.rename = new System.Windows.Forms.Button();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.btndownload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnbrows
            // 
            this.btnbrows.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrows.Location = new System.Drawing.Point(12, 27);
            this.btnbrows.Name = "btnbrows";
            this.btnbrows.Size = new System.Drawing.Size(134, 38);
            this.btnbrows.TabIndex = 4;
            this.btnbrows.Text = "📁 Select Folder";
            this.btnbrows.UseVisualStyleBackColor = true;
            this.btnbrows.Click += new System.EventHandler(this.btnbrows_Click);
            // 
            // txtpath
            // 
            this.txtpath.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpath.Location = new System.Drawing.Point(152, 32);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(316, 29);
            this.txtpath.TabIndex = 5;
            // 
            // txtbefore
            // 
            this.txtbefore.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbefore.Location = new System.Drawing.Point(12, 104);
            this.txtbefore.Name = "txtbefore";
            this.txtbefore.Size = new System.Drawing.Size(197, 29);
            this.txtbefore.TabIndex = 6;
            // 
            // textafter
            // 
            this.textafter.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textafter.Location = new System.Drawing.Point(215, 104);
            this.textafter.Name = "textafter";
            this.textafter.Size = new System.Drawing.Size(253, 29);
            this.textafter.TabIndex = 7;
            // 
            // txtadd
            // 
            this.txtadd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadd.Location = new System.Drawing.Point(215, 169);
            this.txtadd.Name = "txtadd";
            this.txtadd.Size = new System.Drawing.Size(253, 29);
            this.txtadd.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Before";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "After";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Page Counter";
            // 
            // Progresult
            // 
            this.Progresult.BackColor = System.Drawing.SystemColors.Menu;
            this.Progresult.Location = new System.Drawing.Point(12, 215);
            this.Progresult.Multiline = true;
            this.Progresult.Name = "Progresult";
            this.Progresult.ReadOnly = true;
            this.Progresult.Size = new System.Drawing.Size(453, 112);
            this.Progresult.TabIndex = 13;
            // 
            // rename
            // 
            this.rename.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rename.Location = new System.Drawing.Point(12, 333);
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(149, 33);
            this.rename.TabIndex = 18;
            this.rename.Text = "Rename";
            this.rename.UseVisualStyleBackColor = true;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domainUpDown1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.domainUpDown1.Items.Add("1");
            this.domainUpDown1.Items.Add("2");
            this.domainUpDown1.Items.Add("3");
            this.domainUpDown1.Items.Add("4");
            this.domainUpDown1.Location = new System.Drawing.Point(15, 169);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(194, 29);
            this.domainUpDown1.TabIndex = 0;
            this.domainUpDown1.Text = "0";
            this.domainUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDown1.UseWaitCursor = true;
            // 
            // btndownload
            // 
            this.btndownload.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndownload.Location = new System.Drawing.Point(316, 333);
            this.btndownload.Name = "btndownload";
            this.btndownload.Size = new System.Drawing.Size(149, 33);
            this.btndownload.TabIndex = 19;
            this.btndownload.Text = "Download";
            this.btndownload.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(490, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 32);
            this.label4.TabIndex = 20;
            this.label4.Text = "HOW TO USE 💡";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(484, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 320);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBox1.Location = new System.Drawing.Point(7, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(288, 294);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // pdfrenamer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(797, 402);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btndownload);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.rename);
            this.Controls.Add(this.Progresult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtadd);
            this.Controls.Add(this.textafter);
            this.Controls.Add(this.txtbefore);
            this.Controls.Add(this.btnbrows);
            this.Controls.Add(this.txtpath);
            this.Name = "pdfrenamer";
            this.Text = "PdfRenamer";
            this.Load += new System.EventHandler(this.pdfrenamer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnbrows;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.TextBox txtbefore;
        private System.Windows.Forms.TextBox textafter;
        private System.Windows.Forms.TextBox txtadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Progresult;
        private System.Windows.Forms.Button rename;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Button btndownload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}