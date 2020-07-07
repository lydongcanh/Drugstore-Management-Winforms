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
    public partial class B_SaleForm : Form
    {
        private readonly BaseDAO<Patient> PatientDAO = new BaseDAO<Patient>();
        private readonly BaseDAO<PatientPrescription> PrescriptionDAO = new BaseDAO<PatientPrescription>();
        private readonly Employee Employee;

        private List<Patient> patients = new List<Patient>();
        private List<PatientPrescription> prescriptions = new List<PatientPrescription>();

        public B_SaleForm(Employee employee)
        {
            InitializeComponent();

            Employee = employee;
        }

        private void LoadPatients()
        {
            patients = string.IsNullOrWhiteSpace(txtSearch.Text) 
                ? PatientDAO.SelectAll() 
                : PatientDAO.Select(p => p.FullName.Contains(txtSearch.Text));

            lstPatients.Items.Clear();
            foreach(var patient in patients)
            {
                var item = new ListViewItem(patient.EntityId);
                item.SubItems.Add(patient.FullName);
                item.SubItems.Add(patient.PhoneNumber);
                item.SubItems.Add(patient.Gender);
                item.SubItems.Add(patient.BirthDate.ToShortDateString());
                lstPatients.Items.Add(item);
            }
        }

        private void LoadPrescription()
        {
            lstPrescription.Items.Clear();
            var patient = patients[lstPatients.SelectedIndices[0]];
            prescriptions = PrescriptionDAO.Select(p => p.PatientId == patient.EntityId);
            foreach (var prescription in prescriptions)
            {
                lstPrescription.Items.Add(prescription.DiseaseName);
            }
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
            btnAddPrescription.Enabled = false;
            btnSaleReceipt.Enabled = false;
            btnSaleWithPrescription.Enabled = false;

            AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
            allowedTypes.AddRange(PatientDAO.Table.Select(p => p.FullName).ToArray());
            txtSearch.AutoCompleteCustomSource = allowedTypes;
            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void LstPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPatients.SelectedIndices.Count < 1)
            {
                btnSaleReceipt.Enabled = false;
                btnSaleWithPrescription.Enabled = false;
                return;
            }

            btnAddPrescription.Enabled = true;
            btnSaleReceipt.Enabled = true;
            LoadPrescription();
        }

        private void LstPrescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPrescription.SelectedIndices.Count < 1)
            {
                btnSaleWithPrescription.Enabled = false;
                return;
            }

            btnSaleWithPrescription.Enabled = true;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void BtnAddPatient_Click(object sender, EventArgs e)
        {
            var patientForm = new D_PatientForm(PatientDAO, p =>
            {
                txtSearch.Text = "";
                PatientDAO.Add(p); // TODO: Validate
                LoadPatients();
            });
            patientForm.ShowDialog(this);
        }

        private void BtnAddPrescription_Click(object sender, EventArgs e)
        {
            var patient = patients[lstPatients.SelectedIndices[0]];
            var form = new D_PrescriptionForm(Employee, patient, p =>
            {
                LoadPrescription();
            });
            form.ShowDialog(this);
        }

        private void BtnSaleReceipt_Click(object sender, EventArgs e)
        {
            var patient = patients[lstPatients.SelectedIndices[0]];
            var form = new D_SellRecriptForm(patient);
            form.ShowDialog(this);
        }

        private void BtnSaleWithPrescription_Click(object sender, EventArgs e)
        {
            var patient = patients[lstPatients.SelectedIndices[0]];
            var prescription = prescriptions[lstPrescription.SelectedIndex];
            var form = new D_SaleWithPrescriptionForm(Employee, patient, prescription, sr => { });
            form.ShowDialog(this);
        }

        private void BtnDirectSale_Click(object sender, EventArgs e)
        {
            var form = new D_DirectSaleForm(Employee, p => { });
            form.ShowDialog(this);
        }

        private void LstPatients_DoubleClick(object sender, EventArgs e)
        {
            if (lstPatients.SelectedIndices.Count < 1)
                return;

            var patient = patients[lstPatients.SelectedIndices[0]];
            var patientForm = new D_PatientForm(PatientDAO, p =>
            {
                txtSearch.Text = "";
                PatientDAO.Update(p); // TODO: Validate
                LoadPatients();
            }, patient);
            patientForm.ShowDialog(this);
        }

        private void LstPrescription_DoubleClick(object sender, EventArgs e)
        {
            var patient = patients[lstPatients.SelectedIndices[0]];
            var prescription = prescriptions[lstPrescription.SelectedIndex];
            var form = new D_PrescriptionForm(Employee, patient, p =>
            {
                LoadPrescription();
            }, prescription);
            form.ShowDialog(this);
        }
    }
}
