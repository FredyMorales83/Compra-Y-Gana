using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compra_y_Gana_v1._0
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin  frm = new frmLogin();
            frm.ShowDialog();

            if (Properties.Settings.Default.UserID == 0)
            {
                Application.Exit();
            }

            //Cargar configuración del sistema de lealtad para las transacciones
            ApplicationSetting setting = BLL.ApplicationSettingServices.GetDefaultApplicationSetting();

            Properties.Settings.Default.PercentagePoints = setting.PercentagePoints;
            Properties.Settings.Default.PointValueCash = setting.PointValueCash;
            Properties.Settings.Default.AllowCashRequest = setting.AllowCashRequest;
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerList frm = new frmCustomerList
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationSettings frm = new frmApplicationSettings();

            frm.UserLoguedID = Properties.Settings.Default.UserID;
            
            frm.ShowDialog();
        }

        private void proporcionarUnaSugerenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContactForm frm = new frmContactForm(frmContactForm.ContactReason.CommentOrSuggestion);
            frm.ShowDialog();
        }

        private void sugerirFuncionalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContactForm frm = new frmContactForm(frmContactForm.ContactReason.SuggestFunctionality);
            frm.ShowDialog();
        }

        private void notificarUnErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContactForm frm = new frmContactForm(frmContactForm.ContactReason.ErrorNotification);
            frm.ShowDialog();
        }
    }
}
