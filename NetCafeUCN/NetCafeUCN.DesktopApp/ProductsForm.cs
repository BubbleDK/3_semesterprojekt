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

        private void RefreshList()
        {
            //lstConsumables.Items.Clear();
            dgwConsumables.Rows.Clear();
            dgwGamingstations.Rows.Clear();
            //TODO: List should contain Gamingstation and Consumable instead of Product
            List<Consumable> consumables = new();
            List<GamingStation> gamingstations = new();
            consumables = consumableService.GetAll().ToList();
            gamingstations = gamingstationService.GetAll().ToList();
            //foreach (Consumable c in consumables)
            //{
            //    dgwConsumables.Rows.Add(c.Name, c.ProductNumber, c.Description, c.Type);
            //}
            //foreach (GamingStation gs in gamingstations)
            //{
            //    dgwGamingstations.Rows.Add(gs.Name, gs.ProductNumber, gs.SeatNumber, gs.Description, gs.Type);
            //}
            dgwConsumables.DataSource = consumables;
            dgwGamingstations.DataSource = gamingstations;
        }

        private void ShowInputDialog()
        {
            Form inputDialog = new InputDialog("Produkttype");
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
            if (dgwConsumables.CurrentRow != null)
            {
                Consumable c = (Consumable)dgwConsumables.CurrentRow.DataBoundItem;
                Form consumableForm = new ConsumableForm(c, consumableService);
                consumableForm.Show();
            }
            else if (dgwGamingstations.CurrentRow != null)
            {
                GamingStation gs = (GamingStation)dgwGamingstations.CurrentRow.DataBoundItem;
                Form gamingstationForm = new GamingstationForm(gs, gamingstationService);
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
            dgwConsumables.ClearSelection();
            dgwConsumables.CurrentCell = null;
            dgwGamingstations.ClearSelection();
            dgwGamingstations.CurrentCell = null;
        }

        private void DeleteSelectedProduct()
        {
            if (dgwConsumables.CurrentRow != null)
            {
                Consumable c = dgwConsumables.CurrentRow.DataBoundItem as Consumable;
                bool deleted = consumableService.Remove(c.ProductNumber);
                if (deleted)
                {
                    MessageBox.Show("Slettede " + c.Name, "Fjernet produkt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (dgwGamingstations.CurrentRow != null)
            {
                GamingStation gs = dgwGamingstations.CurrentRow.DataBoundItem as GamingStation;
                bool deleted = gamingstationService.Remove(gs.ProductNumber);
                if (deleted)
                {
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
