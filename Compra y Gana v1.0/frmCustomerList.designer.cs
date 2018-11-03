namespace Compra_y_Gana_v1._0
{
    partial class frmCustomerList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerList));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTextToFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaternalLastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaternalLastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cellphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewAccount = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.gbxTransactions = new System.Windows.Forms.GroupBox();
            this.btnAdjustment = new System.Windows.Forms.Button();
            this.btnWithdrawal = new System.Windows.Forms.Button();
            this.btnExpense = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.gbAcciones.SuspendLayout();
            this.gbxTransactions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Búsqueda: ";
            // 
            // txtTextToFind
            // 
            this.txtTextToFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextToFind.Location = new System.Drawing.Point(108, 30);
            this.txtTextToFind.Name = "txtTextToFind";
            this.txtTextToFind.Size = new System.Drawing.Size(370, 23);
            this.txtTextToFind.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtTextToFind, "Criterios de busqueda: Nombres, Apellidos, Correo o Teléfonos");
            this.txtTextToFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTextToFind_KeyUp);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.BackColor = System.Drawing.Color.Peru;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(484, 17);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(144, 48);
            this.btnFind.TabIndex = 16;
            this.btnFind.Text = "Buscar";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Visible = false;
            // 
            // gbList
            // 
            this.gbList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbList.Controls.Add(this.dgvCustomers);
            this.gbList.Controls.Add(this.btnFind);
            this.gbList.Controls.Add(this.txtTextToFind);
            this.gbList.Controls.Add(this.label1);
            this.gbList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbList.Location = new System.Drawing.Point(0, 0);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(634, 506);
            this.gbList.TabIndex = 0;
            this.gbList.TabStop = false;
            this.gbList.Text = "Lista de clientes";
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToOrderColumns = true;
            this.dgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.Names,
            this.PaternalLastname,
            this.MaternalLastname,
            this.Address,
            this.Phone,
            this.Cellphone,
            this.Email,
            this.Nickname,
            this.Username,
            this.Password,
            this.Account,
            this.CreatedDate,
            this.ModifiedDate});
            this.dgvCustomers.Location = new System.Drawing.Point(15, 71);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(613, 429);
            this.dgvCustomers.TabIndex = 17;
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Visible = false;
            this.CustomerID.Width = 116;
            // 
            // Names
            // 
            this.Names.DataPropertyName = "Names";
            this.Names.HeaderText = "Nombre (s)";
            this.Names.Name = "Names";
            this.Names.ReadOnly = true;
            this.Names.Width = 105;
            // 
            // PaternalLastname
            // 
            this.PaternalLastname.DataPropertyName = "PaternalLastname";
            this.PaternalLastname.HeaderText = "Apellido paterno";
            this.PaternalLastname.Name = "PaternalLastname";
            this.PaternalLastname.ReadOnly = true;
            this.PaternalLastname.Width = 139;
            // 
            // MaternalLastname
            // 
            this.MaternalLastname.DataPropertyName = "MaternalLastname";
            this.MaternalLastname.HeaderText = "Apellido materno";
            this.MaternalLastname.Name = "MaternalLastname";
            this.MaternalLastname.ReadOnly = true;
            this.MaternalLastname.Width = 141;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Dirección";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 101;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Teléfono";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 97;
            // 
            // Cellphone
            // 
            this.Cellphone.DataPropertyName = "Cellphone";
            this.Cellphone.HeaderText = "Celular";
            this.Cellphone.Name = "Cellphone";
            this.Cellphone.ReadOnly = true;
            this.Cellphone.Width = 84;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Correo electrónico";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 152;
            // 
            // Nickname
            // 
            this.Nickname.DataPropertyName = "Nickname";
            this.Nickname.HeaderText = "Alias";
            this.Nickname.Name = "Nickname";
            this.Nickname.ReadOnly = true;
            this.Nickname.Width = 68;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Usuario";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Width = 89;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Contraseña";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Visible = false;
            this.Password.Width = 116;
            // 
            // Account
            // 
            this.Account.DataPropertyName = "Account";
            this.Account.HeaderText = "Account";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            this.Account.Visible = false;
            this.Account.Width = 91;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "Fecha de alta";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Width = 96;
            // 
            // ModifiedDate
            // 
            this.ModifiedDate.DataPropertyName = "ModifiedDate";
            this.ModifiedDate.HeaderText = "Fecha Modificado";
            this.ModifiedDate.Name = "ModifiedDate";
            this.ModifiedDate.ReadOnly = true;
            this.ModifiedDate.Width = 146;
            // 
            // btnViewAccount
            // 
            this.btnViewAccount.BackColor = System.Drawing.Color.LimeGreen;
            this.btnViewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAccount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnViewAccount.Image")));
            this.btnViewAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewAccount.Location = new System.Drawing.Point(12, 129);
            this.btnViewAccount.Name = "btnViewAccount";
            this.btnViewAccount.Size = new System.Drawing.Size(144, 48);
            this.btnViewAccount.TabIndex = 12;
            this.btnViewAccount.Text = "Ver Cuenta";
            this.btnViewAccount.UseVisualStyleBackColor = false;
            this.btnViewAccount.Click += new System.EventHandler(this.btnViewAccount_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Orange;
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(12, 23);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(144, 48);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "&Nuevo";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(12, 76);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(144, 48);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "&Editar ";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(12, 452);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(144, 48);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gbAcciones
            // 
            this.gbAcciones.Controls.Add(this.gbxTransactions);
            this.gbAcciones.Controls.Add(this.btnClose);
            this.gbAcciones.Controls.Add(this.btnEdit);
            this.gbAcciones.Controls.Add(this.btnNew);
            this.gbAcciones.Controls.Add(this.btnViewAccount);
            this.gbAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbAcciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAcciones.Location = new System.Drawing.Point(641, 0);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(168, 506);
            this.gbAcciones.TabIndex = 1;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // gbxTransactions
            // 
            this.gbxTransactions.Controls.Add(this.btnAdjustment);
            this.gbxTransactions.Controls.Add(this.btnWithdrawal);
            this.gbxTransactions.Controls.Add(this.btnExpense);
            this.gbxTransactions.Controls.Add(this.btnPurchase);
            this.gbxTransactions.Location = new System.Drawing.Point(6, 186);
            this.gbxTransactions.Name = "gbxTransactions";
            this.gbxTransactions.Size = new System.Drawing.Size(156, 256);
            this.gbxTransactions.TabIndex = 17;
            this.gbxTransactions.TabStop = false;
            this.gbxTransactions.Text = "Transacciones";
            // 
            // btnAdjustment
            // 
            this.btnAdjustment.BackColor = System.Drawing.Color.Goldenrod;
            this.btnAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjustment.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjustment.Location = new System.Drawing.Point(6, 193);
            this.btnAdjustment.Name = "btnAdjustment";
            this.btnAdjustment.Size = new System.Drawing.Size(144, 48);
            this.btnAdjustment.TabIndex = 19;
            this.btnAdjustment.Text = "Ajuste";
            this.btnAdjustment.UseVisualStyleBackColor = false;
            this.btnAdjustment.Visible = false;
            this.btnAdjustment.Click += new System.EventHandler(this.btnAdjustment_Click);
            // 
            // btnWithdrawal
            // 
            this.btnWithdrawal.BackColor = System.Drawing.Color.Tomato;
            this.btnWithdrawal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithdrawal.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWithdrawal.Image = ((System.Drawing.Image)(resources.GetObject("btnWithdrawal.Image")));
            this.btnWithdrawal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWithdrawal.Location = new System.Drawing.Point(6, 139);
            this.btnWithdrawal.Name = "btnWithdrawal";
            this.btnWithdrawal.Size = new System.Drawing.Size(144, 48);
            this.btnWithdrawal.TabIndex = 18;
            this.btnWithdrawal.Text = "Retiro";
            this.btnWithdrawal.UseVisualStyleBackColor = false;
            this.btnWithdrawal.Click += new System.EventHandler(this.btnWithdrawal_Click);
            // 
            // btnExpense
            // 
            this.btnExpense.BackColor = System.Drawing.Color.RosyBrown;
            this.btnExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpense.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpense.Image = ((System.Drawing.Image)(resources.GetObject("btnExpense.Image")));
            this.btnExpense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpense.Location = new System.Drawing.Point(6, 85);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Size = new System.Drawing.Size(144, 48);
            this.btnExpense.TabIndex = 17;
            this.btnExpense.Text = "Gasto";
            this.btnExpense.UseVisualStyleBackColor = false;
            this.btnExpense.Click += new System.EventHandler(this.btnExpense_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchase.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.Image = ((System.Drawing.Image)(resources.GetObject("btnPurchase.Image")));
            this.btnPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchase.Location = new System.Drawing.Point(6, 31);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(144, 48);
            this.btnPurchase.TabIndex = 16;
            this.btnPurchase.Text = "Compra";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // frmCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(809, 506);
            this.Controls.Add(this.gbAcciones);
            this.Controls.Add(this.gbList);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(825, 545);
            this.Name = "frmCustomerList";
            this.Text = "Lista de clientes";
            this.Load += new System.EventHandler(this.frmCustomerList_Load);
            this.gbList.ResumeLayout(false);
            this.gbList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.gbAcciones.ResumeLayout(false);
            this.gbxTransactions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.TextBox txtTextToFind;
        protected System.Windows.Forms.Button btnFind;
        protected System.Windows.Forms.GroupBox gbList;
        protected System.Windows.Forms.Button btnViewAccount;
        protected System.Windows.Forms.Button btnNew;
        protected System.Windows.Forms.Button btnEdit;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.GroupBox gbAcciones;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaternalLastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaternalLastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cellphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nickname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedDate;
        private System.Windows.Forms.GroupBox gbxTransactions;
        protected System.Windows.Forms.Button btnWithdrawal;
        protected System.Windows.Forms.Button btnExpense;
        protected System.Windows.Forms.Button btnPurchase;
        protected System.Windows.Forms.Button btnAdjustment;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}