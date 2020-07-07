using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTHSKFinal_QLBV.DAL;

namespace LTHSKFinal_QLBV.Views
{
    public partial class C_MedicineSupplierForm : Form
    {
        private readonly BaseDAO<MedicineSupplier> SupplierDAO = new BaseDAO<MedicineSupplier>();
        private List<MedicineSupplier> suppliers = new List<MedicineSupplier>();

        public C_MedicineSupplierForm()
        {
            InitializeComponent();
        }

        private void LoadSuppliers()
        {
            suppliers = string.IsNullOrWhiteSpace(txtSearch.Text)
                ? SupplierDAO.SelectAll()
                : SupplierDAO.Select(p => p.Name.Contains(txtSearch.Text));

            lstSupplier.Items.Clear();
            foreach (var supplier in suppliers)
            {
                var item = new ListViewItem(supplier.EntityId);
                item.SubItems.Add(supplier.Name);
                item.SubItems.Add(supplier.PhoneNumber);
                lstSupplier.Items.Add(item);
            }
        }

        private void MedicineSupplierForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();

            AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
            allowedTypes.AddRange(SupplierDAO.Table.Select(s => s.Name).ToArray());
            txtSearch.AutoCompleteCustomSource = allowedTypes;
            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var supplierForm = new D_MedicineSupplierForm(SupplierDAO, ms =>
            {
                txtSearch.Text = "";
                SupplierDAO.Add(ms);
                LoadSuppliers();
            });
            supplierForm.ShowDialog(this);
        }

        private void LstSupplier_DoubleClick(object sender, EventArgs e)
        {
            if (lstSupplier.SelectedIndices.Count < 1)
                return;

            var supplier = suppliers[lstSupplier.SelectedIndices[0]];
            var supplierForm = new D_MedicineSupplierForm(SupplierDAO, ms =>
            {
                txtSearch.Text = "";
                SupplierDAO.Update(ms);
                LoadSuppliers();
            }, supplier);
            supplierForm.ShowDialog(this);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSuppliers();
        }
    }
}
