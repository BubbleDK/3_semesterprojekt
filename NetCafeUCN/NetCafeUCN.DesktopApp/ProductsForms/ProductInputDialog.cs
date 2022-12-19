﻿namespace NetCafeUCN.DesktopApp
{
    public partial class ProductInputDialog : Form
    {
        ProductsForm productsForm;
        /// <summary>
        /// En enum til at bestemme hvilke produkttyper der kan oprettes.
        /// </summary>
        private enum Type
        {
            Gamingstation = 0,
            Consumable = 1,
        };

        /// <summary>
        /// Constructor til formen. I denne form vælger man hvilken type af produkt man vil oprette
        /// </summary>
        /// <param name="productsForm"></param>
        public ProductInputDialog(ProductsForm productsForm)
        {
            InitializeComponent();
            cmbInput.DataSource = Enum.GetValues(typeof(Type));
            this.productsForm = productsForm;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Hide();
            confirmInput();
            this.Dispose();
        }

        private void confirmInput()
        {
            if(cmbInput.SelectedIndex == 0)
            {
                Form gamingStationForm = new GamingstationForm(productsForm);
                gamingStationForm.ShowDialog();
            }else if(cmbInput.SelectedIndex == 1)
            {
                Form consumableForm = new ConsumableForm(productsForm);
                consumableForm.ShowDialog();
            }
        }
    }
}
