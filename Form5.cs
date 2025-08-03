using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UglyToad.PdfPig;
using ClosedXML.Excel; // Add this for Excel export

namespace EruStudio
{
    public partial class pdfrenamer : Form
    {
        private List<(string OldName, string NewName)> renameLog = new List<(string, string)>(); // Track renamed files

        public pdfrenamer()
        {
            InitializeComponent();
            this.rename.Click += new EventHandler(this.rename_Click);
            this.btndownload.Click += new EventHandler(this.btndownload_Click); // Attach click event
        }

        private void pdfrenamer_Load(object sender, EventArgs e)
        {
            domainUpDown1.SelectedIndex = 0; // Default to first item
        }

        private void btnbrows_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtpath.Text = fbd.SelectedPath;

                    var pdfFiles = Directory.GetFiles(fbd.SelectedPath, "*.pdf");
                    int count = pdfFiles.Length;

                    Progresult.Clear();
                    Progresult.AppendText($"Folder selected: {fbd.SelectedPath}\r\n");
                    Progresult.AppendText($"PDF files found: {count}\r\n");
                }
            }
        }

        private void rename_Click(object sender, EventArgs e)
        {
            Progresult.Clear();
            Progresult.AppendText("Starting rename process...\r\n");

            // Disable inputs during processing
            txtpath.ReadOnly = true;
            txtbefore.ReadOnly = true;
            textafter.ReadOnly = true;
            txtadd.ReadOnly = true;
            domainUpDown1.Enabled = false;
            rename.Enabled = false;

            renameLog.Clear(); // Reset previous log

            string folderPath = txtpath.Text;
            string beforeWord = txtbefore.Text.Trim();
            string afterWord = textafter.Text.Trim();
            int maxPages = int.TryParse(domainUpDown1.Text, out int pages) ? pages : 1;
            string additionalText = txtadd.Text.Trim();

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Invalid folder path.");
                return;
            }

            var pdfFiles = Directory.GetFiles(folderPath, "*.pdf");
            Progresult.AppendText($"PDF files to process: {pdfFiles.Length}\r\n");

            foreach (var filePath in pdfFiles)
            {
                Progresult.AppendText($"Processing: {Path.GetFileName(filePath)}\r\n");

                string extractedName = ExtractNameFromPdf(filePath, beforeWord, afterWord, maxPages);

                if (!string.IsNullOrWhiteSpace(extractedName))
                {
                    string fullName = $"{extractedName} {additionalText}".Trim();
                    string sanitizedName = SanitizeFileName(Regex.Replace(fullName, @"\s+", "_"));
                    string newFilePath = Path.Combine(folderPath, sanitizedName + ".pdf");

                    try
                    {
                        if (!File.Exists(newFilePath))
                        {
                            File.Move(filePath, newFilePath);
                            renameLog.Add((Path.GetFileName(filePath), sanitizedName + ".pdf")); // Log
                            Progresult.AppendText($"Renamed to: {sanitizedName}.pdf\r\n");
                        }
                        else
                        {
                            Progresult.AppendText($"Skipped (already exists): {sanitizedName}.pdf\r\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        Progresult.AppendText($"Error renaming {filePath}: {ex.Message}\r\n");
                    }
                }
                else
                {
                    Progresult.AppendText($"Name not found in: {Path.GetFileName(filePath)}\r\n");
                }
            }

            // Re-enable inputs
            txtpath.ReadOnly = false;
            txtbefore.ReadOnly = false;
            textafter.ReadOnly = false;
            txtadd.ReadOnly = false;
            domainUpDown1.Enabled = true;
            rename.Enabled = true;

            Progresult.AppendText("Done.\r\n");
        }

        private string ExtractNameFromPdf(string filePath, string before, string after, int maxPages)
        {
            try
            {
                using (var document = PdfDocument.Open(filePath))
                {
                    int pagesToRead = Math.Min(maxPages, document.NumberOfPages);

                    for (int i = 1; i <= pagesToRead; i++)
                    {
                        var rawText = document.GetPage(i).Text;

                        // Normalize text for pattern matching
                        string normalized = Regex.Replace(rawText, @"\s+", " ");
                        Progresult.AppendText("----- Extracted Text (normalized) -----\r\n");
                        Progresult.AppendText(normalized + "\r\n");
                        Progresult.AppendText("--------------------------------------\r\n");

                        string pattern = $"{Regex.Escape(before)}\\s+(.*?)\\s+{Regex.Escape(after)}";
                        var match = Regex.Match(normalized, pattern, RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            string name = match.Groups[1].Value.Trim();
                            return name;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Progresult.AppendText($"Error reading {Path.GetFileName(filePath)}: {ex.Message}\r\n");
            }

            return null;
        }

        private string SanitizeFileName(string input)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                input = input.Replace(c, '_');
            }
            return input;
        }

        private void btndownload_Click(object sender, EventArgs e)
        {
            if (renameLog.Count == 0)
            {
                MessageBox.Show("No rename history available to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = "RenameLog.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Rename Log");
                            worksheet.Cell("A1").Value = "Original Filename";
                            worksheet.Cell("B1").Value = "Renamed Filename";

                            for (int i = 0; i < renameLog.Count; i++)
                            {
                                worksheet.Cell(i + 2, 1).Value = renameLog[i].OldName;
                                worksheet.Cell(i + 2, 2).Value = renameLog[i].NewName;
                            }

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Excel file saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
