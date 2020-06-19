using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTHSKFinal_QLBV.Views
{
    public partial class B_MedicineForm : Form
    {
        private Form activeForm = null;

        public B_MedicineForm()
        {
            InitializeComponent();
        }

        public void OpenChildForm(Form form)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = form;

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelMain.Controls.Add(form);
            panelMain.Tag = form;

            form.BringToFront();
            form.Show();
        }

        private void MedicineForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new C_MedicineForm());
        }

        private void BtnMedicine_Click(object sender, EventArgs e)
        {
            OpenChildForm(new C_MedicineForm());
        }

        private void BtnSupplier_Click(object sender, EventArgs e)
        {
            OpenChildForm(new C_MedicineSupplierForm());
        }
    }
}
