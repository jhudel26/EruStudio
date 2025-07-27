using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EruStudio
{
    public partial class FormFileModifier : Form
    {
        public FormFileModifier()
        {
            InitializeComponent();

            btnbrows.Click += btnbrows_Click;
            dltemplate.Click += dltemplate_Click;
            imtemplate.Click += imtemplate_Click;
            bntRun.Click += bntRun_Click;
            chkfiles.CheckedChanged += chkfiles_CheckedChanged;
            chkfolders.CheckedChanged += chkfolders_CheckedChanged;
            this.Load += FormFileModifier_Load;

            lblStatus.BackColor = System.Drawing.Color.Transparent;
            lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
            lblStatus.Visible = false;
            progressBar1.Visible = false;
        }

        private void FormFileModifier_Load(object sender, EventArgs e)
        {
            cmbAction.Items.AddRange(new[] { "Create", "Rename", "Move", "Zip" });
        }

        private void btnbrows_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtpath.Text = fbd.SelectedPath;
                    ValidateActionOptions();
                }
            }
        }

        private void chkfiles_CheckedChanged(object sender, EventArgs e)
        {
            ValidateActionOptions();
        }

        private void chkfolders_CheckedChanged(object sender, EventArgs e)
        {
            ValidateActionOptions();
        }

        private void ValidateActionOptions()
        {
            bool foldersChecked = chkfolders.Checked;
            bool filesChecked = chkfiles.Checked;

            cmbAction.Items.Clear();
            if (foldersChecked && !filesChecked)
                cmbAction.Items.Add("Create");

            cmbAction.Items.AddRange(new[] { "Rename", "Move", "Zip" });
        }

        private void dltemplate_Click(object sender, EventArgs e)
        {
            if (cmbAction.SelectedItem == null)
            {
                MessageBox.Show("Please select an action.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtpath.Text))
            {
                MessageBox.Show("Please select a folder first.");
                return;
            }

            string action = cmbAction.SelectedItem.ToString();
            string downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            GenerateExcelTemplate(action, downloadFolder);
        }

        private void GenerateExcelTemplate(string action, string downloadPath)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Template");

            // Headers
            ws.Cell("A1").Value = "Files/Folders Name";
            ws.Cell("B1").Value = "Grouping Word (Only if Per File)";
            if (action == "Zip")
            {
                ws.Cell("C1").Value = "Select type of Zip";
            }

            // Format headers
            var headerRange = ws.Range("A1:B1");
            if (action == "Zip")
                headerRange = ws.Range("A1:C1");

            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.Teal;
            headerRange.Style.Font.FontColor = XLColor.White;
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

            if (action == "Zip")
            {
                var c1 = ws.Cell("C1");
                c1.Style.Font.Bold = true;
                c1.Style.Font.FontSize = 14;
                c1.Style.Fill.BackgroundColor = XLColor.DarkCoral;
                c1.Style.Font.FontColor = XLColor.White;
                c1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                c1.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }

            if (action == "Zip")
            {
                var wsDropdown = wb.Worksheets.Add("DropdownOptions");
                wsDropdown.Cell("A1").Value = "Per File";
                wsDropdown.Cell("A2").Value = "Per Folder";
                wsDropdown.Cell("A3").Value = "Whole Documents";
                wsDropdown.Visibility = XLWorksheetVisibility.VeryHidden;

                var dropdownRange = wsDropdown.Range("A1:A3");
                wb.NamedRanges.Add("ZipOptions", dropdownRange);

                var zipDropdown = ws.Cell("C1").CreateDataValidation();
                zipDropdown.IgnoreBlanks = true;
                zipDropdown.InCellDropdown = true;
                zipDropdown.AllowedValues = XLAllowedValues.List;
                zipDropdown.List("=ZipOptions");
            }

            var entries = new List<string>();
            if (chkfiles.Checked && Directory.Exists(txtpath.Text))
            {
                entries.AddRange(Directory.GetFiles(txtpath.Text).Select(Path.GetFileName));
            }
            if (chkfolders.Checked && Directory.Exists(txtpath.Text))
            {
                entries.AddRange(Directory.GetDirectories(txtpath.Text).Select(Path.GetFileName));
            }

            for (int i = 0; i < entries.Count; i++)
            {
                ws.Cell(i + 2, 1).Value = entries[i];
            }

            string fileName = $"Template_{action}.xlsx";
            string filePath = Path.Combine(downloadPath, fileName);

            try
            {
                wb.SaveAs(filePath);
                MessageBox.Show("Template downloaded to: " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving template: " + ex.Message);
            }
        }

        private void imtemplate_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xlsx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txttemplate.Text = ofd.FileName;
                }
            }
        }

        private void bntRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpath.Text) || string.IsNullOrWhiteSpace(txttemplate.Text))
            {
                MessageBox.Show("Please select folder and upload the template file.");
                return;
            }

            string action = cmbAction.SelectedItem?.ToString();
            if (action == null)
            {
                MessageBox.Show("Please select an action.");
                return;
            }

            try
            {
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                lblStatus.Visible = true;
                lblStatus.Text = "Processing...";
                Application.DoEvents();

                ProcessTemplate(txttemplate.Text, action);

                progressBar1.Value = 100;
                lblStatus.Text = "Done!";
                MessageBox.Show("Operation completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                progressBar1.Visible = false;
                lblStatus.Visible = false;
            }
        }

        private void ProcessTemplate(string templatePath, string action)
        {
            var wb = new XLWorkbook(templatePath);
            var ws = wb.Worksheet(1);
            int row = 2;

            var perFileGroups = new Dictionary<string, List<string>>();

            while (!string.IsNullOrWhiteSpace(ws.Cell(row, 1).GetValue<string>()))
            {
                string originalName = ws.Cell(row, 1).GetValue<string>();
                string originalPath = Path.Combine(txtpath.Text, originalName);

                if (action == "Create")
                {
                    Directory.CreateDirectory(originalPath);
                }
                else if (action == "Rename")
                {
                    string newName = ws.Cell(row, 2).GetValue<string>();
                    string newPath = Path.Combine(txtpath.Text, newName);
                    if (chkfiles.Checked && File.Exists(originalPath))
                        File.Move(originalPath, newPath);
                    else if (chkfolders.Checked && Directory.Exists(originalPath))
                        Directory.Move(originalPath, newPath);
                }
                else if (action == "Move")
                {
                    string destFolder = ws.Cell(row, 2).GetValue<string>();
                    string destPath = Path.Combine(destFolder, Path.GetFileName(originalPath));
                    if (chkfiles.Checked && File.Exists(originalPath))
                        File.Move(originalPath, destPath);
                    else if (chkfolders.Checked && Directory.Exists(originalPath))
                        Directory.Move(originalPath, destPath);
                }
                else if (action == "Zip")
                {
                    string zipType = ws.Cell("C1").GetValue<string>();
                    string groupWord = ws.Cell(row, 2).GetValue<string>();

                    if (zipType == "Per File")
                    {
                        if (!perFileGroups.ContainsKey(groupWord))
                            perFileGroups[groupWord] = new List<string>();

                        string fullPath = Path.Combine(txtpath.Text, originalName);
                        if (File.Exists(fullPath))
                            perFileGroups[groupWord].Add(fullPath);
                    }
                    else
                    {
                        HandleZip(originalPath, zipType, groupWord);
                    }
                }

                row++;
            }

            foreach (var group in perFileGroups)
            {
                string zipOutputPath = Path.Combine(txtpath.Text, "ZippedResults");
                Directory.CreateDirectory(zipOutputPath);
                string zipFullPath = Path.Combine(zipOutputPath, group.Key + ".zip");

                using (ZipArchive archive = ZipFile.Open(zipFullPath, ZipArchiveMode.Create))
                {
                    foreach (var file in group.Value)
                    {
                        archive.CreateEntryFromFile(file, Path.GetFileName(file));
                    }
                }
            }
        }

        private void HandleZip(string path, string zipType, string groupWord)
        {
            string zipOutputPath = Path.Combine(txtpath.Text, "ZippedResults");
            Directory.CreateDirectory(zipOutputPath);

            if (zipType == "Per Folder")
            {
                string zipName = Path.GetFileName(path.TrimEnd(Path.DirectorySeparatorChar)) + ".zip";
                string zipFullPath = Path.Combine(zipOutputPath, zipName);
                if (Directory.Exists(path))
                    ZipFile.CreateFromDirectory(path, zipFullPath);
            }
            else if (zipType == "Whole Documents")
            {
                string zipName = "WholeDocuments.zip";
                string zipFullPath = Path.Combine(zipOutputPath, zipName);
                ZipFile.CreateFromDirectory(txtpath.Text, zipFullPath);
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void progressBar1_Click(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
