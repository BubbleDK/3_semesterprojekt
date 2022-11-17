using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class ProductsForm : Form
    {
        INetCafeDataAccess<Consumable> consumableService = new ConsumableService("https://localhost:7197/api/Consumable/");
        INetCafeDataAccess<GamingStation> gamingstationService = new GamingStationService("https://localhost:7197/api/Gamingstation/");
        public ProductsForm()
        {
            InitializeComponent();
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
            Product p = lstProducts.SelectedItem as Product;
            Form gamingStationForm = new GamingstationForm(p.ProductNumber, p.Type, p.Name);
            gamingStationForm.Show();
        }
        private void ProductsForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                RefreshList();
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Product p = lstProducts.SelectedItem as Product;
            productService.Remove(p.ProductNumber);
        }
    }
}
