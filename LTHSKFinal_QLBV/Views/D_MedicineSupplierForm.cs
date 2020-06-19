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
    public partial class D_MedicineSupplierForm : Form
    {
        private readonly BaseDAO<MedicineSupplier> SuppliderDAO = null;
        private readonly Action<MedicineSupplier> OnOK = null;

        public D_MedicineSupplierForm(BaseDAO<MedicineSupplier> supplierDAO, 
            Action<MedicineSupplier> onOK, MedicineSupplier supplier = null)
        {
            InitializeComponent();

            SuppliderDAO = supplierDAO;
            OnOK = onOK;

            if (supplier != null)
            {
                txtId.Text = supplier.EntityId;
                txtName.Text = supplier.Name;
                txtPhone.Text = supplier.PhoneNumber;
            }
            else
            {
                txtId.Text = "NCC" + (SuppliderDAO.Count() + 1);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // TODO: Validate
            Close();
            OnOK(new MedicineSupplier()
            {
                Id = txtId.Text,
                Name = txtName.Text,
                PhoneNumber = txtPhone.Text,
            });
        }
    }
}
