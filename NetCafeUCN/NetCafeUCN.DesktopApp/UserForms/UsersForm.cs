using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp.UserForms
{
    public partial class UsersForm : Form
    {
        INetCafeDataAccess<CustomerDTO> customerService;
        INetCafeDataAccess<EmployeeDTO> employeeService;
        /// <summary>
        /// Constructoren til at oprette formen for alle users/brugere i systemet.
        /// </summary>
        public UsersForm()
        {
            InitializeComponent();
            customerService = new CustomerService(MainMenu.BaseUrl + "customers");
            employeeService = new EmployeeService(MainMenu.BaseUrl + "employees");
            RefreshList();
        }

        /// <summary>
        /// Metoden til at opdatere datagridview komponentet
        /// </summary>
        public void RefreshList()
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.Rows.Clear();
            dgvEmployees.DataSource = null;
            dgvEmployees.Rows.Clear();
            dgvCustomers.DataSource = customerService.GetAll().ToList();
            dgvEmployees.DataSource = employeeService.GetAll().ToList();
            dgvCustomers.ClearSelection();
            dgvEmployees.CurrentCell = null;
            dgvEmployees.ClearSelection();
            dgvEmployees.CurrentCell = null;
        }

        private void UsersForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                RefreshList();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteSelectedUser();
        }

        /// <summary>
        /// Slet den valgte user fra listen
        /// </summary>
        private void DeleteSelectedUser()
        {
            if (dgvCustomers.CurrentRow != null)
            {
                CustomerDTO c = (CustomerDTO)dgvCustomers.CurrentRow.DataBoundItem;
                bool deleted = customerService.Remove(c.Phone);
                if (deleted)
                {
                    RefreshList();
                    MessageBox.Show("Slettede " + c.Name, "Fjernet bruger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (dgvEmployees.CurrentRow != null)
            {
                EmployeeDTO e = (EmployeeDTO)dgvEmployees.CurrentRow.DataBoundItem;
                bool deleted = employeeService.Remove(e.Phone);
                if (deleted)
                {
                    RefreshList();
                    MessageBox.Show("Slettede " + e.Name, "Fjernet bruger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            UpdateSelectedUser();
            
        }

        /// <summary>
        /// Opdater den valgte bruger fra listen
        /// </summary>
        private void UpdateSelectedUser()
        {
            if (dgvCustomers.CurrentRow != null)
            {
                CustomerDTO c = (CustomerDTO)dgvCustomers.CurrentRow.DataBoundItem;
                Form cuUser = new CreateUpdateUser(this, c);
                cuUser.Show();
            }
            else if (dgvEmployees.CurrentRow != null)
            {
                EmployeeDTO e = (EmployeeDTO)dgvEmployees.CurrentRow.DataBoundItem;
                Form cuUser = new CreateUpdateUser(this, e);
                cuUser.Show();
            }
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Denne funktion er ikke tilgængelig i øjeblikket", "Ikke tilgængelig", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*For at denne funktion virker skal der kunne laves hashed passwords via BCrypt i desktop også
            Pt påsættes der ikke et password*/
            //ShowInputDialog();
        }

        private void ShowInputDialog()
        {
            Form inputDialog = new UserInputDialog(this);
            inputDialog.ShowDialog();
        }

        private void tbUsers_Deselected(object sender, TabControlEventArgs e)
        {
            dgvCustomers.ClearSelection();
            dgvCustomers.CurrentCell = null;
            dgvEmployees.ClearSelection();
            dgvEmployees.CurrentCell = null;
        }
    }
}
