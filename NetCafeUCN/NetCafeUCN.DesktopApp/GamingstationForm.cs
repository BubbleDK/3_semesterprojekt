namespace NetCafeUCN.DesktopApp
{
    public partial class GamingstationForm : Form
    {
        public GamingstationForm()
        {
            InitializeComponent();
        }

        public GamingstationForm(string productNumber, string type, string name)
        {
            InitializeComponent();
            //txtDescription.Text = description;
            txtProductName.Text = name;
            txtProductNum.Text = productNumber;
            txtProductType.Text = type;
            //txtSeatNumber.Text = seatNo;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmOption();
        }

        private void confirmOption()
        {
            //TODO: Call add gamingstation somehow somewhere
        }
    }
}
