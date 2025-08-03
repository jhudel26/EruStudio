using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EruStudio
{
    public partial class EruStudio : Form
    {
        private Panel panelWelcome;

        public EruStudio()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

            // Create the MenuStrip
            MenuStrip menuStrip = new MenuStrip();

            // Create main menu items
            ToolStripMenuItem menuHome = new ToolStripMenuItem("🏠 Home");
            ToolStripMenuItem menuExcel = new ToolStripMenuItem("📚 Excel Consolidator");
            ToolStripMenuItem menuModifier = new ToolStripMenuItem("📝 File Modifier");
            ToolStripMenuItem menuFinder = new ToolStripMenuItem("🔎 File Finder");

            // Create submenu for File Modifier
            ToolStripMenuItem menuPdfRenamer = new ToolStripMenuItem("📄 PDF File Renamer");
            menuPdfRenamer.Click += MenuPdfRenamer_Click;

            // Add submenu to File Modifier
            menuModifier.DropDownItems.Add(menuPdfRenamer);

            // 🔥 Enable hover to open submenu
            menuModifier.MouseEnter += (s, e) =>
            {
                menuModifier.ShowDropDown();
            };

            // Attach click events
            menuHome.Click += MenuHome_Click;
            menuExcel.Click += MenuExcel_Click;
            menuModifier.Click += MenuModifier_Click;
            menuFinder.Click += MenuFinder_Click;

            // Add menu items to the MenuStrip
            menuStrip.Items.Add(menuHome);
            menuStrip.Items.Add(menuExcel);
            menuStrip.Items.Add(menuModifier);
            menuStrip.Items.Add(menuFinder);

            // Dock and attach the MenuStrip
            menuStrip.Dock = DockStyle.Top;
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            // Initialize the welcome panel
            InitializeWelcomePanel();
        }

        private void EruStudio_Load(object sender, EventArgs e)
        {
            panelWelcome.Visible = true;
        }

        private void InitializeWelcomePanel()
        {
            panelWelcome = new Panel();
            panelWelcome.Dock = DockStyle.Fill;
            panelWelcome.BackColor = Color.White;
            panelWelcome.Visible = true;

            Label lblTitle = new Label();
            lblTitle.Text = "✅ Welcome to EruStudio";
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Teal;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Height = 95;

            Label lblDescription = new Label();
            lblDescription.Text =
                "📚 Excel Worksheet Consolidation\n" +
                "   • Combine all worksheets from a file based on headers.\n" +
                "   • Automatically convert formulas to static values.\n\n" +
                "📝 File and Folder Modifier\n" +
                "   • Rename, move, or zip files and folders in bulk.\n" +
                "   • Use Excel templates for defining actions.\n\n" +
                "📝 PDF Fil e Auto Renamer\n" +
                "   • Rename, PDF file in bulk Automaticaly.\n" +
                "   • Rename base on the content of the PDF.\n\n" +
                "🔎 File Finder\n" +
                "   • Search folders for files matching keywords or content.\n" +
                "   • Supports recursive search with results summary.";

            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblDescription.ForeColor = Color.Black;
            lblDescription.Dock = DockStyle.Fill;
            lblDescription.TextAlign = ContentAlignment.TopLeft;
            lblDescription.Padding = new Padding(30, 10, 30, 10);

            panelWelcome.Controls.Add(lblDescription);
            panelWelcome.Controls.Add(lblTitle);
            this.Controls.Add(panelWelcome);
        }

        private void MenuHome_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            panelWelcome.Visible = true;
        }

        private void MenuExcel_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormExcelConsolidator());
        }

        private void MenuModifier_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormFileModifier());
        }

        private void MenuFinder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormFileFinder());
        }

        private void MenuPdfRenamer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new pdfrenamer());
        }

        private void OpenChildForm(Form childForm)
        {
            if (panelWelcome != null)
                panelWelcome.Visible = false;

            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            childForm.MdiParent = this;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional
        }
    }
}
