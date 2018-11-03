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
    public partial class frmLogin : Form
    {
        private int intentos = 0;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals("Usuario"))
            {
                txtUsuario.Text = "";
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals(""))
            {
                txtUsuario.Text = "Usuario";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals("Password"))
            {
                txtPassword.Text = "";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(""))
            {
                txtPassword.Text = "Password";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            intentos++;

            if (intentos < 3)
            {
                try
                {
                    var UserExists = BLL.UserServices.GetUserLogin(txtUsuario.Text.Trim(), txtPassword.Text.Trim());

                    if (UserExists != null)
                    {
                        MessageBox.Show("Bienvenido al sistema", "Autenticación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Properties.Settings.Default.UserID = UserExists.UserID;
                        this.Close();
                    }
                    else
                    {                        
                        throw new ArgumentException("Usuario o contraseña incorrectos, intente de nuevo");
                    }
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show(ex.Message, "Autenticación incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ha realizado demasiados intentos, el sistema se cerrará", "Autenticación incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }            
        }

        private void frmLogin_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    MessageBox.Show("Test");
            //}
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            btnLogin_Click(sender, e);
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
