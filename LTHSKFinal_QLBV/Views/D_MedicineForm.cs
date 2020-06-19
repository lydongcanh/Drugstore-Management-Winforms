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
    public partial class D_MedicineForm : Form
    {
        private readonly BaseDAO<Medicine> MedicineDAO = null;
        private readonly Action<Medicine> OnOK = null;

        public D_MedicineForm(BaseDAO<Medicine> medicineDAO,
            Action<Medicine> onOK, Medicine medicine = null)
        {
            InitializeComponent();

            MedicineDAO = medicineDAO;
            OnOK = onOK;

            if (medicine != null)
            {
                txtId.Text = medicine.EntityId;
                txtName.Text = medicine.Name;
                txtPrice.Text = medicine.SellPrice.ToString();
            }
            else
            {
                txtId.Text = "T" + (MedicineDAO.Count() + 1);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // TODO: Validate
            Close();
            OnOK(new Medicine()
            {
                Id = txtId.Text,
                Name = txtName.Text,
                SellPrice = float.Parse(txtPrice.Text),
            });
        }
    }
}
