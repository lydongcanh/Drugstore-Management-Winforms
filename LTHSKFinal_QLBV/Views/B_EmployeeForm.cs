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
    public partial class B_EmployeeForm : Form
    {
        private readonly BaseDAO<Employee> EmployeeDAO = new BaseDAO<Employee>();
        private List<Employee> employees = new List<Employee>();

        public B_EmployeeForm()
        {
            InitializeComponent();
        }

        private void LoadEmployees()
        {
            employees = string.IsNullOrWhiteSpace(txtSearch.Text)
                ? EmployeeDAO.SelectAll()
                : EmployeeDAO.Select(p => p.FullName.Contains(txtSearch.Text));

            lstEmployee.Items.Clear();
            foreach (var employee in employees)
            {
                var item = new ListViewItem(employee.EntityId);
                item.SubItems.Add(employee.FullName);
                item.SubItems.Add(employee.PhoneNumber);
                item.SubItems.Add(employee.Gender);
                item.SubItems.Add(employee.BirthDate.ToShortDateString());
                item.SubItems.Add(employee.Type);
                lstEmployee.Items.Add(item);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var form = new D_EmployeeForm(EmployeeDAO, ms =>
            {
                txtSearch.Text = "";
                EmployeeDAO.Add(ms);
                LoadEmployees();
            });
            form.ShowDialog(this);
        }

        private void LstEmployee_DoubleClick(object sender, EventArgs e)
        {
            if (lstEmployee.SelectedIndices.Count < 1)
                return;

            var employee = employees[lstEmployee.SelectedIndices[0]];
            var form = new D_EmployeeForm(EmployeeDAO, ms =>
            {
                txtSearch.Text = "";
                EmployeeDAO.Update(ms);
                LoadEmployees();
            }, employee);
            form.ShowDialog(this);
        }

        private void B_EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();

            AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
            allowedTypes.AddRange(EmployeeDAO.Table.Select(emp => emp.FullName).ToArray());
            txtSearch.AutoCompleteCustomSource = allowedTypes;
            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }
    }
}
