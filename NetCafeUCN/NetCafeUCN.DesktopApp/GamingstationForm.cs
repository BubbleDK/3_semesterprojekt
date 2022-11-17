using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class GamingstationForm : Form
    {

        INetCafeDataAccess<GamingStation> gamingstationService;
        GamingStation gs;
        //Type til at bestemme om man redigerer eller opretter nyt objekt
        private string type = "";
        public GamingstationForm()
        {
            InitializeComponent();
            gamingstationService = new GamingStationService("https://localhost:7197/api/Gamingstation/");
            type = "Create";
            gs = new();
            txtProductType.Text = "Gamingstation";
        }

        public GamingstationForm(GamingStation gs, INetCafeDataAccess<GamingStation> service)
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
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmOption();
            this.Dispose();
        }

        private void confirmOption()
        {
            //TODO: Call add gamingstation somehow somewhere
            gs.Name = txtProductName.Text;
            gs.ProductNumber = txtProductNum.Text;
            gs.Type = "Gamingstation";
            gs.SeatNumber = txtSeatNumber.Text;
            gs.Description = txtDescription.Text;
            if (type.Equals("Create"))
            {
                gamingstationService.Add(gs);
            }else if (type.Equals("Edit"))
            {
                gamingstationService.Update(gs);
            }
        }
    }
}
