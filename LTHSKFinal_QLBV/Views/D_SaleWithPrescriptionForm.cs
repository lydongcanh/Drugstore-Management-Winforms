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
    public partial class D_SaleWithPrescriptionForm : Form
    {
        private readonly BaseDAO<SellReceipt> ReceiptDAO = new BaseDAO<SellReceipt>();
        private readonly BaseDAO<SellReceiptDetail> ReceiptDetailsDAO = new BaseDAO<SellReceiptDetail>();
        private readonly BaseDAO<Medicine> MedicineDAO = new BaseDAO<Medicine>();
        private readonly BaseDAO<PatientPrescriptionMedicine> PrescriptionDetailsDAO = new BaseDAO<PatientPrescriptionMedicine>();
        private readonly Patient Patient = null;
        private readonly PatientPrescription Prescription = null;
        private readonly Employee Employee = null;
        private readonly Action<SellReceipt> OnOK = null;

        private List<SellReceiptDetail> details = new List<SellReceiptDetail>();

        public D_SaleWithPrescriptionForm(Employee employee, Patient patient, 
            PatientPrescription prescription, Action<SellReceipt> onOK)
        {
            InitializeComponent();

            Patient = patient;
            Prescription = prescription;
            Employee = employee;
            OnOK = onOK;
        }

        private void D_SaleWithPrescriptionForm_Load(object sender, EventArgs e)
        {
            txtId.Text = "HD" + (ReceiptDAO.Count() + 1);
            txtSum.Text = 0.ToString();
            LoadDetails();
        }

        private void LoadDetails()
        {
            details.Clear();
            var prescriptionDetails = PrescriptionDetailsDAO.Select(pd => pd.PatientPrescriptionId == Prescription.Id);
            foreach(var detail in prescriptionDetails)
            {
                details.Add(new SellReceiptDetail()
                {
                    SellReceiptId = txtId.Text,
                    MedicineId = detail.MedicineId,
                    Quantity = detail.OneDayQuantity * (int)numDateCount.Value
                });
            }

            lstDetails.Items.Clear();
            var sum = 0f;

            foreach (var detail in details)
            {
                var medicine = MedicineDAO.Select(m => m.Id == detail.MedicineId)[0];

                var item = new ListViewItem(medicine.Name);
                item.SubItems.Add(detail.Quantity.ToString());
                lstDetails.Items.Add(item);

                sum += medicine.SellPrice * detail.Quantity;
            }

            txtSum.Text = sum.ToString();
        }

        private void NumDateCount_ValueChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            var receipt = new SellReceipt()
            {
                Id = txtId.Text,
                EmployeeId = Employee.Id,
                PatientId = Patient.Id,
                Price = decimal.Parse(txtSum.Text),
                CreationDate = DateTime.Now,
            };

            ReceiptDAO.Add(receipt);
            foreach (var detail in details)
                ReceiptDetailsDAO.Add(detail);

            Close();
            OnOK(receipt);
        }
    }
}
