namespace NetCafeUCN.DesktopApp
{
    public partial class ConsumableForm : Form
    {
        public ConsumableForm()
        {
            InitializeComponent();
        }

        public ConsumableForm(string productNumber, string type, string name)
        {
            InitializeComponent();
            //txtDescription.Text = description;
            txtProductName.Text = name;
            txtProductNum.Text = productNumber;
            txtProductType.Text = type;
            //txtSeatNumber.Text = seatNo;
        }
    }
}
