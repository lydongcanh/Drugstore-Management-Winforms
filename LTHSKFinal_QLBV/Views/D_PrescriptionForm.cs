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
    public partial class D_PrescriptionForm : Form
    {
        private readonly BaseDAO<Medicine> MedicineDAO = new BaseDAO<Medicine>();
        private readonly BaseDAO<PatientPrescription> PrescriptionDAO = new BaseDAO<PatientPrescription>();
        private readonly BaseDAO<PatientPrescriptionMedicine> PrescriptionDetailDAO = new BaseDAO<PatientPrescriptionMedicine>();
        private readonly Employee Employee = null;
        private readonly Patient Patient = null;
        private readonly Action<PatientPrescription> OnOK = null;

        private List<PatientPrescriptionMedicine> details = new List<PatientPrescriptionMedicine>();

        public D_PrescriptionForm(Employee employee, Patient patient, Action<PatientPrescription> onOK,
            PatientPrescription prescription = null)
        {
            InitializeComponent();

            Employee = employee;
            Patient = patient;
            OnOK = onOK;

            if (prescription == null)
            {
                txtPrescriptionId.Text = "DT" + (PrescriptionDAO.Count() + 1);
            }
            else
            {
                txtPrescriptionId.Text = prescription.EntityId;
                txtPrescriptionId.Enabled = false;
                detailGroup.Visible = false;
                txtDiesease.Text = prescription.DiseaseName;
                details = PrescriptionDetailDAO.Select(pd => pd.PatientPrescriptionId == prescription.EntityId);
                LoadDetails();
            }
        }

        private void LoadMedicines()
        {
            cbMedicine.Items.Clear();
            foreach (var medicine in MedicineDAO.SelectAll())
                cbMedicine.Items.Add(medicine.Name);

            cbMedicine.SelectedIndex = 0;
        }

        private void LoadDetails()
        {
            lstDetails.Items.Clear();
            foreach (var detail in details)
            {
                var item = new ListViewItem(detail.MedicineId);
                item.SubItems.Add(detail.OneDayQuantity.ToString());
                item.SubItems.Add(detail.Description);
                lstDetails.Items.Add(item);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var medicine = MedicineDAO.Select(m => m.Name == cbMedicine.SelectedItem.ToString())[0];

            foreach (var detail in details)
            {
                if (detail.MedicineId == medicine.Id)
                {
                    detail.OneDayQuantity += (int)numQuantity.Value;
                    LoadDetails();
                    return;
                }
            }

            details.Add(new PatientPrescriptionMedicine()
            {
                MedicineId = medicine.EntityId,
                PatientPrescriptionId = txtPrescriptionId.Text,
                OneDayQuantity = (int)numQuantity.Value,
                Description = rtxtDescription.Text
            });
            LoadDetails();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            details.RemoveAt(lstDetails.SelectedIndices[0]);
            LoadDetails();
        }

        private void LstDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isSelected = lstDetails.SelectedIndices.Count > 0;
            btnDelete.Enabled = isSelected;
        }

        private void D_PrescriptionForm_Load(object sender, EventArgs e)
        {
            LoadMedicines();
            numQuantity.Minimum = 1;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            var prescription = new PatientPrescription()
            {
                Id = txtPrescriptionId.Text,
                DiseaseName = txtDiesease.Text,
                PatientId = Patient.EntityId
            };

            if (prescription == null)
            {
                PrescriptionDAO.Add(prescription);
                foreach (var detail in details)
                    PrescriptionDetailDAO.Add(detail);
            }
            else
            {
                PrescriptionDAO.Update(prescription);
            }
            OnOK(prescription);
            Close();
        }
    }
}
