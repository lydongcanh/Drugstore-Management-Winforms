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
    public partial class D_DirectSaleForm : Form
    {
        private readonly BaseDAO<SellReceipt> ReceiptDAO = new BaseDAO<SellReceipt>();
        private readonly BaseDAO<SellReceiptDetail> ReceiptDetailsDAO = new BaseDAO<SellReceiptDetail>();
        private readonly BaseDAO<Medicine> MedicineDAO = new BaseDAO<Medicine>();
        private readonly Employee Employee = null;
        private readonly Action<SellReceipt> OnOK = null;

        private List<SellReceiptDetail> details = new List<SellReceiptDetail>();

        public D_DirectSaleForm(Employee employee, Action<SellReceipt> onOK)
        {
            InitializeComponent();

            Employee = employee;
            OnOK = onOK;            
        }

        private void D_DirectSaleForm_Load(object sender, EventArgs e)
        {
            LoadMedicines();
            btnRemove.Enabled = false;
            numQuantity.Minimum = 1;
            txtId.Text = "HD" + (ReceiptDAO.Count() + 1);
            txtSum.Text = 0.ToString();
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
            float sum = 0;

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

        private void LstDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isSelected = lstDetails.SelectedIndices.Count > 0;
            btnRemove.Enabled = isSelected;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var medicine = MedicineDAO.Select(m => m.Name == cbMedicine.SelectedItem.ToString())[0];

            foreach (var detail in details)
            {
                if (detail.MedicineId == medicine.Id)
                {
                    detail.Quantity += (int)numQuantity.Value;
                    LoadDetails();
                    return;
                }
            }

            details.Add(new SellReceiptDetail()
            {
                SellReceiptId = txtId.Text,
                MedicineId = medicine.EntityId,
                Quantity = (int)numQuantity.Value
            });
            LoadDetails();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            details.RemoveAt(lstDetails.SelectedIndices[0]);
            LoadDetails();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            var receipt = new SellReceipt()
            {
                Id = txtId.Text,
                EmployeeId = Employee.Id,
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
