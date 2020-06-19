namespace LTHSKFinal_QLBV.Views
{
    partial class B_SaleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lTHSKFinalDbDataSet = new LTHSKFinal_QLBV.LTHSKFinalDbDataSet();
            this.patientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientsTableAdapter = new LTHSKFinal_QLBV.LTHSKFinalDbDataSetTableAdapters.PatientsTableAdapter();
            this.lstPatients = new System.Windows.Forms.ListView();
            this.colIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBirthdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPrescriptions = new System.Windows.Forms.Button();
            this.btnDirectSale = new System.Windows.Forms.Button();
            this.btnSaleReceipt = new System.Windows.Forms.Button();
            this.btnAddPrescription = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lTHSKFinalDbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(111, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(567, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(684, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 33);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAddPatient_Click);
            // 
            // lTHSKFinalDbDataSet
            // 
            this.lTHSKFinalDbDataSet.DataSetName = "LTHSKFinalDbDataSet";
            this.lTHSKFinalDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // patientsBindingSource
            // 
            this.patientsBindingSource.DataMember = "Patients";
            this.patientsBindingSource.DataSource = this.lTHSKFinalDbDataSet;
            // 
            // patientsTableAdapter
            // 
            this.patientsTableAdapter.ClearBeforeFill = true;
            // 
            // lstPatients
            // 
            this.lstPatients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIndex,
            this.colName,
            this.colPhone,
            this.colGender,
            this.colBirthdate});
            this.lstPatients.FullRowSelect = true;
            this.lstPatients.GridLines = true;
            this.lstPatients.HideSelection = false;
            this.lstPatients.Location = new System.Drawing.Point(19, 54);
            this.lstPatients.MultiSelect = false;
            this.lstPatients.Name = "lstPatients";
            this.lstPatients.Size = new System.Drawing.Size(781, 535);
            this.lstPatients.TabIndex = 0;
            this.lstPatients.UseCompatibleStateImageBehavior = false;
            this.lstPatients.View = System.Windows.Forms.View.Details;
            this.lstPatients.SelectedIndexChanged += new System.EventHandler(this.LstPatients_SelectedIndexChanged);
            this.lstPatients.DoubleClick += new System.EventHandler(this.LstPatients_DoubleClick);
            // 
            // colIndex
            // 
            this.colIndex.Text = "Id";
            this.colIndex.Width = 90;
            // 
            // colName
            // 
            this.colName.Text = "Tên";
            this.colName.Width = 250;
            // 
            // colPhone
            // 
            this.colPhone.Text = "Số điện thoại";
            this.colPhone.Width = 200;
            // 
            // colGender
            // 
            this.colGender.Text = "Giới tính";
            this.colGender.Width = 120;
            // 
            // colBirthdate
            // 
            this.colBirthdate.Text = "Ngày sinh";
            this.colBirthdate.Width = 116;
            // 
            // btnPrescriptions
            // 
            this.btnPrescriptions.Location = new System.Drawing.Point(192, 595);
            this.btnPrescriptions.Name = "btnPrescriptions";
            this.btnPrescriptions.Size = new System.Drawing.Size(211, 47);
            this.btnPrescriptions.TabIndex = 4;
            this.btnPrescriptions.Text = "Danh sách đơn thuốc";
            this.btnPrescriptions.UseVisualStyleBackColor = true;
            this.btnPrescriptions.Click += new System.EventHandler(this.BtnPrescriptions_Click);
            // 
            // btnDirectSale
            // 
            this.btnDirectSale.Location = new System.Drawing.Point(606, 595);
            this.btnDirectSale.Name = "btnDirectSale";
            this.btnDirectSale.Size = new System.Drawing.Size(193, 47);
            this.btnDirectSale.TabIndex = 6;
            this.btnDirectSale.Text = "Bán không kê đơn";
            this.btnDirectSale.UseVisualStyleBackColor = true;
            this.btnDirectSale.Click += new System.EventHandler(this.BtnDirectSale_Click);
            // 
            // btnSaleReceipt
            // 
            this.btnSaleReceipt.Location = new System.Drawing.Point(409, 595);
            this.btnSaleReceipt.Name = "btnSaleReceipt";
            this.btnSaleReceipt.Size = new System.Drawing.Size(191, 47);
            this.btnSaleReceipt.TabIndex = 5;
            this.btnSaleReceipt.Text = "Danh sách hóa đơn";
            this.btnSaleReceipt.UseVisualStyleBackColor = true;
            // 
            // btnAddPrescription
            // 
            this.btnAddPrescription.Location = new System.Drawing.Point(19, 594);
            this.btnAddPrescription.Name = "btnAddPrescription";
            this.btnAddPrescription.Size = new System.Drawing.Size(167, 47);
            this.btnAddPrescription.TabIndex = 3;
            this.btnAddPrescription.Text = "Thêm đơn thuốc";
            this.btnAddPrescription.UseVisualStyleBackColor = true;
            this.btnAddPrescription.Click += new System.EventHandler(this.BtnAddPrescription_Click);
            // 
            // B_SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(812, 653);
            this.Controls.Add(this.btnAddPrescription);
            this.Controls.Add(this.btnSaleReceipt);
            this.Controls.Add(this.btnDirectSale);
            this.Controls.Add(this.btnPrescriptions);
            this.Controls.Add(this.lstPatients);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "B_SaleForm";
            this.Text = "SaleForm";
            this.Load += new System.EventHandler(this.SaleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lTHSKFinalDbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private LTHSKFinalDbDataSet lTHSKFinalDbDataSet;
        private System.Windows.Forms.BindingSource patientsBindingSource;
        private LTHSKFinalDbDataSetTableAdapters.PatientsTableAdapter patientsTableAdapter;
        private System.Windows.Forms.ListView lstPatients;
        private System.Windows.Forms.ColumnHeader colIndex;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colGender;
        private System.Windows.Forms.ColumnHeader colBirthdate;
        private System.Windows.Forms.Button btnPrescriptions;
        private System.Windows.Forms.Button btnDirectSale;
        private System.Windows.Forms.Button btnSaleReceipt;
        private System.Windows.Forms.Button btnAddPrescription;
    }
}