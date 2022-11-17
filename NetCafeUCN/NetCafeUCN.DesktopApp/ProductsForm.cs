using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;
using System.Windows.Forms;

namespace NetCafeUCN.DesktopApp
{
    public partial class ProductsForm : Form
    {
        INetCafeDataAccess<Consumable> consumableService;
        INetCafeDataAccess<GamingStation> gamingstationService;
        public ProductsForm()
        {
            InitializeComponent();
            consumableService = new ConsumableService("https://localhost:7197/api/Consumable/");
            gamingstationService = new GamingStationService("https://localhost:7197/api/Gamingstation/");
            RefreshList();
        }

        public void RefreshList()
        {
            dgvConsumables.DataSource = null;
            dgvConsumables.Rows.Clear();
            dgvGamingstations.DataSource = null;
            dgvGamingstations.Rows.Clear();
            List<Consumable> consumables = new();
            List<GamingStation> gamingstations = new();
            consumables = consumableService.GetAll().ToList();
            gamingstations = gamingstationService.GetAll().ToList();
            dgvConsumables.DataSource = consumables;
            dgvGamingstations.DataSource = gamingstations;
            dgvConsumables.ClearSelection();
            dgvConsumables.CurrentCell = null;
            dgvGamingstations.ClearSelection();
            dgvGamingstations.CurrentCell = null;

        }

        private void ShowInputDialog()
        {
            Form inputDialog = new InputDialog("Produkttype", this);
            inputDialog.ShowDialog();
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            ShowInputDialog();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void UpdateProduct()
        {
            if (dgvConsumables.CurrentRow != null)
            {
                Consumable c = (Consumable)dgvConsumables.CurrentRow.DataBoundItem;
                Form consumableForm = new ConsumableForm(c, consumableService, this);
                consumableForm.Show();
            }
            else if (dgvGamingstations.CurrentRow != null)
            {
                GamingStation gs = (GamingStation)dgvGamingstations.CurrentRow.DataBoundItem;
                Form gamingstationForm = new GamingstationForm(gs, gamingstationService, this);
                gamingstationForm.Show();
            }
        }
        private void ProductsForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                RefreshList();
            }
        }

        private void tbProducts_Deselected(object sender, TabControlEventArgs e)
        {
            dgvConsumables.ClearSelection();
            dgvConsumables.CurrentCell = null;
            dgvGamingstations.ClearSelection();
            dgvGamingstations.CurrentCell = null;
        }

        private void DeleteSelectedProduct()
        {
            if (dgvConsumables.CurrentRow != null)
            {
                Consumable c = (Consumable)dgvConsumables.CurrentRow.DataBoundItem;
                bool deleted = consumableService.Remove(c.ProductNumber);
                if (deleted)
                {
                    RefreshList();
                    MessageBox.Show("Slettede " + c.Name, "Fjernet produkt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (dgvGamingstations.CurrentRow != null)
            {
                GamingStation gs = (GamingStation)dgvGamingstations.CurrentRow.DataBoundItem;
                bool deleted = gamingstationService.Remove(gs.ProductNumber);
                if (deleted)
                {
                    RefreshList();
                    MessageBox.Show("Slettede " + gs.Name, "Fjernet produkt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteProduct_Click_1(object sender, EventArgs e)
        {
            DeleteSelectedProduct();
        }
    }
}
