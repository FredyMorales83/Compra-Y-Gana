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
    public partial class frmCustomerList : Form
    {
        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            List<Customer> CustomerList = new List<Customer>();

            CustomerList = CustomerServices.GetAll();

            dgvCustomers.DataSource = CustomerList;

            if (CustomerList.Count == 0)
            {
                DisableButtonsWhenNoCustomers(true);
            }
            else
            {
                DisableButtonsWhenNoCustomers(false);
            }

            btnWithdrawal.Visible = Properties.Settings.Default.AllowCashRequest;

            this.WindowState = FormWindowState.Maximized;
        }

        private void DisableButtonsWhenNoCustomers(bool v)
        {
            btnEdit.Enabled = !v;
            btnViewAccount.Enabled = !v;
            gbxTransactions.Enabled = !v;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmNewOrUpdateCustomer frm = new frmNewOrUpdateCustomer();
            
            frm.FormClosed += (s, ev) =>
            {
                frmCustomerList_Load(sender, e);
                this.WindowState = FormWindowState.Maximized;
                this.Show();
            };

            frm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Customer customer = BLL.CustomerServices.FindById(Int32.Parse(dgvCustomers.CurrentRow.Cells["CustomerID"].Value.ToString())); 

            frmNewOrUpdateCustomer frm = new frmNewOrUpdateCustomer(customer);
            frm.Text = "Editar cliente";

            frm.FormClosed += (s, ev) =>
            {
                frmCustomerList_Load(sender, e);
                this.WindowState = FormWindowState.Maximized;
                this.Show();
            };

            frm.ShowDialog();
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            Customer customer = BLL.CustomerServices.FindById(Int32.Parse(dgvCustomers.CurrentRow.Cells["CustomerID"].Value.ToString())); 

            frmCustomerAccount frm = new frmCustomerAccount(customer);
            frm.ShowDialog();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            Customer customer = BLL.CustomerServices.FindById(Int32.Parse(dgvCustomers.CurrentRow.Cells["CustomerID"].Value.ToString())); 

            frmTransactions frm = new frmTransactions(customer, TransactionType.Purchase);
            frm.ShowDialog();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            Customer customer = BLL.CustomerServices.FindById(Int32.Parse(dgvCustomers.CurrentRow.Cells["CustomerID"].Value.ToString()));

            frmTransactions frm = new frmTransactions(customer, TransactionType.Expense);
            frm.ShowDialog();
        }

        private void btnWithdrawal_Click(object sender, EventArgs e)
        {
            Customer customer = BLL.CustomerServices.FindById(Int32.Parse(dgvCustomers.CurrentRow.Cells["CustomerID"].Value.ToString()));

            frmTransactions frm = new frmTransactions(customer, TransactionType.Withdrawal);
            frm.ShowDialog();
        }

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            Customer customer = BLL.CustomerServices.FindById(Int32.Parse(dgvCustomers.CurrentRow.Cells["CustomerID"].Value.ToString()));

            frmTransactions frm = new frmTransactions(customer, TransactionType.Adjustment);
            frm.ShowDialog();
        }

        private void txtTextToFind_KeyUp(object sender, KeyEventArgs e)
        {
            dgvCustomers.DataSource = BLL.CustomerServices.FindByCustomerData(txtTextToFind.Text);
        }
    }
}
