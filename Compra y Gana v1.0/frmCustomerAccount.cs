using Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compra_y_Gana_v1._0
{
    public partial class frmCustomerAccount : Form
    {
        private Customer customer { get; set; }
        private AccountDetailsViewModel accountDetails;
        private int MonthPeriod;

        public frmCustomerAccount(Customer customer)
        {
            InitializeComponent();
            FillTextBoxSince(customer);
            this.customer = customer;

            accountDetails = BLL.AccountServices.GetAccountDetails(customer);

            var account = BLL.AccountServices.FindById(customer.CustomerID);
            txtAccumulatedPoints.Text = accountDetails.AccumulatedPoints.ToString();
            txtCashEquivalents.Text = accountDetails.CashEquivalent.ToString("C4");
        }        

        private void frmCustomerAccount_Load(object sender, EventArgs e)
        {
            cbxPeriod.SelectedIndex = 0;
            txtCurrentMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
        }

        private void GetAccountTransactionsByPeriod(DateTime date)
        {
            try
            {
                var movements = from t in accountDetails.Transactions where (t.TransactionDate.Month == date.Month && t.TransactionDate.Year == date.Year) 
                                select new TransactionViewModel { ID = t.TransactionID, Fecha = t.TransactionDate, Descripcion =  t.Description, Transaccion = TranslateTransactionType(t.TransactionType), Monto = t.Amount.ToString("C2"), Notas = t.Notes };

                dgvTransactions.DataSource = movements.ToList();                
                dgvTransactions.Columns["Notas"].Visible = false;
                dgvTransactions.Columns["ID"].Visible = false;
                dgvTransactions.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error del sistema {ex.GetType().Name}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TranslateTransactionType(TransactionType transactionType)
        {
            switch (transactionType)
            {
                case TransactionType.Purchase:
                    return "Compra";
                case TransactionType.Expense:
                    return "Gasto";
                case TransactionType.Withdrawal:
                    return "Retiro";
                case TransactionType.Adjustment:
                    return "Ajuste";
                default:
                    throw new TypeAccessException("Tipo de transacción desconocida");
            }
        }

        private void cbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxPeriod.SelectedIndex == 0)
                {
                    GetAccountTransactionsByPeriod(DateTime.Now);
                    txtPeriodo.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                }
                else
                {
                    //Condicion para corregir excepcion lanzada en cambio de año y elegir periodo anterior
                    MonthPeriod = DateTime.Now.AddMonths(-1).Month;
                    txtPeriodo.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MonthPeriod);
                    GetAccountTransactionsByPeriod(DateTime.Now.AddMonths(-1));
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, $"Error del sistema {ex.GetType().Name}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillTextBoxSince(Customer customer)
        {
            txtCustomerAddress.Text = customer.Address;
            txtEmail.Text = customer.Email;
            txtCustomerFullname.Text = customer.ToString();
            txtAccountNumber.Text = customer.CustomerID.ToString();
        }

        private void frmCustomerAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dgvTransactions_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var transaccion = dgvTransactions.CurrentRow.DataBoundItem as TransactionViewModel;

            frmTransactions frm = new frmTransactions(customer, transaccion.ID);
            frm.ShowDialog();
        }
    }
}
