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
    public partial class frmContactForm : Form
    {
        public enum ContactReason
        {
            CommentOrSuggestion,
            SuggestFunctionality,
            ErrorNotification
        }

        public frmContactForm(ContactReason reason)
        {
            InitializeComponent();
            cbxContactReason.SelectedIndex = (int)reason;
        }

        private void btnSendCommentsOrSuggestions_Click(object sender, EventArgs e)
        {
            try
            {
                throw new NotImplementedException("Funcionalidad no implementada");
                //Pendiente: Enviar email al correo de la empresa con datos del formulario de contacto
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error del sistema {ex.GetType().ToString()}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }  
        }
    }
}
