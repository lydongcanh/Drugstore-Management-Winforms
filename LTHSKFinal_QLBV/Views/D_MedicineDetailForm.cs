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
    public partial class D_MedicineDetailForm : Form
    {
        private readonly BaseDAO<MedicineDetail> MedDetailDAO = null;
        private readonly BaseDAO<MedicineSupplier> SupplierDAO = new BaseDAO<MedicineSupplier>();
        private readonly Action<MedicineDetail> OnOK = null;
        private readonly Medicine Medicine = null;
        private readonly MedicineDetail MedDetail = null;

        public D_MedicineDetailForm(BaseDAO<MedicineDetail> medDetailDAO, Action<MedicineDetail> onOK,
            Medicine medicine = null, MedicineDetail medDetail = null)
        {
            InitializeComponent();

            MedDetailDAO = medDetailDAO;
            OnOK = onOK;
            Medicine = medicine;
            MedDetail = medDetail;

            if (medDetail != null)
            {
                numQuantity.Value = medDetail.Quantity;
                txtPrice.Text = medDetail.UnitPrice.ToString();
                dtpAddedDate.Value = medDetail.AddedDate;
                dtpExpiredDate.Value = medDetail.ExpirationDate;
                cbSupplier.SelectedItem = medDetail.MedicineSupplier.Name;

                numQuantity.ReadOnly = true;
                txtPrice.Enabled = false;
                dtpAddedDate.Enabled = false;
                dtpExpiredDate.Enabled = false;
                cbSupplier.Enabled = false;
            }
        }

        private void LoadSupplierCombobox()
        {
            cbSupplier.Items.Clear();
            foreach (var supplier in SupplierDAO.SelectAll())
                cbSupplier.Items.Add(supplier.Name);

            cbSupplier.SelectedIndex = 0;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedItem == null)
                return;

            // TODO: Validate
            Close();
            OnOK(new MedicineDetail()
            {
                Id = MedDetail != null ? MedDetail.EntityId : "CTT" + (MedDetailDAO.Count() + 1),
                Quantity = (int)numQuantity.Value,
                UnitPrice = float.Parse(txtPrice.Text),
                AddedDate = dtpAddedDate.Value,
                ExpirationDate = dtpExpiredDate.Value,
                MedicineId = MedDetail != null ? MedDetail.MedicineId : Medicine.EntityId,
                MedicineSupplierId = SupplierDAO.Select(s => s.Name == cbSupplier.SelectedItem.ToString())[0].EntityId
            });
        }

        private void D_MedicineDetailForm_Load(object sender, EventArgs e)
        {
            LoadSupplierCombobox();
        }
    }
}
