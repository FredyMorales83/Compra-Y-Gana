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
        private User user;
        private ApplicationSetting setting;

        public frmApplicationSettings()
        {
            InitializeComponent();
        }

        private void frmApplicationSettings_Load(object sender, EventArgs e)
        {
            try
            {
                setting = BLL.ApplicationSettingServices.GetDefaultApplicationSetting();
                FillTextBoxSince(setting);
                user = BLL.UserServices.GetUserById(UserLoguedID);
                FillTextBoxSince(user);
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
            AssignDataFromTextBox(setting);
            try
            {
                BLL.ApplicationSettingServices.Update(setting);
                Properties.Settings.Default.PercentagePoints = setting.PercentagePoints;
                Properties.Settings.Default.PointValueCash = setting.PointValueCash;
                Properties.Settings.Default.AllowCashRequest = setting.AllowCashRequest;
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
            AssignDataFromTextBox(user);
            try
            {
                BLL.UserServices.Update(user);
                MessageBox.Show("Usuario actualizado satisfactoriamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error del sistema {ex.GetType().Name}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Get and Set Business and User Information
        private void AssignDataFromTextBox(User user)
        {
            user.Address = txtAddress.Text;
            user.Cellphone = txtCellphone.Text;
            user.Email = txtEmail.Text;
            user.MaternalLastname = txtMaternalLastname.Text;
            user.Name = txtName.Text;
            user.Password = txtPassword.Text;
            user.PaternalLastname = txtPaternalLastname.Text;
            user.Phone = txtPhone.Text;
            user.Username = txtUsername.Text;
        }

        private void FillTextBoxSince(User user)
        {
            txtAddress.Text = user.Address;
            txtCellphone.Text = user.Cellphone;
            txtEmail.Text = user.Email;
            txtMaternalLastname.Text = user.MaternalLastname;
            txtName.Text = user.Name;
            txtPassword.Text = user.Password;
            txtPaternalLastname.Text = user.PaternalLastname;
            txtPhone.Text = user.Phone;
            txtUsername.Text = user.Username;
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
