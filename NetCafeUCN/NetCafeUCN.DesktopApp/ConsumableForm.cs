using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class ConsumableForm : Form
    {
        INetCafeDataAccess<Consumable> consumableService;
        Consumable c;
        //Type til at bestemme om man redigerer eller opretter nyt objekt
        private string type = "";
        public ConsumableForm()
        {
            InitializeComponent();
            consumableService = new ConsumableService("https://localhost:7197/api/Consumable/");
            type = "Create";
            c = new();
            txtProductType.Text = "Consumable";
        }

        public ConsumableForm(Consumable c, INetCafeDataAccess<Consumable> service)
        {
            InitializeComponent();
            txtDescription.Text = c.Description;
            txtProductName.Text = c.Name;
            txtProductNum.Text = c.ProductNumber;
            txtProductType.Text = c.Type;
            this.c = c;
            consumableService = service;
            type = "Edit";
        }

        private void confirmOption()
        {
            //TODO: Call add gamingstation somehow somewhere
            c.Name = txtProductName.Text;
            c.ProductNumber = txtProductNum.Text;
            c.Type = "Consumable";
            c.Description = txtDescription.Text;
            if (type.Equals("Create"))
            {
                consumableService.Add(c);
            }else if (type.Equals("Edit"))
            {
                consumableService.Update(c);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmOption();
            this.Dispose();
        }
    }
}
