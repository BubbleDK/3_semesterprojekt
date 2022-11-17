using NetCafeUCN.DesktopApp.DTO;
using NetCafeUCN.DesktopApp.ServiceLayer;

namespace NetCafeUCN.DesktopApp
{
    public partial class UsersForm : Form
    {
        
        public UsersForm()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            lstCustomers.Items.Clear();
            //TODO: List should contain Gamingstation and Consumable instead of Product
            List<Customer> customers = new();
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
    }
}
