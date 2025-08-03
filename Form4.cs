using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace EruStudio
{
    public partial class FormFileFinder : Form
    {
        private List<string> searchWords = new List<string>();
        private List<(string name, string type, string path)> results = new List<(string, string, string)>();
        private HashSet<string> matchedWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public FormFileFinder()
        {
            InitializeComponent();

            btnbrows.Click += btnbrows_Click;
            imtemplate.Click += imtemplate_Click;
            btnCopyto.Click += btnCopyto_Click;
            bntfind.Click += bntfind_Click;
            btndownload.Click += btndownload_Click;
            btnexport.Click += btnexport_Click;
        }

        private void FormFileFinder_Load(object sender, EventArgs e)
        {
            Progresult.ReadOnly = true;
            Progresult.ScrollBars = ScrollBars.Vertical;
        }

        private void LogProgress(string message)
        {
            if (Progresult.InvokeRequired)
            {
                Progresult.Invoke(new Action(() =>
                {
                    Progresult.AppendText(message + Environment.NewLine);
                    Progresult.ScrollToCaret();
                }));
            }
            else
            {
                Progresult.AppendText(message + Environment.NewLine);
                Progresult.ScrollToCaret();
            }
        }

        private void btnbrows_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    txtpath.Text = dialog.SelectedPath;
            }
        }

        private void imtemplate_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Excel Files|*.xlsx";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txttemplate.Text = dialog.FileName;
                    LoadSearchWords(dialog.FileName);
                }
            }
        }

        private void LoadSearchWords(string filePath)
        {
            searchWords.Clear();
            using (var workbook = new XLWorkbook(filePath))
            {
                var ws = workbook.Worksheet(1);
                foreach (var cell in ws.Column(1).CellsUsed())
                {
                    if (!string.IsNullOrWhiteSpace(cell.GetString()))
                        searchWords.Add(cell.GetString().Trim());
                }
            }

            LogProgress("✅ Loaded " + searchWords.Count + " search terms.");
        }

        private void btnCopyto_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    txtto.Text = dialog.SelectedPath;
            }
        }

        private void bntfind_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtpath.Text) || !File.Exists(txttemplate.Text) || !Directory.Exists(txtto.Text))
            {
                MessageBox.Show("⚠️ Please complete all selections before starting the search.");
                return;
            }

            results.Clear();
            matchedWords.Clear();
            Progresult.Clear();

            // ✅ Make inputs read-only before processing
            txtpath.ReadOnly = true;
            txttemplate.ReadOnly = true;
            txtto.ReadOnly = true;

            Task.Run(() => StartSearch(txtpath.Text));
        }

        private void StartSearch(string rootPath)
        {
            LogProgress("🔍 Starting search...");

            var files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);
            var folders = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            if (chkfolders.Checked)
            {
                foreach (var folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    LogProgress("📁 Checking folder: " + name);
                    bool found = false;

                    foreach (string word in searchWords)
                    {
                        if (name.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            LogProgress($"✅ Match found (Folder): {name}");
                            CopyItem(folder, "Folder");
                            matchedWords.Add(word);
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        LogProgress($"❌ Nothing found in folder: {name}");
                    }
                }
            }

            if (chkfiles.Checked)
            {
                foreach (var file in files)
                {
                    string name = Path.GetFileName(file);
                    LogProgress("📄 Checking file: " + name);
                    bool match = false;

                    foreach (string word in searchWords)
                    {
                        if (name.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            LogProgress($"✅ Name match: {name}");
                            matchedWords.Add(word);
                            match = true;
                            break;
                        }
                    }

                    if (!match && Path.GetExtension(file).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        LogProgress($"🔎 Extracting text from PDF: {name}");
                        string text = ExtractPdfText(file);
                        foreach (string word in searchWords)
                        {
                            if (text.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                LogProgress($"✅ PDF content match: {name}");
                                matchedWords.Add(word);
                                match = true;
                                break;
                            }
                        }
                    }

                    if (match)
                    {
                        CopyItem(file, "File");
                    }
                    else
                    {
                        LogProgress($"❌ Nothing found in file: {name}");
                    }
                }
            }

            LogProgress("🎉 Done searching!");

            // ✅ Re-enable inputs after search completes
            this.Invoke(new Action(() =>
            {
                txtpath.ReadOnly = false;
                txttemplate.ReadOnly = false;
                txtto.ReadOnly = false;
            }));
        }

        private string ExtractPdfText(string pdfPath)
        {
            string tempTxt = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".txt");
            string args = $"\"{pdfPath}\" \"{tempTxt}\"";

            ProcessStartInfo psi = new ProcessStartInfo("C:\\tools\\pdftotext.exe", args)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(psi).WaitForExit();

            string content = File.Exists(tempTxt) ? File.ReadAllText(tempTxt) : "";
            File.Delete(tempTxt);
            return content;
        }

        private void CopyItem(string path, string type)
        {
            string dest = Path.Combine(txtto.Text, Path.GetFileName(path));

            try
            {
                if (type == "File")
                    File.Copy(path, dest, true);
                else if (type == "Folder")
                    CopyFolder(path, dest);

                results.Add((Path.GetFileName(path), type, path));

                LogProgress($"✔ Copied: {path}");
            }
            catch (Exception ex)
            {
                LogProgress($"❌ Error copying {path} - {ex.Message}");
            }
        }

        private void CopyFolder(string source, string destination)
        {
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            foreach (var file in Directory.GetFiles(source))
                File.Copy(file, Path.Combine(destination, Path.GetFileName(file)), true);

            foreach (var dir in Directory.GetDirectories(source))
                CopyFolder(dir, Path.Combine(destination, Path.GetFileName(dir)));
        }

        private void btndownload_Click(object sender, EventArgs e)
        {
            if (results.Count == 0 && searchWords.Count == 0)
            {
                MessageBox.Show("No results to export.");
                return;
            }

            using (SaveFileDialog save = new SaveFileDialog() { Filter = "Excel Files|*.xlsx" })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (var wb = new XLWorkbook())
                    {
                        var ws = wb.AddWorksheet("Results");
                        ws.Cell(1, 1).Value = "Name / Search Word";
                        ws.Cell(1, 2).Value = "Type";
                        ws.Cell(1, 3).Value = "Full Path or Note";

                        int row = 2;

                        foreach (var res in results)
                        {
                            ws.Cell(row, 1).Value = res.name;
                            ws.Cell(row, 2).Value = res.type;
                            ws.Cell(row, 3).Value = res.path;
                            row++;
                        }

                        var notMatched = searchWords.Where(word => !matchedWords.Contains(word));
                        foreach (var word in notMatched)
                        {
                            ws.Cell(row, 1).Value = word;
                            ws.Cell(row, 2).Value = "Not Found";
                            ws.Cell(row, 3).Value = "No file/folder found for this search term";
                            row++;
                        }

                        wb.SaveAs(save.FileName);
                    }

                    LogProgress("💾 Excel file saved!");
                }
            }
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Title = "Export Search Template";
                save.Filter = "Excel Files|*.xlsx";
                save.FileName = "SearchTemplate.xlsx";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var wb = new XLWorkbook())
                        {
                            var ws = wb.AddWorksheet("Template");
                            ws.Cell("A1").Value = "Search Word";
                            ws.Columns().AdjustToContents();
                            wb.SaveAs(save.FileName);
                        }

                        LogProgress("📄 Template exported to: " + save.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("❌ Failed to export template.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txttemplate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
