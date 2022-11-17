namespace NetCafeUCN.DesktopApp
{
    public partial class InputDialog : Form
    {
        ProductsForm productsForm;
        private enum Type
        {
            Gamingstation = 0,
            Consumable = 1,
        };

        public InputDialog(string inputFormIdentity, ProductsForm productsForm)
        {
            InitializeComponent();
            lblInput.Text = inputFormIdentity;
            cmbInput.DataSource = Enum.GetValues(typeof(Type));
            this.productsForm = productsForm;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmInupt();
            this.Dispose();
        }

        private void confirmInupt()
        {
            if(cmbInput.SelectedIndex == 0)
            {
                Form gamingStationForm = new GamingstationForm(productsForm);
                gamingStationForm.Show();
            }else if(cmbInput.SelectedIndex == 1)
            {
                Form consumableForm = new ConsumableForm(productsForm);
                consumableForm.Show();
            }
        }
    }
}
