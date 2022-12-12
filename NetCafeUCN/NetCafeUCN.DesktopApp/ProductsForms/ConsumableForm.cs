using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class ConsumableForm : Form
    {
        INetCafeDataAccess<ConsumableDTO> consumableService;
        ConsumableDTO c;
        ProductsForm productsForm;
        //Type til at bestemme om man redigerer eller opretter nyt objekt
        private string type = "";
        public ConsumableForm(ProductsForm productsForm)
        {
            InitializeComponent();
            consumableService = new ConsumableService(MainMenu.BaseUrl + "Consumable/");
            type = "Create";
            c = new();
            txtProductType.Text = "Consumable";
            this.productsForm = productsForm;
            this.txtProductNum.Enabled = true;
        }

        public ConsumableForm(ConsumableDTO c, INetCafeDataAccess<ConsumableDTO> service, ProductsForm productsForm)
        {
            InitializeComponent();
            txtDescription.Text = c.Description;
            txtProductName.Text = c.Name;
            txtProductNum.Text = c.ProductNumber;
            txtProductType.Text = c.Type;
            this.c = c;
            consumableService = service;
            type = "Edit";
            this.productsForm = productsForm;
        }

        private void confirmOption()
        {
            c.Name = txtProductName.Text;
            c.ProductNumber = txtProductNum.Text;
            c.Type = "Consumable";
            c.Description = txtDescription.Text;
            if (type.Equals("Create"))
            {
                consumableService.Add(c);
                productsForm.RefreshList();
            }
            else if (type.Equals("Edit"))
            {
                consumableService.Update(c);
                productsForm.RefreshList();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmOption();
            this.Dispose();
        }
    }
}
