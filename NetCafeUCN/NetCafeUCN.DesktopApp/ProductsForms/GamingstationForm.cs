using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class GamingstationForm : Form
    {

        INetCafeDataAccess<GamingStationDTO> gamingstationService;
        GamingStationDTO gs;
        ProductsForm productsForm;

        //Type til at bestemme om man redigerer eller opretter nyt objekt
        private string type = "";
        public GamingstationForm(ProductsForm productsForm)
        {
            InitializeComponent();
            gamingstationService = new GamingStationService(MainMenu.BaseUrl + "Gamingstation/");
            type = "Create";
            gs = new();
            txtProductType.Text = "Gamingstation";
            this.productsForm = productsForm;
            this.txtProductNum.Enabled = true;
        }

        public GamingstationForm(GamingStationDTO gs, INetCafeDataAccess<GamingStationDTO> service, ProductsForm productsForm)
        {
            InitializeComponent();
            txtProductName.Text = gs.Name;
            txtProductNum.Text = gs.ProductNumber;
            txtProductType.Text = gs.Type;
            txtSeatNumber.Text = gs.SeatNumber;
            txtDescription.Text = gs.Description;
            gamingstationService = service;
            this.gs = gs;
            type = "Edit";
            this.productsForm = productsForm;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmOption();
            this.Dispose();
        }

        private void confirmOption()
        {
            gs.Name = txtProductName.Text;
            gs.ProductNumber = txtProductNum.Text;
            gs.Type = "Gamingstation";
            gs.SeatNumber = txtSeatNumber.Text;
            gs.Description = txtDescription.Text;
            if (type.Equals("Create"))
            {
                gamingstationService.Add(gs);
                productsForm.RefreshList();
            }else if (type.Equals("Edit"))
            {
                gamingstationService.Update(gs);
                productsForm.RefreshList();
            }
        }
    }
}
