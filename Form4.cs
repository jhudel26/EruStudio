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

        public FormFileFinder()
        {
            InitializeComponent();

            // Event bindings
            btnbrows.Click += btnbrows_Click;
            imtemplate.Click += imtemplate_Click;
            btnCopyto.Click += btnCopyto_Click;
            bntfind.Click += bntfind_Click;
            btndownload.Click += btndownload_Click;
            btnexport.Click += btnexport_Click; // ✅ New button
        }

        private void FormFileFinder_Load(object sender, EventArgs e)
        {
            Progresult.ReadOnly = true;
            Progresult.ScrollBars = ScrollBars.Vertical;
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

            Progresult.AppendText("✅ Loaded " + searchWords.Count + " search terms.\r\n");
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
            Progresult.Clear();
            Task.Run(() => StartSearch(txtpath.Text));
        }

        private void StartSearch(string rootPath)
        {
            var files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);
            var folders = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            if (chkfolders.Checked)
            {
                foreach (var folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    foreach (string word in searchWords)
                    {
                        if (name.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            CopyItem(folder, "Folder");
                            break;
                        }
                    }
                }
            }

            if (chkfiles.Checked)
            {
                foreach (var file in files)
                {
                    string name = Path.GetFileName(file);
                    bool match = false;

                    foreach (string word in searchWords)
                    {
                        if (name.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            match = true;
                            break;
                        }
                    }

                    if (!match && Path.GetExtension(file).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        string text = ExtractPdfText(file);
                        foreach (string word in searchWords)
                        {
                            if (text.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                match = true;
                                break;
                            }
                        }
                    }

                    if (match)
                        CopyItem(file, "File");
                }
            }

            this.Invoke(new MethodInvoker(() =>
            {
                Progresult.AppendText("✅ Done searching!\r\n");
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

                this.Invoke(new MethodInvoker(() =>
                {
                    Progresult.AppendText($"✔ Copied: {path}\r\n");
                }));
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    Progresult.AppendText($"❌ Error copying {path} - {ex.Message}\r\n");
                }));
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
            if (results.Count == 0)
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
                        ws.Cell(1, 1).Value = "Name";
                        ws.Cell(1, 2).Value = "Type";
                        ws.Cell(1, 3).Value = "Full Path";

                        int row = 2;
                        foreach (var res in results)
                        {
                            ws.Cell(row, 1).Value = res.name;
                            ws.Cell(row, 2).Value = res.type;
                            ws.Cell(row, 3).Value = res.path;
                            row++;
                        }

                        wb.SaveAs(save.FileName);
                    }

                    Progresult.AppendText("💾 Excel file saved!\r\n");
                }
            }
        }

        // ✅ NEW: Export Template Handler
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

                        Progresult.AppendText("📄 Template exported to: " + save.FileName + "\r\n");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("❌ Failed to export template.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
