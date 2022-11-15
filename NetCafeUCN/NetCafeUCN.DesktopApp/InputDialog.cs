namespace NetCafeUCN.DesktopApp
{
    public partial class InputDialog : Form
    {
        private enum Type
        {
            Gamingstation = 0,
            Consumable = 1,
        };

        public InputDialog(string inputFormIdentity)
        {
            InitializeComponent();
            lblInput.Text = inputFormIdentity;
            cmbInput.DataSource = Enum.GetValues(typeof(Type));
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmInupt();
        }

        private void confirmInupt()
        {
            if(cmbInput.SelectedIndex == 0)
            {
                Form gamingStationForm = new GamingstationForm();
                gamingStationForm.Show();
            }else if(cmbInput.SelectedIndex == 1)
            {
                Form consumableForm = new ConsumableForm();
                consumableForm.Show();
            }
        }
    }
}
