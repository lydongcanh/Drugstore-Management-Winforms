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
    public partial class D_EmployeeForm : Form
    {
        private readonly BaseDAO<Employee> EmployeeDAO = null;
        private readonly Action<Employee> OnOK = null;

        public D_EmployeeForm(BaseDAO<Employee> employeeDAO, Action<Employee> onOK, Employee employee = null)
        {
            InitializeComponent();

            EmployeeDAO = employeeDAO;
            OnOK = onOK;

            cbGender.SelectedIndex = 0;
            cbType.SelectedIndex = 0;

            if (employee != null)
            {
                txtId.Text = employee.EntityId;
                txtName.Text = employee.FullName;
                txtPhone.Text = employee.PhoneNumber;
                cbGender.SelectedItem = employee.Gender;
                dtpBirthdate.Value = employee.BirthDate;
                txtUsername.Text = employee.Username;
                txtPassword.Text = employee.Password;
                cbType.SelectedItem = employee.Type;
            }
            else
            {
                txtId.Text = "NV" + (EmployeeDAO.Count() + 1);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // TODO: Validate
            Close();
            OnOK(new Employee()
            {
                Id = txtId.Text,
                FullName = txtName.Text,
                PhoneNumber = txtPhone.Text,
                Gender = cbGender.SelectedItem.ToString(),
                BirthDate = dtpBirthdate.Value,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Type = cbType.SelectedItem.ToString()
            });
        }
    }
}
