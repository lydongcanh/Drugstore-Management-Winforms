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
    public partial class C_MedicineForm : Form
    {
        private readonly BaseDAO<Medicine> MedicineDAO = new BaseDAO<Medicine>();
        private readonly BaseDAO<MedicineDetail> MedicineDetailDAO = new BaseDAO<MedicineDetail>();
        private List<Medicine> medicines = new List<Medicine>();
        private List<MedicineDetail> medicineDetails = new List<MedicineDetail>();

        public C_MedicineForm()
        {
            InitializeComponent();
        }

        private void LoadMedicines()
        {
            medicines = string.IsNullOrWhiteSpace(txtSearch.Text)
                ? MedicineDAO.SelectAll()
                : MedicineDAO.Select(p => p.Name.Contains(txtSearch.Text));

            lstMedicine.Items.Clear();
            foreach (var medicine in medicines)
            {
                var item = new ListViewItem(medicine.EntityId);
                item.SubItems.Add(medicine.Name);
                item.SubItems.Add(medicine.SellPrice.ToString());
                lstMedicine.Items.Add(item);
            }
        }

        private void LoadMedicineDetails()
        {
            lstMedDetails.Items.Clear();
            if (lstMedicine.SelectedIndices.Count < 1)
            {
                medicineDetails = new List<MedicineDetail>();
                return;
            }

            var medicine = medicines[lstMedicine.SelectedIndices[0]];
            medicineDetails = MedicineDetailDAO.Select(md => md.MedicineId == medicine.EntityId);
            foreach (var md in medicineDetails)
            {
                var item = new ListViewItem(md.Quantity.ToString());
                item.SubItems.Add(md.UnitPrice.ToString());
                item.SubItems.Add(md.AddedDate.ToShortDateString());
                item.SubItems.Add(md.ExpirationDate.ToShortDateString());
                item.SubItems.Add(md.MedicineSupplier.Name);
                lstMedDetails.Items.Add(item);
            }
        }

        private void LstMedicine_DoubleClick(object sender, EventArgs e)
        {
            var medicine = medicines[lstMedicine.SelectedIndices[0]];
            var medicineForm = new D_MedicineForm(MedicineDAO, m =>
            {
                txtSearch.Text = "";
                MedicineDAO.Update(m);
                LoadMedicines();
            }, medicine);
            medicineForm.ShowDialog(this);
        }

        private void LstMedDetails_DoubleClick(object sender, EventArgs e)
        {
            var medDetail = medicineDetails[lstMedDetails.SelectedIndices[0]];
            var medDetailForm = new D_MedicineDetailForm(MedicineDetailDAO, md =>
            {
                MedicineDetailDAO.Update(md);
                LoadMedicineDetails();
            }, medDetail: medDetail);
            medDetailForm.ShowDialog(this);
        }

        private void LstMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddInvoice.Enabled = lstMedicine.SelectedIndices.Count > 0;
            LoadMedicineDetails();
        }

        private void C_MedicineForm_Load(object sender, EventArgs e)
        {
            LoadMedicines();
        }

        private void BtnAddMed_Click(object sender, EventArgs e)
        {
            var medicineForm = new D_MedicineForm(MedicineDAO, m =>
            {
                txtSearch.Text = "";
                MedicineDAO.Add(m);
                LoadMedicines();
            });
            medicineForm.ShowDialog(this);
        }

        private void BtnAddInvoice_Click(object sender, EventArgs e)
        {
            var medicine = medicines[lstMedicine.SelectedIndices[0]];
            var medDetailForm = new D_MedicineDetailForm(MedicineDetailDAO, md =>
            {
                MedicineDetailDAO.Add(md);
                LoadMedicineDetails();
            }, medicine);
            medDetailForm.ShowDialog(this);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMedicines();
            LoadMedicineDetails();
        }
    }
}
