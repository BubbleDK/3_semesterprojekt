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
        /// <summary>
        /// Constructor til at oprette consumable product
        /// </summary>
        /// <param name="productsForm">Base productsform indsættes</param>
        public ConsumableForm(ProductsForm productsForm)
        {
            InitializeComponent();
            consumableService = new ConsumableService(MainMenu.BaseUrl + "Consumables/");
            type = "Create";
            c = new();
            txtProductType.Text = "Consumable";
            this.productsForm = productsForm;
            this.txtProductNum.Enabled = true;
        }

        /// <summary>
        /// Constructor til at opdatere et consumable object
        /// </summary>
        /// <param name="c">En DTO af consumable, det objekt der skal opdateres</param>
        /// <param name="service">Service som bruges når der skal kaldes til API</param>
        /// <param name="productsForm">Base productsform indsættes</param>
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

        /// <summary>
        /// Metoden køres når der bliver trykket bekræft i formen.
        /// </summary>
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
