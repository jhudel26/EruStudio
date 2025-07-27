using ClosedXML.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EruStudio
{
    public partial class FormExcelConsolidator : Form
    {
        public FormExcelConsolidator()
        {
            InitializeComponent();
            btnBrowse.Click += BtnBrowse_Click;
            btnConsolidate.Click += BtnConsolidate_Click;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }

        private void BtnConsolidate_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            int headerRow = (int)numHeaderRow.Value;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Please select a valid Excel file.");
                return;
            }

            if (headerRow < 1)
            {
                MessageBox.Show("Please enter a valid header row number (1 or higher).");
                return;
            }

            try
            {
                using (var originalWorkbook = new XLWorkbook(filePath))
                {
                    using (var consolidatedWorkbook = new XLWorkbook())
                    {
                        var consolidatedSheet = consolidatedWorkbook.Worksheets.Add("Consolidated");
                        int outputRow = 1;
                        bool headersCopied = false;
                        string[] baseHeaders = null;

                        foreach (var ws in originalWorkbook.Worksheets)
                        {
                            if (ws.LastRowUsed() == null) continue;

                            int lastCol = ws.LastColumnUsed().ColumnNumber();
                            int lastRow = ws.LastRowUsed().RowNumber();

                            if (headerRow > lastRow)
                                continue;

                            var headerRange = ws.Range(headerRow, 1, headerRow, lastCol);
                            var headers = new string[lastCol];

                            for (int c = 1; c <= lastCol; c++)
                            {
                                headers[c - 1] = ws.Cell(headerRow, c).GetValue<string>().Trim();
                            }

                            if (!headersCopied)
                            {
                                for (int c = 0; c < headers.Length; c++)
                                {
                                    consolidatedSheet.Cell(outputRow, c + 1).Value = headers[c];
                                }
                                baseHeaders = headers;
                                outputRow++;
                                headersCopied = true;
                            }

                            for (int r = headerRow + 1; r <= lastRow; r++)
                            {
                                for (int c = 1; c <= lastCol; c++)
                                {
                                    var cell = ws.Cell(r, c);
                                    var value = cell.HasFormula ? cell.Value : cell.Value;
                                    consolidatedSheet.Cell(outputRow, c).Value = value;
                                }
                                outputRow++;
                            }
                        }

                        string folder = Path.GetDirectoryName(filePath);
                        string baseName = Path.GetFileNameWithoutExtension(filePath);
                        string newFile = Path.Combine(folder, baseName + "_consolidated.xlsx");

                        consolidatedWorkbook.SaveAs(newFile);
                        MessageBox.Show("Consolidated file saved:\n" + newFile, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during consolidation:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {

        }

        private void FormExcelConsolidator_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click_2(object sender, EventArgs e)
        {

        }
    }
    }