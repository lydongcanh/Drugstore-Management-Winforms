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
    public partial class A_MainForm : Form
    {
        private Form activeForm = null;
        private Employee employee = null;

        public A_MainForm()
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

        public void OpenLoginForm()
        {
            OpenChildForm(new B_LoginForm(e =>
            {
                employee = e;
                btnSale.Enabled = true;
                btnMedicine.Enabled = true;
                btnEmployee.Enabled = true;
                btnAnalyst.Enabled = true;
                btnLogout.Enabled = true;
                OpenChildForm(new B_SaleForm(employee));
                panelSideMenu.Visible = true;
            }));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenLoginForm();
            panelSideMenu.Visible = false;
            btnSale.Enabled = false;
            btnMedicine.Enabled = false;
            btnEmployee.Enabled = false;
            btnAnalyst.Enabled = false;
            btnLogout.Enabled = false;
        }

        private void BtnSale_Click(object sender, EventArgs e)
        {
            OpenChildForm(new B_SaleForm(employee));
        }

        private void BtnMedicine_Click(object sender, EventArgs e)
        {
            OpenChildForm(new B_MedicineForm());
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new B_EmployeeForm());
        }

        private void BtnAnalyst_Click(object sender, EventArgs e)
        {
            OpenChildForm(new B_AnalystForm());
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            MainForm_Load(null, null);
        }
    }
}
