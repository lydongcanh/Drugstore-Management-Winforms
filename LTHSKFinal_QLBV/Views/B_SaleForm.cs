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
        private List<Patient> patients = new List<Patient>();

        public B_SaleForm()
        {
            InitializeComponent();
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

        private void SaleForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
            btnEdit.Enabled = false;
            btnPrescriptions.Enabled = false;
        }

        private void LstPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPatients.SelectedIndices.Count < 1)
            {
                btnEdit.Enabled = false;
                btnPrescriptions.Enabled = false;
                return;
            }

            btnEdit.Enabled = true;
            btnPrescriptions.Enabled = true;
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

        private void BtnEdit_Click(object sender, EventArgs e)
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

        private void BtnPrescriptions_Click(object sender, EventArgs e)
        {

        }

        private void BtnDirectSale_Click(object sender, EventArgs e)
        {

        }
    }
}
