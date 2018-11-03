using Models;
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
        public Customer customer { get; set; }
        private int MonthPeriod;

        public frmCustomerAccount(Customer customer)
        {
            InitializeComponent();
            FillTextBoxSince(customer);
            this.customer = customer;

            var account = BLL.AccountServices.FindById(customer.CustomerID);
            txtAccumulatedPoints.Text = account.CurrentPointsBalance.ToString();
            txtCashEquivalents.Text = (account.CurrentPointsBalance * Properties.Settings.Default.PointValueCash).ToString("C4");
        }        

        private void frmCustomerAccount_Load(object sender, EventArgs e)
        {
            cbxPeriod.SelectedIndex = 0;
            txtCurrentMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
        }

        private void GetAccountTransactionsByPeriod(int MonthPeriod)
        {
            try
            {
                ICollection<Transaction> transactions = BLL.TransactionServices.GetAccountTransactions(customer.CustomerID, MonthPeriod);

                var movements = from t in transactions select new TransactionViewModel { ID = t.TransactionID, Fecha = t.TransactionDate, Descripcion =  t.Description, Transaccion = TranslateTransactionType(t.TransactionType), Monto = t.Amount.ToString("C2"), Notas = t.Notes };

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
                case Models.TransactionType.Purchase:
                    return "Compra";
                case Models.TransactionType.Expense:
                    return "Gasto";
                case Models.TransactionType.Withdrawal:
                    return "Retiro";
                case Models.TransactionType.Adjustment:
                    return "Ajuste";
                default:
                    throw new TypeAccessException("Tipo de transacción desconocida");
            }
        }

        private void cbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPeriod.SelectedIndex == 0)
            {
                MonthPeriod = DateTime.Now.Month;
                GetAccountTransactionsByPeriod(MonthPeriod);
                txtPeriodo.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            }
            else
            {
                MonthPeriod = DateTime.Now.Month - 1;
                GetAccountTransactionsByPeriod(MonthPeriod);
                txtPeriodo.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month - 1);
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

    public class TransactionViewModel
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Transaccion { get; set; }
        public string Monto { get; set; }
        public string Notas { get; set; }
    }
}
