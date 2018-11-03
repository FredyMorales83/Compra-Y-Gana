
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
    public partial class frmTransactions : Form
    {
        private Customer customer;
        private decimal currentMoney;
        decimal currentPoints;

        public frmTransactions(Customer customer, TransactionType transactionType)
        {
            InitializeComponent();
            
            this.customer = customer;
            txtCustomer.Text = customer.ToString();
            txtTransactionDate.Text = DateTime.Now.ToLongDateString();
            cbxTransactionType.SelectedIndex = (int)transactionType;
            txtTransactionNumber.Text = Guid.NewGuid().ToString();            
        }

        public frmTransactions(Customer customer, int TransactionID)
        {
            InitializeComponent();
                        
            Transaction transaction = BLL.TransactionServices.GetById(TransactionID);
            this.customer = customer;
            txtCustomer.Text = customer.ToString();
            txtTransactionNumber.Text = transaction.TransactionCode.ToString();
            txtDescription.Text = transaction.Description;
            txtDescription.ReadOnly = true;
            txtNotes.Text = transaction.Notes;
            txtNotes.ReadOnly = true;
            nudAmount.Value = transaction.Amount;
            nudAmount.ReadOnly = true;
            txtTransactionDate.Text = transaction.TransactionDate.ToLongTimeString();
            cbxTransactionType.SelectedIndex = (int)transaction.TransactionType;
            lblPointsInformation.Visible = false;
            btnSaveTransaction.Visible = false;
        }

        private void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            if (!ValideInput())
            {
                return;
            }

            Transaction transaction = new Transaction();

            transaction.CustomerID = customer.CustomerID;
            transaction.TransactionCode = Guid.Parse(txtTransactionNumber.Text);
            transaction.Amount = nudAmount.Value;
            transaction.Description = txtDescription.Text;
            transaction.Notes = txtNotes.Text;
            transaction.UserID = Properties.Settings.Default.UserID;
            transaction.TransactionType = (TransactionType)cbxTransactionType.SelectedIndex;

            try
            {
                Account account = new Account();

                account = BLL.AccountServices.FindById(customer.CustomerID);

                switch (transaction.TransactionType)
                {
                    case TransactionType.Purchase:
                        BLL.TransactionServices.AddNew(transaction);
                        decimal PercentagePoints = Properties.Settings.Default.PercentagePoints / 100;
                        decimal AmountOfPointsToDeposit = transaction.Amount * PercentagePoints;
                        BLL.AccountServices.Deposit(account, AmountOfPointsToDeposit);                        
                        break;
                    case TransactionType.Expense:
                    case TransactionType.Withdrawal:
                        decimal AmountOfPointsToWithdraw = transaction.Amount * Properties.Settings.Default.PointValueCash * 100;
                        BLL.AccountServices.Withdraw(account, AmountOfPointsToWithdraw);                                                                        
                        BLL.TransactionServices.AddNew(transaction);
                        break;
                    case TransactionType.Adjustment:                        
                    default:
                        MessageBox.Show("Tipo de transacción no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                MessageBox.Show("Transacción registrada con éxito, se ha actualizado el estado de cuenta", "Transacción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error {ex.GetType().Name}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }

        private bool ValideInput()
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorProvider1.SetError(txtDescription, "La descripción es necesaria");
                txtDescription.Focus();
                return false;
            }
            errorProvider1.SetError(txtDescription, "");

            if (nudAmount.Value == 0)
            {
                errorProvider1.SetError(nudAmount, "El monto de la transacción debe ser mayor a cero (0)");
                nudAmount.Focus();
                return false;
            }
            errorProvider1.SetError(nudAmount, "");

            return true;
        }

        private void nudAmount_Enter(object sender, EventArgs e)
        {
            nudAmount.Select(0, nudAmount.Value.ToString("N2").Length + 1);
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            try
            {
                Account account = new Account();

                account = BLL.AccountServices.FindById(customer.CustomerID);

                switch ((TransactionType)cbxTransactionType.SelectedIndex)
                {
                    case TransactionType.Purchase:
                        currentPoints = account.CurrentPointsBalance;
                        lblPointsInformation.Text = $"Tiene {currentPoints} puntos, con esta compra acumula ";
                        break;
                    case TransactionType.Expense:
                        currentMoney = account.CurrentPointsBalance * Properties.Settings.Default.PointValueCash;
                        lblPointsInformation.Text = $"Monto disponible para gasto ${currentMoney}";
                        break;
                    case TransactionType.Withdrawal:
                        currentMoney = account.CurrentPointsBalance * Properties.Settings.Default.PointValueCash;
                        lblPointsInformation.Text = $"Monto disponible para retiro ${currentMoney}";
                        break;
                    case TransactionType.Adjustment:
                    default:
                        MessageBox.Show("Tipo de transacción no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error {ex.GetType().Name}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudAmount_ValueChanged(object sender, EventArgs e)
        {
            if (cbxTransactionType.SelectedIndex == (int)TransactionType.Purchase)
            {
                lblPointsInformation.Text = $"Tiene {currentPoints} puntos, con esta compra acumula {(nudAmount.Value * Properties.Settings.Default.PercentagePoints / 100).ToString()} puntos";
            }
        }        
    }
}
