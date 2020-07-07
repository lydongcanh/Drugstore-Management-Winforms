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
    public partial class D_SellRecriptForm : Form
    {
        private readonly BaseDAO<SellReceipt> ReceiptDAO = new BaseDAO<SellReceipt>();
        private readonly BaseDAO<SellReceiptDetail> ReceiptDetailDAO = new BaseDAO<SellReceiptDetail>();
        private readonly Patient Patient = null;

        private List<SellReceipt> receipts = new List<SellReceipt>();

        public D_SellRecriptForm(Patient patient)
        {
            InitializeComponent();

            Patient = patient;
            txtName.Text = patient.FullName;
            txtPhone.Text = patient.PhoneNumber;
        }

        private void LoadReceipts()
        {
            lstReceipt.Items.Clear();

            var sum = 0f;
            receipts = ReceiptDAO.Select(r => r.PatientId == Patient.Id);
            foreach(var receipt in receipts)
            {
                var item = new ListViewItem(receipt.Id);
                item.SubItems.Add(receipt.CreationDate.ToLongTimeString());
                item.SubItems.Add(((float)receipt.Price).ToString());
                item.SubItems.Add(receipt.Employee.FullName);
                lstReceipt.Items.Add(item);

                sum += (float)receipt.Price;
            }
            txtSum.Text = sum.ToString();
        }

        private void LoadDetails()
        {
            lstDetail.Items.Clear();
            
            if (lstReceipt.SelectedIndices.Count < 1)
                return;

            var receipt = receipts[lstReceipt.SelectedIndices[0]];
            var details = ReceiptDetailDAO.Select(rd => rd.SellReceiptId == receipt.Id);

            foreach (var detail in details)
            {
                var item = new ListViewItem(detail.Medicine.Name);
                item.SubItems.Add(detail.Quantity.ToString());
                lstDetail.Items.Add(item);
            }
        }

        private void D_SellRecriptForm_Load(object sender, EventArgs e)
        {
            LoadReceipts();
        }

        private void LstReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }
    }
}
