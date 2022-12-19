namespace NetCafeUCN.DAL.Model
{
    /// <summary>
    ///  Product model klasse, som er en abstrakt klasse.
    /// </summary>
    public abstract class Product
    {
        public string? ProductNumber{ get; set; }
        public string ?Type { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

        /// <summary>
        /// Product constructor
        /// </summary>
        /// <param name="productNumber">En string af produkt nummeret</param>
        /// <param name="type">En string af produktets type</param>
        /// <param name="name">En string af produktets navn</param>
        public Product(string productNumber, string type, string name)
        {
            this.ProductNumber = productNumber;
            this.Type = type;
            this.Name = name;
            this.IsActive = true;
        }
        public Product()
        {
        }

        public override abstract string ToString();
        

    }
}
