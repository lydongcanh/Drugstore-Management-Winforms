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
    public partial class D_PatientForm : Form
    {
        private readonly BaseDAO<Patient> PatientDAO = null;
        private readonly Action<Patient> OnOK = null;

        public D_PatientForm(BaseDAO<Patient> patientDAO, Action<Patient> onOK, Patient patient = null)
        {
            InitializeComponent();

            PatientDAO = patientDAO;
            OnOK = onOK;

            if (patient != null)
            {
                txtId.Text = patient.EntityId;
                txtName.Text = patient.FullName;
                txtPhone.Text = patient.PhoneNumber;
                cbGender.SelectedItem = patient.Gender;
                dtpBirthdate.Value = patient.BirthDate;
            }
            else
            {
                txtId.Text = "BN" + (PatientDAO.Count() + 1);
                cbGender.SelectedIndex = 0;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // TODO: Validate
            Close();
            OnOK(new Patient()
            {
                Id = txtId.Text,
                FullName = txtName.Text,
                PhoneNumber = txtPhone.Text,
                Gender = cbGender.SelectedItem.ToString(),
                BirthDate = dtpBirthdate.Value
            });
        }
    }
}
