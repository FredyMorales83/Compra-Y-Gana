using AuxiliarUtilities;
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
    public partial class frmApplicationSettings : Form
    {
        public int UserLoguedID { get; set; }
        private Manager _manager;
        private ApplicationSetting _setting;

        public frmApplicationSettings()
        {
            InitializeComponent();
        }

        private void frmApplicationSettings_Load(object sender, EventArgs e)
        {
            try
            {
                _setting = BLL.ApplicationSettingServices.GetDefaultApplicationSetting();
                FillTextBoxSince(_setting);
                _manager = BLL.ManagerServices.GetManagerById(UserLoguedID);
                FillTextBoxSince(_manager);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error del sistema, {ex.GetType().Name}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmApplicationSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnUpdateApplicationSettings_Click(object sender, EventArgs e)
        {
            AssignDataFromTextBox(_setting);
            try
            {
                BLL.ApplicationSettingServices.Update(_setting);
                Properties.Settings.Default.PercentagePoints = _setting.PercentagePoints;
                Properties.Settings.Default.PointValueCash = _setting.PointValueCash;
                Properties.Settings.Default.AllowCashRequest = _setting.AllowCashRequest;
                MessageBox.Show("Configuración actualizada satisfactoriamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error del sistema {ex.GetType().Name}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveRulesConfiguracion_Click(object sender, EventArgs e)
        {
            btnUpdateApplicationSettings_Click(sender, e);
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            _manager = BLL.ManagerServices.GetManagerById(UserLoguedID);

            AssignDataFromTextBox(_manager);
            try
            {
                BLL.ManagerServices.Update(_manager);
                MessageBox.Show("Usuario actualizado satisfactoriamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error del sistema {ex.GetType().Name}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Get and Set Business and User Information
        private void AssignDataFromTextBox(Manager manager)
        {
            manager.Address = txtAddress.Text;
            manager.Cellphone = txtCellphone.Text;
            manager.Email = txtEmail.Text;
            manager.MaternalLastname = txtMaternalLastname.Text;
            manager.Name = txtName.Text;
            manager.PaternalLastname = txtPaternalLastname.Text;
            manager.Phone = txtPhone.Text;
            manager.Login.Username = txtUsername.Text;
            manager.Login.Password = txtPassword.Text;
        }

        private void FillTextBoxSince(Manager manager)
        {
            txtAddress.Text = manager.Address;
            txtCellphone.Text = manager.Cellphone;
            txtEmail.Text = manager.Email;
            txtMaternalLastname.Text = manager.MaternalLastname;
            txtName.Text = manager.Name;
            txtPaternalLastname.Text = manager.PaternalLastname;
            txtPhone.Text = manager.Phone;
            txtUsername.Text = manager.Login.Username;
            txtPassword.Text = RegexUtilities.PasswordDecrypt(manager.Login.Password);
        }

        private void AssignDataFromTextBox(ApplicationSetting setting)
        {
            setting.BusinessAddress = txtBusinessAddress.Text;
            setting.BusinessWebsite = txtWebsite.Text;
            setting.BusinessEmail = txtBusinessEmail.Text;
            setting.BusinessName = txtBusinessName.Text;
            setting.BusinessPhone = txtBusinessPhone.Text;
            setting.BusinessAnniversary = dtpBusinessAnniversary.Value;
            setting.PercentagePoints = nudPercentagePoints.Value;
            setting.PointValueCash = nudPointValueCash.Value;
            setting.RewardDoublePointsOnBusinessAnniversary = chxRewardDoublePointsOnBusinessAnniversary.Checked;
            setting.RewardDoublePointsOnCustomerAnniversary = chxRewardDoublePointsOnCustomerAnniversary.Checked;
            setting.AllowCashRequest = chxAllowCashRequest.Checked;
        }

        private void FillTextBoxSince(ApplicationSetting setting)
        {
            txtBusinessAddress.Text = setting.BusinessAddress;
            txtWebsite.Text = setting.BusinessWebsite;
            txtBusinessEmail.Text = setting.BusinessEmail;
            txtBusinessName.Text = setting.BusinessName;
            txtBusinessPhone.Text = setting.BusinessPhone;
            dtpBusinessAnniversary.Value = setting.BusinessAnniversary;
            nudPercentagePoints.Value = setting.PercentagePoints;
            nudPointValueCash.Value = setting.PointValueCash;
            chxRewardDoublePointsOnBusinessAnniversary.Checked = setting.RewardDoublePointsOnBusinessAnniversary;
            chxRewardDoublePointsOnCustomerAnniversary.Checked = setting.RewardDoublePointsOnCustomerAnniversary;
            chxAllowCashRequest.Checked = setting.AllowCashRequest;
        }
        #endregion

    }
}
