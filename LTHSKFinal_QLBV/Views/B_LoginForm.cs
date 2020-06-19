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
    public partial class B_LoginForm : Form
    {
        private readonly BaseDAO<Employee> EmployeeDAO = new BaseDAO<Employee>();
        private readonly Action<Employee> OnLoggedIn = null;

        public B_LoginForm(Action<Employee> onLoggedIn = null)
        {
            InitializeComponent();
            OnLoggedIn = onLoggedIn;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var employee = EmployeeDAO.Select(emp => emp.Username == txtUsername.Text && emp.Password == txtPassword.Text);
            if (employee == null || employee.Count < 1)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
                return;
            }

            OnLoggedIn?.Invoke(employee[0]);
        }
    }
}
