using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;

namespace Compra_y_Gana_v1._0
{
    public partial class frmNewOrUpdateCustomer : Form
    {
        private Customer customer = null;
        private bool IsNewCustomer;

        public frmNewOrUpdateCustomer()
        {
            InitializeComponent();
        }

        public frmNewOrUpdateCustomer(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            FillTextBoxSince(customer);
            txtUsername.ReadOnly = true;
        }        

        private void frmNewOrUpdateCustomer_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            //Registrar cliente en la BD
            if (customer == null)
            {
                IsNewCustomer = true;
                customer = new Customer();
                
                AssignDataFromTextBox(customer);

                try
                {
                    //Creo al cliente e inmediatamente creo su cuenta correspondiente
                    BLL.CustomerServices.AddNew(customer);

                    if (customer.CustomerID !=0)
                    {
                        BLL.AccountServices.NewAccount(new Account { CustomerID = customer.CustomerID, Active = true, CurrentPointsBalance = 0, CreatedDate = customer.CreatedDate });
                    }

                    MessageBox.Show("Cliente agregado satisfactoriamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else//Actualizar cliente en la BD
            {
                try
                {
                    IsNewCustomer = false;
                    AssignDataFromTextBox(customer);
                    BLL.CustomerServices.Update(customer);
                    MessageBox.Show("Cliente actualizado satisfactoriamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Debe ingresar un nombre");
                txtName.Focus();
                return false;
            }
            errorProvider1.SetError(txtName, "");

            if (string.IsNullOrEmpty(txtPaternalLastname.Text))
            {
                errorProvider1.SetError(txtPaternalLastname, "Debe ingresar el apellido paterno");
                txtPaternalLastname.Focus();
                return false;
            }
            errorProvider1.SetError(txtPaternalLastname, "");

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Debe ingresar un nombre de usuario");
                txtUsername.Focus();
                return false;
            }
            errorProvider1.SetError(txtUsername, "");

            if (txtUsername.Text.Length < 5)
            {
                errorProvider1.SetError(txtUsername, "El nombre de usuario debe tener al menos 5 caracteres");
                txtUsername.Focus();
                return false;
            }

            if (BLL.CustomerServices.UsernameExists(txtUsername.Text) && IsNewCustomer)
            {
                errorProvider1.SetError(txtUsername, "El nombre de usuario ya existe, elija uno diferente");
                txtUsername.Focus();
                return false;
            }
            errorProvider1.SetError(txtUsername, "");

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Debe ingresar una contraseña");
                txtPassword.Focus();
                return false;
            }
            errorProvider1.SetError(txtPassword, "");

            if (txtPassword.Text.Length < 4)
            {
                errorProvider1.SetError(txtPassword, "La contraseña debe tener al menos 4 caracteres");
                txtPassword.Focus();
                return false;
            }
            errorProvider1.SetError(txtPassword, "");

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                RegexUtilities regexUtilities = new RegexUtilities();

                if (!regexUtilities.IsValidEmail(txtEmail.Text))
                {
                    errorProvider1.SetError(txtEmail, "Ingrese un correo válido");
                    txtEmail.Focus();
                    return false;
                }

                errorProvider1.SetError(txtEmail, "");
            }

            return true;
        }

        private void AssignDataFromTextBox(Customer customer)
        {
            customer.Address = txtAddress.Text;
            customer.Cellphone = txtCellphone.Text;
            customer.Email = txtEmail.Text;
            customer.MaternalLastname = txtMaternalLastname.Text;
            customer.Names = txtName.Text;
            customer.Nickname = txtNickname.Text;
            customer.Password = txtPassword.Text;
            customer.PaternalLastname = txtPaternalLastname.Text;
            customer.Phone = txtPhone.Text;
            customer.Username = txtUsername.Text;
        }

        private void FillTextBoxSince(Customer customer)
        {
            txtAddress.Text = customer.Address;
            txtCellphone.Text = customer.Cellphone;
            txtEmail.Text = customer.Email;
            txtMaternalLastname.Text = customer.MaternalLastname;
            txtName.Text = customer.Names;
            txtNickname.Text = customer.Nickname;
            txtPassword.Text = customer.Password;
            txtPaternalLastname.Text = customer.PaternalLastname;
            txtPhone.Text = customer.Phone;
            txtUsername.Text = customer.Username;
        }
    }
}
