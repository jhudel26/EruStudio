using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            // Create menu items
            ToolStripMenuItem menuHome = new ToolStripMenuItem("🏠 Home");
            ToolStripMenuItem menuExcel = new ToolStripMenuItem("📚 Excel Consolidator");
            ToolStripMenuItem menuModifier = new ToolStripMenuItem("📝 File Modifier");
            ToolStripMenuItem menuFinder = new ToolStripMenuItem("🔎 File Finder");

            // Add click event handlers
            menuHome.Click += MenuHome_Click;
            menuExcel.Click += MenuExcel_Click;
            menuModifier.Click += MenuModifier_Click;
            menuFinder.Click += MenuFinder_Click;

            // Add items to the MenuStrip
            menuStrip.Items.Add(menuHome);
            menuStrip.Items.Add(menuExcel);
            menuStrip.Items.Add(menuModifier);
            menuStrip.Items.Add(menuFinder);

            // Dock to top and add to form
            menuStrip.Dock = DockStyle.Top;
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            // Initialize Welcome Panel
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
            lblTitle.Height = 110;

            Label lblDescription = new Label();
            lblDescription.Text =
                "📚 Excel Worksheet Consolidation\n" +
                "   • Combine all worksheets from a file based on headers.\n" +
                "   • Automatically convert formulas to static values.\n\n" +
                "📝 File and Folder Modifier\n" +
                "   • Rename, move, or zip files and folders in bulk.\n" +
                "   • Use Excel templates for defining actions.\n\n" +
                "🔎 File Finder\n" +
                "   • Search folders for files matching keywords or content.\n" +
                "   • Supports recursive search with results summary.";

            lblDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
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
            // Close all child forms
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

        private void OpenChildForm(Form childForm)
        {
            // Hide welcome panel if visible
            if (panelWelcome != null)
                panelWelcome.Visible = false;

            // Close existing child forms
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            childForm.MdiParent = this;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Show();
        }
    }
}
