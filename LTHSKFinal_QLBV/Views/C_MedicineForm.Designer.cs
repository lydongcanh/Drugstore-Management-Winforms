namespace LTHSKFinal_QLBV.Views
{
    partial class C_MedicineForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstMedicine = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstMedDetails = new System.Windows.Forms.ListView();
            this.colQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExpriredDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSupplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAddMed = new System.Windows.Forms.Button();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstMedicine);
            this.groupBox1.Location = new System.Drawing.Point(21, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 542);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thuốc";
            // 
            // lstMedicine
            // 
            this.lstMedicine.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName,
            this.colPrice});
            this.lstMedicine.FullRowSelect = true;
            this.lstMedicine.GridLines = true;
            this.lstMedicine.HideSelection = false;
            this.lstMedicine.Location = new System.Drawing.Point(7, 30);
            this.lstMedicine.MultiSelect = false;
            this.lstMedicine.Name = "lstMedicine";
            this.lstMedicine.Size = new System.Drawing.Size(272, 506);
            this.lstMedicine.TabIndex = 0;
            this.lstMedicine.UseCompatibleStateImageBehavior = false;
            this.lstMedicine.View = System.Windows.Forms.View.Details;
            this.lstMedicine.SelectedIndexChanged += new System.EventHandler(this.LstMedicine_SelectedIndexChanged);
            this.lstMedicine.DoubleClick += new System.EventHandler(this.LstMedicine_DoubleClick);
            // 
            // colId
            // 
            this.colId.Text = "Id";
            this.colId.Width = 50;
            // 
            // colName
            // 
            this.colName.Text = "Tên";
            this.colName.Width = 115;
            // 
            // colPrice
            // 
            this.colPrice.Text = "Giá bán";
            this.colPrice.Width = 100;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstMedDetails);
            this.groupBox2.Location = new System.Drawing.Point(312, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 542);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết thuốc";
            // 
            // lstMedDetails
            // 
            this.lstMedDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colQuantity,
            this.colUnitPrice,
            this.colAddedDate,
            this.colExpriredDate,
            this.colSupplier});
            this.lstMedDetails.FullRowSelect = true;
            this.lstMedDetails.GridLines = true;
            this.lstMedDetails.HideSelection = false;
            this.lstMedDetails.Location = new System.Drawing.Point(13, 30);
            this.lstMedDetails.MultiSelect = false;
            this.lstMedDetails.Name = "lstMedDetails";
            this.lstMedDetails.Size = new System.Drawing.Size(469, 506);
            this.lstMedDetails.TabIndex = 0;
            this.lstMedDetails.UseCompatibleStateImageBehavior = false;
            this.lstMedDetails.View = System.Windows.Forms.View.Details;
            this.lstMedDetails.DoubleClick += new System.EventHandler(this.LstMedDetails_DoubleClick);
            // 
            // colQuantity
            // 
            this.colQuantity.Text = "Số lượng";
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Text = "Giá nhập";
            this.colUnitPrice.Width = 105;
            // 
            // colAddedDate
            // 
            this.colAddedDate.Text = "Ngày nhập";
            this.colAddedDate.Width = 110;
            // 
            // colExpriredDate
            // 
            this.colExpriredDate.Text = "Ngày hết hạn";
            this.colExpriredDate.Width = 150;
            // 
            // colSupplier
            // 
            this.colSupplier.Text = "Nhà cung cấp";
            this.colSupplier.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm theo tên";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(149, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(356, 30);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // btnAddMed
            // 
            this.btnAddMed.Location = new System.Drawing.Point(511, 10);
            this.btnAddMed.Name = "btnAddMed";
            this.btnAddMed.Size = new System.Drawing.Size(129, 31);
            this.btnAddMed.TabIndex = 4;
            this.btnAddMed.Text = "Thêm thuốc";
            this.btnAddMed.UseVisualStyleBackColor = true;
            this.btnAddMed.Click += new System.EventHandler(this.BtnAddMed_Click);
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Enabled = false;
            this.btnAddInvoice.Location = new System.Drawing.Point(646, 10);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(154, 31);
            this.btnAddInvoice.TabIndex = 5;
            this.btnAddInvoice.Text = "Thêm chi tiết";
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            this.btnAddInvoice.Click += new System.EventHandler(this.BtnAddInvoice_Click);
            // 
            // C_MedicineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 603);
            this.Controls.Add(this.btnAddInvoice);
            this.Controls.Add(this.btnAddMed);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "C_MedicineForm";
            this.Text = "MedicineDetailsForm";
            this.Load += new System.EventHandler(this.C_MedicineForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstMedicine;
        private System.Windows.Forms.ListView lstMedDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddMed;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colQuantity;
        private System.Windows.Forms.ColumnHeader colUnitPrice;
        private System.Windows.Forms.ColumnHeader colAddedDate;
        private System.Windows.Forms.ColumnHeader colExpriredDate;
        private System.Windows.Forms.ColumnHeader colSupplier;
    }
}