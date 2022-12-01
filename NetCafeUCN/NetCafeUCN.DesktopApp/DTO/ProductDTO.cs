namespace NetCafeUCN.DesktopApp.DTO
{
    public abstract class ProductDTO
    {
        public string? ProductNumber { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return "Produkt: " + Name + "Produkt nr: " + ProductNumber + " Produkttype: " + Type;
        }
    }
}
