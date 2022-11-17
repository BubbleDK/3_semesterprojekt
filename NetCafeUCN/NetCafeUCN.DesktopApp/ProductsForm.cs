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
            lstConsumables.Items.Clear();
            lstGamingstations.Items.Clear();
            //TODO: List should contain Gamingstation and Consumable instead of Product
            List<Consumable> consumables = new();
            List<GamingStation> gamingstations = new();
            consumables = consumableService.GetAll().ToList();
            gamingstations = gamingstationService.GetAll().ToList();
            foreach (Consumable c in consumables)
            {
                lstConsumables.Items.Add(c);
            }
            foreach (GamingStation gs in gamingstations)
            {
                lstGamingstations.Items.Add(gs);
            }
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
            if(lstConsumables.SelectedIndex != -1)
            {
                Consumable c = lstConsumables.SelectedItem as Consumable;
                Form consumableForm = new ConsumableForm(c, consumableService);
                consumableForm.Show();
            }
            else if (lstGamingstations.SelectedIndex != -1)
            {
                GamingStation gs = lstGamingstations.SelectedItem as GamingStation;
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
            lstConsumables.SelectedIndex = -1;
            lstGamingstations.SelectedIndex = -1;
        }

        private void DeleteSelectedProduct()
        {
            if (lstConsumables.SelectedIndex != -1)
            {
                Consumable c = lstConsumables.SelectedItem as Consumable;
                bool deleted = consumableService.Remove(c.ProductNumber);
                if (deleted)
                {
                    MessageBox.Show("Slettede " + c.Name, "Fjernet produkt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (lstGamingstations.SelectedIndex != -1)
            {
                GamingStation gs = lstGamingstations.SelectedItem as GamingStation;
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
